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
        public kelola_akun(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
            tampil_akun();
            TampilkanNamaUser();
        }

        private void TampilkanNamaUser()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    string queryNama = "SELECT nama FROM usser WHERE username = @username LIMIT 1";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryNama, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            label5.Text = result.ToString();
                        }
                        else
                        {
                            label5.Text = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                label5.Text = userLoginAktif;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
