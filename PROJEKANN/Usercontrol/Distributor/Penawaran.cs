using System;
using System.Data;
using System.Windows.Forms;
using PROJEKANN.controller; 
using PROJEKANN.model;      

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class Penawaran : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private int idGradeTerpilih = 0;

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

            ModelDistributorPenawaran data = _controller.AmbilDataAwal(this.userLoginAktif);

            if (lblNamaUser != null)
            {
                lblNamaUser.Text = data.NamaAsliUser;
            }

            if (data.TabelPenawaran != null)
            {
                dgvPenawaran.DataSource = data.TabelPenawaran;
                dgvPenawaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvPenawaran.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvPenawaran.MultiSelect = false;

                dgvPenawaran.ReadOnly = true;

                if (dgvPenawaran.Columns.Contains("harga_per_kg"))
                {
                    dgvPenawaran.Columns["harga_per_kg"].DefaultCellStyle.Format = "N0";
                }
            }
        }


        private void btnKirim_Click(object sender, EventArgs e)
        {
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

            bool sukses = _controller.KirimHargaPenawaran(hargaTawar, idGradeTerpilih);

            if (sukses)
            {
                MessageBox.Show("Penawaran berhasil dikirim!");
                txtHargaTawar.Clear();

                SegarkanDataPenawaran();
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

        private void dgvPenawaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idGradeTerpilih = Convert.ToInt32(
                    dgvPenawaran.Rows[e.RowIndex]
                    .Cells["id_grade"].Value
                );
            }
        }
    }
}