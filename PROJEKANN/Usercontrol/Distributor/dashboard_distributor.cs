using System;
using System.Windows.Forms;
using PROJEKANN.controller; // 🚀 Akses ke folder controller
using PROJEKANN.model;      // 🚀 Akses ke folder model

namespace PROJEKANN.Usercontrol
{
    public partial class dashboard_distributor : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        // Daftarkan controller dashboard distributor
        private ControllerDashboardDistributor _controller = new ControllerDashboardDistributor();

        public dashboard_distributor(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
        }

        private void dashboard_distributor_Load(object sender, EventArgs e)
        {
            SegarkanDataTampilan();
        }

        private void SegarkanDataTampilan()
        {
            // 1. Minta data rangkuman ke controller
            ModelDashboardDistributor data = _controller.AmbilDataDashboard(this.userLoginAktif);

            // 2. Distribusikan data ke masing-masing komponen UI
            lblNamaUser.Text = data.NamaUserReal;
            lblJumlahPanen.Text = data.TeksJumlahPanen;
            lblDemand.Text = data.TeksDemand;
            lblTotalTransaksi.Text = data.TeksTotalTransaksi;

            // 3. Ikat data ke DataGridView jika datanya tersedia
            if (data.TabelTransaksiAkhir != null)
            {
                dgvDashboard.DataSource = data.TabelTransaksiAkhir;
                dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            DashboardDistributor.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            DashboardDistributor.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        // ========================================================
        // 🗺️ TOMBOL NAVIGASI MENU DISTRIBUTOR
        // ========================================================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void btnPanen_Click(object sender, EventArgs e)
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

        // Event kosong dibiarkan agar tidak merusak pointer designer .picker
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void lblJumlahPanen_Click(object sender, EventArgs e) { }
        private void lblDemand_Click(object sender, EventArgs e) { }
        private void lblTotalTransaksi_Click(object sender, EventArgs e) { }
        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblNamaUser_Click(object sender, EventArgs e) { }

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