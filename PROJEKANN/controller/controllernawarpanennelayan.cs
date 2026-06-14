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
                        string queryTabel = "SELECT vp.* FROM vw_konfirmasi_penawaran vp JOIN panen p ON vp.id_panen = p.id_panen JOIN usser u ON p.id_user = u.id_user WHERE u.username = @username";
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
                System.Windows.Forms.MessageBox.Show("Gagal memuat data: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return model;
        }

        public bool UpdateStatusPenawaran(string idPanen, string statusBaru)
        {
            bool isSuccess = false;
            string query = "";

            if (statusBaru.ToLower() == "diterima")
            {
                query = @"UPDATE transaksi 
                          SET konfir_penawaran = 'Diterima', konfir_pembelian = 'Belum Dibayar' 
                          WHERE id_grade IN (SELECT id_grade FROM grade WHERE id_panen = @id_panen)";
            }
            else if (statusBaru.ToLower() == "ditolak")
            {
                query = @"UPDATE transaksi 
                          SET konfir_penawaran = 'Ditolak', status_transaksi = 'Ditolak' 
                          WHERE id_grade IN (SELECT id_grade FROM grade WHERE id_panen = @id_panen)";
            }

            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@id_panen", Convert.ToInt32(idPanen));
                        if (cmd.ExecuteNonQuery() > 0) isSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal merubah status: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return isSuccess;
        }
    }
}