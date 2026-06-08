using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerKelolaAkun
    {
        public ModelKelolaAkun AmbilHalamanKelolaAkun(string username)
        {
            ModelKelolaAkun model = new ModelKelolaAkun();
            model.NamaUserReal = username; 

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

                    string queryTabel = "SELECT * FROM v_konfir_akun2";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelAkun = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Controller Error: " + ex.Message);
            }

            return model;
        }


        public bool UpdateStatusAkun(string username, string statusBaru)
        {
            string queryUpdate = "UPDATE usser SET status_konfir_akun = @status WHERE username = @username";
            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", statusBaru);
                        cmd.Parameters.AddWithValue("@username", username);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal eksekusi update status: " + ex.Message, "Error Database");
                return false;
            }
        }
    }
}