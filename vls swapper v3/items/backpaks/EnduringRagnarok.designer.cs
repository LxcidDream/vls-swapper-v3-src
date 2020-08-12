namespace vls_swapper_v3.Backblings
{
    // Token: 0x020000B2 RID: 178
    public partial class EnduringRagnarok : global::MaterialSkin.Controls.MaterialForm
    {
        // Token: 0x06000A1E RID: 2590 RVA: 0x000D07D4 File Offset: 0x000CE9D4
        protected override void Dispose(bool disposing)
        {
            bool flag = disposing && this.components != null;
            if (flag)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Token: 0x06000A1F RID: 2591 RVA: 0x000D080C File Offset: 0x000CEA0C
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnduringRagnarok));
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
            this.RichTextBoxInfo.Location = new System.Drawing.Point(281, 78);
            this.RichTextBoxInfo.Name = "RichTextBoxInfo";
            this.RichTextBoxInfo.ReadOnly = true;
            this.RichTextBoxInfo.Size = new System.Drawing.Size(147, 157);
            this.RichTextBoxInfo.TabIndex = 86;
            this.RichTextBoxInfo.Text = "";
            // 
            // revert
            // 
            this.revert.Depth = 0;
            this.revert.Location = new System.Drawing.Point(174, 115);
            this.revert.MouseState = MaterialSkin.MouseState.HOVER;
            this.revert.Name = "revert";
            this.revert.Primary = true;
            this.revert.Size = new System.Drawing.Size(96, 31);
            this.revert.TabIndex = 88;
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
            this.convert.TabIndex = 87;
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 90;
            this.pictureBox1.TabStop = false;
            // 
            // EnduringRagnarok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(440, 250);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RichTextBoxInfo);
            this.Controls.Add(this.revert);
            this.Controls.Add(this.convert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EnduringRagnarok";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GhoulTrooper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        // Token: 0x04000FD7 RID: 4055
        private global::System.ComponentModel.IContainer components = null;

        // Token: 0x04000FD8 RID: 4056
        private global::System.Windows.Forms.RichTextBox RichTextBoxInfo;

        // Token: 0x04000FDA RID: 4058
        private global::MaterialSkin.Controls.MaterialRaisedButton revert;

        // Token: 0x04000FDB RID: 4059
        private global::MaterialSkin.Controls.MaterialRaisedButton convert;

        // Token: 0x04000FDC RID: 4060
        private global::System.ComponentModel.BackgroundWorker revert1Bytes;

        // Token: 0x04000FDD RID: 4061
        private global::System.ComponentModel.BackgroundWorker change1Bytes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
