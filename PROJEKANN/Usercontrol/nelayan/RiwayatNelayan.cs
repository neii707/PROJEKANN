using PROJEKANN.controller;
using PROJEKANN.model;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class RiwayatNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private string namaAsliUser = "";

        private ControllerRiwayat _controller = new ControllerRiwayat();

        public RiwayatNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            SegarkanTampilanRiwayat();
        }

        private void SegarkanTampilanRiwayat()
        {
            ModelRiwayat data = _controller.AmbilDataRiwayat(this.userLoginAktif);

            this.namaAsliUser = data.NamaAsliUser;
            if (lbnamauser_riwayat != null)
            {
                lbnamauser_riwayat.Text = this.namaAsliUser;
            }

            if (totallabel_riwayat != null)
            {
                totallabel_riwayat.Text = data.TeksStatistik;
            }

            if (data.TabelRiwayatTransaksi != null)
            {
                dgvTransaksi.AutoGenerateColumns = false;
                dgvTransaksi.DataSource = data.TabelRiwayatTransaksi;

                colID.DataPropertyName = "id_panen";
                colDistributor.DataPropertyName = "nama_distributor";
                colBerat.DataPropertyName = "berat_kg";
                colGrade.DataPropertyName = "grade";
                colTotal.DataPropertyName = "total";
                colTanggal.DataPropertyName = "tanggal_konfirmasi";
                colStatus.DataPropertyName = "status";

                dgvTransaksi.DataSource = data.TabelRiwayatTransaksi;
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
                    mainForm?.TampilkanHalaman(ucBaru);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardbutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_riwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_riwayat_Click(object sender, EventArgs e)
        {
            SegarkanTampilanRiwayat();
        }

        private void keluarbutton_riwayat_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Apakah anda yakin ingin keluar aplikasi?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (k == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }
    }
}