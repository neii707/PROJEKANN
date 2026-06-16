using System;
using System.Windows.Forms;
using PROJEKANN.controller; 
using PROJEKANN.model;      

namespace PROJEKANN.Usercontrol.admin
{
    public partial class kelola_demand : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private ControllerKelolaDemand _controller = new ControllerKelolaDemand();
        public kelola_demand(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;

            SegarkanDataTampilan();
        }

        private void SegarkanDataTampilan()
        {
            ModelKelolaDemand data = _controller.AmbilHalamanDemand(this.userLoginAktif);
            label5.Text = data.NamaUserReal;
            if (data.TabelDemand != null)
            {
                dataGridView1.DataSource = data.TabelDemand;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetRaw = textBox1.Text.Trim();
            DateTime tanggal = dateTimePicker1.Value.Date;
            DateTime hariIni = DateTime.Today;


            if (tanggal < hariIni)
            {
                MessageBox.Show("Input demand paling lambat hari ini!", "Input Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(targetRaw))
            {
                MessageBox.Show("Data tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(targetRaw, out int targetKg))
            {
                MessageBox.Show("Target KG harus berupa angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_controller.TambahDemand(targetKg, tanggal, this.userLoginAktif))
            {
                MessageBox.Show("Data demand baru berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear(); 
                SegarkanDataTampilan();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_admin(this.mainForm, this.userLoginAktif));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_akun(this.mainForm, this.userLoginAktif));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_demand(this.mainForm, this.userLoginAktif));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_stok(this.mainForm, this.userLoginAktif));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_transaksi(this.mainForm, this.userLoginAktif));
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
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login((Form1)this.FindForm()));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}