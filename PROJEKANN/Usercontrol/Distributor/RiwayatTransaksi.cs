using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; 
using PROJEKANN.model;      

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class RiwayatTransaksi : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

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
            ModelRiwayatDistributor data = _controller.AmbilSemuaDataRiwayat(this.userLoginAktif);

            if (lblNamaUser != null)
            {
                lblNamaUser.Text = data.NamaUserReal;
            }

            if (lblSelesai != null)
            {
                lblSelesai.Text = data.TotalSelesai;
            }
            if (lblTotal != null)
            {
                lblTotal.Text = "Rp " + data.TotalPembayaran.ToString("N0");
            }

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

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
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