using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerDashboardNelayan
    {
        public ModelDashboardNelayan AmbilDataDashboard(string username)
        {
            ModelDashboardNelayan model = new ModelDashboardNelayan();
            model.NamaUserReal = username;
            model.TeksStok = "0.0 kg";
            model.TeksPenawaran = "0 Berkas";
            model.TeksPenjualan = "Rp 0";

            DataTable dtBersih = new DataTable();
            dtBersih.Columns.Add("ID");
            dtBersih.Columns.Add("Grade");
            dtBersih.Columns.Add("Berat");
            dtBersih.Columns.Add("Tanggal");
            dtBersih.Columns.Add("Status");
            model.TabelAktivitasBersih = dtBersih;

            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) model.NamaUserReal = result.ToString();
                    }

                    string queryStok = "SELECT total_stok FROM view_stok_nelayan WHERE username = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        double totalStok = (result != null && result != DBNull.Value) ? Convert.ToDouble(result) : 0;
                        model.TeksStok = totalStok.ToString("N1") + " kg";
                    }

                    string queryPenawaran = @"
                        SELECT COUNT(*) 
                        FROM transaksi t
                        JOIN grade g ON t.id_grade = g.id_grade
                        JOIN panen p ON g.id_panen = p.id_panen
                        JOIN usser u ON p.id_user = u.id_user
                        WHERE u.username = @username AND LOWER(t.status_transaksi) != 'selesai'";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenawaran, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int totalPenawaran = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        model.TeksPenawaran = totalPenawaran.ToString() + " Berkas";
                    }

                    string queryPenjualan = "SELECT total_penjualan FROM view_total_penjualan_nelayan WHERE username = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenjualan, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        decimal totalDuit = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                        model.TeksPenjualan = "Rp " + totalDuit.ToString("N0");
                    }

                    string queryTabel = @"SELECT id_asli, aktivitas, tanggal, 
                                         CASE 
                                             WHEN status_asli IS NULL OR TRIM(status_asli) = '' THEN 'menunggu grading' 
                                             ELSE status_asli 
                                         END as status_asli 
                                  FROM view_dashboard_nelayan 
                                  WHERE username_nelayan = @username 
                                    AND (status_asli IS NULL OR LOWER(status_asli) != 'selesai')
                                  LIMIT 5";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dtRaw = new DataTable();
                            adapter.Fill(dtRaw);

                            foreach (DataRow row in dtRaw.Rows)
                            {
                                string teksAktivitas = row["aktivitas"].ToString();
                                string berat = "";
                                string grade = "";

                                // Logika parsing teks aktivitas penangkapan ikan
                                if (teksAktivitas.Contains("Kg") && teksAktivitas.Contains("Grade"))
                                {
                                    int indexKg = teksAktivitas.IndexOf("Kg");
                                    berat = teksAktivitas.Substring(0, indexKg).Trim() + " kg";

                                    int indexGrade = teksAktivitas.IndexOf("Grade") + 5;
                                    int indexStrip = teksAktivitas.IndexOf("-", indexGrade);

                                    if (indexStrip > indexGrade)
                                        grade = teksAktivitas.Substring(indexGrade, indexStrip - indexGrade).Trim();
                                    else
                                        grade = teksAktivitas.Substring(indexGrade).Trim();
                                }
                                else
                                {
                                    berat = teksAktivitas;
                                }

                                string tglFormated = "";
                                if (row["tanggal"] != DBNull.Value)
                                {
                                    string rawTanggal = row["tanggal"].ToString().Split(' ')[0];
                                    if (DateTime.TryParse(rawTanggal, out DateTime parsedDate))
                                        tglFormated = parsedDate.ToString("dd/MM/yyyy");
                                    else
                                        tglFormated = rawTanggal;
                                }

                                model.TabelAktivitasBersih.Rows.Add(
                                    row["id_asli"].ToString(),
                                    grade,
                                    berat,
                                    tglFormated,
                                    row["status_asli"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Controller Error: " + ex.Message, "Error");
            }

            return model;
        }
    }
}