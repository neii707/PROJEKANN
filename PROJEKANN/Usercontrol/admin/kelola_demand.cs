using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.admin
{
    public partial class kelola_demand : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        public kelola_demand(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
            tampil_demand();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string targetkg = textBox1.Text.Trim();
            DateTime tanggal = dateTimePicker1.Value.Date;

            if (string.IsNullOrEmpty(targetkg))
            {
                MessageBox.Show("Data tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                INSERT INTO demand (target_kg, deadline, id_user) 
                VALUES (@target, @tanggal, '1')";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@target", Convert.ToInt32(targetkg));
                        cmd.Parameters.AddWithValue("@tanggal", tanggal);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data demand baru berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tampil_demand();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tampil_demand()
        {
            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM v_demand";

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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

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
