using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller;
using PROJEKANN.model;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class KelolaPanenNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private string namaAsliUser = "";
        private int idPanenTerpilih = 0;

        private ControllerKelolaPanen _controller = new ControllerKelolaPanen();

        public KelolaPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            MuatUlangSeluruhTampilan();
        }

        private void MuatUlangSeluruhTampilan()
        {
            ModelKelolaPanen data = _controller.AmbilDataKelolaPanen(this.userLoginAktif);

            this.namaAsliUser = data.NamaAsliUser;
            lbnamauser_kelola.Text = data.NamaAsliUser;

            if (data.TabelPanenSaya != null)
            {
                dgvriwayatpanen.AutoGenerateColumns = false;
                colID.DataPropertyName = "id";
                colBerat.DataPropertyName = "berat";
                colGrade.DataPropertyName = "grade";
                colHarga.DataPropertyName = "harga_per_kg";
                colStatus.DataPropertyName = "status";

                dgvriwayatpanen.DataSource = data.TabelPanenSaya;
            }
        }

        private void simpanpanen_kelola_Click(object sender, EventArgs e)
        {
            double beratInput = Convert.ToDouble(numBerat.Value);
            DateTime tanggalInput = dtptanggalpanen.Value;

            if (beratInput <= 0)
            {
                MessageBox.Show("Silakan masukkan berat panen yang valid!", "Peringatan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sukses = _controller.SimpanAtauUbahPanen(userLoginAktif, idPanenTerpilih, beratInput, tanggalInput);

            if (sukses)
            {
                numBerat.Value = 0;
                idPanenTerpilih = 0;
                simpanpanen_kelola.Text = "simpan";

                MuatUlangSeluruhTampilan();
            }
        }

        private void hapuspanen_kelola_Click(object sender, EventArgs e)
        {
            if (dgvriwayatpanen.CurrentRow == null) return;

            string statusPanen = dgvriwayatpanen.CurrentRow.Cells["colStatus"].Value.ToString().ToLower();

            if (statusPanen == "menunggu grading")
            {
                string idPanenTerpilihText = dgvriwayatpanen.CurrentRow.Cells["colID"].Value.ToString();
                DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin menghapus data panen dengan ID {idPanenTerpilihText}?", "Konfirmasi Hapus", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.OK || konfirmasi == DialogResult.Yes)
                {
                    bool suksesHapus = _controller.HapusPanen(Convert.ToInt32(idPanenTerpilihText));
                    if (suksesHapus)
                    {
                        MuatUlangSeluruhTampilan();
                    }
                }
            }
            else
            {
                MessageBox.Show("Data tidak bisa dihapus karena sudah di-grade atau diproses oleh distributor!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void dgvriwayatpanen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvriwayatpanen.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow row = dgvriwayatpanen.Rows[e.RowIndex];
                    if (row.Cells["colID"].Value != null && row.Cells["colID"].Value != DBNull.Value)
                    {
                        idPanenTerpilih = Convert.ToInt32(row.Cells["colID"].Value);

                        if (decimal.TryParse(row.Cells["colBerat"].Value.ToString(), out decimal berat))
                        {
                            numBerat.Value = berat;
                        }

                        simpanpanen_kelola.Text = "Ubah Data";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengambil data baris: " + ex.Message, "Error Seleksi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Ganti(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                Panel indukPanel = this.Parent as Panel;
                if (indukPanel != null)
                {
                    indukPanel.Controls.Clear();
                    ucBaru.Dock = DockStyle.Fill;
                    indukPanel.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
                    if (kelolapanenpanel != null)
                    {
                        kelolapanenpanel.Controls.Clear();
                        ucBaru.Dock = DockStyle.Fill;
                        kelolapanenpanel.Controls.Add(ucBaru);
                        ucBaru.BringToFront();
                    }
                    else
                    {
                        mainForm.TampilkanHalaman(ucBaru);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardbutton_kelola_Click(object sender, EventArgs e)
        {
            Ganti(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_kelola_Click(object sender, EventArgs e)
        {
            MuatUlangSeluruhTampilan();
        }

        private void penawaranbutton_kelola_Click(object sender, EventArgs e)
        {
            Ganti(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_kelola_Click(object sender, EventArgs e)
        {
            Ganti(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_kelola_Click(object sender, EventArgs e)
        {
            Ganti(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_kelola_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Logout Sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                Ganti(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void dgvriwayatpanen_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}