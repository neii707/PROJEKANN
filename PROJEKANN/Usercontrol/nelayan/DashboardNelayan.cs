using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; // Panggil folder controller
using PROJEKANN.model;      // Panggil folder model

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class DashboardNelayan : UserControl
    {
        // ── Session (diisi dari Form utama saat LoadUC) ───────────────
        public static int IdUser { get; set; }

        public static string username { get; set; } = "";
        private Form1 mainForm;
        private string userLoginAktif;

        // Instansiasi Controller pendukung
        private ControllerDashboardNelayan _controller;

        public DashboardNelayan(Form1 formUtama, string userLogin)
        {
            InitializeComponent();
            this.mainForm = formUtama;
            this.userLoginAktif = userLogin;
            username = userLogin; // Mengisi static property username
            _controller = new ControllerDashboardNelayan();
            MuatData();
        }

        // ── Load pertama kali ─────────────────────────────────────────
        private void DashboardNelayan_Load(object sender, EventArgs e)
        {
            lbnamauser_dashboard.Text = username;
            MuatData();
        }

        // =============================================================
        // MUAT DATA UTAMA (Menerapkan Pola MVC)
        // =============================================================
        private void MuatData()
        {
            // 1. Minta data ke controller
            ModelDashboardNelayan data = _controller.AmbilDataDashboard(username);

            // 2. Tampilkan data Ringkasan ke Label UI
            stoklabel_dashboard.Text = data.StokPanen;
            penawaranlabel_dashboard.Text = data.TotalPenjualan;
            penjualanlabel_dashboard.Text = "Rp " + data.TotalPendapatan.ToString("N0");

            // 3. Masukkan data ke DataGridView (Sudah dibuka comment-nya)
            dgvDashboard.Rows.Clear();
            if (data.TabelDashboard != null)
            {
                foreach (DataRow row in data.TabelDashboard.Rows)
                {
                    dgvDashboard.Rows.Add(
                        row["id_panen"] != DBNull.Value ? row["id_panen"] : "",
                        row["grade"] != DBNull.Value ? row["grade"] : "-",
                        row["berat_kg"] != DBNull.Value ? row["berat_kg"] : 0,
                        row["tanggal"] != DBNull.Value ? Convert.ToDateTime(row["tanggal"].ToString()).ToString("dd/MM/yyyy") : "-",
                        row["status"] != DBNull.Value ? row["status"] : "-"
                    );
                }
            }
        }

        // =============================================================
        // NAVIGASI SIDEBAR
        // =============================================================
        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            MuatData();
        }

        private void inputpanenbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.KelolaPanenNelayan(this.mainForm, this.userLoginAktif));
        }

        private void penawaranbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.NawarPanenNelayan(this.mainForm, this.userLoginAktif));
        }

        private void transaksibutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.TransaksiNelayan(this.mainForm, this.userLoginAktif));
        }

        private void riwayatbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.RiwayatNelayan(this.mainForm, this.userLoginAktif));
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            var konfirm = MessageBox.Show("Yakin ingin keluar?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirm == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // =============================================================
        // HELPER NAVIGASI — ganti UserControl di Panel induk
        // =============================================================
        private void GantiHalamanFitur(UserControl ucBaru)
        {
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        // Event Stub dari Designer
        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void stoklabel_dashboard_Click(object sender, EventArgs e) { }
        private void penawaranlabel_dashboard_Click(object sender, EventArgs e) { }
        private void lbnamauser_dashboard_Click(object sender, EventArgs e) { }
    }
}