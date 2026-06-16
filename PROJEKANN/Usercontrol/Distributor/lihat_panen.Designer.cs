namespace PROJEKANN.Usercontrol.Distributor
{
    partial class lihat_panen
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
            lblNamaUser = new Label();
            btnKeluar = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btnRiwayat = new Button();
            btnTransaksi = new Button();
            btnPenawaran = new Button();
            btnGrading = new Button();
            button2 = new Button();
            btnPanen = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblNamaUser
            // 
            lblNamaUser.AutoSize = true;
            lblNamaUser.BackColor = Color.Transparent;
            lblNamaUser.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblNamaUser.Location = new Point(108, 62);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(44, 32);
            lblNamaUser.TabIndex = 13;
            lblNamaUser.Text = "---";
            // 
            // btnKeluar
            // 
            btnKeluar.BackColor = Color.Transparent;
            btnKeluar.FlatAppearance.BorderSize = 0;
            btnKeluar.FlatStyle = FlatStyle.Flat;
            btnKeluar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKeluar.Location = new Point(10, 646);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(53, 34);
            btnKeluar.TabIndex = 12;
            btnKeluar.TextAlign = ContentAlignment.MiddleRight;
            btnKeluar.UseVisualStyleBackColor = false;
            btnKeluar.Click += btnKeluar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label1.Location = new Point(325, 105);
            label1.Name = "label1";
            label1.Size = new Size(271, 38);
            label1.TabIndex = 7;
            label1.Text = "Data Panen Saat Ini:";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(334, 145);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(778, 521);
            dataGridView1.TabIndex = 6;
            // 
            // btnRiwayat
            // 
            btnRiwayat.BackColor = Color.Transparent;
            btnRiwayat.FlatAppearance.BorderSize = 0;
            btnRiwayat.FlatStyle = FlatStyle.Flat;
            btnRiwayat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRiwayat.Location = new Point(44, 374);
            btnRiwayat.Name = "btnRiwayat";
            btnRiwayat.Size = new Size(193, 34);
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
            btnTransaksi.Location = new Point(44, 327);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(115, 34);
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
            btnPenawaran.Location = new Point(43, 283);
            btnPenawaran.Name = "btnPenawaran";
            btnPenawaran.Size = new Size(130, 34);
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
            btnGrading.Location = new Point(37, 234);
            btnGrading.Name = "btnGrading";
            btnGrading.Size = new Size(112, 34);
            btnGrading.TabIndex = 2;
            btnGrading.Text = "GRADING";
            btnGrading.UseVisualStyleBackColor = false;
            btnGrading.Click += btnGrading_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(41, 184);
            button2.Name = "button2";
            button2.Size = new Size(132, 34);
            button2.TabIndex = 1;
            button2.Text = "LIHAT PANEN";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnPanen
            // 
            btnPanen.BackColor = Color.Transparent;
            btnPanen.FlatAppearance.BorderSize = 0;
            btnPanen.FlatStyle = FlatStyle.Flat;
            btnPanen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPanen.Location = new Point(40, 143);
            btnPanen.Name = "btnPanen";
            btnPanen.Size = new Size(130, 34);
            btnPanen.TabIndex = 8;
            btnPanen.Text = "DASHBOARD";
            btnPanen.UseVisualStyleBackColor = false;
            btnPanen.Click += btnPanen_Click;
            // 
            // lihat_panen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.lihat_paneh_dis;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(lblNamaUser);
            Controls.Add(btnKeluar);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(btnRiwayat);
            Controls.Add(btnTransaksi);
            Controls.Add(btnPenawaran);
            Controls.Add(btnGrading);
            Controls.Add(button2);
            Controls.Add(btnPanen);
            Name = "lihat_panen";
            Size = new Size(1135, 690);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPanen;
        private Button btnTransaksi;
        private Button btnPenawaran;
        private Button btnGrading;
        private Button button2;
        private DataGridView dataGridView1;
        private Button btnRiwayat;
        private Label label1;
        private Button btnKeluar;
        private Label lblNamaUser;
    }
}
