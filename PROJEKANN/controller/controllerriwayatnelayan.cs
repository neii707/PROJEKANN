using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.controller
{
    public class ControllerRiwayat
    {
        public ModelRiwayat AmbilDataRiwayat(string username)
        {
            ModelRiwayat model = new ModelRiwayat();
            model.NamaAsliUser = username;
            model.TeksStatistik = "Total Transaksi: 0 | Total Pendapatan: Rp. 0";

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
                        if (result != null && result != DBNull.Value)
                        {
                            model.NamaAsliUser = result.ToString();
                        }
                    }

                    string queryStatistik = "SELECT total_transaksi, total_nilai FROM public.fn_label_riwayat_nelayan(@username)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStatistik, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalTransaksi = reader["total_transaksi"] != DBNull.Value ? Convert.ToInt32(reader["total_transaksi"]) : 0;
                                decimal totalNilaiSelesai = reader["total_nilai"] != DBNull.Value ? Convert.ToDecimal(reader["total_nilai"]) : 0;

                                model.TeksStatistik = $"Total Transaksi: {totalTransaksi} | Total Pendapatan: Rp. {totalNilaiSelesai:N0}";
                            }
                        }
                    }

                    string queryTabel = @"
                        SELECT * FROM public.vw_riwayat_transaksi
                        WHERE username = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            model.TabelRiwayatTransaksi = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses database riwayat: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }
    }
}