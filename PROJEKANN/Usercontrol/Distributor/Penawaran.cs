using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; // 🚀 Hubungkan folder controller
using PROJEKANN.model;      // 🚀 Hubungkan folder model

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class Penawaran : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private int idGradeTerpilih = 0;

        // Deklarasi controller penawaran distributor
        private ControllerDistributorPenawaran _controller = new ControllerDistributorPenawaran();

        public Penawaran(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
        }

        private void Penawaran_Load(object sender, EventArgs e)
        {
            SegarkanDataPenawaran();
        }

        private void SegarkanDataPenawaran()
        {
            // 1. Tarik paket data olahan dari controller
            ModelDistributorPenawaran data = _controller.AmbilDataAwal(this.userLoginAktif);

            // 2. Tampilkan Nama User ke label desainer
            if (lblNamaUser != null)
            {
                lblNamaUser.Text = data.NamaAsliUser;
            }

            // 3. Masukkan tabel data ke DataGridView
            if (data.TabelPenawaran != null)
            {
                dgvPenawaran.DataSource = data.TabelPenawaran;
                dgvPenawaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvPenawaran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil nilai cell id_grade dari baris terpilih
                idGradeTerpilih = Convert.ToInt32(dgvPenawaran.Rows[e.RowIndex].Cells["id_grade"].Value);
            }
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            // Validasi Input Kosong bawaan program
            if (idGradeTerpilih == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu!");
                return;
            }

            if (string.IsNullOrEmpty(txtHargaTawar.Text))
            {
                MessageBox.Show("Harga tawar harus diisi!");
                return;
            }

            decimal hargaTawar = Convert.ToDecimal(txtHargaTawar.Text);

            // Jalankan perintah insert lewat Stored Procedure di controller
            bool sukses = _controller.KirimHargaPenawaran(hargaTawar, idGradeTerpilih);

            if (sukses)
            {
                MessageBox.Show("Penawaran berhasil dikirim!");
                txtHargaTawar.Clear();

                // Segarkan kembali data gridview
                SegarkanDataPenawaran();
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

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading(this.mainForm, this.userLoginAktif));
        }

        private void btnPenawaran_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran(this.mainForm, this.userLoginAktif));
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi(this.mainForm, this.userLoginAktif));
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi(this.mainForm, this.userLoginAktif));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void button3_Click(object sender, EventArgs e)
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