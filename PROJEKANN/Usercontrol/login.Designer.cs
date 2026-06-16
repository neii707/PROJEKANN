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
            button2 = new Button();
            button1 = new Button();
            passworduser = new TextBox();
            lblNamaUser = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = Color.SeaGreen;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(754, 579);
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
            button1.Location = new Point(754, 494);
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
            passworduser.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passworduser.Location = new Point(703, 434);
            passworduser.Name = "passworduser";
            passworduser.Size = new Size(194, 22);
            passworduser.TabIndex = 6;
            passworduser.TextChanged += textBox4_TextChanged_1;
            // 
            // lblNamaUser
            // 
            lblNamaUser.BorderStyle = BorderStyle.None;
            lblNamaUser.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNamaUser.Location = new Point(703, 361);
            lblNamaUser.Name = "lblNamaUser";
            lblNamaUser.Size = new Size(194, 22);
            lblNamaUser.TabIndex = 5;
            lblNamaUser.TextChanged += textBox3_TextChanged;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.new_login;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lblNamaUser);
            Controls.Add(passworduser);
            Name = "login";
            Size = new Size(1135, 690);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox passworduser;
        private TextBox lblNamaUser;
        private Button button2;
    }
}
