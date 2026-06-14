using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.controller
{
    public class ControllerTransaksi
    {
        public ModelTransaksi AmbilDataTransaksiAktif(string username)
        {
            ModelTransaksi model = new ModelTransaksi();
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

                    string queryTabel = @"
    SELECT * FROM vw_konfirmasi_transaksi 
    WHERE ""ID Panen"" IN (
        SELECT p.id_panen FROM panen p 
        JOIN usser u ON p.id_user = u.id_user 
        WHERE u.username = @username
    )";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            model.TabelTransaksiAktif = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat transaksi aktif: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return model;
        }

        public bool KonfirmasiTransaksiSelesai(int idPanen)
        {
            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();
                    string query = @"
                UPDATE transaksi 
                SET konfir_pembelian = 'Selesai', 
                    status_transaksi = 'Selesai', 
                    tanggal = CURRENT_DATE 
                WHERE id_grade IN (SELECT id_grade FROM grade WHERE id_panen = @id_panen)
                  AND konfir_pembelian = 'Sudah Dibayar'";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@id_panen", idPanen);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Aplikasi: " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}