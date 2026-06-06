namespace PROJEKANN.Usercontrol
{
    partial class dashboard_distributor
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
            DashboardDistributor = new Panel();
            label1 = new Label();
            lblTotalTransaksi = new Label();
            lblDemand = new Label();
            lblNamaUser = new Label();
            btnKeluar = new Button();
            dgvDashboard = new DataGridView();
            label2 = new Label();
            lblJumlahPanen = new Label();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            btnPanen = new Button();
            btnDashboard = new Button();
            DashboardDistributor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).BeginInit();
            SuspendLayout();
            // 
            // DashboardDistributor
            // 
            DashboardDistributor.BackgroundImage = Properties.Resources.WhatsApp_Image_2026_06_03_at_19_52_35;
            DashboardDistributor.BackgroundImageLayout = ImageLayout.Stretch;
            DashboardDistributor.Controls.Add(label1);
            DashboardDistributor.Controls.Add(lblTotalTransaksi);
            DashboardDistributor.Controls.Add(lblDemand);
            DashboardDistributor.Controls.Add(lblNamaUser);
            DashboardDistributor.Controls.Add(btnKeluar);
            DashboardDistributor.Controls.Add(dgvDashboard);
            DashboardDistributor.Controls.Add(label2);
            DashboardDistributor.Controls.Add(lblJumlahPanen);
            DashboardDistributor.Controls.Add(btnRiwayat);
            DashboardDistributor.Controls.Add(btnTransaksi);
            DashboardDistributor.Controls.Add(btnPenawaran);
            DashboardDistributor.Controls.Add(btnGrading);
            DashboardDistributor.Controls.Add(btnPanen);
            DashboardDistributor.Controls.Add(btnDashboard);
            DashboardDistributor.Location = new Point(0, 0);
            DashboardDistributor.Name = "DashboardDistributor";
            DashboardDistributor.Size = new Size(908, 555);
            DashboardDistributor.TabIndex = 0;
            DashboardDistributor.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(266, 194);
            label1.Name = "label1";
            label1.Size = new Size(240, 38);
            label1.TabIndex = 14;
            label1.Text = "Transaksi Terakhir";
            // 
            // lblTotalTransaksi
            // 
            lblTotalTransaksi.AutoSize = true;
            lblTotalTransaksi.BackColor = Color.Transparent;
            lblTotalTransaksi.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalTransaksi.Location = new Point(741, 108);
            lblTotalTransaksi.Name = "lblTotalTransaksi";
            lblTotalTransaksi.Size = new Size(33, 38);
            lblTotalTransaksi.TabIndex = 13;
            lblTotalTransaksi.Text = "0";
            // 
            // lblDemand
            // 
            lblDemand.AutoSize = true;
            lblDemand.BackColor = Color.Transparent;
            lblDemand.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblDemand.Location = new Point(539, 108);
            lblDemand.Name = "lblDemand";
            lblDemand.Size = new Size(33, 38);
            lblDemand.TabIndex = 12;
            lblDemand.Text = "0";
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNamaUser.Location = new Point(84, 51);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(33, 25);
            lblNamaUser.TabIndex = 11;
            lblNamaUser.Text = "---";
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
            btnKeluar.TabIndex = 10;
            btnKeluar.Text = "KELUAR";
            btnKeluar.UseVisualStyleBackColor = false;
            // 
            // dgvDashboard
            // 
            dgvDashboard.BackgroundColor = Color.White;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(266, 235);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.RowHeadersWidth = 62;
            dgvDashboard.Size = new Size(624, 301);
            dgvDashboard.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(503, 114);
            label2.Name = "label2";
            label2.Size = new Size(0, 28);
            label2.TabIndex = 7;
            // 
            // lblJumlahPanen
            // 
            lblJumlahPanen.AutoSize = true;
            lblJumlahPanen.BackColor = Color.Transparent;
            lblJumlahPanen.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblJumlahPanen.Location = new Point(303, 108);
            lblJumlahPanen.Name = "lblJumlahPanen";
            lblJumlahPanen.Size = new Size(33, 38);
            lblJumlahPanen.TabIndex = 6;
            lblJumlahPanen.Text = "0";
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(35, 296);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(197, 34);
            btnRiwayat.TabIndex = 5;
            btnRiwayat.Text = "RIWAYAT TRANSAKSI";
            btnRiwayat.UseVisualStyleBackColor = false;
            btnRiwayat.Click += btnRiwayat_Click;
            // 
            // btnTransaksi
            // 
            btnTransaksi.BackColor = Color.Transparent;
            btnTransaksi.FlatAppearance.BorderSize = 0;
            btnTransaksi.FlatStyle = FlatStyle.Flat;
            btnTransaksi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransaksi.Location = new Point(29, 260);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(132, 34);
            btnTransaksi.TabIndex = 4;
            btnTransaksi.Text = "TRANSAKSI";
            btnTransaksi.UseVisualStyleBackColor = false;
            btnTransaksi.Click += btnTransaksi_Click;
            // 
            // btnPenawaran
            // 
            btnPenawaran.BackColor = Color.Transparent;
            btnPenawaran.FlatAppearance.BorderSize = 0;
            btnPenawaran.FlatStyle = FlatStyle.Flat;
            btnPenawaran.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPenawaran.Location = new Point(34, 222);
            btnPenawaran.Name = "btnPenawaran";
            btnPenawaran.Size = new Size(137, 34);
            btnPenawaran.TabIndex = 3;
            btnPenawaran.Text = "PENAWARAN";
            btnPenawaran.UseVisualStyleBackColor = false;
            btnPenawaran.Click += btnPenawaran_Click;
            // 
            // btnGrading
            // 
            btnGrading.BackColor = Color.Transparent;
            btnGrading.FlatAppearance.BorderSize = 0;
            btnGrading.FlatStyle = FlatStyle.Flat;
            btnGrading.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGrading.Location = new Point(31, 182);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(112, 34);
            btnGrading.TabIndex = 2;
            btnGrading.Text = "GRADING";
            btnGrading.UseVisualStyleBackColor = false;
            btnGrading.Click += btnGrading_Click;
            // 
            // btnPanen
            // 
            btnPanen.BackColor = Color.Transparent;
            btnPanen.FlatAppearance.BorderSize = 0;
            btnPanen.FlatStyle = FlatStyle.Flat;
            btnPanen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPanen.Location = new Point(34, 145);
            btnPanen.Name = "btnPanen";
            btnPanen.Size = new Size(134, 34);
            btnPanen.TabIndex = 1;
            btnPanen.Text = "LIHAT PANEN";
            btnPanen.UseVisualStyleBackColor = false;
            btnPanen.Click += btnPanen_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboard.Location = new Point(29, 112);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(140, 34);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // dashboard_distributor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DashboardDistributor);
            Name = "dashboard_distributor";
            Size = new Size(908, 555);
            Load += dashboard_distributor_Load;
            DashboardDistributor.ResumeLayout(false);
            DashboardDistributor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel DashboardDistributor;
        private Button btnDashboard;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button btnPanen;
        private Button btnRiwayat;
        private Button btnTransaksi;
        private Label lblJumlahPanen;
        private Label label2;
        private DataGridView dgvDashboard;
        private Button btnKeluar;
        private Label lblNamaUser;
        private Label lblDemand;
        private Label lblTotalTransaksi;
        private Label label1;
    }
}