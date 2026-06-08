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
        private string userLoginAktif;
        private string namaAsliUser = "";

        public TransaksiNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;

            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            AmbilDanTampilkanNamaAsli();

            MuatTabelTransaksiAktif();
        }

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
                            this.namaAsliUser = userLoginAktif;
                        }
                    }
                }
            }
            catch
            {
                this.namaAsliUser = userLoginAktif;
            }

            if (lbnamauser_transaksi != null)
            {
                lbnamauser_transaksi.Text = this.namaAsliUser;
            }
        }

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

                            dgvtransaksi.AutoGenerateColumns = false;

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

        private void konfirmasi_transaksi_Click(object sender, EventArgs e)
        {
            if (dgvtransaksi.CurrentRow == null)
            {
                MessageBox.Show("Pilih baris transaksi pada tabel terlebih dahulu sebelum menekan tombol konfirmasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTransaksiSelected = Convert.ToInt32(dgvtransaksi.CurrentRow.Cells["colID"].Value);

            DialogResult dr = MessageBox.Show($"Apakah Anda yakin ingin memberikan konfirmasi selesai pada transaksi ID {idTransaksiSelected}?",
                "Konfirmasi Penyelesaian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (NpgsqlConnection kon = PROJEKANN.database.DBConnection.GetConnection())
                {
                    kon.Open();

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

                            sqlTrans.Commit();
                            MessageBox.Show($"Transaksi #{idTransaksiSelected} sukses ditutup dan dipindahkan ke riwayat archive.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MuatTabelTransaksiAktif();
                        }
                        catch (Exception ex)
                        {
                            sqlTrans.Rollback();
                            MessageBox.Show("Gagal mengonfirmasi transaksi. Perubahan database dibatalkan: " + ex.Message, "Transaction Rollback", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void GantiHalaman(UserControl ucBaru)
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
                else
                {
                    mainForm.TampilkanHalaman(ucBaru);
                }
            }
            catch
            {
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
                GantiHalaman(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void paneltransaksi_Paint(object sender, PaintEventArgs e) { }
    }
}