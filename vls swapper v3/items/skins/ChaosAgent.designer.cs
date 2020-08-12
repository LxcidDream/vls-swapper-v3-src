namespace vls_swapper_v3.Skins
{
	// Token: 0x0200002F RID: 47
	public partial class ChaosAgent : global::MaterialSkin.Controls.MaterialForm
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x00038B0C File Offset: 0x00036D0C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00038B44 File Offset: 0x00036D44
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChaosAgent));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.revert1Bytes = new System.ComponentModel.BackgroundWorker();
            this.change1Bytes = new System.ComponentModel.BackgroundWorker();
            this.revert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.convert = new MaterialSkin.Controls.MaterialRaisedButton();
            this.RichTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 2;
            this.bunifuElipse1.TargetControl = this;
            // 
            // revert1Bytes
            // 
            this.revert1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RevertBytes_DoWork);
            // 
            // change1Bytes
            // 
            this.change1Bytes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChangeBytes_DoWork);
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 115);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 83;
            this.revert.Text = "Revert";
            this.revert.UseVisualStyleBackColor = true;
            this.revert.Click += new System.EventHandler(this.revert_Click);
            // 
            // convert
            // 
            this.convert.Depth = 0;
            this.convert.Location = new System.Drawing.Point(174, 78);
            this.convert.MouseState = MaterialSkin.MouseState.HOVER;
            this.convert.Name = "convert";
            this.convert.Primary = true;
            this.convert.Size = new System.Drawing.Size(96, 31);
            this.convert.TabIndex = 85;
            this.convert.Text = "Convert";
            this.convert.UseVisualStyleBackColor = true;
            this.convert.Click += new System.EventHandler(this.convert_Click);
            // 
            // RichTextBoxInfo
            // 
            this.RichTextBoxInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.RichTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBoxInfo.ForeColor = System.Drawing.Color.White;
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 78);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 82;
            this.RichTextBoxInfo.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // ChaosAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(440, 248);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Controls.Add(this.RichTextBoxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChaosAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GingerGunner";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000365 RID: 869
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000366 RID: 870
		private global::Bunifu.Framework.UI.BunifuElipse bunifuElipse1;

		// Token: 0x04000367 RID: 871
		private global::System.ComponentModel.BackgroundWorker revert1Bytes;

		// Token: 0x04000368 RID: 872
		private global::System.ComponentModel.BackgroundWorker change1Bytes;

		// Token: 0x04000369 RID: 873
		private global::MaterialSkin.Controls.MaterialRaisedButton revert;

		// Token: 0x0400036A RID: 874
		private global::MaterialSkin.Controls.MaterialRaisedButton convert;

		// Token: 0x0400036C RID: 876
		private global::System.Windows.Forms.RichTextBox RichTextBoxInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
