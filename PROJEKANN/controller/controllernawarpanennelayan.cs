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

        public bool UpdateStatusPenawaran(string idTransaksi, string statusBaru)
        {
            bool isSuccess = false;
            string query = "";
            if (statusBaru.ToLower() == "diterima") query = "UPDATE transaksi SET konfir_penawaran = 'Diterima', konfir_pembelian = 'Menunggu' WHERE id_transaksi = @id";
            else if (statusBaru.ToLower() == "ditolak") query = "UPDATE transaksi SET konfir_penawaran = 'Ditolak', status_transaksi = 'Ditolak' WHERE id_transaksi = @id";

            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idTransaksi));
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