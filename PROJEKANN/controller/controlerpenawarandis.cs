using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerDistributorPenawaran
    {
        // 1. Fungsi mengambil data inisialisasi awal (Nama & Tabel View)
        public ModelDistributorPenawaran AmbilDataAwal(string username)
        {
            ModelDistributorPenawaran model = new ModelDistributorPenawaran();
            model.NamaAsliUser = username; // Fallback jika kosong

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // Ambil nama asli dari user
                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            model.NamaAsliUser = result.ToString();
                        }
                    }

                    // Ambil seluruh data dari view_penawaran
                    string queryTabel = "SELECT * FROM view_penawaran_panen";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(queryTabel, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        model.TabelPenawaran = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memuat data penawaran: " + ex.Message, "Error Database");
            }

            return model;
        }

        // 2. Fungsi eksekusi Stored Procedure PostgreSQL
        public bool KirimHargaPenawaran(decimal hargaTawar, int idGrade)
        {
            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "CALL tambah_penawaran(@harga, @idGrade)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@harga", hargaTawar);
                        cmd.Parameters.AddWithValue("@idGrade", idGrade);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error Mengirim Penawaran");
                return false;
            }
        }
    }
}