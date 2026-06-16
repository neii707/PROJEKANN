using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller;
using PROJEKANN.model;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class DashboardNelayan : UserControl
    {
        public static int IdUser { get; set; }

        public static string username { get; set; } = "";
        private Form1 mainForm;
        private string userLoginAktif;

        private ControllerDashboardNelayan _controller;

        public DashboardNelayan(Form1 formUtama, string userLogin)
        {
            InitializeComponent();
            this.mainForm = formUtama;
            this.userLoginAktif = userLogin;
            username = userLogin;
            _controller = new ControllerDashboardNelayan();
            MuatData();
        }

        private void DashboardNelayan_Load(object sender, EventArgs e)
        {
            MuatData();
        }

        private void MuatData()
        {
            ModelDashboardNelayan data = _controller.AmbilDataDashboard(username);
            lbnamauser_dashboard.Text = !string.IsNullOrEmpty(data.nama) ? data.nama : username;

            stoklabel_dashboard.Text = data.StokPanen;
            penawaranlabel_dashboard.Text = data.TotalPenjualan;
            penjualanlabel_dashboard.Text = "Rp " + data.TotalPendapatan.ToString("N0");

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

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.DashboardNelayan(this.mainForm, this.userLoginAktif));
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
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login((Form1)this.FindForm()));
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void stoklabel_dashboard_Click(object sender, EventArgs e) { }
        private void penawaranlabel_dashboard_Click(object sender, EventArgs e) { }
        private void lbnamauser_dashboard_Click(object sender, EventArgs e) { }

        private void DashboardNelayan_Load_1(object sender, EventArgs e)
        {

        }
    }
}