using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; 
using PROJEKANN.model;      

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class Grading : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private int idPanenTerpilih = 0;

        private ControllerGrading _controller = new ControllerGrading();

        public Grading(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
        }

        private void Grading_Load_1(object sender, EventArgs e)
        {
            SegarkanTampilanGrading();

            cbGrade.Items.Clear();
            cbGrade.Items.Add("A");
            cbGrade.Items.Add("B");
            cbGrade.Items.Add("C");

            dgvGrading.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;
            dgvGrading.MultiSelect = false;
        }

        private void SegarkanTampilanGrading()
        {
            ModelGrading data = _controller.AmbilDataGrading(this.userLoginAktif);

            lblNamaUser.Text = data.NamaUserReal;

            if (data.TabelGradingPanen != null)
            {
                dgvGrading.DataSource = data.TabelGradingPanen;
                dgvGrading.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnTetapkan_Click(object sender, EventArgs e)
        {
            if (idPanenTerpilih == 0)
            {
                MessageBox.Show("Pilih data panen terlebih dahulu!", "Validasi Sistem");
                return;
            }

            if (cbGrade.SelectedItem == null)
            {
                MessageBox.Show("Pilih grade terlebih dahulu!", "Validasi Sistem");
                return;
            }

            string gradeDipilih = cbGrade.SelectedItem.ToString();
            string keterangan = txtKeterangan.Text;
            decimal harga = 0;

            if (gradeDipilih == "A") harga = 18000;
            else if (gradeDipilih == "B") harga = 13000;
            else harga = 5000;

            bool berhasil = _controller.TetapkanGradePanen(idPanenTerpilih, gradeDipilih, keterangan, harga);

            if (berhasil)
            {
                MessageBox.Show("Grade berhasil ditetapkan!", "Sukses");

                idPanenTerpilih = 0;
                cbGrade.SelectedIndex = -1;
                txtKeterangan.Clear();

                SegarkanTampilanGrading();
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void btnPanen_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen(this.mainForm, this.userLoginAktif));
        }

        private void btnPanen_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen(this.mainForm, this.userLoginAktif));
        }

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading(this.mainForm, this.userLoginAktif));
        }

        private void btnGrading_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading(this.mainForm, this.userLoginAktif));
        }

        private void btnPenawaran_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran(this.mainForm, this.userLoginAktif));
        }

        private void btnPenawaran_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran(this.mainForm, this.userLoginAktif));
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi(this.mainForm, this.userLoginAktif));
        }

        private void btnTransaksi_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi(this.mainForm, this.userLoginAktif));
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi(this.mainForm, this.userLoginAktif));
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

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void dgvGrading_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idPanenTerpilih =
                    Convert.ToInt32(
                    dgvGrading.Rows[e.RowIndex]
                    .Cells["id_panen"].Value
                );

                dgvGrading.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}