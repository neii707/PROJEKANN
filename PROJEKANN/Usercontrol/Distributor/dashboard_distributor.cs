using Npgsql;
using PROJEKANN.database;
using PROJEKANN.Usercontrol.Distributor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            DashboardDistributor.Controls.Clear();

            ucBaru.Dock = DockStyle.Fill;

            DashboardDistributor.Controls.Add(ucBaru);

            ucBaru.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Form1 formUtama = this.FindForm() as Form1;

            if (formUtama != null)
            {
                formUtama.TampilkanHalaman(
                    new PROJEKANN.Usercontrol.dashboard_distributor()
                );
            }
        }

        private void btnPanen_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.lihat_panen()
    );
        }

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
       new PROJEKANN.Usercontrol.Distributor.Grading()
   );
        }

        private void btnPenawaran_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.Penawaran()
    );
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.Transaksi()
    );
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi()
    );
        }

        private void lblJumlahPanen_Click(object sender, EventArgs e)
        {

        }

        private void lblDemand_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalTransaksi_Click(object sender, EventArgs e)
        {


        }
    }
}