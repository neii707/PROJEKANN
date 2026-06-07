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
        public Penawaran(Form1 form1, string username)
        {
            InitializeComponent();
            TampilkanNamaUser();
            this.mainForm = form1;
            this.userLoginAktif = username;
        }

        private void Penawaran_Load(object sender, EventArgs e)
        {
            TampilDataPenawaran();
            TampilkanNamaUser();
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

        private void btnGrading_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
       new PROJEKANN.Usercontrol.Distributor.Grading(this.mainForm, this.userLoginAktif)
   );
        }

        private void btnPenawaran_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.Penawaran(this.mainForm, this.userLoginAktif)
    );
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.Transaksi(this.mainForm, this.userLoginAktif)
    );
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(
        new PROJEKANN.Usercontrol.Distributor.RiwayatTransaksi(this.mainForm, this.userLoginAktif)
    );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.dashboard_distributor(this.mainForm, this.userLoginAktif));
        }

        private void button3_Click(object sender, EventArgs e)
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
