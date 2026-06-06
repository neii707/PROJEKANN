using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

// Disamakan ke subfolder nelayan agar satu ekosistem tanpa error namespace
namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class TransaksiNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif; // Memegang USERNAME user aktif
        private string namaAsliUser = ""; // Memegang NAMA ASLI untuk label di UI

        public TransaksiNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;

            // Definisikan user fallback jika string parameter kosong
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            // Jalankan konverter untuk mencari nama asli di database dan set ke label sidebar
            AmbilDanTampilkanNamaAsli();

            // Tetap muat tabel transaksi aktif menggunakan username
            MuatTabelTransaksiAktif();
        }

        /// <summary>
        /// Mengambil nama asli berdasarkan username login aktif dan menampilkannya ke label sidebar
        /// </summary>
        private void AmbilDanTampilkanNamaAsli()
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
                            this.namaAsliUser = result.ToString();
                        }
                        else
                        {
                            // Fallback jika nama di database ternyata kosong
                            this.namaAsliUser = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                this.namaAsliUser = userLoginAktif;
            }

            // Sinkronisasi teks nama pengguna asli ke label designer Anda
            if (lbnamauser_transaksi != null)
            {
                lbnamauser_transaksi.Text = this.namaAsliUser;
            }
        }

        /// <summary>
        /// Mengambil data transaksi berjalan via View PostgreSQL
        /// </summary>
        private void MuatTabelTransaksiAktif()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();
                    string query = "SELECT id, distributor, berat, total, tanggal, status " +
                                   "FROM view_transaksi_aktif_nelayan WHERE nelayan = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Mengunci dgvtransaksi agar kolom customized di designer Anda tidak terduplikasi otomatis
                            dgvtransaksi.AutoGenerateColumns = false;

                            // Pemetaan eksplisit berdasarkan nama kolom di berkas .Designer.cs Anda
                            colID.DataPropertyName = "id";
                            colDistributor.DataPropertyName = "distributor";
                            colBerat.DataPropertyName = "berat";
                            colTotal.DataPropertyName = "total";
                            colTanggal.DataPropertyName = "tanggal";
                            colStatus.DataPropertyName = "status";

                            dgvtransaksi.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat transaksi aktif: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mengeksekusi perubahan status transaksi menjadi 'selesai' dengan SQL Transaction ACID Guard
        /// </summary>
        private void konfirmasi_transaksi_Click(object sender, EventArgs e)
        {
            // Proteksi jika user belum memilih baris data apa pun di grid view
            if (dgvtransaksi.CurrentRow == null)
            {
                MessageBox.Show("Pilih baris transaksi pada tabel terlebih dahulu sebelum menekan tombol konfirmasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Membaca nilai ID dari kolom sel yang terpilih
            int idTransaksiSelected = Convert.ToInt32(dgvtransaksi.CurrentRow.Cells["colID"].Value);

            DialogResult dr = MessageBox.Show($"Apakah Anda yakin ingin memberikan konfirmasi selesai pada transaksi ID {idTransaksiSelected}?",
                "Konfirmasi Penyelesaian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

                    // MEMULAI TRANSAKSI AMAN (Mencegah data corrupt jika koneksi terputus di tengah jalan)
                    using (NpgsqlTransaction sqlTrans = kon.BeginTransaction())
                    {
                        try
                        {
                            string queryUpdateStatus = @"
                                UPDATE transaksi 
                                SET status_transaksi = 'selesai' 
                                WHERE id_transaksi = @id_transaksi";

                            using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdateStatus, kon, sqlTrans))
                            {
                                cmd.Parameters.AddWithValue("@id_transaksi", idTransaksiSelected);
                                cmd.ExecuteNonQuery();
                            }

                            // Commit data ke server jika berhasil mutlak
                            sqlTrans.Commit();
                            MessageBox.Show($"Transaksi #{idTransaksiSelected} sukses ditutup dan dipindahkan ke riwayat archive.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Muat ulang isi grid data transaksi aktif
                            MuatTabelTransaksiAktif();
                        }
                        catch (Exception ex)
                        {
                            // Batalkan seluruh kodingan update di atas jika terjadi kegagalan sistem
                            sqlTrans.Rollback();
                            MessageBox.Show("Gagal mengonfirmasi transaksi. Perubahan database dibatalkan: " + ex.Message, "Transaction Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // ==========================================
        // ROUTING MENU: PERPINDAHAN USER CONTROL AMAN
        // ==========================================
        private void GantiHalaman(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                // Mencari panel kontainer utama tempat UserControl menempel
                Panel panelInduk = this.Parent as Panel;

                if (panelInduk != null)
                {
                    panelInduk.Controls.Clear();
                    ucBaru.Dock = DockStyle.Fill;
                    panelInduk.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
                    // Fallback jika panel induk tidak terbaca langsung, panggil method Form utama
                    mainForm.TampilkanHalaman(ucBaru);
                }
            }
            catch
            {
                // Fallback terakhir lewat metode default mainForm Anda
                mainForm.TampilkanHalaman(ucBaru);
            }
        }

        private void dashboardbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new NawarPanenNelayan(mainForm, userLoginAktif));
        }

        private void transaksibutton_transaksi_Click(object sender, EventArgs e)
        {
            AmbilDanTampilkanNamaAsli();
            MuatTabelTransaksiAktif();
        }

        private void riwayatbutton_transaksi_Click(object sender, EventArgs e)
        {
            GantiHalaman(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_transaksi_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Apakah anda yakin ingin keluar aplikasi?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (k == DialogResult.Yes)
            {
                // Keluar menuju halaman login di luar folder nelayan
                GantiHalaman(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void paneltransaksi_Paint(object sender, PaintEventArgs e) { }
    }
}