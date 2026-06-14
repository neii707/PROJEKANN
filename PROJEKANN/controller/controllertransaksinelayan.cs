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

                    string queryTabel = @"SELECT * FROM vw_konfirmasi_transaksi 
                                          WHERE ""id_panen"" IN (
                                          SELECT p.id_panen FROM panen p 
                                          JOIN usser u ON p.id_user = u.id_user 
                                          WHERE u.username = @username)";
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

                    using (NpgsqlCommand cmd = new NpgsqlCommand("public.sp_konfirmasi_transaksi_by_panen", kon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id_panen", NpgsqlTypes.NpgsqlDbType.Integer, idPanen);

                        cmd.Parameters.AddWithValue(
                            "p_tanggal_konfir",
                            NpgsqlTypes.NpgsqlDbType.Date,
                            DateTime.Today
                        );

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (PostgresException ex)
            {
                // Pesan error dari 'RAISE EXCEPTION' di pgAdmin otomatis tampil utuh di sini
                System.Windows.Forms.MessageBox.Show(ex.MessageText, "Konfirmasi Ditolak", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Aplikasi: " + ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}