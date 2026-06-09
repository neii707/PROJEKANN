namespace PROJEKANN.Usercontrol.admin
{
    partial class monitor_stok
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(monitor_stok));
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            label5 = new Label();
            keluarbutton_dashboard = new Button();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(81, 54);
            label5.Name = "label5";
            label5.Size = new Size(63, 25);
            label5.TabIndex = 17;
            label5.Text = "label5";
            label5.Click += label5_Click;
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
            keluarbutton_dashboard.Location = new Point(-14, 509);
            keluarbutton_dashboard.Name = "keluarbutton_dashboard";
            keluarbutton_dashboard.Size = new Size(85, 46);
            keluarbutton_dashboard.TabIndex = 15;
            keluarbutton_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            keluarbutton_dashboard.UseVisualStyleBackColor = false;
            keluarbutton_dashboard.Click += keluarbutton_dashboard_Click;
            // 
            // cartesianChart1
            // 
            cartesianChart1.AutoUpdateEnabled = true;
            cartesianChart1.ChartTheme = null;
            skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend1.Content = null;
            skDefaultLegend1.IsValid = false;
            skDefaultLegend1.Opacity = 1F;
            padding1.Bottom = 0F;
            padding1.Left = 0F;
            padding1.Right = 0F;
            padding1.Top = 0F;
            skDefaultLegend1.Padding = padding1;
            skDefaultLegend1.RemoveOnCompleted = false;
            skDefaultLegend1.RotateTransform = 0F;
            skDefaultLegend1.X = 0F;
            skDefaultLegend1.Y = 0F;
            cartesianChart1.Legend = skDefaultLegend1;
            cartesianChart1.Location = new Point(282, 108);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(580, 400);
            cartesianChart1.TabIndex = 23;
            skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip1.Content = null;
            skDefaultTooltip1.IsValid = false;
            skDefaultTooltip1.Opacity = 1F;
            padding2.Bottom = 0F;
            padding2.Left = 0F;
            padding2.Right = 0F;
            padding2.Top = 0F;
            skDefaultTooltip1.Padding = padding2;
            skDefaultTooltip1.RemoveOnCompleted = false;
            skDefaultTooltip1.RotateTransform = 0F;
            skDefaultTooltip1.Wedge = 10;
            skDefaultTooltip1.X = 0F;
            skDefaultTooltip1.Y = 0F;
            cartesianChart1.Tooltip = skDefaultTooltip1;
            cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            cartesianChart1.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            cartesianChart1.Load += cartesianChart1_Load;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(31, 260);
            button5.Name = "button5";
            button5.Size = new Size(219, 34);
            button5.TabIndex = 22;
            button5.Text = "MONITOR TRANSAKSI";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(31, 222);
            button4.Name = "button4";
            button4.Size = new Size(219, 34);
            button4.TabIndex = 21;
            button4.Text = "MONITOR STOK";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(31, 186);
            button3.Name = "button3";
            button3.Size = new Size(175, 34);
            button3.TabIndex = 20;
            button3.Text = "KELOLA DEMAND";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(31, 147);
            button6.Name = "button6";
            button6.Size = new Size(149, 34);
            button6.TabIndex = 19;
            button6.Text = "KELOLA AKUN";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(31, 110);
            button7.Name = "button7";
            button7.Size = new Size(135, 34);
            button7.TabIndex = 18;
            button7.Text = "DASHBOARD";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // monitor_stok
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.stok;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(keluarbutton_dashboard);
            Controls.Add(button3);
            Controls.Add(button6);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(cartesianChart1);
            Controls.Add(label5);
            Name = "monitor_stok";
            Size = new Size(908, 555);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button6;
        private Button button7;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private Button keluarbutton_dashboard;
        private Label label5;
    }
}
