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
            btnKonfirmasi = new Button();
            lblNamaUser = new Label();
            btnKeluar = new Button();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            btnPanen = new Button();
            btnDashboard = new Button();
            dgvTransaksi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            SuspendLayout();
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.BackColor = Color.DarkSeaGreen;
            btnKonfirmasi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKonfirmasi.Location = new Point(324, 624);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(137, 50);
            btnKonfirmasi.TabIndex = 1;
            btnKonfirmasi.Text = "KONFIRMASI";
            btnKonfirmasi.UseVisualStyleBackColor = false;
            btnKonfirmasi.Click += btnKonfirmasi_Click_1;
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNamaUser.Location = new Point(105, 57);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(44, 32);
            lblNamaUser.TabIndex = 16;
            lblNamaUser.Text = "---";
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(3, 515);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(68, 34);
            btnKeluar.TabIndex = 15;
            btnKeluar.TextAlign = ContentAlignment.MiddleRight;
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(43, 373);
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
            btnTransaksi.Location = new Point(36, 327);
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
            btnPenawaran.Location = new Point(34, 281);
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
            btnGrading.Location = new Point(38, 232);
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
            btnPanen.Location = new Point(32, 187);
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
            btnDashboard.Location = new Point(37, 144);
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
            dgvTransaksi.Location = new Point(331, 116);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.RowHeadersWidth = 62;
            dgvTransaksi.Size = new Size(783, 500);
            dgvTransaksi.TabIndex = 0;
            dgvTransaksi.CellClick += dgvTransaksi_CellClick;
            // 
            // Transaksi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.transaksi_dis;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(lblNamaUser);
            Controls.Add(btnKeluar);
            Controls.Add(btnRiwayat);
            Controls.Add(btnTransaksi);
            Controls.Add(btnPenawaran);
            Controls.Add(btnGrading);
            Controls.Add(btnPanen);
            Controls.Add(btnDashboard);
            Controls.Add(btnKonfirmasi);
            Controls.Add(dgvTransaksi);
            Name = "Transaksi";
            Size = new Size(1135, 690);
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKonfirmasi;
        private DataGridView dgvTransaksi;
        private Button btnRiwayat;
        private Button btnTransaksi;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button btnPanen;
        private Button btnDashboard;
        private Button btnKeluar;
        private Label lblNamaUser;
    }
}
