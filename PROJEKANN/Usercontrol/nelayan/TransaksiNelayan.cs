using PROJEKANN.controller;
using PROJEKANN.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class TransaksiNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private string namaAsliUser = "";

        private ControllerTransaksi _controller = new ControllerTransaksi();

        public TransaksiNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            SegarkanTampilanTransaksi();
        }

        private void SegarkanTampilanTransaksi()
        {
            ModelTransaksi data = _controller.AmbilDataTransaksiAktif(this.userLoginAktif);

            this.namaAsliUser = data.NamaAsliUser;
            if (lbnamauser_transaksi != null)
            {
                lbnamauser_transaksi.Text = this.namaAsliUser;
            }

            if (data.TabelTransaksiAktif != null)
            {
                dgvtransaksi.AutoGenerateColumns = false;

                // MENYINKRONKAN DATA PROPERTY NAME DENGAN KOLOM VIEW DATABASE
                colID.DataPropertyName = "ID Panen";
                colDistributor.DataPropertyName = "Distributor";
                colBerat.DataPropertyName = "Berat (kg)";
                total_pembayaran.DataPropertyName = "total_pembayaran";
                colStatus.DataPropertyName = "Status";

                dgvtransaksi.DataSource = data.TabelTransaksiAktif;
            }
        }

        private void konfirmasi_transaksi_Click(object sender, EventArgs e)
        {
            if (dgvtransaksi.CurrentRow == null)
            {
                MessageBox.Show("Pilih baris transaksi pada tabel terlebih dahulu sebelum menekan tombol konfirmasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView row = (DataRowView)dgvtransaksi.CurrentRow.DataBoundItem;

            // VALIDASI STATUS: JIKA BELUM DIBAYAR, BLOKIR PROSESNYA
            string statusPembelian = row["Status"].ToString();
            if (statusPembelian.ToLower() == "belum dibayar")
            {
                MessageBox.Show("Transaksi tidak bisa dikonfirmasi! Tunggu distributor melakukan pembayaran terlebih dahulu.", "Konfirmasi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int idTransaksiSelected = Convert.ToInt32(row["id_transaksi"]);

            DialogResult dr = MessageBox.Show("Apakah Anda yakin ingin memberikan konfirmasi selesai pada transaksi ini?",
                "Konfirmasi Penyelesaian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool sukses = _controller.KonfirmasiTransaksiSelesai(idTransaksiSelected);

                if (sukses)
                {
                    MessageBox.Show("Transaksi sukses ditutup dan dipindahkan ke riwayat archive.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SegarkanTampilanTransaksi();
                }
            }
        }

        private void GantiHalaman(UserControl ucBaru)
        {
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void dashboardbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_transaksi_Click(object sender, EventArgs e)
        {
            SegarkanTampilanTransaksi();
        }

        private void riwayatbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_transaksi_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Apakah anda yakin ingin keluar aplikasi?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (k == DialogResult.Yes)
            {
                GantiHalaman(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void paneltransaksi_Paint(object sender, PaintEventArgs e) { }

        private void dgvtransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}