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

                    string queryTabel = @"SELECT * FROM vw_konfirmasi_transaksi vt
                      JOIN transaksi t ON vt.id_transaksi = t.id_transaksi
                      JOIN grade g ON t.id_grade = g.id_grade
                      JOIN panen p ON g.id_panen = p.id_panen
                      JOIN usser u_nelayan ON p.id_user = u_nelayan.id_user
                      WHERE u_nelayan.username = @username";

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

        public bool KonfirmasiTransaksiSelesai(int idTransaksi)
        {
            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();

                    string query = "CALL public.sp_konfirmasi_transaksi(@id)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (PostgresException ex)
            {
                MessageBox.Show("Error Database: " + ex.MessageText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Aplikasi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}