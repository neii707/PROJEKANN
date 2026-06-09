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

                    string queryTabel = "SELECT id, distributor, berat, total, tanggal, status " +
                                       "FROM view_transaksi_aktif_nelayan WHERE nelayan = @username";

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
            using (NpgsqlConnection kon = DBConnection.GetConnection())
            {
                kon.Open();

                using (NpgsqlTransaction sqlTrans = kon.BeginTransaction())
                {
                    try
                    {
                        string queryUpdateStatus = @"
                            UPDATE transaksi 
                            SET status_transaksi = 'selesai' 
                            WHERE id_transaksi = @id_transaksi";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdateStatus, kon, sqlTrans))
                        {
                            cmd.Parameters.AddWithValue("@id_transaksi", idTransaksi);
                            cmd.ExecuteNonQuery();
                        }

                        sqlTrans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("Gagal mengonfirmasi transaksi. Perubahan database dibatalkan: " + ex.Message, "Transaction Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
    }
}