namespace PROJEKANN.Usercontrol
{
    partial class login
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
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            passworduser = new TextBox();
            lblNamaUser = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(passworduser);
            panel1.Controls.Add(lblNamaUser);
            panel1.Location = new Point(0, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(902, 549);
            panel1.TabIndex = 5;
            // 
            // button2
            // 
            button2.BackColor = Color.SeaGreen;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(593, 457);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 8;
            button2.Text = "REGISTER";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(593, 388);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 7;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // passworduser
            // 
            passworduser.BorderStyle = BorderStyle.None;
            passworduser.Font = new Font("Segoe UI", 5F);
            passworduser.Location = new Point(562, 345);
            passworduser.Name = "passworduser";
            passworduser.Size = new Size(163, 14);
            passworduser.TabIndex = 6;
            passworduser.TextChanged += textBox4_TextChanged_1;
            // 
            // lblNamaUser
            // 
            lblNamaUser.BorderStyle = BorderStyle.None;
            lblNamaUser.Font = new Font("Segoe UI", 5F);
            lblNamaUser.Location = new Point(562, 286);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(163, 14);
            lblNamaUser.TabIndex = 5;
            lblNamaUser.TextChanged += textBox3_TextChanged;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.new_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(panel1);
            Name = "login";
            Size = new Size(908, 555);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button button1;
        private TextBox passworduser;
        private TextBox lblNamaUser;
        private Button button2;
    }
}
