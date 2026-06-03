using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using PROJEKANN.database;

namespace PROJEKANN.Usercontrol
{
    public partial class dashboard_distributor : UserControl
    {
        public dashboard_distributor()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_distributor_Load(object sender, EventArgs e)
        {
            MuatTransaksiTerkini();
        }

        private void MuatTransaksiTerkini()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT *
                        FROM view_dashboard_distributor
                        LIMIT 10;
                    ";

                    using (NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataAdapter da =
                            new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            da.Fill(dt);

                            dgvDashboard.DataSource = dt;

                            dgvDashboard.AutoSizeColumnsMode =
                                DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}