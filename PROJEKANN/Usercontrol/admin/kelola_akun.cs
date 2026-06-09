using System;
using System.Windows.Forms;
using PROJEKANN.controller; 
using PROJEKANN.model;      

namespace PROJEKANN.Usercontrol.admin
{
    public partial class kelola_akun : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private ControllerKelolaAkun _controller = new ControllerKelolaAkun();
        public kelola_akun(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;

            SegarkanDataTampilan();
        }

        private void SegarkanDataTampilan()
        {
            ModelKelolaAkun data = _controller.AmbilHalamanKelolaAkun(this.userLoginAktif);
            label5.Text = data.NamaUserReal;
            if (data.TabelAkun != null)
            {
                dataGridView1.DataSource = data.TabelAkun;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih baris data akun yang ingin dikonfirmasi terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usernameTerpilih = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show($"Apakah Anda yakin ingin mengonfirmasi akun dengan username '{usernameTerpilih}'?", "Konfirmasi Akun", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (_controller.UpdateStatusAkun(usernameTerpilih, "Konfirmasi"))
                {
                    MessageBox.Show($"Akun '{usernameTerpilih}' berhasil dikonfirmasi dan sekarang sudah aktif!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SegarkanDataTampilan(); 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih baris data akun yang ingin diblokir terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usernameTerpilih = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show($"Apakah Anda yakin ingin memblokir akun dengan username '{usernameTerpilih}'?", "Konfirmasi Akun", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                if (_controller.UpdateStatusAkun(usernameTerpilih, "Blokir"))
                {
                    MessageBox.Show($"Akun '{usernameTerpilih}' berhasil diblokir !", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SegarkanDataTampilan();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_admin(this.mainForm, this.userLoginAktif));
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}