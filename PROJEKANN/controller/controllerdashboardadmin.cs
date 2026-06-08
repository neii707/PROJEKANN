using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class DashboardAdminController
    {
        public DashboardAdminModel AmbilSemuaDataDashboard(string username)
        {
            DashboardAdminModel model = new DashboardAdminModel();
            model.NamaUser = username;

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // 1. Tampilkan Nama User Real
                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value) model.NamaUser = res.ToString();
                    }

                    // 2. Ambil Angka Label Akun
                    string queryAkun = "SELECT * FROM v_labelakun";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryAkun, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        model.LabelAkun = res != null ? res.ToString() : "0";
                    }

                    // 3. Ambil Angka Label Stok
                    string queryStok = "SELECT * FROM v_labelstok";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        model.LabelStok = res != null ? res.ToString() + " KG" : "0 KG";
                    }

                    // 4. Ambil Angka Label Transaksi
                    string queryTransaksi = "SELECT * FROM v_labeltransaksi";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTransaksi, conn))
                    {
                        object res = cmd.ExecuteScalar();
                        model.LabelTransaksi = res != null ? res.ToString() : "0";
                    }

                    // 5. Ambil Data Tabel Aktivitas Terkini
                    string queryTabel = @"
                        SELECT 
                            id AS ""ID"", 
                            pengguna AS ""Pengguna"", 
                            aktivitas AS ""Aktivitas"" 
                        FROM v_aktivitas_terkini 
                        LIMIT 10;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelAktivitas = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memuat data di Controller: " + ex.Message, "Error Controller");
            }

            return model;
        }
    }
}