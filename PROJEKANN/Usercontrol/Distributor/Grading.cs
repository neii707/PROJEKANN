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
    public partial class Grading : UserControl
    {
        int idPanenTerpilih = 0;
        public Grading()
        {
            InitializeComponent();
        }

        private void TampilDataPanen()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT *
                FROM view_grading_panen;
            ";

                    using (NpgsqlDataAdapter da =
                        new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvGrading.DataSource = dt;

                        dgvGrading.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grading_Load(object sender, EventArgs e)
        {
            TampilDataPanen();
        }

        private void btnTetapkan_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPanenTerpilih == 0)
                {
                    MessageBox.Show(
                        "Pilih data panen terlebih dahulu!"
                    );

                    return;
                }

                if (cbGrade.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Pilih grade terlebih dahulu!"
                    );

                    return;
                }

                string gradeDipilih =
                    cbGrade.SelectedItem.ToString();

                string keterangan =
                    txtKeterangan.Text;

                decimal harga = 0;

                if (gradeDipilih == "A")
                {
                    harga = 18000;
                }
                else if (gradeDipilih == "B")
                {
                    harga = 13000;
                }
                else
                {
                    harga = 5000;
                }

                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
        INSERT INTO grade
        (
            kategori,
            keterangan,
            harga_per_kg,
            id_panen,
            id_demand,
            id_distributor
        )
        VALUES
        (
            @kategori,
            @keterangan,
            @harga,
            @idPanen,
            1,
            2
        );
    ";

                    using (NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@kategori",
                            gradeDipilih
                        );

                        cmd.Parameters.AddWithValue(
                            "@keterangan",
                            keterangan
                        );

                        cmd.Parameters.AddWithValue(
                            "@harga",
                            harga
                        );

                        cmd.Parameters.AddWithValue(
                            "@idPanen",
                            idPanenTerpilih
                        );

                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Grade berhasil ditetapkan!"
                        );

                        cbGrade.SelectedIndex = -1;
                        txtKeterangan.Clear();

                        TampilDataPanen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal grading : " + ex.Message
                );
            }
        }

        private void dgvGrading_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idPanenTerpilih = Convert.ToInt32(
                    dgvGrading.Rows[e.RowIndex]
                    .Cells["id_panen"].Value
                );
            }
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Grading_Load_1(object sender, EventArgs e)
        {
            TampilDataPanen();

            cbGrade.Items.Add("A");
            cbGrade.Items.Add("B");
            cbGrade.Items.Add("C");
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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor());
        }

        private void btnPanen_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen());
        }

        private void btnGrading_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading());
        }

        private void btnPenawaran_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran());
        }

        private void btnTransaksi_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi());
        }

        private void btnRiwayat_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi());
        }
    }
}
