using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.controller
{
    public class ControllerNawarPanen
    {
        public ModelNawarPanen AmbilDataNawarPanen(string username)
        {
            ModelNawarPanen model = new ModelNawarPanen { NamaAsliUser = username };
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
                        if (result != null && result != DBNull.Value) model.NamaAsliUser = result.ToString();
                    }

                    if (!string.IsNullOrEmpty(username))
                    {
                        string queryTabel = @"SELECT vp.* FROM vw_konfirmasi_penawaran vp 
                                              JOIN panen p ON vp.id_panen = p.id_panen 
                                              JOIN usser u ON p.id_user = u.id_user 
                                              WHERE u.username = @username";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
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
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public bool UpdateStatusPenawaran(int idPanen, string statusBaru)
        {
            bool isSuccess = false;
            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryCall = "CALL public.proses_penawaran(@p_id_panen, @p_keputusan);";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryCall, kon))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@p_id_panen", idPanen);
                        cmd.Parameters.AddWithValue("@p_keputusan", statusBaru.ToUpper());

                        cmd.ExecuteNonQuery();
                        isSuccess = true;

                        MessageBox.Show($"Penawaran sukses {statusBaru.ToLower()}!", "Informasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (PostgresException ex)
            {
                MessageBox.Show(ex.MessageText, "Gagal Memproses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal merubah status: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isSuccess;
        }
    }
}