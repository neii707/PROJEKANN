namespace PROJEKANN.Usercontrol
{
    partial class DashboardNelayan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardNelayan));
            panel2 = new Panel();
            dashboardbutton = new Button();
            inputpanenbutton_dashboard = new Button();
            penawaranbutton_dashboard = new Button();
            transaksibutton_dashboard = new Button();
            button1 = new Button();
            namauserlabel_dashboard = new Label();
            penawaranlabel_dashboard = new Label();
            stoklabel_dashboard = new Label();
            penjualanlabel_dashboard = new Label();
            dataGridView1 = new DataGridView();
            panenlabel_dashboard = new Label();
            keluarbutton_dashboard = new Button();
            colID = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colBerat = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lbnamauser_dashboard = new Label();
            labeldemand_dashboard = new Label();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(labeldemand_dashboard);
            panel2.Controls.Add(lbnamauser_dashboard);
            panel2.Controls.Add(keluarbutton_dashboard);
            panel2.Controls.Add(panenlabel_dashboard);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(penjualanlabel_dashboard);
            panel2.Controls.Add(stoklabel_dashboard);
            panel2.Controls.Add(penawaranlabel_dashboard);
            panel2.Controls.Add(namauserlabel_dashboard);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(transaksibutton_dashboard);
            panel2.Controls.Add(penawaranbutton_dashboard);
            panel2.Controls.Add(inputpanenbutton_dashboard);
            panel2.Controls.Add(dashboardbutton);
            panel2.Location = new Point(-1, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(908, 555);
            panel2.TabIndex = 1;
            // 
            // dashboardbutton
            // 
            dashboardbutton.BackColor = Color.Transparent;
            dashboardbutton.FlatAppearance.BorderSize = 0;
            dashboardbutton.FlatStyle = FlatStyle.Flat;
            dashboardbutton.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbutton.Location = new Point(33, 115);
            dashboardbutton.Name = "dashboardbutton";
            dashboardbutton.Size = new Size(119, 26);
            dashboardbutton.TabIndex = 0;
            dashboardbutton.Text = "DASHBOARD";
            dashboardbutton.UseVisualStyleBackColor = false;
            dashboardbutton.Click += dashboardbutton_Click;
            // 
            // inputpanenbutton_dashboard
            // 
            inputpanenbutton_dashboard.BackColor = Color.Transparent;
            inputpanenbutton_dashboard.FlatAppearance.BorderSize = 0;
            inputpanenbutton_dashboard.FlatStyle = FlatStyle.Flat;
            inputpanenbutton_dashboard.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            inputpanenbutton_dashboard.Location = new Point(33, 163);
            inputpanenbutton_dashboard.Name = "inputpanenbutton_dashboard";
            inputpanenbutton_dashboard.Size = new Size(143, 26);
            inputpanenbutton_dashboard.TabIndex = 1;
            inputpanenbutton_dashboard.Text = "KELOLA PANEN";
            inputpanenbutton_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            inputpanenbutton_dashboard.UseVisualStyleBackColor = false;
            inputpanenbutton_dashboard.Click += inputpanenbutton_dashboard_Click;
            // 
            // penawaranbutton_dashboard
            // 
            penawaranbutton_dashboard.BackColor = Color.Transparent;
            penawaranbutton_dashboard.FlatAppearance.BorderSize = 0;
            penawaranbutton_dashboard.FlatStyle = FlatStyle.Flat;
            penawaranbutton_dashboard.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            penawaranbutton_dashboard.Location = new Point(33, 191);
            penawaranbutton_dashboard.Name = "penawaranbutton_dashboard";
            penawaranbutton_dashboard.Size = new Size(180, 26);
            penawaranbutton_dashboard.TabIndex = 2;
            penawaranbutton_dashboard.Text = "PENAWARAN PANEN";
            penawaranbutton_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            penawaranbutton_dashboard.UseVisualStyleBackColor = false;
            penawaranbutton_dashboard.Click += penawaranbutton_dashboard_Click;
            // 
            // transaksibutton_dashboard
            // 
            transaksibutton_dashboard.BackColor = Color.Transparent;
            transaksibutton_dashboard.FlatAppearance.BorderSize = 0;
            transaksibutton_dashboard.FlatStyle = FlatStyle.Flat;
            transaksibutton_dashboard.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            transaksibutton_dashboard.Location = new Point(34, 219);
            transaksibutton_dashboard.Name = "transaksibutton_dashboard";
            transaksibutton_dashboard.Size = new Size(105, 26);
            transaksibutton_dashboard.TabIndex = 3;
            transaksibutton_dashboard.Text = "TRANSAKSI";
            transaksibutton_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            transaksibutton_dashboard.UseVisualStyleBackColor = false;
            transaksibutton_dashboard.Click += transaksibutton_dashboard_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            button1.Location = new Point(32, 265);
            button1.Name = "button1";
            button1.Size = new Size(180, 26);
            button1.TabIndex = 4;
            button1.Text = "RIWAYAT TRANSAKSI";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = false;
            // 
            // namauserlabel_dashboard
            // 
            namauserlabel_dashboard.AutoSize = true;
            namauserlabel_dashboard.BackColor = Color.Transparent;
            namauserlabel_dashboard.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            namauserlabel_dashboard.Location = new Point(93, 61);
            namauserlabel_dashboard.Name = "namauserlabel_dashboard";
            namauserlabel_dashboard.Size = new Size(0, 21);
            namauserlabel_dashboard.TabIndex = 5;
            // 
            // penawaranlabel_dashboard
            // 
            penawaranlabel_dashboard.AutoSize = true;
            penawaranlabel_dashboard.BackColor = Color.Transparent;
            penawaranlabel_dashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            penawaranlabel_dashboard.Location = new Point(539, 128);
            penawaranlabel_dashboard.Name = "penawaranlabel_dashboard";
            penawaranlabel_dashboard.Size = new Size(0, 32);
            penawaranlabel_dashboard.TabIndex = 6;
            // 
            // stoklabel_dashboard
            // 
            stoklabel_dashboard.AutoSize = true;
            stoklabel_dashboard.BackColor = Color.Transparent;
            stoklabel_dashboard.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            stoklabel_dashboard.Location = new Point(312, 115);
            stoklabel_dashboard.Name = "stoklabel_dashboard";
            stoklabel_dashboard.Size = new Size(0, 38);
            stoklabel_dashboard.TabIndex = 7;
            // 
            // penjualanlabel_dashboard
            // 
            penjualanlabel_dashboard.AutoSize = true;
            penjualanlabel_dashboard.BackColor = Color.Transparent;
            penjualanlabel_dashboard.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            penjualanlabel_dashboard.Location = new Point(763, 115);
            penjualanlabel_dashboard.Name = "penjualanlabel_dashboard";
            penjualanlabel_dashboard.Size = new Size(0, 38);
            penjualanlabel_dashboard.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(192, 255, 255);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colID, colGrade, colBerat, colTanggal, colStatus });
            dataGridView1.Location = new Point(274, 318);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(603, 203);
            dataGridView1.TabIndex = 10;
            // 
            // panenlabel_dashboard
            // 
            panenlabel_dashboard.AutoSize = true;
            panenlabel_dashboard.BackColor = Color.Transparent;
            panenlabel_dashboard.Font = new Font("Book Antiqua", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panenlabel_dashboard.ForeColor = SystemColors.ControlText;
            panenlabel_dashboard.Location = new Point(274, 286);
            panenlabel_dashboard.Name = "panenlabel_dashboard";
            panenlabel_dashboard.Size = new Size(175, 28);
            panenlabel_dashboard.TabIndex = 11;
            panenlabel_dashboard.Text = "Panen Terbaru";
            // 
            // keluarbutton_dashboard
            // 
            keluarbutton_dashboard.BackColor = Color.Transparent;
            keluarbutton_dashboard.BackgroundImage = (Image)resources.GetObject("keluarbutton_dashboard.BackgroundImage");
            keluarbutton_dashboard.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_dashboard.Cursor = Cursors.Hand;
            keluarbutton_dashboard.FlatAppearance.BorderSize = 0;
            keluarbutton_dashboard.FlatStyle = FlatStyle.Flat;
            keluarbutton_dashboard.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_dashboard.Location = new Point(-17, 487);
            keluarbutton_dashboard.Name = "keluarbutton_dashboard";
            keluarbutton_dashboard.Size = new Size(110, 69);
            keluarbutton_dashboard.TabIndex = 12;
            keluarbutton_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_dashboard.UseVisualStyleBackColor = false;
            keluarbutton_dashboard.Click += keluarbutton_dashboard_Click;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colGrade
            // 
            colGrade.HeaderText = "Grade";
            colGrade.MinimumWidth = 8;
            colGrade.Name = "colGrade";
            colGrade.ReadOnly = true;
            // 
            // colBerat
            // 
            colBerat.HeaderText = "Berat (kg)";
            colBerat.MinimumWidth = 8;
            colBerat.Name = "colBerat";
            colBerat.ReadOnly = true;
            // 
            // colTanggal
            // 
            colTanggal.HeaderText = "Tanggal";
            colTanggal.MinimumWidth = 8;
            colTanggal.Name = "colTanggal";
            colTanggal.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lbnamauser_dashboard
            // 
            lbnamauser_dashboard.AutoSize = true;
            lbnamauser_dashboard.BackColor = Color.Transparent;
            lbnamauser_dashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnamauser_dashboard.Location = new Point(92, 48);
            lbnamauser_dashboard.Name = "lbnamauser_dashboard";
            lbnamauser_dashboard.Size = new Size(88, 25);
            lbnamauser_dashboard.TabIndex = 26;
            lbnamauser_dashboard.Text = "Natachai";
            // 
            // labeldemand_dashboard
            // 
            labeldemand_dashboard.AutoSize = true;
            labeldemand_dashboard.BackColor = Color.FromArgb(192, 255, 255);
            labeldemand_dashboard.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labeldemand_dashboard.Location = new Point(277, 206);
            labeldemand_dashboard.Name = "labeldemand_dashboard";
            labeldemand_dashboard.Size = new Size(437, 38);
            labeldemand_dashboard.TabIndex = 27;
            labeldemand_dashboard.Text = "Demand Terkini: Memuat Data..";
            labeldemand_dashboard.Click += labeldemand_dashboard_Click;
            // 
            // DashboardNelayan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Name = "DashboardNelayan";
            Size = new Size(908, 555);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Button dashboardbutton;
        private Button inputpanenbutton_dashboard;
        private Button penawaranbutton_dashboard;
        private Button transaksibutton_dashboard;
        private Button button1;
        private Label namauserlabel_dashboard;
        private Label stoklabel_dashboard;
        private Label penawaranlabel_dashboard;
        private Label penjualanlabel_dashboard;
        private DataGridView dataGridView1;
        private Label panenlabel_dashboard;
        private Button keluarbutton_dashboard;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colBerat;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colStatus;
        private Label lbnamauser_dashboard;
        private Label labeldemand_dashboard;
    }
}
