using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class dashboard_admin : UserControl
    {
        public dashboard_admin()
        {
            InitializeComponent();
            MuatAktivitasTerkini();
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
            MuatAktivitasTerkini();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formUtama = this.FindForm() as Form1;

            if (formUtama != null)
            {
                MessageBox.Show("Form ketemu");

                var halaman = new PROJEKANN.Usercontrol.admin.kelola_akun();

                MessageBox.Show("UserControl berhasil dibuat");

                formUtama.TampilkanHalaman(halaman);

                MessageBox.Show("TampilkanHalaman selesai");
            }
        }
    }
}