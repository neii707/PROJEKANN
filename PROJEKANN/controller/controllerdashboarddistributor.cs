using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerDashboardDistributor
    {
        private int AmbilIdDistributor(string username)
        {
            int idDistributor = 0;

            using (NpgsqlConnection conn =
                DBConnection.GetConnection())
            {
                conn.Open();

                string query = "SELECT id_user FROM usser WHERE username = @username";

                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@username",
                        username
                    );

                    object result =
                        cmd.ExecuteScalar();

                    if (result != null &&
                        result != DBNull.Value)
                    {
                        idDistributor =
                            Convert.ToInt32(result);
                    }
                }
            }

            return idDistributor;
        }

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

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) model.NamaUserReal = res.ToString();
                    }


                    string queryTabel = "SELECT * FROM view_transaksi_paling_akhir WHERE id_distributor = @idDistributor LIMIT 5;";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idDistributor",
                            AmbilIdDistributor(username)
                        );

                        using (NpgsqlDataAdapter da =
                            new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelTransaksiAkhir = dt;
                        }
                    }

                    string queryPanen = "SELECT total_panen FROM view_jumlah_panen";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPanen, conn))
                    {
                        object resPanen = cmd.ExecuteScalar();
                        if (resPanen != null && resPanen != DBNull.Value) model.TeksJumlahPanen = resPanen.ToString();
                    }


                    string queryTotalTrx = @"
                    SELECT total_transaksi
                    FROM view_total_transaksi_distributor
                    WHERE id_distributor = @idDistributor
                    ";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTotalTrx, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idDistributor",
                            AmbilIdDistributor(username)
                        );

                        object resTrx = cmd.ExecuteScalar();

                        if (resTrx != null &&
                            resTrx != DBNull.Value)
                        {
                            model.TeksTotalTransaksi =
                                resTrx.ToString();
                        }
                    }


                    string queryDemand = "SELECT total_demand FROM view_demand_distributor";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryDemand, conn))
                    {
                        object resDemand =
                            cmd.ExecuteScalar();

                        if (resDemand != null &&
                            resDemand != DBNull.Value)
                        {
                            decimal totalDemand =
                                Convert.ToDecimal(resDemand);

                            if (totalDemand >= 1000)
                            {
                                model.TeksDemand =
                                    (totalDemand / 1000)
                                    .ToString("N1") + " Ton";
                            }
                            else if (totalDemand >= 100)
                            {
                                model.TeksDemand =
                                    (totalDemand / 100)
                                    .ToString("N0") + " Kwintal";
                            }
                            else
                            {
                                model.TeksDemand =
                                    totalDemand
                                    .ToString("N0") + " Kg";
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