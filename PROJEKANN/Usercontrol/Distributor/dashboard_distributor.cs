using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using PROJEKANN.database;

namespace PROJEKANN.Usercontrol
{
    public partial class dashboard_distributor : UserControl
    {
        public dashboard_distributor()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_distributor_Load(object sender, EventArgs e)
        {
            MuatTransaksiTerkini();

            MuatJumlahPanen();

            MuatDemand();

            MuatTotalTransaksi();
        }

        private void MuatTransaksiTerkini()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT *
                        FROM view_dashboard_distributor
                        LIMIT 10;
                    ";

                    using (NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da =
                            new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            da.Fill(dt);

                            dgvDashboard.DataSource = dt;

                            dgvDashboard.AutoSizeColumnsMode =
                                DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MuatJumlahPanen()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT total_panen FROM view_jumlah_panen";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    lblJumlahPanen.Text =
                        cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MuatDemand()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT total_demand FROM view_demand_aktif";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    lblDemand.Text =
                        cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MuatTotalTransaksi()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT total_transaksi FROM view_total_transaksi";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    object hasil =
                        cmd.ExecuteScalar();

                    lblTotalTransaksi.Text =
                        "Rp " +
                        Convert.ToDecimal(hasil)
                        .ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }


}