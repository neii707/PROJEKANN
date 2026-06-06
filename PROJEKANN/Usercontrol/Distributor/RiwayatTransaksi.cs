using Npgsql;
using PROJEKANN.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class RiwayatTransaksi : UserControl
    {
        public RiwayatTransaksi()
        {
            InitializeComponent();
            TampilRiwayat();
            HitungStatistik();
        }

        private void TampilRiwayat()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT *
                FROM view_riwayat_transaksi;
            ";

                    using (NpgsqlDataAdapter da =
                        new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvRiwayat.DataSource = dt;

                        dgvRiwayat.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;

                        dgvRiwayat.Columns["harga_tawar"].DefaultCellStyle.Format = "N0";

                        dgvRiwayat.Columns["total_pembayaran"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HitungStatistik()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string queryJumlah = @"
                SELECT COUNT(*)
                FROM transaksi
                WHERE status_transaksi = 'Selesai';
            ";

                    using (NpgsqlCommand cmdJumlah =
                        new NpgsqlCommand(queryJumlah, conn))
                    {
                        lblSelesai.Text =
                            cmdJumlah.ExecuteScalar().ToString();
                    }

                    string queryTotal = @"
                SELECT COALESCE(
                    SUM(total_pembayaran), 0
                )
                FROM transaksi
                WHERE status_transaksi = 'Selesai';
            ";

                    using (NpgsqlCommand cmdTotal =
                        new NpgsqlCommand(queryTotal, conn))
                    {
                        decimal total =
                        Convert.ToDecimal(
                        cmdTotal.ExecuteScalar()
                         );

                        lblTotal.Text =
                            "Rp " +
                            total.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void btnPanen_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.lihat_panen()
    );
        }

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
       new PROJEKANN.Usercontrol.Distributor.Grading()
   );
        }

        private void btnPenawaran_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.Penawaran()
    );
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.Transaksi()
    );
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi()
    );
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
