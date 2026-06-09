using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; // 🚀 Hubungkan folder controller
using PROJEKANN.model;      // 🚀 Hubungkan folder model

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class RiwayatTransaksi : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        // Inisialisasi object controller distributor
        private ControllerRiwayatDistributor _controller = new ControllerRiwayatDistributor();

        public RiwayatTransaksi(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;

            SegarkanDataTampilan();
        }

        private void RiwayatTransaksi_Load(object sender, EventArgs e) { }

        private void SegarkanDataTampilan()
        {
            // 1. Ambil paket bundle data olahan dari controller
            ModelRiwayatDistributor data = _controller.AmbilSemuaDataRiwayat(this.userLoginAktif);

            // 2. Tampilkan Nama User ke Komponen View
            if (lblNamaUser != null)
            {
                lblNamaUser.Text = data.NamaUserReal;
            }

            // 3. Tampilkan Data Statistik ke Komponen View
            if (lblSelesai != null)
            {
                lblSelesai.Text = data.TotalSelesai;
            }
            if (lblTotal != null)
            {
                lblTotal.Text = "Rp " + data.TotalPembayaran.ToString("N0");
            }

            // 4. Bind Data ke DataGridView dan Atur Format Penulisan Angka Desimal
            if (data.TabelRiwayat != null && dgvRiwayat != null)
            {
                dgvRiwayat.DataSource = data.TabelRiwayat;
                dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvRiwayat.Columns.Contains("harga_tawar"))
                {
                    dgvRiwayat.Columns["harga_tawar"].DefaultCellStyle.Format = "N0";
                }
                if (dgvRiwayat.Columns.Contains("total_pembayaran"))
                {
                    dgvRiwayat.Columns["total_pembayaran"].DefaultCellStyle.Format = "N0";
                }
            }
        }

        // ========================================================
        // 🗺️ SISTEM NAVIGASI FITUR MENU ASLI BAWAAN PROGRAM
        // ========================================================
        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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
            SegarkanDataTampilan();
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