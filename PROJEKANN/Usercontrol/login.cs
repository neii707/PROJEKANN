using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private void GantiHalaman(UserControl ucBaru)
        {
            this.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            this.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged_1(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = lblNamaUser.Text.Trim();
            string password = passworduser.Text.Trim();

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
                    string query = "SELECT role_pilihan FROM usser WHERE username = @username AND passwd = @password AND status_konfir_akun = 'Konfirmasi'";

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
                                    dashboard_admin adminDashboard = new dashboard_admin(mainForm, username);
                                    adminDashboard.Dock = DockStyle.Fill;
                                    mainForm.Controls.Add(adminDashboard);
                                    break;

                                case "distributor":
                                    dashboard_distributor distributorDashboard = new dashboard_distributor(mainForm, username);
                                    distributorDashboard.Dock = DockStyle.Fill;
                                    mainForm.Controls.Add(distributorDashboard);
                                    break;

                                case "nelayan":
             
                                    PROJEKANN.Usercontrol.nelayan.DashboardNelayan nelayanDashboard = new PROJEKANN.Usercontrol.nelayan.DashboardNelayan(mainForm, username);
                                    nelayanDashboard.Dock = DockStyle.Fill;

                                    mainForm.Controls.Add(nelayanDashboard);
                                    nelayanDashboard.BringToFront();
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

        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalaman(new PROJEKANN.Usercontrol.register(mainForm));
        }
    }
}