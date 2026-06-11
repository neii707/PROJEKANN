using PROJEKANN.controller;
using PROJEKANN.model;
using PROJEKANN.Usercontrol.Distributor;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJEKANN.Usercontrol.nelayan
{
    public partial class NawarPanenNelayan : UserControl
    {
        private Form1 mainForm;
        private string userLoginAktif;
        private string namaAsliUser = "";

        private ControllerNawarPanen _controller = new ControllerNawarPanen();

        public NawarPanenNelayan(Form1 form1, string usernameLogin)
        {
            InitializeComponent();
            this.mainForm = form1;
            this.userLoginAktif = string.IsNullOrEmpty(usernameLogin) ? "" : usernameLogin.Trim();

            SegarkanTampilanPenawaran();
        }

        private void SegarkanTampilanPenawaran()
        {
            ModelNawarPanen data = _controller.AmbilDataNawarPanen(this.userLoginAktif);

            this.namaAsliUser = data.NamaAsliUser;
            if (lbnamauser_dashboard != null)
            {
                lbnamauser_dashboard.Text = this.namaAsliUser;
            }

            if (data.TabelPenawaran != null)
            {
                dgvpenawaran.AutoGenerateColumns = false;
                dgvpenawaran.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (data.TabelPenawaran != null && data.TabelPenawaran.Columns.Count > 0)
                {
                    for (int i = 0; i < dgvpenawaran.Columns.Count && i < data.TabelPenawaran.Columns.Count; i++)
                    {
                        dgvpenawaran.Columns[i].DataPropertyName = data.TabelPenawaran.Columns[i].ColumnName;
                    }
                }

                dgvpenawaran.DataSource = data.TabelPenawaran;
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

        private void dashboardbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new DashboardNelayan(mainForm, userLoginAktif));
        }

        private void inputpanenbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new KelolaPanenNelayan(mainForm, userLoginAktif));
        }

        private void penawaranbutton_nawar_Click(object sender, EventArgs e)
        {
            SegarkanTampilanPenawaran();
        }

        private void transaksibutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new TransaksiNelayan(mainForm, userLoginAktif));
        }

        private void riwayatbutton_nawar_Click(object sender, EventArgs e)
        {
            GantiHalamanFitur(new RiwayatNelayan(mainForm, userLoginAktif));
        }

        private void keluarbutton_nawar_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Logout Sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                GantiHalamanFitur(new PROJEKANN.Usercontrol.login(mainForm));
            }
        }

        private void terima_nawar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Penawaran Berhasil Diterima!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tolak_tawaran_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Penawaran Berhasil Ditolak!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}