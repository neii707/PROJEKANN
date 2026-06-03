using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class DashboardNelayan : UserControl
    {
        public DashboardNelayan()
        {
            InitializeComponent();

            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                LoadDemandTerbaru();
                LoadDataPanen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat dashboard : " + ex.Message);
            }
        }

        private void LoadDemandTerbaru()
        {
            using (NpgsqlConnection conn =
                PROJEKANN.database.DBConnection.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT target_kg, deadline
                    FROM demand
                    ORDER BY id_demand DESC
                    LIMIT 1";

                using (NpgsqlCommand cmd =
                    new NpgsqlCommand(query, conn))
                {
                    using (NpgsqlDataReader dr =
                        cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            labeldemand_dashboard.Text =
                                "Target : "
                                + dr["target_kg"].ToString()
                                + " Kg | Deadline : "
                                + Convert.ToDateTime(
                                    dr["deadline"])
                                .ToString("dd/MM/yyyy");
                        }
                    }
                }
            }
        }

        private void LoadDataPanen()
        {
            // Isi nanti setelah tahu nama DataGridView
        }

        private void inputpanenbutton_dashboard_Click(object sender, EventArgs e)
        {
            // pindah ke kelola panen
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            // sudah berada di dashboard
        }

        private void penawaranbutton_dashboard_Click(object sender, EventArgs e)
        {
            // pindah ke penawaran
        }

        private void transaksibutton_dashboard_Click(object sender, EventArgs e)
        {
            // pindah ke transaksi
        }

        private void riwayatbutton_dashboard_Click(object sender, EventArgs e)
        {
            // pindah ke riwayat
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void labeldemand_dashboard_Click(object sender, EventArgs e)
        {

        }
    }
}