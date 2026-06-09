using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; // 🚀 Hubungkan folder controller
using PROJEKANN.model;      // 🚀 Hubungkan folder model

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class Transaksi : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private int idTransaksiTerpilih = 0;

        // Instansiasi objek controller transaksi distributor
        private ControllerDistributorTransaksi _controller = new ControllerDistributorTransaksi();

        public Transaksi(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;

            SegarkanDataTransaksi();
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            SegarkanDataTransaksi();
        }

        private void SegarkanDataTransaksi()
        {
            // 1. Tarik bungkusan data dari controller
            ModelDistributorTransaksi data = _controller.AmbilDataAwal(this.userLoginAktif);

            // 2. Tempel nama asli ke label UI desainer
            if (lblNamaUser != null)
            {
                lblNamaUser.Text = data.NamaAsliUser;
            }

            // 3. Ikat data ke DataGridView
            if (data.TabelTransaksi != null)
            {
                dgvTransaksi.DataSource = data.TabelTransaksi;
                dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Mengambil nilai ID transaksi dari baris grid yang diklik
                idTransaksiTerpilih = Convert.ToInt32(dgvTransaksi.Rows[e.RowIndex].Cells["id_transaksi"].Value);
            }
        }

        private void btnKonfirmasi_Click_1(object sender, EventArgs e)
        {
            if (idTransaksiTerpilih == 0)
            {
                MessageBox.Show("Pilih transaksi dulu!");
                return;
            }

            DialogResult hasil = MessageBox.Show("Konfirmasi pembayaran cash?", "Konfirmasi", MessageBoxButtons.YesNo);

            if (hasil == DialogResult.Yes)
            {
                // Kirim perintah update ke controller
                bool sukses = _controller.KonfirmasiPembayaranCash(idTransaksiTerpilih);

                if (sukses)
                {
                    MessageBox.Show("Pembayaran berhasil dikonfirmasi!");

                    // Reset selection ID dan segarkan tabel kembali
                    idTransaksiTerpilih = 0;
                    SegarkanDataTransaksi();
                }
            }
        }

        // ========================================================
        // 🗺️ SISTEM NAVIGASI DISTRIBUTOR (TETAP DI VIEW UTAMA)
        // ========================================================
        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
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