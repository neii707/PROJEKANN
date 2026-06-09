using System;
using System.Windows.Forms;
using PROJEKANN.controller; // 🚀 Akses ke folder controller
using PROJEKANN.model;      // 🚀 Akses ke folder model

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class lihat_panen : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        // Deklarasi controller lihat panen
        private ControllerLihatPanen _controller = new ControllerLihatPanen();

        public lihat_panen(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;

            SegarkanDataTampilan();
        }

        private void lihat_panen_Load(object sender, EventArgs e)
        {
            // Pemicu dibiarkan kosong agar tidak merusak pointer designer (.picker)
        }

        private void SegarkanDataTampilan()
        {
            // 1. Ambil olahan data dari Controller
            ModelLihatPanen data = _controller.AmbilDataLihatPanen(this.userLoginAktif);

            // 2. Tampilkan Nama User Real ke UI
            lblNamaUser.Text = data.NamaUserReal;

            // 3. Ikat data tabel panen ke komponen DataGridView
            if (data.TabelPanen != null)
            {
                dataGridView1.DataSource = data.TabelPanen;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            // Menggunakan objek 'this' agar aman jika panel raksasa di desainer sudah dibersihkan
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        // ========================================================
        // 🗺️ TOMBOL NAVIGASI MENU (TETAP DI VIEW)
        // ========================================================
        private void btnPanen_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen(this.mainForm, this.userLoginAktif));
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