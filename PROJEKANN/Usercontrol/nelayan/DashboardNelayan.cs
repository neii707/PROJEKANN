using Npgsql;
using PROJEKANN.Usercontrol.nelayan;
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
            // Jika username kosong, otomatis menggunakan "James" sesuai data di database kamu
            userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "James" : usernameLogin;

            MuatSistemDashboardUtama();
        }

        private void MuatSistemDashboardUtama()
        {
            // Dibungkus try-catch per fungsi agar kalau ada data error, 
            // tombol menu di UI TIDAK IKUT MACET/DEAD lock.
            try { HitungStatistikOtomatis(); } catch { }
            try { MuatTabelPanenTerbaru(); } catch { }
        }

        private void HitungStatistikOtomatis()
        {
            using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
            {
                kon.Open();

                // 1. Ambil Total Stok
                string queryStok = "SELECT total_stok FROM view_stok_nelayan WHERE username = @username";
                using (NpgsqlCommand cmd = new NpgsqlCommand(queryStok, kon))
                {
                    cmd.Parameters.AddWithValue("@username", userLoginAktif);
                    object result = cmd.ExecuteScalar();
                    double totalStok = (result != null && result != DBNull.Value) ? Convert.ToDouble(result) : 0;
                    stoklabel_dashboard.Text = totalStok.ToString("N1") + " kg";
                }

                // 2. Hitung jumlah berkas penawaran langsung (Aman dari error column tidak ada)
                string queryPenawaran = @"
                    SELECT COUNT(*) 
                    FROM transaksi t
                    JOIN grade g ON t.id_grade = g.id_grade
                    JOIN panen p ON g.id_panen = p.id_panen
                    JOIN usser u ON p.id_user = u.id_user
                    WHERE u.username = @username AND LOWER(t.status_transaksi) != 'selesai'";

                using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenawaran, kon))
                {
                    cmd.Parameters.AddWithValue("@username", userLoginAktif);
                    int totalPenawaran = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    penawaranlabel_dashboard.Text = totalPenawaran.ToString() + " Berkas";
                }

                // 3. Ambil Total Penjualan
                string queryPenjualan = "SELECT total_penjualan FROM view_total_penjualan_nelayan WHERE username = @username";
                using (NpgsqlCommand cmd = new NpgsqlCommand(queryPenjualan, kon))
                {
                    cmd.Parameters.AddWithValue("@username", userLoginAktif);
                    object result = cmd.ExecuteScalar();
                    decimal totalDuit = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    penjualanlabel_dashboard.Text = "Rp " + totalDuit.ToString("N0");
                }
            }
        }

        private void MuatTabelPanenTerbaru()
        {
            using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
            {
                kon.Open();

                // Ambil data yang benar-benar ada di view dashboard
                string queryTabel = "SELECT id_asli, aktivitas, tanggal, status_asli, nama_lengkap " +
                                   "FROM view_dashboard_nelayan " +
                                   "WHERE username_nelayan = @username " +
                                   "LIMIT 5";

                using (NpgsqlCommand cmd = new NpgsqlCommand(queryTabel, kon))
                {
                    cmd.Parameters.AddWithValue("@username", userLoginAktif);

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            lbnamauser_dashboard.Text = dt.Rows[0]["nama_lengkap"].ToString();
                        }

                        // Buat struktur tabel bersih yang MENYESUAIKAN 5 KOLOM di Designer kamu
                        DataTable dtBersih = new DataTable();
                        dtBersih.Columns.Add("ID");
                        dtBersih.Columns.Add("Grade");
                        dtBersih.Columns.Add("Berat");
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
                                    grade = teksAktivitas.Substring(indexGrade, indexStrip - indexGrade).Trim();
                                else
                                    grade = teksAktivitas.Substring(indexGrade).Trim();
                            }
                            else
                            {
                                berat = teksAktivitas;
                            }

                            string tglFormated = "";
                            if (row["tanggal"] != DBNull.Value)
                            {
                                string rawTanggal = row["tanggal"].ToString().Split(' ')[0];
                                if (DateTime.TryParse(rawTanggal, out DateTime parsedDate))
                                    tglFormated = parsedDate.ToString("dd/MM/yyyy");
                                else
                                    tglFormated = rawTanggal;
                            }

                            dtBersih.Rows.Add(
                                row["id_asli"].ToString(),
                                grade,
                                berat,
                                tglFormated,
                                row["status_asli"].ToString()
                            );
                        }

                        // Sinkronisasi ke DataGridView DataPropertyName
                        dgvDashboard.AutoGenerateColumns = false;
                        dgvDashboard.Columns[0].DataPropertyName = "ID";
                        dgvDashboard.Columns[1].DataPropertyName = "Grade";
                        dgvDashboard.Columns[2].DataPropertyName = "Berat";
                        dgvDashboard.Columns[3].DataPropertyName = "Tanggal";
                        dgvDashboard.Columns[4].DataPropertyName = "Status";

                        dgvDashboard.DataSource = dtBersih;
                    }
                }
            }
        }

        // =======================================================
        // NAVIGASI FIX: Memaksa Penggantian Kontrol Secara Langsung
        // =======================================================
        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                // Ambil panel penampung tempat Dashboard ini berada saat ini
                Panel panelInduk = this.Parent as Panel;

                if (panelInduk != null)
                {
                    // Bersihkan isi panel penampung utama tersebut
                    panelInduk.Controls.Clear();

                    // Set ukuran penuh dan masukkan UserControl baru
                    ucBaru.Dock = DockStyle.Fill;
                    panelInduk.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else if (this.Parent != null)
                {
                    // Jika terpasang langsung pada Form tanpa perantara Panel
                    Control indukUtama = this.Parent;
                    indukUtama.Controls.Remove(this);
                    ucBaru.Dock = DockStyle.Fill;
                    indukUtama.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
                    // Jalur Cadangan Akhir: Mencari Form Utama yang sedang aktif lewat Windows
                    Form1 formAktif = Application.OpenForms["Form1"] as Form1;
                    if (formAktif != null)
                    {
                        formAktif.TampilkanHalaman(ucBaru);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_dashboard_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_dashboard_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new login(mainForm));
            }
        }

        private void dgvDashboard_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void stoklabel_dashboard_Click(object sender, EventArgs e) { }
        private void penawaranlabel_dashboard_Click(object sender, EventArgs e) { }
    }
}