namespace PROJEKANN.Usercontrol.Distributor
{
    partial class Penawaran
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
            dgvPenawaran = new DataGridView();
            lblNamaUser = new Label();
            btnKeluar = new Button();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            button3 = new Button();
            button2 = new Button();
            btnKirim = new Button();
            txtHargaTawar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvPenawaran).BeginInit();
            SuspendLayout();
            // 
            // dgvPenawaran
            // 
            dgvPenawaran.BackgroundColor = Color.White;
            dgvPenawaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenawaran.Location = new Point(333, 146);
            dgvPenawaran.Name = "dgvPenawaran";
            dgvPenawaran.RowHeadersWidth = 62;
            dgvPenawaran.Size = new Size(779, 402);
            dgvPenawaran.TabIndex = 0;
            dgvPenawaran.CellClick += dgvPenawaran_CellClick;
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNamaUser.Location = new Point(106, 51);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(44, 32);
            lblNamaUser.TabIndex = 14;
            lblNamaUser.Text = "---";
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(7, 514);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(59, 34);
            btnKeluar.TabIndex = 13;
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
            btnRiwayat.Location = new Point(45, 373);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(194, 34);
            btnRiwayat.TabIndex = 13;
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
            btnTransaksi.Location = new Point(37, 327);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(129, 34);
            btnTransaksi.TabIndex = 12;
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
            btnPenawaran.TabIndex = 11;
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
            btnGrading.Location = new Point(39, 232);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(112, 34);
            btnGrading.TabIndex = 10;
            btnGrading.Text = "GRADING";
            btnGrading.UseVisualStyleBackColor = false;
            btnGrading.Click += btnGrading_Click_1;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(34, 185);
            button3.Name = "button3";
            button3.Size = new Size(150, 34);
            button3.TabIndex = 9;
            button3.Text = "LIHAT PANEN";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(38, 144);
            button2.Name = "button2";
            button2.Size = new Size(137, 34);
            button2.TabIndex = 4;
            button2.Text = "DASHBOARD";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnKirim
            // 
            btnKirim.BackColor = Color.DarkSeaGreen;
            btnKirim.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKirim.Location = new Point(774, 566);
            btnKirim.Name = "btnKirim";
            btnKirim.Size = new Size(84, 36);
            btnKirim.TabIndex = 2;
            btnKirim.Text = "KIRIM";
            btnKirim.UseVisualStyleBackColor = false;
            btnKirim.Click += btnKirim_Click;
            // 
            // txtHargaTawar
            // 
            txtHargaTawar.Location = new Point(618, 568);
            txtHargaTawar.Name = "txtHargaTawar";
            txtHargaTawar.Size = new Size(150, 31);
            txtHargaTawar.TabIndex = 1;
            // 
            // Penawaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.penawaran_dis;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(lblNamaUser);
            Controls.Add(btnKeluar);
            Controls.Add(btnRiwayat);
            Controls.Add(btnTransaksi);
            Controls.Add(btnPenawaran);
            Controls.Add(btnGrading);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnKirim);
            Controls.Add(txtHargaTawar);
            Controls.Add(dgvPenawaran);
            Name = "Penawaran";
            Size = new Size(1135, 690);
            Load += Penawaran_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPenawaran).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPenawaran;
        private Button btnKirim;
        private TextBox txtHargaTawar;
        private Button button2;
        private Button btnRiwayat;
        private Button btnTransaksi;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button button3;
        private Button btnKeluar;
        private Label lblNamaUser;
    }
}
