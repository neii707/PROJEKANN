using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerNawarPanen
    {
        public ModelNawarPanen AmbilDataNawarPanen(string username)
        {
            ModelNawarPanen model = new ModelNawarPanen();
            model.NamaAsliUser = username; 

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
                        if (result != null && result != DBNull.Value)
                        {
                            model.NamaAsliUser = result.ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(model.NamaAsliUser))
                    {
                        string queryTabel = @"SELECT id, distributor, berat, grade, harga, estimasi, tanggal, status 
                                             FROM view_penawaran_panen_nelayan 
                                             WHERE nama_nelayan = @nama 
                                             ORDER BY id DESC";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                        {
                            cmd.Parameters.AddWithValue("@nama", model.NamaAsliUser);

                            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);
                                model.TabelPenawaran = dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memuat data penawaran: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return model;
        }
    }
}