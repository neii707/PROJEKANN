using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerRiwayatDistributor
    {
        public ModelRiwayatDistributor AmbilSemuaDataRiwayat(string username)
        {
            ModelRiwayatDistributor model = new ModelRiwayatDistributor();
            model.NamaUserReal = username; // Default fallback
            model.TotalSelesai = "0";
            model.TotalPembayaran = 0;

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // 1. Tampilkan Nama User Real
                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            model.NamaUserReal = result.ToString();
                        }
                    }

                    // 2. Hitung Statistik - Jumlah Transaksi Selesai
                    string queryJumlah = @"
                        SELECT COUNT(*)
                        FROM transaksi
                        WHERE status_transaksi = 'Selesai';";
                    using (NpgsqlCommand cmdJumlah = new NpgsqlCommand(queryJumlah, conn))
                    {
                        object jml = cmdJumlah.ExecuteScalar();
                        model.TotalSelesai = jml != null ? jml.ToString() : "0";
                    }

                    // 3. Hitung Statistik - Total Nilai Pembayaran Selesai
                    string queryTotal = @"
                        SELECT COALESCE(SUM(total_pembayaran), 0)
                        FROM transaksi
                        WHERE status_transaksi = 'Selesai';";
                    using (NpgsqlCommand cmdTotal = new NpgsqlCommand(queryTotal, conn))
                    {
                        model.TotalPembayaran = Convert.ToDecimal(cmdTotal.ExecuteScalar());
                    }

                    // 4. Muat Data Tabel Riwayat
                    string queryTabel = "SELECT * FROM view_riwayat_transaksi;";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(queryTabel, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        model.TabelRiwayat = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memproses data riwayat distributor: " + ex.Message, "Error Database");
            }

            return model;
        }
    }
}