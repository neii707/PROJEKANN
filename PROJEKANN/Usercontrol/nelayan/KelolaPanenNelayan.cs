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
        private int idPanenTerpilih = 0;
        public KelolaPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;

            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin;

            TampilkanNamaAsliUser();

            ResetFormInput();

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
                        }
                        else
                        {
                            lbnamauser_kelola.Text = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                lbnamauser_kelola.Text = userLoginAktif;
            }
        }

        private void MuatTabelPanenSaya()
        {
            try
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();
                    string query = "SELECT id, berat, grade, harga_per_kg, status FROM view_riwayat_panen_nelayan WHERE username_nelayan = @username ORDER BY id DESC";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, kon))
                    {
                        cmd.Parameters.AddWithValue("@username", userLoginAktif);

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvriwayatpanen.AutoGenerateColumns = false;

                            colID.DataPropertyName = "id";
                            colID.Name = "colID"; 
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

        private void ResetFormInput()
        {
            numBerat.Value = 0;
            dtptanggalpanen.Value = DateTime.Now;
            idPanenTerpilih = 0;
            simpanpanen_kelola.Text = "simpan";
        }
        private void simpanpanen_kelola_Click(object sender, EventArgs e)
        {
            double beratInput = Convert.ToDouble(numBerat.Value);
            DateTime tanggalInput = dtptanggalpanen.Value;

            if (beratInput <= 0)
            {
                MessageBox.Show("Silakan masukkan berat panen yang valid (harus lebih besar dari 0 kg)!", "Peringatan Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Sesi user Anda tidak valid. Silakan lakukan login ulang.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Data panen berhasil ditambahkan! Menunggu penilaian grading dari distributor.", "Sukses Menyimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string queryCekGrade = "SELECT COUNT(*) FROM grade WHERE id_panen = @id";
                        using (NpgsqlCommand cmdCek = new NpgsqlCommand(queryCekGrade, kon))
                        {
                            cmdCek.Parameters.AddWithValue("@id", idPanenTerpilih);
                            if (Convert.ToInt32(cmdCek.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show("Gagal merubah data! Data panen ini sudah dinilai/di-grade oleh pihak distributor dan telah dikunci.", "Akses Terkunci", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                ResetFormInput();
                                return;
                            }
                        }

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

                    ResetFormInput();
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
            if (dgvriwayatpanen.CurrentRow == null)
            {
                MessageBox.Show("Silakan tentukan data panen pada tabel di bawah terlebih dahulu untuk dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idPanenTerpilihText = dgvriwayatpanen.CurrentRow.Cells["colID"].Value.ToString();

            DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin menghapus data panen dengan ID {idPanenTerpilihText} secara permanen?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                            int hasilEksekusi = cmd.ExecuteNonQuery();

                            if (hasilEksekusi > 0)
                            {
                                MessageBox.Show("Data panen berhasil dihapus dari sistem.", "Sukses Terhapus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Gagal menghapus! Data panen ini sudah dinilai/di-grade oleh distributor sehingga dikunci sistem.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }

                    ResetFormInput();
                    MuatTabelPanenSaya();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memproses penghapusan data: " + ex.Message, "Error Sistem Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                        numBerat.Value = Convert.ToDecimal(row.Cells["colBerat"].Value);
                        simpanpanen_kelola.Text = "Ubah Data";
                    }
                }
                catch
                {
                    ResetFormInput();
                }
            }
        }

        private void GantiHalamanFitur(UserControl ucBaru)
        {
            if (ucBaru == null) return;

            try
            {
                Panel panelInduk = this.Parent as Panel;

                if (panelInduk != null)
                {
                    panelInduk.Controls.Clear();
                    ucBaru.Dock = DockStyle.Fill;
                    panelInduk.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else if (this.Parent != null)
                {
                    Control indukUtama = this.Parent;
                    indukUtama.Controls.Remove(this);
                    ucBaru.Dock = DockStyle.Fill;
                    indukUtama.Controls.Add(ucBaru);
                    ucBaru.BringToFront();
                }
                else
                {
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

        private void dashboardbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_kelola_Click(object sender, EventArgs e)
        {
            ResetFormInput();
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

        private void riwayatbutton_kelola_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new PROJEKANN.Usercontrol.nelayan.RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_kelola_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Logout Sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }
    }
}