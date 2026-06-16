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
            lblNamaUser = new Label();
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
            ((System.ComponentModel.ISupportInitialize)dgvGrading).BeginInit();
            SuspendLayout();
            // 
            // dgvGrading
            // 
            dgvGrading.BackgroundColor = Color.White;
            dgvGrading.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrading.Location = new Point(330, 169);
            dgvGrading.Name = "dgvGrading";
            dgvGrading.RowHeadersWidth = 62;
            dgvGrading.Size = new Size(785, 388);
            dgvGrading.TabIndex = 0;
            dgvGrading.CellClick += dgvGrading_CellClick;
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNamaUser.Location = new Point(104, 55);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(44, 32);
            lblNamaUser.TabIndex = 12;
            lblNamaUser.Text = "---";
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(11, 645);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(48, 34);
            btnKeluar.TabIndex = 11;
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // txtKeterangan
            // 
            txtKeterangan.Location = new Point(788, 583);
            txtKeterangan.Multiline = true;
            txtKeterangan.Name = "txtKeterangan";
            txtKeterangan.Size = new Size(266, 33);
            txtKeterangan.TabIndex = 10;
            // 
            // btnDashboard
            // 
            btnDashboard.AutoSize = true;
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.Black;
            btnDashboard.Location = new Point(43, 148);
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
            btnRiwayat.Location = new Point(43, 374);
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
            btnTransaksi.Location = new Point(39, 326);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(119, 34);
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
            btnPenawaran.Location = new Point(36, 283);
            btnPenawaran.Name = "btnPenawaran";
            btnPenawaran.Size = new Size(138, 34);
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
            btnGrading.Location = new Point(41, 234);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(101, 34);
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
            btnPanen.Location = new Point(36, 186);
            btnPanen.Name = "btnPanen";
            btnPanen.Size = new Size(138, 34);
            btnPanen.TabIndex = 4;
            btnPanen.Text = "LIHAT PANEN";
            btnPanen.UseVisualStyleBackColor = false;
            btnPanen.Click += btnPanen_Click_1;
            // 
            // btnTetapkan
            // 
            btnTetapkan.BackColor = Color.DarkSeaGreen;
            btnTetapkan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTetapkan.Location = new Point(788, 623);
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
            cbGrade.Location = new Point(517, 583);
            cbGrade.Name = "cbGrade";
            cbGrade.Size = new Size(90, 33);
            cbGrade.TabIndex = 1;
            cbGrade.SelectedIndexChanged += cbGrade_SelectedIndexChanged;
            // 
            // Grading
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.grading_dis;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(lblNamaUser);
            Controls.Add(btnKeluar);
            Controls.Add(txtKeterangan);
            Controls.Add(btnDashboard);
            Controls.Add(btnRiwayat);
            Controls.Add(btnTransaksi);
            Controls.Add(btnPenawaran);
            Controls.Add(btnGrading);
            Controls.Add(btnPanen);
            Controls.Add(btnTetapkan);
            Controls.Add(cbGrade);
            Controls.Add(dgvGrading);
            Name = "Grading";
            Size = new Size(1135, 690);
            Load += Grading_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvGrading).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvGrading;
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
