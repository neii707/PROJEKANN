namespace PROJEKANN.Usercontrol.Distributor
{
    partial class Transaksi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transaksi));
            btnKonfirmasi = new Button();
            panel1 = new Panel();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            btnPanen = new Button();
            btnDashboard = new Button();
            dgvTransaksi = new DataGridView();
            btnKeluar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            SuspendLayout();
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.BackColor = Color.DarkSeaGreen;
            btnKonfirmasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfirmasi.Location = new Point(259, 508);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(137, 34);
            btnKonfirmasi.TabIndex = 1;
            btnKonfirmasi.Text = "KONFIRMASI";
            btnKonfirmasi.UseVisualStyleBackColor = false;
            btnKonfirmasi.Click += btnKonfirmasi_Click_1;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(btnKeluar);
            panel1.Controls.Add(btnRiwayat);
            panel1.Controls.Add(btnTransaksi);
            panel1.Controls.Add(btnPenawaran);
            panel1.Controls.Add(btnGrading);
            panel1.Controls.Add(btnPanen);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(btnKonfirmasi);
            panel1.Controls.Add(dgvTransaksi);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(908, 555);
            panel1.TabIndex = 1;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(38, 304);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(194, 34);
            btnRiwayat.TabIndex = 14;
            btnRiwayat.Text = "RIWAYAT TRANSAKSI";
            btnRiwayat.UseVisualStyleBackColor = false;
            btnRiwayat.Click += btnRiwayat_Click_1;
            // 
            // btnTransaksi
            // 
            btnTransaksi.BackColor = Color.Transparent;
            btnTransaksi.FlatAppearance.BorderSize = 0;
            btnTransaksi.FlatStyle = FlatStyle.Flat;
            btnTransaksi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransaksi.Location = new Point(32, 265);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(129, 34);
            btnTransaksi.TabIndex = 13;
            btnTransaksi.Text = "TRANSAKSI";
            btnTransaksi.UseVisualStyleBackColor = false;
            btnTransaksi.Click += btnTransaksi_Click_1;
            // 
            // btnPenawaran
            // 
            btnPenawaran.BackColor = Color.Transparent;
            btnPenawaran.FlatAppearance.BorderSize = 0;
            btnPenawaran.FlatStyle = FlatStyle.Flat;
            btnPenawaran.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPenawaran.Location = new Point(30, 229);
            btnPenawaran.Name = "btnPenawaran";
            btnPenawaran.Size = new Size(147, 34);
            btnPenawaran.TabIndex = 12;
            btnPenawaran.Text = "PENAWARAN";
            btnPenawaran.UseVisualStyleBackColor = false;
            btnPenawaran.Click += btnPenawaran_Click_1;
            // 
            // btnGrading
            // 
            btnGrading.BackColor = Color.Transparent;
            btnGrading.FlatAppearance.BorderSize = 0;
            btnGrading.FlatStyle = FlatStyle.Flat;
            btnGrading.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGrading.Location = new Point(33, 190);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(112, 34);
            btnGrading.TabIndex = 11;
            btnGrading.Text = "GRADING";
            btnGrading.UseVisualStyleBackColor = false;
            btnGrading.Click += btnGrading_Click_1;
            // 
            // btnPanen
            // 
            btnPanen.BackColor = Color.Transparent;
            btnPanen.FlatAppearance.BorderSize = 0;
            btnPanen.FlatStyle = FlatStyle.Flat;
            btnPanen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPanen.Location = new Point(28, 152);
            btnPanen.Name = "btnPanen";
            btnPanen.Size = new Size(150, 34);
            btnPanen.TabIndex = 10;
            btnPanen.Text = "LIHAT PANEN";
            btnPanen.UseVisualStyleBackColor = false;
            btnPanen.Click += btnPanen_Click_1;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.Location = new Point(32, 118);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(137, 34);
            btnDashboard.TabIndex = 9;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.BackgroundColor = Color.White;
            dgvTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaksi.Location = new Point(269, 103);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.RowHeadersWidth = 62;
            dgvTransaksi.Size = new Size(621, 384);
            dgvTransaksi.TabIndex = 0;
            dgvTransaksi.CellContentClick += dgvTransaksi_CellContentClick;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(6, 515);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(116, 34);
            btnKeluar.TabIndex = 15;
            btnKeluar.Text = "KELUAR";
            btnKeluar.TextAlign = ContentAlignment.MiddleRight;
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // Transaksi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "Transaksi";
            Size = new Size(908, 555);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnKonfirmasi;
        private Panel panel1;
        private DataGridView dgvTransaksi;
        private Button btnRiwayat;
        private Button btnTransaksi;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button btnPanen;
        private Button btnDashboard;
        private Button btnKeluar;
    }
}
