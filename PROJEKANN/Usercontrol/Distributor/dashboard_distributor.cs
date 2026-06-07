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
using static System.Windows.Forms.DataFormats;

namespace PROJEKANN.Usercontrol
{
    public partial class dashboard_distributor : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        public dashboard_distributor(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_distributor_Load(object sender, EventArgs e)
        {
           
            MuatTransaksiPalingAkhir();
            MuatJumlahPanen();
            MuatDemand();
            MuatJumlahTransaksiSelesai();
            TampilkanNamaUser();
        }

        private void TampilkanNamaUser()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            lblNamaUser.Text = result.ToString();
                        }
                        else
                        {
                            lblNamaUser.Text = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                lblNamaUser.Text = userLoginAktif;
            }
        }

        private void MuatTransaksiPalingAkhir()
        {
            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM view_transaksi_palin_akhir;";

                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvDashboard.DataSource = dt;

                        dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat transaksi: " + ex.Message);
            }
        }

        private void MuatJumlahPanen()
        {
            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT total_panen FROM view_jumlah_panen";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                    lblJumlahPanen.Text = cmd.ExecuteScalar().ToString();
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

                    string query = "SELECT total_demand FROM view_deman_aktif";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    decimal totalDemand = Convert.ToDecimal(cmd.ExecuteScalar());

                    if (totalDemand >= 1000)
                    {
                        lblDemand.Text =
                            (totalDemand / 1000).ToString("N1") + " Ton";
                    }
                    else if (totalDemand >= 100)
                    {
                        lblDemand.Text =
                            (totalDemand / 100).ToString("N1") + " Kwintal";
                    }
                    else
                    {
                        lblDemand.Text =
                            totalDemand.ToString("N0") + " Kg";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat demand: " + ex.Message);
            }
        }

        private void MuatJumlahTransaksiSelesai()
        {
            try
            {
                using (NpgsqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT total_transaksi FROM view_total_transaksi";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                    lblTotalTransaksi.Text = cmd.ExecuteScalar().ToString();
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
                    new PROJEKANN.Usercontrol.dashboard_distributor(formUtama, this.userLoginAktif)
                );
            }
        }

        private void btnPanen_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen());
        }

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading());
        }

        private void btnPenawaran_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran());
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi());
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi());
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

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblNamaUser_Click(object sender, EventArgs e)
        {

        }
    }
}