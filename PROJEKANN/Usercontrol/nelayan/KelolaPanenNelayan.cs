using Npgsql;
using PROJEKANN.controller;
using PROJEKANN.database;
using PROJEKANN.model;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

            numBerat.DecimalPlaces = 2;
            numBerat.Increment = 0.5M;

            MuatUlangSeluruhTampilan();
        }

        private void MuatUlangSeluruhTampilan()
        {
            ModelKelolaPanen data = _controller.AmbilDataKelolaPanen(this.userLoginAktif);

            this.namaAsliUser = data.NamaAsliUser;
            lbnamauser_kelola.Text = data.NamaAsliUser;

            if (data.TabelPanenSaya != null)
            {
                dgvriwayatpanen.DataSource = null;
                dgvriwayatpanen.AutoGenerateColumns = false;

                colID.DataPropertyName = "id";
                colBerat.DataPropertyName = "berat";
                colGrade.DataPropertyName = "grade";
                colHarga.DataPropertyName = "harga_per_kg";
                colStatus.DataPropertyName = "status";

                CultureInfo kulturIndo = new CultureInfo("id-ID");
                colBerat.DefaultCellStyle.FormatProvider = kulturIndo;
                colBerat.DefaultCellStyle.Format = "N2";

                colHarga.DefaultCellStyle.FormatProvider = kulturIndo;
                colHarga.DefaultCellStyle.Format = "C2";

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

            string statusPanen = dgvriwayatpanen.CurrentRow.Cells["colStatus"].Value?.ToString().ToLower() ?? "";

            if (statusPanen.Contains("belum") || statusPanen.Contains("menunggu"))
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

                        using (NpgsqlConnection kon = DBConnection.GetConnection())
                        {
                            kon.Open();
                            string queryCekTanggal = "SELECT tanggal FROM panen WHERE id_panen = @id LIMIT 1";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(queryCekTanggal, kon))
                            {
                                cmd.Parameters.AddWithValue("@id", idPanenTerpilih);
                                object resTgl = cmd.ExecuteScalar();
                                if (resTgl != null && resTgl != DBNull.Value)
                                {
                                    dtptanggalpanen.Value = Convert.ToDateTime(resTgl);
                                }
                            }
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

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void dashboardbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.DashboardNelayan(this.mainForm, this.userLoginAktif));
        }

        private void inputpanenbutton_kelola_Click(object sender, EventArgs e)
        {
            MuatUlangSeluruhTampilan();
        }

        private void penawaranbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.NawarPanenNelayan(this.mainForm, this.userLoginAktif));
        }

        private void transaksibutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.TransaksiNelayan(this.mainForm, this.userLoginAktif));
        }

        private void riwayatbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.RiwayatNelayan(this.mainForm, this.userLoginAktif));
        }

        private void keluarbutton_kelola_Click(object sender, EventArgs e)
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

        private void dgvriwayatpanen_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}