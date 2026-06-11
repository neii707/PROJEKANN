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

                    string queryTabel = "SELECT *  FROM vw_konfirmasi_transaksi";

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

                    // Kolom diubah ke 'Selesai' agar hilang dari vw_konfirmasi_transaksi dan masuk ke vw_riwayat_transaksi
                    string query = @"UPDATE transaksi 
                             SET konfir_pembelian = 'Selesai' 
                             WHERE id_transaksi = @id";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        int barisTerganti = cmd.ExecuteNonQuery();

                        return barisTerganti > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}