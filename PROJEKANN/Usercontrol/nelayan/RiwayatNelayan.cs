using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class RiwayatNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif; 
        private string namaAsliUser = "";

        public RiwayatNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            AmbilDanTampilkanNamaAsli();

            MuatRangkumanStatistik();
            MuatTabelRiwayat();
        }

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
                            this.namaAsliUser = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                this.namaAsliUser = userLoginAktif;
            }

            if (lbnamauser_riwayat != null)
            {
                lbnamauser_riwayat.Text = this.namaAsliUser;
            }
        }

        private void MuatRangkumanStatistik()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryStatistik = @"
                        SELECT 
                            COUNT(id) as total_transaksi,
                            COUNT(CASE WHEN LOWER(status) = 'selesai' THEN 1 END) as total_selesai,
                            COALESCE(SUM(CASE WHEN LOWER(status) = 'selesai' THEN total ELSE 0 END), 0) as total_nilai
                        FROM view_riwayat_transaksi_nelayan 
                        WHERE nelayan = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStatistik, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalTransaksi = Convert.ToInt32(reader["total_transaksi"]);
                                int totalSelesai = Convert.ToInt32(reader["total_selesai"]);
                                decimal totalNilaiSelesai = Convert.ToDecimal(reader["total_nilai"]);

                                if (totallabel_riwayat != null)
                                {
                                    totallabel_riwayat.Text = $"Total Transaksi: {totalTransaksi} | Selesai: {totalSelesai} transaksi | Total Nilai Selesai: Rp {totalNilaiSelesai:N0}";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat statistik agregat: " + ex.Message, "Error Statistik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MuatTabelRiwayat()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    string query = "SELECT id, distributor, nelayan, berat, grade, harga_per_kg, total, tanggal, status " +
                                   "FROM view_riwayat_transaksi_nelayan WHERE nelayan = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvTransaksi.AutoGenerateColumns = false;

                            colID.DataPropertyName = "id";
                            colDistributor.DataPropertyName = "distributor";
                            colNelayan.DataPropertyName = "nelayan";
                            colBerat.DataPropertyName = "berat";
                            colGrade.DataPropertyName = "grade";
                            colHarga.DataPropertyName = "harga_per_kg";
                            colTotal.DataPropertyName = "total";
                            colTanggal.DataPropertyName = "tanggal";
                            colStatus.DataPropertyName = "status";

                            dgvTransaksi.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat grid riwayat transaksi: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    mainForm?.TampilkanHalaman(ucBaru);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardbutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_riwayat_Click(object sender, EventArgs e)
        {
            AmbilDanTampilkanNamaAsli();
            MuatRangkumanStatistik();
            MuatTabelRiwayat();
        }

        private void keluarbutton_riwayat_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Apakah anda yakin ingin keluar aplikasi?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (k == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }
    }
}