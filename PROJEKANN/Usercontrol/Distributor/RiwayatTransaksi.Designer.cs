namespace PROJEKANN.Usercontrol.Distributor
{
    partial class RiwayatTransaksi
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
            dgvRiwayat = new DataGridView();
            panel1 = new Panel();
            btnKeluar = new Button();
            lblTotal = new Label();
            lblSelesai = new Label();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            btnPanen = new Button();
            btnDashboard = new Button();
            lblNamaUser = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRiwayat
            // 
            dgvRiwayat.BackgroundColor = Color.White;
            dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRiwayat.Location = new Point(268, 143);
            dgvRiwayat.Name = "dgvRiwayat";
            dgvRiwayat.RowHeadersWidth = 62;
            dgvRiwayat.Size = new Size(619, 390);
            dgvRiwayat.TabIndex = 3;
            dgvRiwayat.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.riwayat_transaksi;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(lblNamaUser);
            panel1.Controls.Add(btnKeluar);
            panel1.Controls.Add(lblTotal);
            panel1.Controls.Add(lblSelesai);
            panel1.Controls.Add(btnRiwayat);
            panel1.Controls.Add(btnTransaksi);
            panel1.Controls.Add(btnPenawaran);
            panel1.Controls.Add(btnGrading);
            panel1.Controls.Add(btnPanen);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(dgvRiwayat);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(908, 555);
            panel1.TabIndex = 1;
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(7, 513);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(116, 34);
            btnKeluar.TabIndex = 14;
            btnKeluar.Text = "KELUAR";
            btnKeluar.TextAlign = ContentAlignment.MiddleRight;
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(499, 88);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(22, 25);
            lblTotal.TabIndex = 16;
            lblTotal.Text = "0";
            // 
            // lblSelesai
            // 
            lblSelesai.AutoSize = true;
            lblSelesai.BackColor = Color.Transparent;
            lblSelesai.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelesai.Location = new Point(311, 88);
            lblSelesai.Name = "lblSelesai";
            lblSelesai.Size = new Size(22, 25);
            lblSelesai.TabIndex = 15;
            lblSelesai.Text = "0";
            lblSelesai.Click += label1_Click;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(35, 295);
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
            btnTransaksi.Location = new Point(29, 256);
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
            btnPenawaran.Location = new Point(27, 220);
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
            btnGrading.Location = new Point(30, 181);
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
            btnPanen.Location = new Point(25, 143);
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
            btnDashboard.Location = new Point(29, 109);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(137, 34);
            btnDashboard.TabIndex = 9;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNamaUser.Location = new Point(80, 47);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(33, 25);
            lblNamaUser.TabIndex = 17;
            lblNamaUser.Text = "---";
            // 
            // RiwayatTransaksi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "RiwayatTransaksi";
            Size = new Size(908, 555);
            ((System.ComponentModel.ISupportInitialize)dgvRiwayat).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRiwayat;
        private Panel panel1;
        private Button btnRiwayat;
        private Button btnTransaksi;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button btnPanen;
        private Button btnDashboard;
        private Label lblTotal;
        private Label lblSelesai;
        private Button btnKeluar;
        private Label lblNamaUser;
    }
}
