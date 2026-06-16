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
            model.username = username;

            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmdNama = new NpgsqlCommand(queryNama, kon))
                    {
                        cmdNama.Parameters.AddWithValue("@username", username);
                        object result = cmdNama.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            model.nama = result.ToString();
                        }
                        else
                        {
                            model.nama = username;
                        }
                    }

                    string sqlTabel = @"SELECT * FROM vw_dashboard_nelayan 
                                        WHERE username = @username
                                        ORDER BY id_panen asc";

                    using (NpgsqlCommand cmdTabel = new NpgsqlCommand(sqlTabel, kon))
                    {
                        cmdTabel.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmdTabel))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            model.TabelDashboard = dt;
                        }
                    }

                    string sqlSummary = "SELECT stok, jual, pendapatan FROM public.fn_label_dashboard_nelayan(@username)";

                    using (NpgsqlCommand cmdSum = new NpgsqlCommand(sqlSummary, kon))
                    {
                        cmdSum.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataReader dr = cmdSum.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                model.StokPanen = dr["stok"] != DBNull.Value ? dr["stok"].ToString() : "0";
                                model.TotalPenjualan = dr["jual"] != DBNull.Value ? dr["jual"].ToString() : "0";
                                model.TotalPendapatan = dr["pendapatan"] != DBNull.Value ? Convert.ToDecimal(dr["pendapatan"]) : 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memuat data dashboard: " + ex.Message,
                    "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return model;
        }
    }
}