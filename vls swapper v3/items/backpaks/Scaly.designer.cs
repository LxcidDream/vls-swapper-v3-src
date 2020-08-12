namespace vls_swapper_v3.Backblings
{
	// Token: 0x020000BA RID: 186
	public partial class Scaly : global::MaterialSkin.Controls.MaterialForm
	{
		// Token: 0x06000A86 RID: 2694 RVA: 0x000D8018 File Offset: 0x000D6218
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x000D8050 File Offset: 0x000D6250
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scaly));
            this.RichTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.revert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.convert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.revert1Bytes = new System.ComponentModel.BackgroundWorker();
            this.change1Bytes = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RichTextBoxInfo
            // 
            this.RichTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.RichTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxInfo.ForeColor = System.Drawing.Color.White;
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 79);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 126;
            this.RichTextBoxInfo.Text = "";
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 116);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 128;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.Click += new System.EventHandler(this.revert_Click);
            // 
            // convert
            // 
            this.convert.Depth = 0;
            this.convert.Location = new System.Drawing.Point(174, 79);
            this.convert.MouseState = MaterialSkin.MouseState.HOVER;
            this.convert.Name = "convert";
            this.convert.Primary = true;
            this.convert.Size = new System.Drawing.Size(96, 31);
            this.convert.TabIndex = 127;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // revert1Bytes
            // 
            this.revert1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RevertBytes_DoWork);
            // 
            // change1Bytes
            // 
            this.change1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChangeBytes_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 130;
            this.pictureBox1.TabStop = false;
            // 
            // Scaly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(440, 251);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RichTextBoxInfo);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Scaly";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GhoulTrooper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x0400107A RID: 4218
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400107B RID: 4219
		private global::System.Windows.Forms.RichTextBox RichTextBoxInfo;

		// Token: 0x0400107D RID: 4221
		private global::MaterialSkin.Controls.MaterialRaisedButton revert;

		// Token: 0x0400107E RID: 4222
		private global::MaterialSkin.Controls.MaterialRaisedButton convert;

		// Token: 0x0400107F RID: 4223
		private global::System.ComponentModel.BackgroundWorker revert1Bytes;

		// Token: 0x04001080 RID: 4224
		private global::System.ComponentModel.BackgroundWorker change1Bytes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
