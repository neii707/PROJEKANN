using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class KelolaPanenNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private string namaAsliUser = "";
        private int idPanenTerpilih = 0;

        // Konstruktor Utama
        public KelolaPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            TampilkanNamaAsliUser();
            MuatTabelPanenSaya();
        }

        private void TampilkanNamaAsliUser()
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
                            lbnamauser_kelola.Text = result.ToString();
                            this.namaAsliUser = result.ToString();
                        }
                        else
                        {
                            lbnamauser_kelola.Text = userLoginAktif;
                            this.namaAsliUser = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                lbnamauser_kelola.Text = userLoginAktif;
                this.namaAsliUser = userLoginAktif;
            }
        }

        private void MuatTabelPanenSaya()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    string query = @"SELECT 
                    p.id_panen AS id, 
                    p.berat_per_kg AS berat, 
                    COALESCE(g.kategori, '-') AS grade, 
                    COALESCE(g.harga_per_kg, 0) AS harga_per_kg,
                    CASE 
                        WHEN g.id_grade IS NULL THEN 'menunggu grading' 
                        ELSE 'sudah digrading'
                    END AS status
                 FROM panen p
                 INNER JOIN usser u ON p.id_user = u.id_user
                 LEFT JOIN grade g ON p.id_panen = g.id_panen
                 WHERE u.username = @username 
                 ORDER BY p.id_panen DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvriwayatpanen.AutoGenerateColumns = false;

                            colID.DataPropertyName = "id";
                            colBerat.DataPropertyName = "berat";
                            colGrade.DataPropertyName = "grade";
                            colHarga.DataPropertyName = "harga_per_kg";
                            colStatus.DataPropertyName = "status";

                            dgvriwayatpanen.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem gagal memuat riwayat panen ke tabel: " + ex.Message, "Error Tabel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Disesuaikan dengan nama komponen di desainer Anda yang dilaporkan error
        private void simpanpanen_kelola_Click(object sender, EventArgs e)
        {
            double beratInput = Convert.ToDouble(numBerat.Value);
            DateTime tanggalInput = dtptanggalpanen.Value;

            if (beratInput <= 0)
            {
                MessageBox.Show("Silakan masukkan berat panen yang valid!", "Peringatan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    int idUser = 0;
                    string queryUser = "SELECT id_user FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmdUser = new NpgsqlCommand(queryUser, kon))
                    {
                        cmdUser.Parameters.AddWithValue("@username", userLoginAktif);
                        idUser = Convert.ToInt32(cmdUser.ExecuteScalar() ?? 0);
                    }

                    if (idUser == 0)
                    {
                        MessageBox.Show("Sesi user Anda tidak valid.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (idPanenTerpilih == 0)
                    {
                        string queryInsert = "INSERT INTO panen (id_user, berat_per_kg, tanggal) VALUES (@id_user, @berat, @tanggal)";
                        using (NpgsqlCommand cmdInsert = new NpgsqlCommand(queryInsert, kon))
                        {
                            cmdInsert.Parameters.AddWithValue("@id_user", idUser);
                            cmdInsert.Parameters.AddWithValue("@berat", beratInput);
                            cmdInsert.Parameters.AddWithValue("@tanggal", tanggalInput);
                            cmdInsert.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data panen berhasil ditambahkan!", "Sukses Menyimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string queryUpdate = "UPDATE panen SET berat_per_kg = @berat, tanggal = @tanggal WHERE id_panen = @id";
                        using (NpgsqlCommand cmdUpdate = new NpgsqlCommand(queryUpdate, kon))
                        {
                            cmdUpdate.Parameters.AddWithValue("@berat", beratInput);
                            cmdUpdate.Parameters.AddWithValue("@tanggal", tanggalInput);
                            cmdUpdate.Parameters.AddWithValue("@id", idPanenTerpilih);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        MessageBox.Show("Perubahan data panen berhasil diperbarui!", "Sukses Diperbarui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    numBerat.Value = 0;
                    idPanenTerpilih = 0;
                    simpanpanen_kelola.Text = "simpan";

                    MuatTabelPanenSaya();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kendala saat memproses database: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hapuspanen_kelola_Click(object sender, EventArgs e)
        {
            if (dgvriwayatpanen.CurrentRow == null) return;

            // 1. Ambil status panen dari baris DataGridView yang sedang ditunjuk
            string statusPanen = dgvriwayatpanen.CurrentRow.Cells["colStatus"].Value.ToString().ToLower();

            // 2. Validasi: Hanya boleh dihapus jika statusnya masih 'menunggu grading'
            if (statusPanen == "menunggu grading")
            {
                string idPanenTerpilihText = dgvriwayatpanen.CurrentRow.Cells["colID"].Value.ToString();
                DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin menghapus data panen dengan ID {idPanenTerpilihText}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (konfirmasi == DialogResult.Yes)
                {
                    try
                    {
                        using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                        {
                            kon.Open();
                            string queryHapus = "DELETE FROM panen WHERE id_panen = @id AND id_panen NOT IN (SELECT id_panen FROM grade)";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(queryHapus, kon))
                            {
                                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idPanenTerpilihText));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MuatTabelPanenSaya();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memproses penghapusan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Jika statusnya selain 'menunggu grading' (Berarti sudah berstatus 'Telah Dinilai' / masuk ke proses penawaran)
                MessageBox.Show("Data tidak bisa dihapus karena sudah di-grade atau diproses oleh distributor!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        

        private void dgvriwayatpanen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvriwayatpanen.CurrentRow != null)
            {
                try
                {
                    DataGridViewRow row = dgvriwayatpanen.Rows[e.RowIndex];
                    if (row.Cells["colID"].Value != null && row.Cells["colID"].Value != DBNull.Value)
                    {
                        idPanenTerpilih = Convert.ToInt32(row.Cells["colID"].Value);

                        if (decimal.TryParse(row.Cells["colBerat"].Value.ToString(), out decimal berat))
                        {
                            numBerat.Value = berat;
                        }

                        simpanpanen_kelola.Text = "Ubah Data";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal mengambil data baris: " + ex.Message, "Error Seleksi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Ganti(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                Panel indukPanel = this.Parent as Panel;
                if (indukPanel != null)
                {
                    indukPanel.Controls.Clear();
                    ucBaru.Dock = DockStyle.Fill;
                    indukPanel.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
                    if (kelolapanenpanel != null)
                    {
                        kelolapanenpanel.Controls.Clear();
                        ucBaru.Dock = DockStyle.Fill;
                        kelolapanenpanel.Controls.Add(ucBaru);
                        ucBaru.BringToFront();
                    }
                    else
                    {
                        mainForm.TampilkanHalaman(ucBaru);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal berpindah halaman: " + ex.Message, "Sistem Navigasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // EVENT NAVIGATION BUTTONS (SINKRON & VALID)
        // ==========================================
        private void dashboardbutton_kelola_Click(object sender, EventArgs e)
        {
            // Diperbaiki agar kembali ke DashboardNelayan
            Ganti(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_kelola_Click(object sender, EventArgs e)
        {
            MuatTabelPanenSaya();
        }

        private void penawaranbutton_kelola_Click(object sender, EventArgs e)
        {
            // Diaktifkan dan diarahkan ke halaman penawaran nelayan yang benar
            Ganti(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_kelola_Click(object sender, EventArgs e)
        {
            // Diluruskan ke TransaksiNelayan (bukan ke halaman admin)
            Ganti(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_kelola_Click(object sender, EventArgs e)
        {
            Ganti(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_kelola_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Logout Sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                Ganti(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void dgvriwayatpanen_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}