using Npgsql;
using PROJEKANN.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class RiwayatTransaksi : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        public RiwayatTransaksi(Form1 form1, string username)
        {
            InitializeComponent();
            TampilRiwayat();
            HitungStatistik();
            TampilkanNamaUser();
        }

        private void RiwayatTransaksi_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            TampilRiwayat();
            HitungStatistik();
            TampilkanNamaUser();
        }

        private void TampilRiwayat()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT *
                FROM view_riwayat_transaksi;
            ";

                    using (NpgsqlDataAdapter da =
                        new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvRiwayat.DataSource = dt;

                        dgvRiwayat.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvRiwayat.Columns["harga_tawar"].DefaultCellStyle.Format = "N0";

                        dgvRiwayat.Columns["total_pembayaran"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HitungStatistik()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string queryJumlah = @"
                SELECT COUNT(*)
                FROM transaksi
                WHERE status_transaksi = 'Selesai';
            ";

                    using (NpgsqlCommand cmdJumlah =
                        new NpgsqlCommand(queryJumlah, conn))
                    {
                        lblSelesai.Text =
                            cmdJumlah.ExecuteScalar().ToString();
                    }

                    string queryTotal = @"
                SELECT COALESCE(
                    SUM(total_pembayaran), 0
                )
                FROM transaksi
                WHERE status_transaksi = 'Selesai';
            ";

                    using (NpgsqlCommand cmdTotal =
                        new NpgsqlCommand(queryTotal, conn))
                    {
                        decimal total =
                        Convert.ToDecimal(
                        cmdTotal.ExecuteScalar()
                         );

                        lblTotal.Text =
                            "Rp " +
                            total.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void btnPanen_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen(this.mainForm, this.userLoginAktif));
        }

        private void btnGrading_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading(this.mainForm, this.userLoginAktif));
        }

        private void btnPenawaran_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran(this.mainForm, this.userLoginAktif));
        }

        private void btnTransaksi_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi(this.mainForm, this.userLoginAktif));
        }

        private void btnRiwayat_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi(this.mainForm, this.userLoginAktif));
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
               "Apakah Anda yakin ingin keluar dari program?",
               "Konfirmasi Keluar",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login((Form1)this.FindForm()));
            }
        }
    }
}
