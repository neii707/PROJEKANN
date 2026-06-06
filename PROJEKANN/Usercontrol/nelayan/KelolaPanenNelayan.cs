using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class KelolaPanenNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;

        // Constructor menerima Form1 dan Session Username dari Dashboard
        public KelolaPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;

            // Mengamankan username login agar tidak kosong saat dimuat
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "Natachai" : usernameLogin;

            // Menampilkan nama user aktif pada label pojok kiri atas
            lbnamauser_kelola.Text = this.userLoginAktif;

            // Inisialisasi nilai awal komponen input
            numBerat.Value = 0;
            dtptanggalpanen.Value = DateTime.Now;

            MuatTabelPanenSaya();
        }

        /// <summary>
        /// Mengambil data riwayat panen nelayan dan memasukkannya ke DataGridView
        /// </summary>
        private void MuatTabelPanenSaya()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();
                    // Query mengambil view yang memfilter berdasarkan username nelayan aktif
                    string query = "SELECT id, berat, grade, harga_per_kg, status FROM view_riwayat_panen_nelayan WHERE username_nelayan = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Matikan auto-generate agar struktur desainer yang kamu buat tidak berantakan
                            dgvriwayatpanen.AutoGenerateColumns = false;

                            // Memetakan DataPropertyName ke kolom-kolom yang sudah kamu deklarasikan di designer
                            colID.DataPropertyName = "id";
                            colBerat.DataPropertyName = "berat";
                            colGrade.DataPropertyName = "grade";
                            colHarga.DataPropertyName = "harga_per_kg";
                            colStatus.DataPropertyName = "status";

                            // Mengikat data table ke DataGridView
                            dgvriwayatpanen.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat riwayat panen: " + ex.Message, "Error Tabel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // LOGIKATOMBOL: SIMPAN & HAPUS DATA PANEN
        // ==========================================

        private void simpanpanen_kelola_Click(object sender, EventArgs e)
        {
            double beratInput = Convert.ToDouble(numBerat.Value);
            DateTime tanggalInput = dtptanggalpanen.Value;

            // Validasi input berat
            if (beratInput <= 0)
            {
                MessageBox.Show("Silakan masukkan berat panen yang valid (lebih dari 0 kg)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    // 1. Dapatkan id_user dari tabel usser berdasarkan username login
                    int idUser = 0;
                    string queryUser = "SELECT id_user FROM usser WHERE username = @username LIMIT 1";
                    using (NpgsqlCommand cmdUser = new NpgsqlCommand(queryUser, kon))
                    {
                        cmdUser.Parameters.AddWithValue("@username", userLoginAktif);
                        idUser = Convert.ToInt32(cmdUser.ExecuteScalar() ?? 0);
                    }

                    if (idUser == 0)
                    {
                        MessageBox.Show("Sesi user tidak ditemukan di database. Silakan login kembali.", "Error Profil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Lakukan Insert data ke tabel panen asli
                    string queryInsert = "INSERT INTO panen (id_user, berat_per_kg, tanggal_panen) VALUES (@id_user, @berat, @tanggal)";
                    using (NpgsqlCommand cmdInsert = new NpgsqlCommand(queryInsert, kon))
                    {
                        cmdInsert.Parameters.AddWithValue("@id_user", idUser);
                        cmdInsert.Parameters.AddWithValue("@berat", beratInput);
                        cmdInsert.Parameters.AddWithValue("@tanggal", tanggalInput);

                        cmdInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data panen berhasil ditambahkan! Menunggu proses grading dari distributor.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form input dan segarkan isi tabel
                    numBerat.Value = 0;
                    MuatTabelPanenSaya();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data panen: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hapuspanen_kelola_Click(object sender, EventArgs e)
        {
            // Validasi baris data yang ditunjuk
            if (dgvriwayatpanen.CurrentRow == null)
            {
                MessageBox.Show("Silakan pilih salah satu data panen pada tabel di bawah terlebih dahulu untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengambil ID panen dari baris terpilih pada kolom colID
            string idPanenTerpilih = dgvriwayatpanen.CurrentRow.Cells["colID"].Value.ToString();

            DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin menghapus data panen dengan ID {idPanenTerpilih}?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                    {
                        kon.Open();
                        // Proteksi SQL: Data tidak bisa dihapus jika relasi ID sudah masuk ke tabel grading distributor
                        string queryHapus = "DELETE FROM panen WHERE id_panen = @id AND id_panen NOT IN (SELECT id_panen FROM grade)";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryHapus, kon))
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idPanenTerpilih));
                            int hasilEksekusi = cmd.ExecuteNonQuery();

                            if (hasilEksekusi > 0)
                            {
                                MessageBox.Show("Data panen sukses dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Gagal menghapus! Data ini sudah dinilai/di-grade oleh distributor dan terkunci.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    // Refresh isi DataGridView
                    MuatTabelPanenSaya();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi error sistem saat menghapus data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==========================================
        // SIDEBAR MENUS: NAVIGASI MULTI-USERCONTROL
        // ==========================================

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            mainForm.TampilkanHalaman(ucBaru);
        }

        private void dashboardbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_kelola_Click(object sender, EventArgs e)
        {
            // Karena ini halaman ini sendiri, panggil refresh tabel saja
            MuatTabelPanenSaya();
        }

        private void penawaranbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_kelola_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                mainForm.TampilkanHalaman(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }
    }
}