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
            txtKeterangan = new TextBox();
            btnDashboard = new Label();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            btnPanen = new Button();
            btnTetapkan = new Button();
            cbGrade = new ComboBox();
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
            panel1.Controls.Add(txtKeterangan);
            panel1.Controls.Add(btnDashboard);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
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
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(35, 298);
            button7.Name = "button7";
            button7.Size = new Size(194, 34);
            button7.TabIndex = 8;
            button7.Text = "RIWAYAT TRANSAKSI";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(29, 259);
            button6.Name = "button6";
            button6.Size = new Size(129, 34);
            button6.TabIndex = 7;
            button6.Text = "TRANSAKSI";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(27, 223);
            button5.Name = "button5";
            button5.Size = new Size(147, 34);
            button5.TabIndex = 6;
            button5.Text = "PENAWARAN";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(30, 184);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 5;
            button4.Text = "GRADING";
            button4.UseVisualStyleBackColor = false;
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
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button btnPanen;
        private Label btnDashboard;
        private TextBox txtKeterangan;
    }
}
