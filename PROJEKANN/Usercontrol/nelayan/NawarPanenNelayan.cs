using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class NawarPanenNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif; // Memegang USERNAME user aktif
        private string namaAsliUser = ""; // Memegang NAMA ASLI untuk pencarian tabel

        public NawarPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;

            // MENERIMA USERNAME LOGIN
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            // Jalankan pencarian nama asli & muat tabel penawaran
            AmbilDanTampilkanNamaAsli();
            MuatTabelPenawaran();
        }

        /// <summary>
        /// Mengambil nama asli berdasarkan username login aktif dan menampilkannya ke label sidebar
        /// </summary>
        private void AmbilDanTampilkanNamaAsli()
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
                            this.namaAsliUser = result.ToString();
                        }
                        else
                        {
                            // Fallback jika nama kosong di database
                            this.namaAsliUser = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                this.namaAsliUser = userLoginAktif;
            }

            // SET TEKS NAMA ASLI KE LABELLING SIDEBAR
            if (lbnamauser_dashboard != null)
            {
                lbnamauser_dashboard.Text = this.namaAsliUser;
            }
        }

        private void MuatTabelPenawaran()
        {
            // Jika nama asli belum siap atau kosong, jangan eksekusi query dulu
            if (string.IsNullOrEmpty(namaAsliUser)) return;

            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    // QUERY FINAL menggunakan namaAsliUser hasil pencarian tabel database
                    string query = @"SELECT id, distributor, berat, grade, harga, estimasi, tanggal, status 
                                     FROM view_penawaran_panen_nelayan 
                                     WHERE nama_nelayan = @nama 
                                     ORDER BY id DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@nama", namaAsliUser);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvpenawaran.AutoGenerateColumns = false;

                            // Pemetaan komponen kolom DataGridView
                            colID.DataPropertyName = "id";
                            colDistributor.DataPropertyName = "distributor";
                            colBerat.DataPropertyName = "berat";
                            colGrade.DataPropertyName = "grade";
                            colHarga.DataPropertyName = "harga";
                            colEstimasi.DataPropertyName = "estimasi";
                            colTanggal.DataPropertyName = "tanggal";
                            colStatus.DataPropertyName = "status";

                            dgvpenawaran.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data penawaran: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // MEKANISME NAVIGASI UTAMA (SINKRON DENGAN KELOLA PANEN)
        // ==========================================================
        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                Panel panelInduk = this.Parent as Panel;

                if (panelInduk != null)
                {
                    panelInduk.Controls.Clear();
                    ucBaru.Dock = DockStyle.Fill;
                    panelInduk.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else if (this.Parent != null)
                {
                    Control indukUtama = this.Parent;
                    indukUtama.Controls.Remove(this);
                    ucBaru.Dock = DockStyle.Fill;
                    indukUtama.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
                    Form1 formAktif = Application.OpenForms["Form1"] as Form1;
                    if (formAktif != null)
                    {
                        formAktif.TampilkanHalaman(ucBaru);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // SIDEBAR NAVIGATION ACTIONS (KONSISTEN MENGIRIM USERNAME)
        // ==========================================================
        private void dashboardbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_nawar_Click(object sender, EventArgs e)
        {
            AmbilDanTampilkanNamaAsli();
            MuatTabelPenawaran();
        }

        private void transaksibutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_nawar_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Logout Sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        // ==========================================================
        // FITUR AKSI TRANSAKSI PENAWARAN
        // ==========================================================
        private void terima_nawar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Penawaran Berhasil Diterima!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tolak_tawaran_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Penawaran Berhasil Ditolak!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}