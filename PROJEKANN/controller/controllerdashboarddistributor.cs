using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerDashboardDistributor
    {
        public ModelDashboardDistributor AmbilDataDashboard(string username)
        {
            ModelDashboardDistributor model = new ModelDashboardDistributor();
            model.NamaUserReal = username;
            model.TeksJumlahPanen = "0";
            model.TeksDemand = "0 Kg";
            model.TeksTotalTransaksi = "0";

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // 1. Ambil Nama Asli User
                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) model.NamaUserReal = res.ToString();
                    }

                    // 2. Ambil Tabel Transaksi Terakhir
                    string queryTabel = "SELECT * FROM view_transaksi_paling_akhir;";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelTransaksiAkhir = dt;
                        }
                    }

                    // 3. Ambil Jumlah Panen
                    string queryPanen = "SELECT total_panen FROM view_jumlah_panen";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPanen, conn))
                    {
                        object resPanen = cmd.ExecuteScalar();
                        if (resPanen != null && resPanen != DBNull.Value) model.TeksJumlahPanen = resPanen.ToString();
                    }

                    // 4. Ambil Jumlah Transaksi Selesai
                    string queryTotalTrx = "SELECT total_transaksi FROM view_total_transaksi";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTotalTrx, conn))
                    {
                        object resTrx = cmd.ExecuteScalar();
                        if (resTrx != null && resTrx != DBNull.Value) model.TeksTotalTransaksi = resTrx.ToString();
                    }

                    // 5. Ambil Demand Aktif & Hitung Konversi Satuan
                    string queryDemand = "SELECT total_demand FROM view_demand_aktif";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryDemand, conn))
                    {
                        object resDemand = cmd.ExecuteScalar();
                        if (resDemand != null && resDemand != DBNull.Value)
                        {
                            decimal totalDemand = Convert.ToDecimal(resDemand);
                            if (totalDemand >= 1000)
                            {
                                model.TeksDemand = (totalDemand / 1000).ToString("N1") + " Ton";
                            }
                            else if (totalDemand >= 100)
                            {
                                model.TeksDemand = (totalDemand / 100).ToString("N1") + " Kwintal";
                            }
                            else
                            {
                                model.TeksDemand = totalDemand.ToString("N0") + " Kg";
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