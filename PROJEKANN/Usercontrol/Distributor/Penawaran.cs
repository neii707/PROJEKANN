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
    public partial class Penawaran : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        int idGradeTerpilih = 0;
        public Penawaran()
        {
            InitializeComponent();
        }

        private void Penawaran_Load(object sender, EventArgs e)
        {
            TampilDataPenawaran();
        }

        private void TampilDataPenawaran()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT *
                FROM view_penawaran;
            ";

                    using (NpgsqlDataAdapter da =
                        new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvPenawaran.DataSource = dt;

                        dgvPenawaran.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPenawaran_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idGradeTerpilih =
                    Convert.ToInt32(
                    dgvPenawaran.Rows[e.RowIndex]
                    .Cells["id_grade"].Value
                );
            }
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            try
            {
                if (idGradeTerpilih == 0)
                {
                    MessageBox.Show(
                        "Pilih data terlebih dahulu!"
                    );

                    return;
                }

                if (txtHargaTawar.Text == "")
                {
                    MessageBox.Show(
                        "Harga tawar harus diisi!"
                    );

                    return;
                }

                decimal hargaTawar =
                    Convert.ToDecimal(
                        txtHargaTawar.Text
                    );

                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query =
                    "CALL tambah_penawaran(@harga, @idGrade)";

                    using (NpgsqlCommand cmd =
                        new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@harga",
                            hargaTawar
                        );

                        cmd.Parameters.AddWithValue(
                            "@idGrade",
                            idGradeTerpilih
                        );

                        cmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Penawaran berhasil dikirim!"
                        );

                        txtHargaTawar.Clear();

                        TampilDataPenawaran();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formUtama = this.FindForm() as Form1;

            if (formUtama != null)
            {
                formUtama.TampilkanHalaman(
                    new PROJEKANN.Usercontrol.dashboard_distributor(formUtama, this.userLoginAktif)
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
