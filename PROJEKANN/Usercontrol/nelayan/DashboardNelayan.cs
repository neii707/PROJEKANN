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

            userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "Natachai" : usernameLogin;

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

                    string queryStok = "SELECT total_stok FROM view_stok_nelayan WHERE username = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        double totalStok = Convert.ToDouble(cmd.ExecuteScalar() ?? 0);
                        stoklabel_dashboard.Text = totalStok.ToString("N1") + " kg";
                    }

                    string queryPenawaran = "SELECT total_penawaran FROM view_penawaran_nelayan WHERE username = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenawaran, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        int totalPenawaran = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        penawaranlabel_dashboard.Text = totalPenawaran.ToString() + " Berkas";
                    }

                    string queryPenjualan = "SELECT total_pembayaran FROM view_total_transaksi_nelayan WHERE username = @username";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenjualan, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        decimal totalDuit = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
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
                    string queryTabel = "SELECT distributor AS \"Distributor\", " +
                                       "aktivitas AS \"Aktivitas\", " +
                                       "tanggal AS \"Tanggal\" " +
                                       "FROM view_dashboard_nelayan " +
                                       "WHERE username = @username " +
                                       "LIMIT 5";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvDashboard.DataSource = dt;
                            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tabel aktivitas terbaru: " + ex.Message, "Error Tabel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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