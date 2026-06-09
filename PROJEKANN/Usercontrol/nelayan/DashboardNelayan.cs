using System;
using System.Windows.Forms;
using PROJEKANN.controller;
using PROJEKANN.model; 

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class DashboardNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        private ControllerDashboardNelayan _controller = new ControllerDashboardNelayan();

        public DashboardNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            mainForm = form1;

            userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "Zhao_yufan" : usernameLogin.Trim();

            SegarkanTampilanDashboard();
        }

        private void SegarkanTampilanDashboard()
        {
            ModelDashboardNelayan data = _controller.AmbilDataDashboard(this.userLoginAktif);

            lbnamauser_dashboard.Text = data.NamaUserReal;
            stoklabel_dashboard.Text = data.TeksStok;
            penawaranlabel_dashboard.Text = data.TeksPenawaran;
            penjualanlabel_dashboard.Text = data.TeksPenjualan;

            if (data.TabelAktivitasBersih != null)
            {
                dgvDashboard.AutoGenerateColumns = false;
                dgvDashboard.Columns[0].DataPropertyName = "ID";
                dgvDashboard.Columns[1].DataPropertyName = "Grade";
                dgvDashboard.Columns[2].DataPropertyName = "Berat";
                dgvDashboard.Columns[3].DataPropertyName = "Tanggal";
                dgvDashboard.Columns[4].DataPropertyName = "Status";

                dgvDashboard.DataSource = data.TabelAktivitasBersih;
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                Panel panelInduk = this.Parent as Panel;

                if (panelInduk != null)
                {
                    panelInduk.Controls.Clear();
                    ucBaru.Dock = DockStyle.Fill;
                    panelInduk.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else if (this.Parent != null)
                {
                    Control indukUtama = this.Parent;
                    indukUtama.Controls.Remove(this);
                    ucBaru.Dock = DockStyle.Fill;
                    indukUtama.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
                    Form1 formAktif = Application.OpenForms["Form1"] as Form1;
                    if (formAktif != null)
                    {
                        formAktif.TampilkanHalaman(ucBaru);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin keluar dari program?",
                "Konfirmasi Keluar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void stoklabel_dashboard_Click(object sender, EventArgs e) { }
        private void penawaranlabel_dashboard_Click(object sender, EventArgs e) { }
        private void lbnamauser_dashboard_Click(object sender, EventArgs e) { }
    }
}