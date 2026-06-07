using Npgsql;
using PROJEKANN.database;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class dashboard_admin : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        public dashboard_admin(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
            MuatAktivitasTerkini();
            labelakun();
            labelstok();
            labeltransaksi();
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

        private void labelakun()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "select * from v_labelakun";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    object hasil =
                        cmd.ExecuteScalar();

                    label2.Text =
                        cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labelstok()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT * FROM v_labelstok";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    object hasil =
                        cmd.ExecuteScalar();

                    label3.Text =
                        cmd.ExecuteScalar().ToString()
                        + " KG";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void labeltransaksi()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT * FROM v_labeltransaksi";

                    NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn);

                    object hasil =
                        cmd.ExecuteScalar();

                    label4.Text =
                        cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MuatAktivitasTerkini()
        {
            try
            {
                using (NpgsqlConnection conn = PROJEKANN.database.DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            id AS ""ID"", 
                            pengguna AS ""Pengguna"", 
                            aktivitas AS ""Aktivitas"" 
                        FROM v_aktivitas_terkini 
                        LIMIT 10;";

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

        private void aktivitas(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
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
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_admin(this.mainForm, this.userLoginAktif));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_akun(this.mainForm, this.userLoginAktif));
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}