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
            // Default teks diubah (menghilangkan bagian "Selesai")
            model.TeksStatistik = "Total Transaksi: 0 | Total Nilai Selesai: Rp 0";

            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();

                    // 1. Ambil Nama Asli User
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

                    // 2. Query Statistik (Ditambahkan WHERE u.username = @username)
                    string queryStatistik = @"
                        SELECT 
                            COUNT(vt.id_panen) as total_transaksi,
                            COALESCE(SUM(CASE WHEN LOWER(vt.status) = 'selesai' THEN vt.total ELSE 0 END), 0) as total_nilai
                        FROM public.vw_riwayat_transaksi vt
                        JOIN public.panen p ON vt.id_panen = p.id_panen
                        JOIN public.usser u ON p.id_user = u.id_user
                        WHERE u.username = @username"; // <- PENTING: Filter berdasarkan user

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStatistik, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalTransaksi = Convert.ToInt32(reader["total_transaksi"]);
                                decimal totalNilaiSelesai = Convert.ToDecimal(reader["total_nilai"]);

                                // Format string diubah di sini untuk menghilangkan info "Selesai"
                                model.TeksStatistik = $"Total Transaksi: {totalTransaksi} | Total Nilai Selesai: Rp {totalNilaiSelesai:N0}";
                            }
                        }
                    }

                    // 3. Query Tabel Riwayat (Ditambahkan WHERE agar data tabel tidak bocor milik user lain)
                    string queryTabel = @"
                        SELECT vt.* FROM vw_riwayat_transaksi vt
                        JOIN panen p ON vt.id_panen = p.id_panen
                        JOIN usser u ON p.id_user = u.id_user
                        WHERE u.username = @username"; // whitespace filter

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