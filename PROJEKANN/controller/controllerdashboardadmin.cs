using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class DashboardAdminController
    {
        public DashboardAdminModel AmbilSemuaDataDashboard(string username)
        {
            DashboardAdminModel model = new DashboardAdminModel();
            model.username = username;

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
                        if (res != null && res != DBNull.Value) model.username = res.ToString();
                    }


                    string queryAkun = "SELECT public.fn_labelakun()";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryAkun, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        model.LabelAkun = res != null ? res.ToString() : "0";
                    }


                    string queryStok = "SELECT * FROM public.fn_labelstok()";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        model.LabelStok = res != null ? res.ToString() + " KG" : "0 KG";
                    }


                    string queryTransaksi = "SELECT * FROM public.fn_labeltransaksi()";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTransaksi, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        model.LabelTransaksi = res != null ? res.ToString() : "0";
                    }

                    string queryTabel = @"
                        SELECT *
                        FROM v_aktivitas_terkini 
                        LIMIT 10;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelAktivitas = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memuat data di Controller: " + ex.Message, "Error Controller");
            }

            return model;
        }
    }
}