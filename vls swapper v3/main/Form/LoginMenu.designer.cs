namespace vls_swapper_v3.Menus
{
    partial class LoginMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginMenu));
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rememberMe = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.freeButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txt2FA = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Depth = 0;
            this.txtPassword.Hint = "Enter your password...";
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
            this.txtPassword.Click += new System.EventHandler(this.txtPassword_Click);
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
            // rememberMe
            // 
            this.rememberMe.AutoSize = true;
            this.rememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rememberMe.Depth = 0;
            this.rememberMe.Font = new System.Drawing.Font("Roboto", 10F);
            this.rememberMe.Location = new System.Drawing.Point(22, 299);
            this.rememberMe.Margin = new System.Windows.Forms.Padding(0);
            this.rememberMe.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rememberMe.MouseState = MaterialSkin.MouseState.HOVER;
            this.rememberMe.Name = "rememberMe";
            this.rememberMe.Ripple = true;
            this.rememberMe.Size = new System.Drawing.Size(120, 30);
            this.rememberMe.TabIndex = 41;
            this.rememberMe.Text = "Remember Me";
            this.rememberMe.UseVisualStyleBackColor = true;
            this.rememberMe.CheckedChanged += new System.EventHandler(this.rememberMe_CheckedChanged);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(22, 449);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(315, 30);
            this.materialRaisedButton2.TabIndex = 40;
            this.materialRaisedButton2.Text = "BUY/register";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(22, 341);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(315, 30);
            this.materialRaisedButton1.TabIndex = 39;
            this.materialRaisedButton1.Text = "LOGIN";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // freeButton
            // 
            this.freeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.freeButton.Depth = 0;
            this.freeButton.Location = new System.Drawing.Point(22, 413);
            this.freeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.freeButton.Name = "freeButton";
            this.freeButton.Primary = true;
            this.freeButton.Size = new System.Drawing.Size(315, 30);
            this.freeButton.TabIndex = 38;
            this.freeButton.Text = "FREE";
            this.freeButton.UseVisualStyleBackColor = true;
            this.freeButton.Click += new System.EventHandler(this.freeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(153, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 40);
            this.label1.TabIndex = 37;
            this.label1.Text = "Login Page";
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Location = new System.Drawing.Point(22, 377);
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
            this.txt2FA.Location = new System.Drawing.Point(22, 348);
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
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(12, 28);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(142, 25);
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // LoginMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 490);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rememberMe);
            this.Controls.Add(this.materialRaisedButton3);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.freeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt2FA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginMenu";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vls swapper v3";
            this.Load += new System.EventHandler(this.LoginMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUsername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialCheckBox rememberMe;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton freeButton;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txt2FA;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}