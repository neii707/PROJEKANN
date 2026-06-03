using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class login : UserControl
    {
        private Form1 mainForm;

        public login(Form1 form1)
        {
            InitializeComponent();
            mainForm = form1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox3.Text.Trim();
            string password = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT role_pilihan FROM usser WHERE username = @username AND passwd = @password";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString().ToLower();
                            MessageBox.Show("Login Berhasil! Role Anda: " + role, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            mainForm.Controls.Clear();

                            switch (role)
                            {
                                case "admin":
                                    dashboard_admin adminDashboard = new dashboard_admin();
                                    adminDashboard.Dock = DockStyle.Fill;
                                    mainForm.Controls.Add(adminDashboard);
                                    break;

                                case "distributor":
                                    dashboard_distributor distributorDashboard = new dashboard_distributor();
                                    distributorDashboard.Dock = DockStyle.Fill;
                                    mainForm.Controls.Add(distributorDashboard);
                                    break;

                                case "nelayan":
                                    dashboard_nelayan nelayanDashboard = new dashboard_nelayan();
                                    nelayanDashboard.Dock = DockStyle.Fill;
                                    mainForm.Controls.Add(nelayanDashboard);
                                    break;

                                default:
                                    MessageBox.Show("Role tidak dikenali!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username atau Password salah!", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan koneksi database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}