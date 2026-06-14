using Npgsql;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;

namespace PROJEKANN.controller
{
    public class ControllerDistributorTransaksi
    {

        private int AmbilIdDistributor(string username)
        {
            int idDistributor = 0;

            using (NpgsqlConnection conn =
                DBConnection.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT id_user
            FROM usser
            WHERE username = @username
        ";

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

        public ModelDistributorTransaksi AmbilDataAwal(string username)
        {
            ModelDistributorTransaksi model = new ModelDistributorTransaksi();
            model.NamaAsliUser = username;

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
                            model.NamaAsliUser = result.ToString();
                        }
                    }

                    string queryTabel = "SELECT * FROM view_transaksi_distributor WHERE id_distributor = @idDistributor";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idDistributor",
                            AmbilIdDistributor(username)
                        );

                        using (NpgsqlDataAdapter da =
                            new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            model.TabelTransaksi = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error Database");
            }

            return model;
        }

        public bool KonfirmasiPembayaranCash(int idTransaksi)
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "CALL konfirmasi_pembayaran(@id)";

                    using (NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id",
                            idTransaksi
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message,
                    "Error Update Transaksi"
                );

                return false;
            }
        }

    }
}