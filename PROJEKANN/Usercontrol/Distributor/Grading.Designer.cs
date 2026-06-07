namespace PROJEKANN.Usercontrol.Distributor
{
    partial class Grading
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
            dgvGrading = new DataGridView();
            panel1 = new Panel();
            btnKeluar = new Button();
            txtKeterangan = new TextBox();
            btnDashboard = new Label();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            btnPanen = new Button();
            btnTetapkan = new Button();
            cbGrade = new ComboBox();
            lblNamaUser = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvGrading).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvGrading
            // 
            dgvGrading.BackgroundColor = Color.White;
            dgvGrading.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrading.Location = new Point(269, 143);
            dgvGrading.Name = "dgvGrading";
            dgvGrading.RowHeadersWidth = 62;
            dgvGrading.Size = new Size(618, 296);
            dgvGrading.TabIndex = 0;
            dgvGrading.CellContentClick += dgvGrading_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.grade;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(lblNamaUser);
            panel1.Controls.Add(btnKeluar);
            panel1.Controls.Add(txtKeterangan);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(btnRiwayat);
            panel1.Controls.Add(btnTransaksi);
            panel1.Controls.Add(btnPenawaran);
            panel1.Controls.Add(btnGrading);
            panel1.Controls.Add(btnPanen);
            panel1.Controls.Add(btnTetapkan);
            panel1.Controls.Add(cbGrade);
            panel1.Controls.Add(dgvGrading);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(908, 555);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(24, 515);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(112, 34);
            btnKeluar.TabIndex = 11;
            btnKeluar.Text = "KELUAR";
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // txtKeterangan
            // 
            txtKeterangan.Location = new Point(629, 468);
            txtKeterangan.Multiline = true;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.Size = new Size(212, 33);
            txtKeterangan.TabIndex = 10;
            // 
            // btnDashboard
            // 
            btnDashboard.AutoSize = true;
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.Black;
            btnDashboard.Location = new Point(37, 118);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(121, 25);
            btnDashboard.TabIndex = 9;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(35, 298);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(194, 34);
            btnRiwayat.TabIndex = 8;
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
            btnTransaksi.Location = new Point(29, 259);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(129, 34);
            btnTransaksi.TabIndex = 7;
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
            btnPenawaran.Location = new Point(27, 223);
            btnPenawaran.Name = "btnPenawaran";
            btnPenawaran.Size = new Size(147, 34);
            btnPenawaran.TabIndex = 6;
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
            btnGrading.Location = new Point(30, 184);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(112, 34);
            btnGrading.TabIndex = 5;
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
            btnPanen.Location = new Point(25, 146);
            btnPanen.Name = "btnPanen";
            btnPanen.Size = new Size(150, 34);
            btnPanen.TabIndex = 4;
            btnPanen.Text = "LIHAT PANEN";
            btnPanen.UseVisualStyleBackColor = false;
            btnPanen.Click += btnPanen_Click_1;
            // 
            // btnTetapkan
            // 
            btnTetapkan.BackColor = Color.DarkSeaGreen;
            btnTetapkan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTetapkan.Location = new Point(629, 505);
            btnTetapkan.Name = "btnTetapkan";
            btnTetapkan.Size = new Size(117, 39);
            btnTetapkan.TabIndex = 2;
            btnTetapkan.Text = "TETAPKAN";
            btnTetapkan.UseVisualStyleBackColor = false;
            btnTetapkan.Click += btnTetapkan_Click;
            // 
            // cbGrade
            // 
            cbGrade.FormattingEnabled = true;
            cbGrade.Location = new Point(414, 468);
            cbGrade.Name = "cbGrade";
            cbGrade.Size = new Size(90, 33);
            cbGrade.TabIndex = 1;
            cbGrade.SelectedIndexChanged += cbGrade_SelectedIndexChanged;
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNamaUser.Location = new Point(86, 50);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(33, 25);
            lblNamaUser.TabIndex = 12;
            lblNamaUser.Text = "---";
            // 
            // Grading
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "Grading";
            Size = new Size(908, 555);
            Load += Grading_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvGrading).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvGrading;
        private Panel panel1;
        private Button btnTetapkan;
        private ComboBox cbGrade;
        private Button btnRiwayat;
        private Button btnTransaksi;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button btnPanen;
        private Label btnDashboard;
        private TextBox txtKeterangan;
        private Button btnKeluar;
        private Label lblNamaUser;
    }
}
