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
        public Transaksi(Form1 form1, string username)
        {
            InitializeComponent();
            TampilDataTransaksi();
            TampilkanNamaUser();
        }

        private void Transaksi_Load(object sender, EventArgs e)
        {
            TampilDataTransaksi();
            TampilkanNamaUser();
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
                            lblNamaUser.Text = result.ToString();
                        }
                        else
                        {
                            lblNamaUser.Text = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                lblNamaUser.Text = userLoginAktif;
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
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void btnPanen_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.lihat_panen(this.mainForm, this.userLoginAktif));
        }

        private void btnGrading_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Grading(this.mainForm, this.userLoginAktif));
        }

        private void btnPenawaran_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Penawaran(this.mainForm, this.userLoginAktif));
        }

        private void btnTransaksi_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.Transaksi(this.mainForm, this.userLoginAktif));
        }

        private void btnRiwayat_Click_1(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi(this.mainForm, this.userLoginAktif));
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

