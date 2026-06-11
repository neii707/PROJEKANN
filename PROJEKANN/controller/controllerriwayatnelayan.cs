using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerRiwayat
    {
        public ModelRiwayat AmbilDataRiwayat(string username)
        {
            ModelRiwayat model = new ModelRiwayat();
            model.NamaAsliUser = username; 
            model.TeksStatistik = "Total Transaksi: 0 | Selesai: 0 transaksi | Total Nilai Selesai: Rp 0";

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

                    string queryStatistik = @"
                        SELECT 
                            COUNT(id) as total_transaksi,
                            COUNT(CASE WHEN LOWER(status) = 'selesai' THEN 1 END) as total_selesai,
                            COALESCE(SUM(CASE WHEN LOWER(status) = 'selesai' THEN total ELSE 0 END), 0) as total_nilai
                        FROM vw_riwayat_transaksi
                        WHERE nelayan = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStatistik, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalTransaksi = Convert.ToInt32(reader["total_transaksi"]);
                                int totalSelesai = Convert.ToInt32(reader["total_selesai"]);
                                decimal totalNilaiSelesai = Convert.ToDecimal(reader["total_nilai"]);

                                model.TeksStatistik = $"Total Transaksi: {totalTransaksi} | Selesai: {totalSelesai} transaksi | Total Nilai Selesai: Rp {totalNilaiSelesai:N0}";
                            }
                        }
                    }

                    string queryTabel = "SELECT * FROM vw_riwayat_transaksi";

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
                System.Windows.Forms.MessageBox.Show("Gagal memproses database riwayat: " + ex.Message, "Error Database");
            }

            return model;
        }
    }
}