using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerRiwayatDistributor
    {
        private int AmbilIdDistributor(string username)
        {
            int idDistributor = 0;

            using (NpgsqlConnection conn =
                DBConnection.GetConnection())
            {
                conn.Open();

                string query = "SELECT id_user FROM usser WHERE username = @username";

                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@username",
                        username
                    );

                    object result =
                        cmd.ExecuteScalar();

                    if (result != null &&
                        result != DBNull.Value)
                    {
                        idDistributor =
                            Convert.ToInt32(result);
                    }
                }
            }

            return idDistributor;
        }

        public ModelRiwayatDistributor AmbilSemuaDataRiwayat(string username)
        {
            ModelRiwayatDistributor model = new ModelRiwayatDistributor();
            model.NamaUserReal = username; 
            model.TotalSelesai = "0";
            model.TotalPembayaran = 0;

            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            model.NamaUserReal = result.ToString();
                        }
                    }

                    string queryJumlah = "SELECT total_selesai_distributor(@idDistributor)";

                    using (NpgsqlCommand cmdJumlah =
                        new NpgsqlCommand(queryJumlah, conn))
                    {
                        cmdJumlah.Parameters.AddWithValue(
                            "@idDistributor",
                            AmbilIdDistributor(username)
                        );

                        object jml =
                            cmdJumlah.ExecuteScalar();

                        model.TotalSelesai =
                            jml != null &&
                            jml != DBNull.Value
                            ? jml.ToString()
                            : "0";
                    }

                    string queryTotal = "SELECT total_pembayaran_distributor(@idDistributor)";
                    using (NpgsqlCommand cmdTotal =
                        new NpgsqlCommand(queryTotal, conn))
                    {
                        cmdTotal.Parameters.AddWithValue(
                            "@idDistributor",
                            AmbilIdDistributor(username)
                        );

                        object total = cmdTotal.ExecuteScalar();

                        model.TotalPembayaran =
                            total != null &&
                            total != DBNull.Value
                            ? Convert.ToDecimal(total)
                            : 0;
                    }

                    string queryTabel = "SELECT * FROM view_riwayat_transaksi WHERE id_distributor = @idDistributor;";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idDistributor",
                            AmbilIdDistributor(username)
                        );

                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelRiwayat = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Gagal memproses data riwayat distributor: " + ex.Message, "Error Database");
            }

            return model;
        }
    }
}