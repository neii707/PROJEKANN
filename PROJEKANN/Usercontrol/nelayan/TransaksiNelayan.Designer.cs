namespace PROJEKANN.Usercontrol.nelayan
{
    partial class TransaksiNelayan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransaksiNelayan));
            konfirmasi_transaksi = new Button();
            dgvtransaksi = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colDistributor = new DataGridViewTextBoxColumn();
            colBerat = new DataGridViewTextBoxColumn();
            total_pembayaran = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            keluarbutton_transaksi = new Button();
            riwayatbutton_transaksi = new Button();
            transaksibutton_transaksi = new Button();
            penawaranbutton_transaksi = new Button();
            inputpanenbutton_transaksi = new Button();
            dashboardbutton_transaksi = new Button();
            lbnamauser_transaksi = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvtransaksi).BeginInit();
            SuspendLayout();
            // 
            // konfirmasi_transaksi
            // 
            konfirmasi_transaksi.BackColor = Color.LimeGreen;
            konfirmasi_transaksi.FlatAppearance.BorderSize = 0;
            konfirmasi_transaksi.FlatStyle = FlatStyle.Flat;
            konfirmasi_transaksi.Font = new Font("Calibri", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            konfirmasi_transaksi.Location = new Point(325, 624);
            konfirmasi_transaksi.Name = "konfirmasi_transaksi";
            konfirmasi_transaksi.Size = new Size(176, 49);
            konfirmasi_transaksi.TabIndex = 35;
            konfirmasi_transaksi.Text = "KONFIRMASI";
            konfirmasi_transaksi.UseVisualStyleBackColor = false;
            konfirmasi_transaksi.Click += konfirmasi_transaksi_Click;
            // 
            // dgvtransaksi
            // 
            dgvtransaksi.AllowUserToAddRows = false;
            dgvtransaksi.AllowUserToDeleteRows = false;
            dgvtransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvtransaksi.BackgroundColor = Color.MediumAquamarine;
            dgvtransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvtransaksi.Columns.AddRange(new DataGridViewColumn[] { colID, colDistributor, colBerat, total_pembayaran, colStatus });
            dgvtransaksi.Location = new Point(315, 181);
            dgvtransaksi.Name = "dgvtransaksi";
            dgvtransaksi.ReadOnly = true;
            dgvtransaksi.RowHeadersVisible = false;
            dgvtransaksi.RowHeadersWidth = 62;
            dgvtransaksi.Size = new Size(806, 425);
            dgvtransaksi.TabIndex = 34;
            dgvtransaksi.CellContentClick += dgvtransaksi_CellContentClick;
            // 
            // colID
            // 
            colID.HeaderText = "id_panen";
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
            // colBerat
            // 
            colBerat.HeaderText = "Berat (kg)";
            colBerat.MinimumWidth = 8;
            colBerat.Name = "colBerat";
            colBerat.ReadOnly = true;
            // 
            // total_pembayaran
            // 
            total_pembayaran.DataPropertyName = "total_pembayaran";
            total_pembayaran.HeaderText = "total_pembayaran";
            total_pembayaran.MinimumWidth = 8;
            total_pembayaran.Name = "total_pembayaran";
            total_pembayaran.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 8;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // keluarbutton_transaksi
            // 
            keluarbutton_transaksi.BackColor = Color.Transparent;
            keluarbutton_transaksi.BackgroundImage = (Image)resources.GetObject("keluarbutton_transaksi.BackgroundImage");
            keluarbutton_transaksi.BackgroundImageLayout = ImageLayout.Stretch;
            keluarbutton_transaksi.Cursor = Cursors.Hand;
            keluarbutton_transaksi.FlatAppearance.BorderSize = 0;
            keluarbutton_transaksi.FlatStyle = FlatStyle.Flat;
            keluarbutton_transaksi.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            keluarbutton_transaksi.Location = new Point(-21, 624);
            keluarbutton_transaksi.Name = "keluarbutton_transaksi";
            keluarbutton_transaksi.Size = new Size(110, 69);
            keluarbutton_transaksi.TabIndex = 33;
            keluarbutton_transaksi.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_transaksi.UseVisualStyleBackColor = false;
            keluarbutton_transaksi.Click += keluarbutton_transaksi_Click;
            // 
            // riwayatbutton_transaksi
            // 
            riwayatbutton_transaksi.BackColor = Color.Transparent;
            riwayatbutton_transaksi.FlatAppearance.BorderSize = 0;
            riwayatbutton_transaksi.FlatStyle = FlatStyle.Flat;
            riwayatbutton_transaksi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            riwayatbutton_transaksi.Location = new Point(46, 327);
            riwayatbutton_transaksi.Name = "riwayatbutton_transaksi";
            riwayatbutton_transaksi.Size = new Size(225, 40);
            riwayatbutton_transaksi.TabIndex = 32;
            riwayatbutton_transaksi.Text = "RIWAYAT TRANSAKSI";
            riwayatbutton_transaksi.TextAlign = ContentAlignment.MiddleLeft;
            riwayatbutton_transaksi.UseVisualStyleBackColor = false;
            riwayatbutton_transaksi.Click += riwayatbutton_transaksi_Click;
            // 
            // transaksibutton_transaksi
            // 
            transaksibutton_transaksi.BackColor = Color.Transparent;
            transaksibutton_transaksi.FlatAppearance.BorderSize = 0;
            transaksibutton_transaksi.FlatStyle = FlatStyle.Flat;
            transaksibutton_transaksi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            transaksibutton_transaksi.Location = new Point(46, 267);
            transaksibutton_transaksi.Name = "transaksibutton_transaksi";
            transaksibutton_transaksi.Size = new Size(143, 41);
            transaksibutton_transaksi.TabIndex = 31;
            transaksibutton_transaksi.Text = "TRANSAKSI";
            transaksibutton_transaksi.TextAlign = ContentAlignment.MiddleLeft;
            transaksibutton_transaksi.UseVisualStyleBackColor = false;
            transaksibutton_transaksi.Click += transaksibutton_transaksi_Click;
            // 
            // penawaranbutton_transaksi
            // 
            penawaranbutton_transaksi.BackColor = Color.Transparent;
            penawaranbutton_transaksi.FlatAppearance.BorderSize = 0;
            penawaranbutton_transaksi.FlatStyle = FlatStyle.Flat;
            penawaranbutton_transaksi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            penawaranbutton_transaksi.Location = new Point(46, 233);
            penawaranbutton_transaksi.Name = "penawaranbutton_transaksi";
            penawaranbutton_transaksi.Size = new Size(180, 35);
            penawaranbutton_transaksi.TabIndex = 30;
            penawaranbutton_transaksi.Text = "PENAWARAN PANEN";
            penawaranbutton_transaksi.TextAlign = ContentAlignment.MiddleLeft;
            penawaranbutton_transaksi.UseVisualStyleBackColor = false;
            penawaranbutton_transaksi.Click += penawaranbutton_transaksi_Click;
            // 
            // inputpanenbutton_transaksi
            // 
            inputpanenbutton_transaksi.BackColor = Color.Transparent;
            inputpanenbutton_transaksi.FlatAppearance.BorderSize = 0;
            inputpanenbutton_transaksi.FlatStyle = FlatStyle.Flat;
            inputpanenbutton_transaksi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            inputpanenbutton_transaksi.Location = new Point(47, 198);
            inputpanenbutton_transaksi.Name = "inputpanenbutton_transaksi";
            inputpanenbutton_transaksi.Size = new Size(180, 38);
            inputpanenbutton_transaksi.TabIndex = 29;
            inputpanenbutton_transaksi.Text = "KELOLA PANEN";
            inputpanenbutton_transaksi.TextAlign = ContentAlignment.MiddleLeft;
            inputpanenbutton_transaksi.UseVisualStyleBackColor = false;
            inputpanenbutton_transaksi.Click += inputpanenbutton_transaksi_Click;
            // 
            // dashboardbutton_transaksi
            // 
            dashboardbutton_transaksi.BackColor = Color.Transparent;
            dashboardbutton_transaksi.FlatAppearance.BorderSize = 0;
            dashboardbutton_transaksi.FlatStyle = FlatStyle.Flat;
            dashboardbutton_transaksi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dashboardbutton_transaksi.Location = new Point(47, 138);
            dashboardbutton_transaksi.Name = "dashboardbutton_transaksi";
            dashboardbutton_transaksi.Size = new Size(146, 45);
            dashboardbutton_transaksi.TabIndex = 28;
            dashboardbutton_transaksi.Text = "DASHBOARD";
            dashboardbutton_transaksi.UseVisualStyleBackColor = false;
            dashboardbutton_transaksi.Click += dashboardbutton_transaksi_Click;
            // 
            // lbnamauser_transaksi
            // 
            lbnamauser_transaksi.AutoSize = true;
            lbnamauser_transaksi.BackColor = Color.Transparent;
            lbnamauser_transaksi.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbnamauser_transaksi.Location = new Point(102, 59);
            lbnamauser_transaksi.Name = "lbnamauser_transaksi";
            lbnamauser_transaksi.Size = new Size(123, 36);
            lbnamauser_transaksi.TabIndex = 27;
            lbnamauser_transaksi.Text = "Natachai";
            // 
            // TransaksiNelayan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LOGIN__6_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(konfirmasi_transaksi);
            Controls.Add(dgvtransaksi);
            Controls.Add(keluarbutton_transaksi);
            Controls.Add(riwayatbutton_transaksi);
            Controls.Add(transaksibutton_transaksi);
            Controls.Add(penawaranbutton_transaksi);
            Controls.Add(inputpanenbutton_transaksi);
            Controls.Add(dashboardbutton_transaksi);
            Controls.Add(lbnamauser_transaksi);
            Name = "TransaksiNelayan";
            Size = new Size(1135, 690);
            Load += TransaksiNelayan_Load;
            ((System.ComponentModel.ISupportInitialize)dgvtransaksi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbnamauser_transaksi;
        private Button dashboardbutton_transaksi;
        private Button inputpanenbutton_transaksi;
        private Button penawaranbutton_transaksi;
        private Button transaksibutton_transaksi;
        private Button riwayatbutton_transaksi;
        private Button keluarbutton_transaksi;
        private DataGridView dgvtransaksi;
        private Button konfirmasi_transaksi;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn colDistributor;
        private DataGridViewTextBoxColumn colBerat;
        private DataGridViewTextBoxColumn total_pembayaran;
        private DataGridViewTextBoxColumn colStatus;
    }
}
