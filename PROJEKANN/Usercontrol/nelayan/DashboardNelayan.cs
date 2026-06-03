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

            // Jika username login kosong (misal saat testing langsung), otomatis gunakan "Natachai" atau user bawaan DB
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

                    // =========================================================================
                    // 1. QUERY STOK PANEN
                    // Menghitung total berat_per_kg dari tabel panen milik nelayan yang login
                    // =========================================================================
                    string queryStok = "SELECT COALESCE(SUM(p.berat_per_kg), 0) " +
                                       "FROM panen p " +
                                       "JOIN usser u ON p.id_user = u.id_user " +
                                       "WHERE u.username = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        double totalStok = Convert.ToDouble(cmd.ExecuteScalar());
                        stoklabel_dashboard.Text = totalStok.ToString("N1") + " kg";
                    }

                    // =========================================================================
                    // 2. QUERY PENAWARAN (DARI TABEL TRANSAKSI)
                    // Menghitung jumlah penawaran yang konfir_penawaran-nya masih 'Menunggu'
                    // =========================================================================
                    string queryPenawaran = "SELECT COUNT(*) " +
                                            "FROM transaksi t " +
                                            "JOIN grade g ON t.id_grade = g.id_grade " +
                                            "JOIN panen p ON g.id_panen = p.id_panen " +
                                            "JOIN usser u ON p.id_user = u.id_user " +
                                            "WHERE t.konfir_penawaran = 'Menunggu' AND u.username = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenawaran, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        int jumlahPenawaran = Convert.ToInt32(cmd.ExecuteScalar());
                        penawaranlabel_dashboard.Text = jumlahPenawaran.ToString() + " Berkas";
                    }

                    // =========================================================================
                    // 3. QUERY PENJUALAN (DARI TABEL TRANSAKSI)
                    // Menghitung total_pembayaran dari transaksi yang status_transaksi-nya 'Selesai'
                    // =========================================================================
                    string queryPenjualan = "SELECT COALESCE(SUM(t.total_pembayaran), 0) " +
                                            "FROM transaksi t " +
                                            "JOIN grade g ON t.id_grade = g.id_grade " +
                                            "JOIN panen p ON g.id_panen = p.id_panen " +
                                            "JOIN usser u ON p.id_user = u.id_user " +
                                            "WHERE t.status_transaksi = 'Selesai' AND u.username = @username";

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

                    // =========================================================================
                    // 4. QUERY DATAGRIDVIEW PANEN TERBARU
                    // Mengambil data panen milik nelayan dan mencocokkan Grade dari Distributor jika ada (LEFT JOIN)
                    // =========================================================================
                    string queryTabel = "SELECT p.id_panen AS \"ID\", " +
                                       "COALESCE(g.kategori, '-') AS \"Grade\", " +
                                       "p.berat_per_kg AS \"Berat (kg)\", " +
                                       "p.tanggal AS \"Tanggal\", " +
                                       "COALESCE(t.status_transaksi, 'Menunggu') AS \"Status\" " +
                                       "FROM panen p " +
                                       "JOIN usser u ON p.id_user = u.id_user " +
                                       "LEFT JOIN grade g ON p.id_panen = g.id_panen " +
                                       "LEFT JOIN transaksi t ON g.id_grade = t.id_grade " +
                                       "WHERE u.username = @username " +
                                       "ORDER BY p.id_panen DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDashboard.DataSource = dt;

                            // Merapikan ukuran kolom tabel di aplikasi secara otomatis
                            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tabel panen terbaru: " + ex.Message, "Error Tabel", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Meneruskan data user yang sedang login aktif ke halaman Kelola Panen
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