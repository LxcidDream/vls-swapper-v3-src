namespace vls_swapper_v3.items
{
    partial class accountinfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accountinfo));
            this.username = new System.Windows.Forms.Label();
            this.HWID = new System.Windows.Forms.Label();
            this.ExpirationDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Transparent;
            this.username.Location = new System.Drawing.Point(13, 209);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(0, 20);
            this.username.TabIndex = 11;
            // 
            // HWID
            // 
            this.HWID.AutoSize = true;
            this.HWID.BackColor = System.Drawing.Color.Transparent;
            this.HWID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HWID.ForeColor = System.Drawing.Color.Transparent;
            this.HWID.Location = new System.Drawing.Point(13, 245);
            this.HWID.Name = "HWID";
            this.HWID.Size = new System.Drawing.Size(0, 20);
            this.HWID.TabIndex = 13;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.AutoSize = true;
            this.ExpirationDate.BackColor = System.Drawing.Color.Transparent;
            this.ExpirationDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpirationDate.ForeColor = System.Drawing.Color.Transparent;
            this.ExpirationDate.Location = new System.Drawing.Point(13, 284);
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.Size = new System.Drawing.Size(0, 20);
            this.ExpirationDate.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(387, 284);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(100, 27);
            this.materialRaisedButton2.TabIndex = 187;
            this.materialRaisedButton2.Text = "ok";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // accountinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 319);
            this.ControlBox = false;
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ExpirationDate);
            this.Controls.Add(this.HWID);
            this.Controls.Add(this.username);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "accountinfo";
            this.Sizable = false;
            this.Text = "Premium Account Info";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label HWID;
        private System.Windows.Forms.Label ExpirationDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
    }
}