using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace PROJEKANN.Usercontrol
{
    public partial class NawarPanenNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private int idTransaksiTerpilih = 0;

        public NawarPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "Natachai" : usernameLogin;

            // Menyesuaikan komponen label user dari file designer kamu
            if (lbnamauser_dashboard != null) lbnamauser_dashboard.Text = this.userLoginAktif;

            MuatTabelPenawaran();
            HubungkanEventGrid();
        }

        private void MuatTabelPenawaran()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();
                    // Mengambil data dari Complex View terpisah yang ada di pgAdmin
                    string query = "SELECT id, distributor, berat, grade, harga_per_kg, estimasi_total, tanggal, status, id_transaksi " +
                                   "FROM view_penawaran_nelayan WHERE username_nelayan = @username";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Menggunakan dgvpenawaran (huruf kecil) sesuai file designer kamu
                            dgvpenawaran.AutoGenerateColumns = false;

                            // Pemetaan eksplisit ke objek kolom designer kamu
                            colID.DataPropertyName = "id";
                            colDistributor.DataPropertyName = "distributor";
                            colBerat.DataPropertyName = "berat";
                            colGrade.DataPropertyName = "grade";
                            colHarga.DataPropertyName = "harga_per_kg";
                            colEstimasi.DataPropertyName = "estimasi_total";
                            colTanggal.DataPropertyName = "tanggal";
                            colStatus.DataPropertyName = "status";

                            dgvpenawaran.DataSource = dt;
                        }
                    }
                }
                idTransaksiTerpilih = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data penawaran kompleks: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HubungkanEventGrid()
        {
            // Mengaitkan event klik baris pada dgvpenawaran
            dgvpenawaran.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && dgvpenawaran.CurrentRow != null)
                {
                    DataRowView row = (DataRowView)dgvpenawaran.Rows[e.RowIndex].DataBoundItem;
                    if (row != null)
                    {
                        // Mengambil id_transaksi hidden untuk dieksekusi oleh query transaction
                        idTransaksiTerpilih = Convert.ToInt32(row["id_transaksi"]);
                    }
                }
            };
        }

        // ========================================================
        // ADVANCED IMPLEMENTATION: EXPLICIT TRANSACTION PROCESSING
        // ========================================================

        private void terima_nawar_Click(object sender, EventArgs e)
        {
            if (idTransaksiTerpilih == 0)
            {
                MessageBox.Show("Silakan pilih baris penawaran pada tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
            {
                kon.Open();

                // Pamer materi kuliah: Explicit Transaction dengan tingkat isolasi data tertinggi (ReadCommitted/Serializable)
                using (NpgsqlTransaction sqlTransaction = kon.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        // Perintah ini otomatis memicu Trigger BEFORE UPDATE 'trg_log_status_transaksi' di pgAdmin
                        string queryUpdate = "UPDATE transaksi SET status_transaksi = 'Disetujui Nelayan' WHERE id_transaksi = @idTrans";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdate, kon))
                        {
                            cmd.Transaction = sqlTransaction; // Mengunci perintah ke dalam scope transaksi aktif
                            cmd.Parameters.AddWithValue("@idTrans", idTransaksiTerpilih);

                            cmd.ExecuteNonQuery();
                        }

                        // Jika disetujui server dan lolos dari hadangan Trigger, simpan permanen
                        sqlTransaction.Commit();

                        MessageBox.Show("Penawaran Berhasil Disetujui! [DATABASE TRANSACTION COMMITTED]", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MuatTabelPenawaran();
                    }
                    catch (PostgresException pgEx)
                    {
                        // Menangkap Rollback otomatis akibat kegagalan validasi aturan bisnis di Trigger pgAdmin
                        sqlTransaction.Rollback();
                        MessageBox.Show("Ditolak Database (Trigger Block): " + pgEx.MessageText, "Pelanggaran Aturan Bisnis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    catch (Exception ex)
                    {
                        // Menangkap error umum sistem, lakukan rollback demi keamanan integritas data
                        sqlTransaction.Rollback();
                        MessageBox.Show("Sistem mendeteksi kegagalan data. Transaksi otomatis di-Rollback! \nDetail: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tolak_tawaran_Click(object sender, EventArgs e)
        {
            if (idTransaksiTerpilih == 0)
            {
                MessageBox.Show("Silakan pilih baris penawaran pada tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin MENOLAK penawaran harga dari distributor ini?", "Konfirmasi Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.No) return;

            using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
            {
                kon.Open();

                using (NpgsqlTransaction sqlTransaction = kon.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        string queryUpdate = "UPDATE transaksi SET status_transaksi = 'Ditolak Nelayan' WHERE id_transaksi = @idTrans";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(queryUpdate, kon))
                        {
                            cmd.Transaction = sqlTransaction;
                            cmd.Parameters.AddWithValue("@idTrans", idTransaksiTerpilih);

                            cmd.ExecuteNonQuery();
                        }

                        sqlTransaction.Commit();
                        MessageBox.Show("Penawaran Berhasil Ditolak! [DATABASE TRANSACTION COMMITTED]", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MuatTabelPenawaran();
                    }
                    catch (PostgresException pgEx)
                    {
                        sqlTransaction.Rollback();
                        MessageBox.Show("Ditolak Database (Trigger Block): " + pgEx.MessageText, "Pelanggaran Aturan Bisnis", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    catch (Exception ex)
                    {
                        sqlTransaction.Rollback();
                        MessageBox.Show("Gagal menolak data, dilakukan rollback menyeluruh. \nDetail: " + ex.Message, "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ==========================================
        // SIDEBAR MENUS: NAVIGASI PINDAH HALAMAN
        // ==========================================
        private void GantiHalaman(UserControl ucBaru)
        {
            mainForm.TampilkanHalaman(ucBaru);
        }

        private void dashboardbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalaman(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalaman(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_nawar_Click(object sender, EventArgs e)
        {
            MuatTabelPenawaran();
        }

        private void transaksibutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalaman(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalaman(new PROJEKANN.Usercontrol.nelayan.RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_nawar_Click(object sender, EventArgs e)
        {
            DialogResult k = MessageBox.Show("Apakah anda yakin ingin keluar aplikasi?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (k == DialogResult.Yes) GantiHalaman(new login(mainForm));
        }

        // Mengosongkan method bawaan lama jika tidak sengaja ter-generate klik ganda di designer
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}