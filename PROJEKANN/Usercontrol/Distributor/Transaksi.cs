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
    
    public partial class Transaksi : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        int idTransaksiTerpilih = 0;
        public Transaksi()
        {
            InitializeComponent();
            TampilDataTransaksi();
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            TampilDataTransaksi();
        }

        private void TampilDataTransaksi()
        {
            try
            {
                using (NpgsqlConnection conn =
                    DBConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT *
                        FROM view_transaksi_distributor;
                    ";

                    using (NpgsqlDataAdapter da =
                        new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvTransaksi.DataSource = dt;

                        dgvTransaksi.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idTransaksiTerpilih =
                    Convert.ToInt32(
                    dgvTransaksi.Rows[e.RowIndex]
                    .Cells["id_transaksi"].Value);
            }
        }

        private void btnKonfirmasi_Click_1(object sender, EventArgs e)
        {
            if (idTransaksiTerpilih == 0)
            {
                MessageBox.Show(
                    "Pilih transaksi dulu!");
                return;
            }

            DialogResult hasil =
                MessageBox.Show(
                    "Konfirmasi pembayaran cash?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo);

            if (hasil == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection conn =
                        DBConnection.GetConnection())
                    {
                        conn.Open();

                        string query = @"
                            UPDATE transaksi
                            SET
                                status_transaksi = 'Selesai',
                                konfir_pembelian = 'Selesai'
                            WHERE id_transaksi = @id;
                        ";

                        using (NpgsqlCommand cmd =
                            new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue(
                                "@id",
                                idTransaksiTerpilih);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show(
                            "Pembayaran berhasil dikonfirmasi!");

                        TampilDataTransaksi();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel1.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel1.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Form1 formUtama = this.FindForm() as Form1;

            if (formUtama != null)
            {
                formUtama.TampilkanHalaman(
                    new PROJEKANN.Usercontrol.dashboard_distributor(formUtama, this.userLoginAktif)
                );
            }
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

        private void btnKeluar_Click(object sender, EventArgs e)
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
    }
}

