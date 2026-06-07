using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJEKANN.Usercontrol.admin
{
    public partial class kelola_akun : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        public kelola_akun()
        {
            InitializeComponent();
            tampil_akun();
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
                try
                {
                    using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                    {
                        conn.Open();

                        string queryUpdate = @"
                    UPDATE usser 
                    SET status_konfir_akun = 'Konfirmasi' 
                    WHERE username = @username";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", usernameTerpilih);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Akun '{usernameTerpilih}' berhasil dikonfirmasi dan sekarang sudah aktif!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tampil_akun();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengonfirmasi akun: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tampil_akun()
        {
            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM v_konfir_akun2";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat aktivitas lewat View: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 formUtama = this.FindForm() as Form1;

            if (formUtama != null)
            {
                formUtama.TampilkanHalaman(new PROJEKANN.Usercontrol.dashboard_admin(formUtama, this.userLoginAktif));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_akun());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_demand());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_stok());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.monitor_transaksi());
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
                try
                {
                    using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                    {
                        conn.Open();

                        string queryUpdate = @"
                    UPDATE usser 
                    SET status_konfir_akun = 'Blokir' 
                    WHERE username = @username";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", usernameTerpilih);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Akun '{usernameTerpilih}' berhasil diblokir !", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tampil_akun();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memblokir akun: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
    }
}
