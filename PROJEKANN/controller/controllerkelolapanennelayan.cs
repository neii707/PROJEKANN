using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerKelolaPanen
    {
        public ModelKelolaPanen AmbilDataKelolaPanen(string username)
        {
            ModelKelolaPanen model = new ModelKelolaPanen();
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
                        if (result != null && result != DBNull.Value) model.NamaAsliUser = result.ToString();
                    }

                    string queryTabel = @"SELECT 
                                            p.id_panen AS id, 
                                            p.berat_per_kg AS berat, 
                                            COALESCE(g.kategori, '-') AS grade, 
                                            COALESCE(g.harga_per_kg, 0) AS harga_per_kg,
                                            CASE 
                                                WHEN g.id_grade IS NULL THEN 'menunggu grading' 
                                                ELSE 'sudah digrading'
                                            END AS status
                                         FROM panen p
                                         INNER JOIN usser u ON p.id_user = u.id_user
                                         LEFT JOIN grade g ON p.id_panen = g.id_panen
                                         WHERE u.username = @username 
                                         ORDER BY p.id_panen DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            model.TabelPanenSaya = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memuat data dari database: " + ex.Message, "Error Controller");
            }

            return model;
        }

        public bool SimpanAtauUbahPanen(string username, int idPanenTerpilih, double berat, DateTime tanggal)
        {
            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();

                    int idUser = 0;
                    string queryUser = "SELECT id_user FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmdUser = new NpgsqlCommand(queryUser, kon))
                    {
                        cmdUser.Parameters.AddWithValue("@username", username);
                        idUser = Convert.ToInt32(cmdUser.ExecuteScalar() ?? 0);
                    }

                    if (idUser == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Sesi user Anda tidak valid.", "Akses Ditolak");
                        return false;
                    }

                    if (idPanenTerpilih == 0)
                    {
                        string queryInsert = "INSERT INTO panen (id_user, berat_per_kg, tanggal) VALUES (@id_user, @berat, @tanggal)";
                        using (NpgsqlCommand cmdInsert = new NpgsqlCommand(queryInsert, kon))
                        {
                            cmdInsert.Parameters.AddWithValue("@id_user", idUser);
                            cmdInsert.Parameters.AddWithValue("@berat", berat);
                            cmdInsert.Parameters.AddWithValue("@tanggal", tanggal);
                            cmdInsert.ExecuteNonQuery();
                        }
                        System.Windows.Forms.MessageBox.Show("Data panen berhasil ditambahkan!", "Sukses Menyimpan");
                    }
                    else
                    {
                        string queryUpdate = "UPDATE panen SET berat_per_kg = @berat, tanggal = @tanggal WHERE id_panen = @id";
                        using (NpgsqlCommand cmdUpdate = new NpgsqlCommand(queryUpdate, kon))
                        {
                            cmdUpdate.Parameters.AddWithValue("@berat", berat);
                            cmdUpdate.Parameters.AddWithValue("@tanggal", tanggal);
                            cmdUpdate.Parameters.AddWithValue("@id", idPanenTerpilih);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        System.Windows.Forms.MessageBox.Show("Perubahan data panen berhasil diperbarui!", "Sukses Diperbarui");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Terjadi kendala memproses database: " + ex.Message, "Error Database");
                return false;
            }
        }

        public bool HapusPanen(int idPanen)
        {
            try
            {
                using (NpgsqlConnection kon = DBConnection.GetConnection())
                {
                    kon.Open();
                    string queryHapus = "DELETE FROM panen WHERE id_panen = @id AND id_panen NOT IN (SELECT id_panen FROM grade)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryHapus, kon))
                    {
                        cmd.Parameters.AddWithValue("@id", idPanen);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memproses penghapusan data: " + ex.Message, "Error");
                return false;
            }
        }
    }
}