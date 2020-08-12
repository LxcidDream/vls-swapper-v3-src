namespace vls_swapper_v3.Menus
{
    partial class ResetPass
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPass));
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txt2FA = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNewPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtNewPasswordCheck = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Depth = 0;
            this.txtPassword.Hint = "Enter your old password...";
            this.txtPassword.Location = new System.Drawing.Point(22, 256);
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(315, 23);
            this.txtPassword.TabIndex = 36;
            this.txtPassword.UseSystemPasswordChar = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Depth = 0;
            this.txtUsername.Hint = "Enter your username...";
            this.txtUsername.Location = new System.Drawing.Point(22, 214);
            this.txtUsername.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.Size = new System.Drawing.Size(315, 23);
            this.txtUsername.TabIndex = 35;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(153, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 37);
            this.label1.TabIndex = 37;
            this.label1.Text = "Reset Password";
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Location = new System.Drawing.Point(22, 432);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(315, 30);
            this.materialRaisedButton3.TabIndex = 40;
            this.materialRaisedButton3.Text = "RESET PASSWORD";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            this.materialRaisedButton3.Click += new System.EventHandler(this.materialRaisedButton3_Click);
            // 
            // txt2FA
            // 
            this.txt2FA.Depth = 0;
            this.txt2FA.Hint = "Enter your 2FA code (leave blank if disabled)";
            this.txt2FA.Location = new System.Drawing.Point(22, 382);
            this.txt2FA.MouseState = MaterialSkin.MouseState.HOVER;
            this.txt2FA.Name = "txt2FA";
            this.txt2FA.PasswordChar = '\0';
            this.txt2FA.SelectedText = "";
            this.txt2FA.SelectionLength = 0;
            this.txt2FA.SelectionStart = 0;
            this.txt2FA.Size = new System.Drawing.Size(315, 23);
            this.txt2FA.TabIndex = 36;
            this.txt2FA.UseSystemPasswordChar = false;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Depth = 0;
            this.txtNewPassword.Hint = "Enter your new password...";
            this.txtNewPassword.Location = new System.Drawing.Point(22, 298);
            this.txtNewPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.SelectionLength = 0;
            this.txtNewPassword.SelectionStart = 0;
            this.txtNewPassword.Size = new System.Drawing.Size(315, 23);
            this.txtNewPassword.TabIndex = 36;
            this.txtNewPassword.UseSystemPasswordChar = false;
            // 
            // txtNewPasswordCheck
            // 
            this.txtNewPasswordCheck.Depth = 0;
            this.txtNewPasswordCheck.Hint = "Confirm your new password...";
            this.txtNewPasswordCheck.Location = new System.Drawing.Point(22, 340);
            this.txtNewPasswordCheck.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNewPasswordCheck.Name = "txtNewPasswordCheck";
            this.txtNewPasswordCheck.PasswordChar = '•';
            this.txtNewPasswordCheck.SelectedText = "";
            this.txtNewPasswordCheck.SelectionLength = 0;
            this.txtNewPasswordCheck.SelectionStart = 0;
            this.txtNewPasswordCheck.Size = new System.Drawing.Size(315, 23);
            this.txtNewPasswordCheck.TabIndex = 36;
            this.txtNewPasswordCheck.UseSystemPasswordChar = false;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(22, 468);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(315, 30);
            this.materialRaisedButton1.TabIndex = 40;
            this.materialRaisedButton1.Text = "CANCEL";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // ResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 510);
            this.Controls.Add(this.txt2FA);
            this.Controls.Add(this.txtNewPasswordCheck);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.materialRaisedButton3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ResetPass";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vls swapper v3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt2FA;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNewPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNewPasswordCheck;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}