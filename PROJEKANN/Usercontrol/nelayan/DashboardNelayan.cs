using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class DashboardNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        public DashboardNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            mainForm = form1;

            // Jika kosong, default diganti ke nama asli yang ada di INSERT database kamu (contoh: Seonghyeon)
            userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "Seonghyeon" : usernameLogin;

            MuatSistemDashboardUtama();
        }

        private void MuatSistemDashboardUtama()
        {
            try
            {
                HitungStatistikOtomatis();
                MuatTabelPanenTerbaru();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi masalah saat memuat data dashboard: " + ex.Message, "Sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HitungStatistikOtomatis()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    // Diubah dari username menjadi nama asli user
                    string queryStok = "SELECT total_stok FROM view_stok_nelayan WHERE nama = @nama";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, kon))
                    {
                        cmd.Parameters.AddWithValue("@nama", userLoginAktif);
                        double totalStok = Convert.ToDouble(cmd.ExecuteScalar() ?? 0);
                        stoklabel_dashboard.Text = totalStok.ToString("N1") + " kg";
                    }

                    string queryPenawaran = "SELECT total_penawaran FROM view_penawaran_nelayan WHERE nama = @nama";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenawaran, kon))
                    {
                        cmd.Parameters.AddWithValue("@nama", userLoginAktif);
                        int totalPenawaran = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        penawaranlabel_dashboard.Text = totalPenawaran.ToString() + " Berkas";
                    }

                    string queryPenjualan = "SELECT total_penjualan FROM view_total_penjualan_nelayan WHERE nama = @nama";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenjualan, kon))
                    {
                        cmd.Parameters.AddWithValue("@nama", userLoginAktif);
                        decimal totalDuit = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                        penjualanlabel_dashboard.Text = "Rp " + totalDuit.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat statistik database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MuatTabelPanenTerbaru()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    // Filter WHERE diganti ke kolom nama_nelayan
                    string queryTabel = "SELECT id_asli, distributor, aktivitas, tanggal, status_asli, nama_lengkap " +
                                       "FROM view_dashboard_nelayan " +
                                       "WHERE nama_nelayan = @nama " +
                                       "LIMIT 5";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                    {
                        cmd.Parameters.AddWithValue("@nama", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                lbnamauser_dashboard.Text = dt.Rows[0]["nama_lengkap"].ToString();
                            }
                            else
                            {
                                lbnamauser_dashboard.Text = userLoginAktif;
                            }

                            DataTable dtBersih = new DataTable();
                            dtBersih.Columns.Add("ID");
                            dtBersih.Columns.Add("Grade");
                            dtBersih.Columns.Add("Berat (kg)");
                            dtBersih.Columns.Add("Tanggal");
                            dtBersih.Columns.Add("Status");

                            foreach (DataRow row in dt.Rows)
                            {
                                string teksAktivitas = row["aktivitas"].ToString();
                                string berat = "";
                                string grade = "";

                                if (teksAktivitas.Contains("Kg") && teksAktivitas.Contains("Grade"))
                                {
                                    int indexKg = teksAktivitas.IndexOf("Kg");
                                    berat = teksAktivitas.Substring(0, indexKg).Trim() + " kg";

                                    int indexGrade = teksAktivitas.IndexOf("Grade") + 5;
                                    int indexStrip = teksAktivitas.IndexOf("-", indexGrade);

                                    if (indexStrip > indexGrade)
                                    {
                                        grade = teksAktivitas.Substring(indexGrade, indexStrip - indexGrade).Trim();
                                    }
                                    else
                                    {
                                        grade = teksAktivitas.Substring(indexGrade).Trim();
                                    }
                                }
                                else
                                {
                                    berat = teksAktivitas;
                                }

                                string tglFormated = "";
                                if (row["tanggal"] != DBNull.Value)
                                {
                                    if (row["tanggal"] is DateTime dtValue)
                                    {
                                        tglFormated = dtValue.ToString("dd/MM/yyyy");
                                    }
                                    else
                                    {
                                        string rawTanggal = row["tanggal"].ToString();
                                        if (rawTanggal.Contains(" "))
                                        {
                                            rawTanggal = rawTanggal.Split(' ')[0];
                                        }
                                        tglFormated = rawTanggal;
                                    }
                                }

                                dtBersih.Rows.Add(
                                    row["id_asli"].ToString(),
                                    grade,
                                    berat,
                                    tglFormated,
                                    row["status_asli"].ToString()
                                );
                            }

                            dgvDashboard.AutoGenerateColumns = false;

                            dgvDashboard.Columns[0].DataPropertyName = "ID";
                            dgvDashboard.Columns[1].DataPropertyName = "Grade";
                            dgvDashboard.Columns[2].DataPropertyName = "Berat (kg)";
                            dgvDashboard.Columns[3].DataPropertyName = "Tanggal";
                            dgvDashboard.Columns[4].DataPropertyName = "Status";

                            dgvDashboard.DataSource = dtBersih;
                            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tabel aktivitas terbaru: " + ex.Message, "Error Tabel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            panel2.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            panel2.Controls.Add(ucBaru);
            ucBaru.BringToFront();
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            panel2.Controls.Add(lbnamauser_dashboard);
            panel2.Controls.Add(keluarbutton_dashboard);
            panel2.Controls.Add(panenlabel_dashboard);
            panel2.Controls.Add(dgvDashboard);
            panel2.Controls.Add(penjualanlabel_dashboard);
            panel2.Controls.Add(stoklabel_dashboard);
            panel2.Controls.Add(penawaranlabel_dashboard);
            panel2.Controls.Add(namauserlabel_dashboard);
            panel2.Controls.Add(riwayatbutton_dashboard);
            panel2.Controls.Add(transaksibutton_dashboard);
            panel2.Controls.Add(penawaranbutton_dashboard);
            panel2.Controls.Add(inputpanenbutton_dashboard);
            panel2.Controls.Add(dashboardbutton);

            MuatSistemDashboardUtama();
        }

        private void inputpanenbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.KelolaPanenNelayan());
        }

        private void penawaranbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.NawarPanenNelayan());
        }

        private void transaksibutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.TransaksiNelayan());
        }

        private void riwayatbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.RiwayatNelayan());
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                mainForm.TampilkanHalaman(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void stoklabel_dashboard_Click(object sender, EventArgs e)
        {
        }

        private void penawaranlabel_dashboard_Click(object sender, EventArgs e)
        {
        }
    }
}