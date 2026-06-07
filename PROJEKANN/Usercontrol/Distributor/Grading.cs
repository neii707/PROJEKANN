using Npgsql;
using PROJEKANN.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJEKANN.Usercontrol.Distributor
{
    public partial class Grading : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        int idPanenTerpilih = 0;
        public Grading(Form1 form1, string username)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = username;
            TampilkanNamaUser();
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

            TampilkanNamaUser();

            cbGrade.Items.Clear();

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
        new PROJEKANN.Usercontrol.Distributor.lihat_panen(this.mainForm, this.userLoginAktif)
    );
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
