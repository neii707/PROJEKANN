using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class DashboardNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        public DashboardNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            mainForm = form1;
            userLoginAktif = usernameLogin;

            MuatSistemDashboardUtama();
        }

        private void MuatSistemDashboardUtama()
        {
            try
            {
                lbnamauser_dashboard.Text = userLoginAktif;
                HitungStatistikOtomatis();
                MuatTabelPanenTerbaru();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi masalah saat memuat data: " + ex.Message, "Sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HitungStatistikOtomatis()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryStok = "SELECT COALESCE(SUM(berat), 0) FROM tabel_panen WHERE status = 'Tersedia' AND nama_user = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        double totalStok = Convert.ToDouble(cmd.ExecuteScalar());
                        stoklabel_dashboard.Text = totalStok.ToString("N1") + " kg";
                    }

                    string queryPenawaran = "SELECT COUNT(*) FROM tabel_penawaran WHERE status = 'Pending' AND nama_user = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenawaran, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        int jumlahPenawaran = Convert.ToInt32(cmd.ExecuteScalar());
                        penawaranlabel_dashboard.Text = jumlahPenawaran.ToString() + " Berkas";
                    }

                    string queryPenjualan = "SELECT COALESCE(SUM(total_harga), 0) FROM tabel_transaksi WHERE status = 'Selesai' AND nama_user = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenjualan, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        decimal totalDuit = Convert.ToDecimal(cmd.ExecuteScalar());
                        penjualanlabel_dashboard.Text = "Rp " + totalDuit.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat statistik database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MuatTabelPanenTerbaru()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();
                    string queryTabel = "SELECT id_panen, grade, berat, tanggal_panen, status FROM tabel_panen WHERE nama_user = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDashboard.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel2.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel2.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            panel2.Controls.Add(lbnamauser_dashboard);
            panel2.Controls.Add(keluarbutton_dashboard);
            panel2.Controls.Add(panenlabel_dashboard);
            panel2.Controls.Add(dgvDashboard);
            panel2.Controls.Add(penjualanlabel_dashboard);
            panel2.Controls.Add(stoklabel_dashboard);
            panel2.Controls.Add(penawaranlabel_dashboard);
            panel2.Controls.Add(namauserlabel_dashboard);
            panel2.Controls.Add(riwayatbutton_dashboard);
            panel2.Controls.Add(transaksibutton_dashboard);
            panel2.Controls.Add(penawaranbutton_dashboard);
            panel2.Controls.Add(inputpanenbutton_dashboard);
            panel2.Controls.Add(dashboardbutton);

            MuatSistemDashboardUtama();
        }

        private void inputpanenbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.KelolaPanenNelayan());
        }

        private void penawaranbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.NawarPanenNelayan());
        }

        private void transaksibutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.TransaksiNelayan());
        }

        private void riwayatbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.RiwayatNelayan());
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                mainForm.TampilkanHalaman(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}