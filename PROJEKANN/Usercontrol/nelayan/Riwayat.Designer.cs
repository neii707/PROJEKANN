namespace PROJEKANN.Usercontrol
{
    partial class Riwayat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Riwayat));
            panelriwayat = new FlowLayoutPanel();
            dashboardbutton_transaksi = new Button();
            panelriwayat.SuspendLayout();
            SuspendLayout();
            // 
            // panelriwayat
            // 
            panelriwayat.BackgroundImage = (Image)resources.GetObject("panelriwayat.BackgroundImage");
            panelriwayat.BackgroundImageLayout = ImageLayout.Stretch;
            panelriwayat.Controls.Add(dashboardbutton_transaksi);
            panelriwayat.Location = new Point(0, 0);
            panelriwayat.Name = "panelriwayat";
            panelriwayat.Size = new Size(908, 555);
            panelriwayat.TabIndex = 0;
            // 
            // dashboardbutton_transaksi
            // 
            dashboardbutton_transaksi.BackColor = Color.Transparent;
            dashboardbutton_transaksi.FlatAppearance.BorderSize = 0;
            dashboardbutton_transaksi.FlatStyle = FlatStyle.Flat;
            dashboardbutton_transaksi.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboardbutton_transaksi.Location = new Point(3, 3);
            dashboardbutton_transaksi.Name = "dashboardbutton_transaksi";
            dashboardbutton_transaksi.Size = new Size(119, 26);
            dashboardbutton_transaksi.TabIndex = 29;
            dashboardbutton_transaksi.Text = "DASHBOARD";
            dashboardbutton_transaksi.UseVisualStyleBackColor = false;
            // 
            // Riwayat
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelriwayat);
            Name = "Riwayat";
            Size = new Size(908, 555);
            panelriwayat.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelriwayat;
        private Button dashboardbutton_transaksi;
    }
}
