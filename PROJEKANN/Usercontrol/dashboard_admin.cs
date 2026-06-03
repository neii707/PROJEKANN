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
                            'NEL0' || p.id_panen AS ""ID"", 
                            u.nama AS ""Pengguna"", 
                            'Input Panen (' || p.berat_per_kg || ' Kg)' AS ""Aktivitas""
                        FROM panen p
                        JOIN usser u ON p.id_user = u.id_user
                        
                        UNION ALL
                        
                        SELECT 
                            'DIS0' || d.id_demand AS ""ID"", 
                            u.nama AS ""Pengguna"", 
                            'Minta Demand (' || d.target_kg || ' Kg)' AS ""Aktivitas""
                        FROM demand d
                        JOIN usser u ON d.id_user = u.id_user
                        
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
                MessageBox.Show("Gagal memuat aktivitas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aktivitas(object sender, DataGridViewCellEventArgs e)
        {
            MuatAktivitasTerkini();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MuatAktivitasTerkini();
        }
    }
}