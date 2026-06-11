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

            try
            {
                // Gunakan class koneksi database utama yang biasa kamu pakai (misal: DBConnection)
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();


                    // 1. Ambil data Tabel via VIEW vw_dashboard_nelayan
                    string sqlTabel = @"SELECT * FROM vw_dashboard_nelayan 
                                        WHERE username = @username
                                        ORDER BY tanggal DESC";

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

                    // 2. Ambil data Ringkasan via FUNCTION Database
                    string sqlSummary = @"SELECT fn_stok_panen(@id)           AS stok,
                                                 fn_penjualan(@id)            AS jual,
                                                 fn_pendapatan_bulan_ini(@id) AS pendapatan";

                    using (NpgsqlCommand cmdSum = new NpgsqlCommand(sqlSummary, kon))
                    {
                        cmdSum.Parameters.AddWithValue("@id", username);
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