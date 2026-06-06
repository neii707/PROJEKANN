namespace PROJEKANN.Usercontrol.nelayan
{
    partial class RiwayatNelayan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RiwayatNelayan));
            riwayatpanel = new Panel();
            dgvTransaksi = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colDistributor = new DataGridViewTextBoxColumn();
            colNelayan = new DataGridViewTextBoxColumn();
            colBerat = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colHarga = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colTanggal = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            totallabel_riwayat = new Label();
            keluarbutton_riwayat = new Button();
            riwayatbutton_riwayat = new Button();
            transaksibutton_riwayat = new Button();
            penawaranbutton_riwayat = new Button();
            inputpanenbutton_riwayat = new Button();
            dashboardbutton_riwayat = new Button();
            lbnamauser_riwayat = new Label();
            riwayatpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            SuspendLayout();
            // 
            // riwayatpanel
            // 
            riwayatpanel.BackgroundImage = (Image)resources.GetObject("riwayatpanel.BackgroundImage");
            riwayatpanel.BackgroundImageLayout = ImageLayout.Stretch;
            riwayatpanel.Controls.Add(dgvTransaksi);
            riwayatpanel.Controls.Add(totallabel_riwayat);
            riwayatpanel.Controls.Add(keluarbutton_riwayat);
            riwayatpanel.Controls.Add(riwayatbutton_riwayat);
            riwayatpanel.Controls.Add(transaksibutton_riwayat);
            riwayatpanel.Controls.Add(penawaranbutton_riwayat);
            riwayatpanel.Controls.Add(inputpanenbutton_riwayat);
            riwayatpanel.Controls.Add(dashboardbutton_riwayat);
            riwayatpanel.Controls.Add(lbnamauser_riwayat);
            riwayatpanel.Location = new Point(0, 0);
            riwayatpanel.Name = "riwayatpanel";
            riwayatpanel.Size = new Size(908, 555);
            riwayatpanel.TabIndex = 0;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.AllowUserToAddRows = false;
            dgvTransaksi.AllowUserToDeleteRows = false;
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransaksi.BackgroundColor = Color.MediumAquamarine;
            dgvTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaksi.Columns.AddRange(new DataGridViewColumn[] { colID, colDistributor, colNelayan, colBerat, colGrade, colHarga, colTotal, colTanggal, colStatus });
            dgvTransaksi.Location = new Point(268, 199);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.ReadOnly = true;
            dgvTransaksi.RowHeadersVisible = false;
            dgvTransaksi.RowHeadersWidth = 62;
            dgvTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransaksi.Size = new Size(619, 332);
            dgvTransaksi.TabIndex = 35;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 8;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colDistributor
            // 
            colDistributor.HeaderText = "Distributor";
            colDistributor.MinimumWidth = 8;
            colDistributor.Name = "colDistributor";
            colDistributor.ReadOnly = true;
            // 
            // colNelayan
            // 
            colNelayan.HeaderText = "Nelayan";
            colNelayan.MinimumWidth = 8;
            colNelayan.Name = "colNelayan";
            colNelayan.ReadOnly = true;
            // 
            // colBerat
            // 
            colBerat.HeaderText = "Berat";
            colBerat.MinimumWidth = 8;
            colBerat.Name = "colBerat";
            colBerat.ReadOnly = true;
            // 
            // colGrade
            // 
            colGrade.HeaderText = "Grade";
            colGrade.MinimumWidth = 8;
            colGrade.Name = "colGrade";
            colGrade.ReadOnly = true;
            // 
            // colHarga
            // 
            colHarga.HeaderText = "Harga (kg)";
            colHarga.MinimumWidth = 8;
            colHarga.Name = "colHarga";
            colHarga.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 8;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
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
            // totallabel_riwayat
            // 
            totallabel_riwayat.AutoSize = true;
            totallabel_riwayat.BackColor = Color.Transparent;
            totallabel_riwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totallabel_riwayat.Location = new Point(312, 131);
            totallabel_riwayat.Name = "totallabel_riwayat";
            totallabel_riwayat.Size = new Size(135, 25);
            totallabel_riwayat.TabIndex = 34;
            totallabel_riwayat.Text = "Loading Data..";
            // 
            // keluarbutton_riwayat
            // 
            keluarbutton_riwayat.BackColor = Color.Transparent;
            keluarbutton_riwayat.BackgroundImage = (Image)resources.GetObject("keluarbutton_riwayat.BackgroundImage");
            keluarbutton_riwayat.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_riwayat.Cursor = Cursors.Hand;
            keluarbutton_riwayat.FlatAppearance.BorderSize = 0;
            keluarbutton_riwayat.FlatStyle = FlatStyle.Flat;
            keluarbutton_riwayat.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_riwayat.Location = new Point(-17, 486);
            keluarbutton_riwayat.Name = "keluarbutton_riwayat";
            keluarbutton_riwayat.Size = new Size(110, 69);
            keluarbutton_riwayat.TabIndex = 33;
            keluarbutton_riwayat.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_riwayat.UseVisualStyleBackColor = false;
            keluarbutton_riwayat.Click += keluarbutton_riwayat_Click;
            // 
            // riwayatbutton_riwayat
            // 
            riwayatbutton_riwayat.BackColor = Color.Transparent;
            riwayatbutton_riwayat.FlatAppearance.BorderSize = 0;
            riwayatbutton_riwayat.FlatStyle = FlatStyle.Flat;
            riwayatbutton_riwayat.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            riwayatbutton_riwayat.Location = new Point(33, 264);
            riwayatbutton_riwayat.Name = "riwayatbutton_riwayat";
            riwayatbutton_riwayat.Size = new Size(180, 26);
            riwayatbutton_riwayat.TabIndex = 32;
            riwayatbutton_riwayat.Text = "RIWAYAT TRANSAKSI";
            riwayatbutton_riwayat.TextAlign = ContentAlignment.MiddleLeft;
            riwayatbutton_riwayat.UseVisualStyleBackColor = false;
            riwayatbutton_riwayat.Click += riwayatbutton_riwayat_Click;
            // 
            // transaksibutton_riwayat
            // 
            transaksibutton_riwayat.BackColor = Color.Transparent;
            transaksibutton_riwayat.FlatAppearance.BorderSize = 0;
            transaksibutton_riwayat.FlatStyle = FlatStyle.Flat;
            transaksibutton_riwayat.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            transaksibutton_riwayat.Location = new Point(39, 220);
            transaksibutton_riwayat.Name = "transaksibutton_riwayat";
            transaksibutton_riwayat.Size = new Size(105, 26);
            transaksibutton_riwayat.TabIndex = 31;
            transaksibutton_riwayat.Text = "TRANSAKSI";
            transaksibutton_riwayat.TextAlign = ContentAlignment.MiddleLeft;
            transaksibutton_riwayat.UseVisualStyleBackColor = false;
            transaksibutton_riwayat.Click += transaksibutton_riwayat_Click;
            // 
            // penawaranbutton_riwayat
            // 
            penawaranbutton_riwayat.BackColor = Color.Transparent;
            penawaranbutton_riwayat.FlatAppearance.BorderSize = 0;
            penawaranbutton_riwayat.FlatStyle = FlatStyle.Flat;
            penawaranbutton_riwayat.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            penawaranbutton_riwayat.Location = new Point(36, 191);
            penawaranbutton_riwayat.Name = "penawaranbutton_riwayat";
            penawaranbutton_riwayat.Size = new Size(180, 26);
            penawaranbutton_riwayat.TabIndex = 30;
            penawaranbutton_riwayat.Text = "PENAWARAN PANEN";
            penawaranbutton_riwayat.TextAlign = ContentAlignment.MiddleLeft;
            penawaranbutton_riwayat.UseVisualStyleBackColor = false;
            penawaranbutton_riwayat.Click += penawaranbutton_riwayat_Click;
            // 
            // inputpanenbutton_riwayat
            // 
            inputpanenbutton_riwayat.BackColor = Color.Transparent;
            inputpanenbutton_riwayat.FlatAppearance.BorderSize = 0;
            inputpanenbutton_riwayat.FlatStyle = FlatStyle.Flat;
            inputpanenbutton_riwayat.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            inputpanenbutton_riwayat.Location = new Point(36, 162);
            inputpanenbutton_riwayat.Name = "inputpanenbutton_riwayat";
            inputpanenbutton_riwayat.Size = new Size(143, 26);
            inputpanenbutton_riwayat.TabIndex = 29;
            inputpanenbutton_riwayat.Text = "KELOLA PANEN";
            inputpanenbutton_riwayat.TextAlign = ContentAlignment.MiddleLeft;
            inputpanenbutton_riwayat.UseVisualStyleBackColor = false;
            inputpanenbutton_riwayat.Click += inputpanenbutton_riwayat_Click;
            // 
            // dashboardbutton_riwayat
            // 
            dashboardbutton_riwayat.BackColor = Color.Transparent;
            dashboardbutton_riwayat.FlatAppearance.BorderSize = 0;
            dashboardbutton_riwayat.FlatStyle = FlatStyle.Flat;
            dashboardbutton_riwayat.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbutton_riwayat.Location = new Point(31, 114);
            dashboardbutton_riwayat.Name = "dashboardbutton_riwayat";
            dashboardbutton_riwayat.Size = new Size(119, 26);
            dashboardbutton_riwayat.TabIndex = 28;
            dashboardbutton_riwayat.Text = "DASHBOARD";
            dashboardbutton_riwayat.UseVisualStyleBackColor = false;
            dashboardbutton_riwayat.Click += dashboardbutton_riwayat_Click;
            // 
            // lbnamauser_riwayat
            // 
            lbnamauser_riwayat.AutoSize = true;
            lbnamauser_riwayat.BackColor = Color.Transparent;
            lbnamauser_riwayat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnamauser_riwayat.Location = new Point(92, 47);
            lbnamauser_riwayat.Name = "lbnamauser_riwayat";
            lbnamauser_riwayat.Size = new Size(88, 25);
            lbnamauser_riwayat.TabIndex = 27;
            lbnamauser_riwayat.Text = "Natachai";
            // 
            // RiwayatNelayan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(riwayatpanel);
            Name = "RiwayatNelayan";
            Size = new Size(908, 555);
            riwayatpanel.ResumeLayout(false);
            riwayatpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel riwayatpanel;
        private Label lbnamauser_riwayat;
        private Button dashboardbutton_riwayat;
        private Button inputpanenbutton_riwayat;
        private Button penawaranbutton_riwayat;
        private Button transaksibutton_riwayat;
        private Button riwayatbutton_riwayat;
        private Button keluarbutton_riwayat;
        private Label totallabel_riwayat;
        private DataGridView dgvTransaksi;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colDistributor;
        private DataGridViewTextBoxColumn colNelayan;
        private DataGridViewTextBoxColumn colBerat;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colHarga;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colTanggal;
        private DataGridViewTextBoxColumn colStatus;
    }
}
