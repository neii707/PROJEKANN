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
            MuatAktivitasTerkini();
            labelakun();
            labelstok();
            labeltransaksi();
            this.mainForm = form1;
            this.userLoginAktif = username;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 formUtama = this.FindForm() as Form1;

            if (formUtama != null)
            {
                formUtama.TampilkanHalaman(new PROJEKANN.Usercontrol.dashboard_admin(formUtama, this.userLoginAktif));
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.admin.kelola_akun());
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
    }
}