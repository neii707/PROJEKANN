using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerKelolaDemand
    {
        public ModelKelolaDemand AmbilHalamanDemand(string username)
        {
            ModelKelolaDemand model = new ModelKelolaDemand();
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

                    string queryTabel = "SELECT * FROM v_demand ORDER BY id DESC";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelDemand = dt;
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

        public bool TambahDemand(int targetKg, DateTime deadline, string usernameAktif)
        {
            string queryInsert = @"
                INSERT INTO demand (target_kg, deadline, id_user) 
                VALUES (@target, @deadline, (SELECT id_user FROM usser WHERE username = @username LIMIT 1))";

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@target", targetKg);
                        cmd.Parameters.AddWithValue("@deadline", deadline);
                        cmd.Parameters.AddWithValue("@username", usernameAktif);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal menyimpan data ke database: " + ex.Message, "Error Database");
                return false;
            }
        }
    }
}