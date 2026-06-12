using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerGrading
    {
        public ModelGrading AmbilDataGrading(string username)
        {
            ModelGrading model = new ModelGrading();
            model.NamaUserReal = username;

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
                        if (result != null && result != DBNull.Value) model.NamaUserReal = result.ToString();
                    }

                    string queryTabel = "SELECT * FROM view_grading_panen;";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(queryTabel, kon))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        model.TabelGradingPanen = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal mengambil data database: " + ex.Message, "Error Controller");
            }

            return model;
        }

        public bool TetapkanGradePanen(int idPanen, string gradeDipilih, string keterangan, decimal harga, string username)
        {
            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string queryInsert = @"
                        INSERT INTO grade (kategori, keterangan, harga_per_kg, id_panen, id_demand, id_distributor)
                        VALUES (@kategori, @keterangan, @harga, @idPanen, 1, @idDistributor);";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@kategori", gradeDipilih);
                        cmd.Parameters.AddWithValue("@keterangan", keterangan);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@idPanen", idPanen);
                        cmd.Parameters.AddWithValue("@idDistributor", AmbilIdDistributor(username));

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal grading : " + ex.Message, "Error Database");
                return false;
            }
        }

        private int AmbilIdDistributor(string username)
        {
            int idDistributor = 0;

            using (NpgsqlConnection conn =
                DBConnection.GetConnection())
            {
                conn.Open();

                string query = "SELECT id_user,FROM usser,WHERE username = @username";

                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@username",
                        username
                    );

                    object result =
                        cmd.ExecuteScalar();

                    if (result != null)
                    {
                        idDistributor =
                            Convert.ToInt32(result);
                    }
                }
            }

            return idDistributor;
        }
    }
}