﻿using vls_swapper_v3.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using vls_swapper_v3;
using System.IO;
using System.Windows.Forms;
using vls_swapper_v3.main.popups;
using System.Globalization;
using vls_swapper_v3.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace vls_swapper_v3.items.skins
{
    public partial class arialasualt : MaterialForm
    {
		Point lastPoint;
		CultureInfo culture = CultureInfo.CurrentUICulture;
		string enable = Resources.enabled;
		string disabled = Resources.disabled;
		string actsomewhelse = Resources.alreadydone;
		string paksinvalid = Resources.pathinvalid;
		string error = Resources.error;
		MaterialSkinManager skinManager = MaterialSkinManager.Instance;
		public arialasualt()
        {
            InitializeComponent(); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon)); Icon = ((System.Drawing.Icon)(Resources.tumblr_aa9595fd4142b5c8982167f16ee70617_7e8b2860_640_yVE_icon));
			this.skinManager.AddFormToManage(this);
			this.skinManager.Theme = MaterialSkinManager.Themes.DARK;
			bool flag = Settings.Default.ismode;
			bool flag2 = flag;
			bool enabledmode = !Settings.Default.ismode; if (enabledmode) { skinManager.ColorScheme = new ColorScheme(Primary.DeepPurple500, Primary.Grey900, Primary.Grey900, Accent.DeepPurple400, TextShade.WHITE); } else { skinManager.ColorScheme = new ColorScheme(Primary.Pink500, Primary.Grey900, Primary.Grey900, Accent.Pink400, TextShade.WHITE); }
			this.Text = "Aerial Assault Trooper";
			
			bool AerialEnabled = Settings.Default.AerialEnabled;
			bool flag3 = AerialEnabled;
			if (flag3)
			{
				this.revert.Enabled = true;
				this.materialRaisedButton1.Enabled = false;
			}
			else
			{
				this.revert.Enabled = false;
				this.materialRaisedButton1.Enabled = true;
			}
		}



































		private static byte[] byte_0 = new byte[]
	{
		67,
		73,
		68,
		95,
		48,
		49,
		55,
		95,
		65,
		116,
		104,
		101,
		110,
		97,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		77,
		46,
		67,
		73,
		68,
		95,
		48,
		49,
		55,
		95,
		65,
		116,
		104,
		101,
		110,
		97,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		77,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0
	};

		// Token: 0x04000B26 RID: 2854
		private static byte[] byte_1 = new byte[]
		{
		67,
		73,
		68,
		95,
		50,
		57,
		52,
		95,
		65,
		116,
		104,
		101,
		110,
		97,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		70,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		87,
		105,
		110,
		116,
		101,
		114,
		46,
		67,
		73,
		68,
		95,
		50,
		57,
		52,
		95,
		65,
		116,
		104,
		101,
		110,
		97,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		70,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		87,
		105,
		110,
		116,
		101,
		114
		};

		// Token: 0x04000B27 RID: 2855
		private static byte[] byte_2 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		116,
		104,
		101,
		110,
		97,
		47,
		72,
		101,
		114,
		111,
		101,
		115,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		67,
		80,
		95,
		66,
		111,
		100,
		121,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		70,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		18,
		130,
		155,
		123,
		69,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		97,
		115,
		101,
		47,
		83,
		75,
		95,
		77,
		95,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		66,
		97,
		115,
		101,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		0,
		100,
		205,
		113,
		128,
		95,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		97,
		115,
		101,
		47,
		83,
		75,
		95,
		77,
		95,
		77,
		65,
		76,
		69,
		95,
		66,
		97,
		115,
		101,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		46,
		83,
		75,
		95,
		77,
		95,
		77,
		65,
		76,
		69,
		95,
		66,
		97,
		115,
		101,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		211,
		180,
		18,
		27,
		86,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		0,
		62,
		99,
		223,
		70,
		103,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		114,
		111,
		110,
		116,
		111,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		114,
		111,
		110,
		116,
		111,
		46,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		114,
		111,
		110,
		116,
		111,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		30,
		191,
		47,
		134,
		102,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		95,
		65,
		110,
		105,
		109,
		66,
		80,
		0,
		88,
		94,
		162,
		58,
		137,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		114,
		111,
		110,
		116,
		111,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		114,
		111,
		110,
		116,
		111,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		95,
		65,
		110,
		105,
		109,
		66,
		108,
		117,
		101,
		112,
		114,
		105,
		110,
		116,
		46,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		114,
		111,
		110,
		116,
		111,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		95,
		65,
		110,
		105,
		109,
		66,
		108,
		117,
		101,
		112,
		114,
		105,
		110,
		116,
		95,
		67,
		0,
		112,
		160,
		67,
		146,
		135,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		83,
		107,
		105,
		110,
		115,
		47,
		84,
		86,
		95,
		51,
		50,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		77,
		95,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		176,
		115,
		107,
		132,
		169,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		47,
		83,
		107,
		105,
		110,
		115,
		47,
		67,
		86,
		95,
		48,
		52,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		95,
		67,
		86,
		48,
		52,
		46,
		77,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		52,
		95,
		67,
		86,
		48,
		52,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		7,
		132,
		132,
		79,
		20,
		0,
		0,
		0
		};

		// Token: 0x04000B28 RID: 2856
		private static byte[] byte_3 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		116,
		104,
		101,
		110,
		97,
		47,
		72,
		101,
		114,
		111,
		101,
		115,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		67,
		80,
		95,
		66,
		111,
		100,
		121,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		70,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		18,
		130,
		155,
		123,
		69,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		97,
		115,
		101,
		47,
		83,
		75,
		95,
		77,
		95,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		66,
		97,
		115,
		101,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		0,
		100,
		205,
		113,
		128,
		95,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		97,
		115,
		101,
		47,
		83,
		75,
		95,
		77,
		95,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		66,
		97,
		115,
		101,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		46,
		83,
		75,
		95,
		77,
		95,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		66,
		97,
		115,
		101,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		0,
		211,
		180,
		18,
		27,
		86,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		0,
		62,
		99,
		223,
		70,
		103,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		46,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		0,
		30,
		191,
		47,
		134,
		102,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		95,
		65,
		110,
		105,
		109,
		66,
		80,
		0,
		88,
		94,
		162,
		58,
		137,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		95,
		65,
		110,
		105,
		109,
		66,
		80,
		46,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		95,
		83,
		107,
		101,
		108,
		101,
		116,
		111,
		110,
		95,
		65,
		110,
		105,
		109,
		66,
		80,
		95,
		67,
		0,
		112,
		160,
		67,
		146,
		135,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		83,
		107,
		105,
		110,
		115,
		47,
		84,
		86,
		95,
		51,
		50,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		77,
		95,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		176,
		115,
		107,
		132,
		169,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		66,
		111,
		100,
		105,
		101,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		83,
		111,
		108,
		100,
		105,
		101,
		114,
		95,
		48,
		49,
		47,
		83,
		107,
		105,
		110,
		115,
		47,
		84,
		86,
		95,
		51,
		50,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		77,
		95,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		46,
		77,
		95,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		7,
		132,
		132,
		79,
		20,
		0,
		0,
		0
		};

		// Token: 0x04000B29 RID: 2857
		private static byte[] byte_4 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		67,
		111,
		108,
		111,
		114,
		83,
		119,
		97,
		116,
		99,
		104,
		101,
		115,
		47,
		83,
		107,
		105,
		110,
		47,
		77,
		95,
		77,
		101,
		100,
		95,
		66,
		76,
		75,
		46,
		77,
		95,
		77,
		101,
		100,
		95,
		66,
		76,
		75,
		0,
		167,
		232,
		113,
		89,
		78,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		80,
		97,
		114,
		116,
		115,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		67,
		80,
		95,
		72,
		101,
		97,
		100,
		95,
		70,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		40,
		90,
		224,
		32,
		110,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		67,
		104,
		97,
		105,
		110,
		109,
		97,
		105,
		108,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		70,
		155,
		176,
		219,
		142,
		0,
		0,
		0,
		47,
		48,
		48,
		48,
		48,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		67,
		104,
		97,
		105,
		110,
		109,
		97,
		105,
		108,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		49,
		46,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		49,
		0,
		196,
		14,
		118,
		16,
		91,
		0,
		0,
		0,
		47,
		48,
		48,
		48,
		48,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		78,
		111,
		95,
		72,
		97,
		105,
		114,
		0,
		226,
		46,
		48,
		204,
		114,
		0,
		0,
		0,
		47,
		48,
		48,
		48,
		48,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		78,
		111,
		95,
		72,
		97,
		105,
		114,
		46,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		78,
		111,
		95,
		72,
		97,
		105,
		114,
		0,
		139,
		228,
		86,
		98,
		101,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		0,
		149,
		173,
		169,
		206,
		127,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		77,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		76,
		75,
		95,
		83,
		121,
		100,
		110,
		101,
		121,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		101,
		115,
		47,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		76,
		75,
		95,
		83,
		121,
		100,
		110,
		101,
		121,
		95,
		48,
		49,
		46,
		77,
		95,
		77,
		69,
		68,
		95,
		66,
		76,
		75,
		95,
		83,
		121,
		100,
		110,
		101,
		121,
		95,
		48,
		49,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0
		};

		// Token: 0x04000B2A RID: 2858
		private static byte[] byte_5 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		67,
		111,
		108,
		111,
		114,
		83,
		119,
		97,
		116,
		99,
		104,
		101,
		115,
		47,
		83,
		107,
		105,
		110,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		73,
		83,
		46,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		73,
		83,
		0,
		167,
		232,
		113,
		89,
		78,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		80,
		97,
		114,
		116,
		115,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		67,
		80,
		95,
		72,
		101,
		97,
		100,
		95,
		70,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		40,
		90,
		224,
		32,
		110,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		67,
		104,
		97,
		105,
		110,
		109,
		97,
		105,
		108,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		70,
		155,
		176,
		219,
		142,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		67,
		104,
		97,
		105,
		110,
		109,
		97,
		105,
		108,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		46,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		196,
		14,
		118,
		16,
		91,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		78,
		111,
		95,
		72,
		97,
		105,
		114,
		0,
		226,
		46,
		48,
		204,
		114,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		101,
		100,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		78,
		111,
		95,
		72,
		97,
		105,
		114,
		46,
		70,
		95,
		77,
		69,
		68,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		78,
		111,
		95,
		72,
		97,
		105,
		114,
		0,
		139,
		228,
		86,
		98,
		101,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		0,
		149,
		173,
		169,
		206,
		127,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		67,
		104,
		97,
		114,
		97,
		99,
		116,
		101,
		114,
		115,
		47,
		80,
		108,
		97,
		121,
		101,
		114,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		47,
		77,
		101,
		100,
		105,
		117,
		109,
		47,
		72,
		101,
		97,
		100,
		115,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		47,
		77,
		101,
		115,
		104,
		47,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49,
		46,
		70,
		95,
		77,
		69,
		68,
		95,
		72,
		73,
		83,
		95,
		82,
		97,
		109,
		105,
		114,
		101,
		122,
		95,
		72,
		101,
		97,
		100,
		95,
		48,
		49
		};

		// Token: 0x04000B2B RID: 2859
		private static byte[] byte_6 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		99,
		99,
		101,
		115,
		115,
		111,
		114,
		105,
		101,
		115,
		47,
		72,
		97,
		116,
		115,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		72,
		97,
		116,
		95,
		77,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		48,
		50,
		95,
		86,
		48,
		49,
		46,
		72,
		97,
		116,
		95,
		77,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		48,
		50,
		95,
		86,
		48,
		49,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		172,
		69,
		43,
		180,
		62,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		99,
		99,
		101,
		115,
		115,
		111,
		114,
		105,
		101,
		115,
		47,
		72,
		97,
		116,
		115,
		47,
		77,
		101,
		115,
		104,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		66,
		82,
		95,
		66,
		108,
		97,
		99,
		107,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		48,
		49,
		0,
		126,
		104,
		103,
		56,
		96,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		99,
		99,
		101,
		115,
		115,
		111,
		114,
		105,
		101,
		115,
		47,
		72,
		97,
		116,
		115,
		47,
		77,
		101,
		115,
		104,
		47,
		77,
		97,
		108,
		101,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		48,
		50,
		46,
		77,
		97,
		108,
		101,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		48,
		50,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0
		};

		// Token: 0x04000B2C RID: 2860
		private static byte[] byte_7 = new byte[]
		{
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		99,
		99,
		101,
		115,
		115,
		111,
		114,
		105,
		101,
		115,
		47,
		72,
		97,
		116,
		115,
		47,
		77,
		97,
		116,
		101,
		114,
		105,
		97,
		108,
		115,
		47,
		72,
		97,
		116,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		46,
		72,
		97,
		116,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		82,
		101,
		100,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		87,
		105,
		110,
		116,
		101,
		114,
		0,
		172,
		69,
		43,
		180,
		62,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		99,
		99,
		101,
		115,
		115,
		111,
		114,
		105,
		101,
		115,
		47,
		72,
		97,
		116,
		115,
		47,
		77,
		101,
		115,
		104,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		66,
		82,
		95,
		66,
		108,
		97,
		99,
		107,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		48,
		49,
		0,
		126,
		104,
		103,
		56,
		96,
		0,
		0,
		0,
		47,
		71,
		97,
		109,
		101,
		47,
		65,
		99,
		99,
		101,
		115,
		115,
		111,
		114,
		105,
		101,
		115,
		47,
		72,
		97,
		116,
		115,
		47,
		77,
		101,
		115,
		104,
		47,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		66,
		82,
		95,
		66,
		108,
		97,
		99,
		107,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		48,
		49,
		46,
		70,
		101,
		109,
		97,
		108,
		101,
		95,
		67,
		111,
		109,
		109,
		97,
		110,
		100,
		111,
		95,
		66,
		82,
		95,
		66,
		108,
		97,
		99,
		107,
		75,
		110,
		105,
		103,
		104,
		116,
		95,
		48,
		49
		};

		private void revert1Bytes_DoWork(object sender, DoWorkEventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

			materialRaisedButton1.Enabled = false;

			RichTextBoxInfo.Text += "\n[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";


			Stream Stream1 = File.OpenRead(filePath);
			foreach (long offset3 in Researcher.FindPosition(Stream1, 0, (long)offsetskin2, arialasualt.byte_4))
			{
				Stream1.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_5);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head removed!";
			}

			Stream Stream2 = File.OpenRead(filePath);
			foreach (long offset3 in Researcher.FindPosition(Stream2, 0, (long)offsetskin2, arialasualt.byte_6))
			{
				Stream2.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_7);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Hat removed!";
			}

			Stream Stream3 = File.OpenRead(filePath);
			foreach (long offset3 in Researcher.FindPosition(Stream3, 0, (long)offsetskin1, arialasualt.byte_2))
			{
				Stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_3);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body removed!";
			}

			Stream Stream4 = File.OpenRead(filePath1);
			foreach (long offset3 in Researcher.FindPosition(Stream4, 0, (long)offsetlobby, arialasualt.byte_0))
			{
				Stream4.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(offset3, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_1);
				Settings.Default.AerialEnabled = false;
				Settings.Default.Save();
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID removed!";
			}

			this.revert.Enabled = false;
			this.materialRaisedButton1.Enabled = true;
			sw.Stop();
			double num3 = (double)sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done";
		}

		private void change1Bytes_DoWork(object sender, DoWorkEventArgs e)
		{
			if (Settings.Default.ReconFRKEnabled)
			{
				MetroFramework.MetroMessageBox.Show(this, "Recon" + actsomewhelse, error, MessageBoxButtons.OK, MessageBoxIcon.Error, 100);
				return;
			}

			CheckForIllegalCrossThreadCalls = false; int offsetskin1 = Settings.Default.offsetskin1; int offsetpick = Settings.Default.offsetpick; int offsetback = Settings.Default.offsetback; int offsetskin2 = Settings.Default.offsetskin2; int offsetemote = Settings.Default.offsetemote; int offsetlobby = Settings.Default.offsetlobby; int offsetpickmesh = Settings.Default.offsetpickmesh;

			materialRaisedButton1.Enabled = false;

			RichTextBoxInfo.Text += "\n[LOG] Starting...";

			Stopwatch sw = new Stopwatch();
			sw.Start();

			string filePath = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			string filePath1 = Options.GetPaksFolder + "\\pakchunk0-WindowsClient.pak";


			Stream Stream1 = File.OpenRead(filePath);
			foreach (long s in Researcher.FindPosition(Stream1, 0, (long)offsetskin2, arialasualt.byte_5))
			{
				Stream1.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(s, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_4);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Head added!";
			}

			Stream Stream2 = File.OpenRead(filePath);
			foreach (long s in Researcher.FindPosition(Stream2, 0, (long)offsetskin2, arialasualt.byte_7))
			{
				Stream2.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(s, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_6);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Hat added!";
			}

			Stream Stream3 = File.OpenRead(filePath);
			foreach (long s in Researcher.FindPosition(Stream3, 0, (long)offsetskin1, arialasualt.byte_3))
			{
				Stream3.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(s, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_2);
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] Body added!";
			}

			Stream Stream4 = File.OpenRead(filePath1);
			foreach (long s in Researcher.FindPosition(Stream4, 0, (long)offsetlobby, arialasualt.byte_1))
			{
				Stream4.Close();
				BinaryWriter binaryWriter3 = new BinaryWriter(File.Open(filePath1, FileMode.Open, FileAccess.ReadWrite));
				binaryWriter3.BaseStream.Seek(s, SeekOrigin.Begin);
				binaryWriter3.Write(arialasualt.byte_0);
				Settings.Default.AerialEnabled = true;
				Settings.Default.Save();
				binaryWriter3.Close();
				this.RichTextBoxInfo.Text = this.RichTextBoxInfo.Text + "\n[LOG] CID added!";
			}

			this.revert.Enabled = true;
			this.materialRaisedButton1.Enabled = false;
			sw.Stop();
			double num3 = (double)sw.Elapsed.Seconds;
			RichTextBoxInfo.Text = RichTextBoxInfo.Text + "\n[LOG] Done";


		}

		

		private void revert_Click(object sender, EventArgs e)
		{
			string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			bool flag = !File.Exists(path);
			if (flag)
			{
				paks paks = new paks();
				paks.ShowDialog();
			}
			else
			{
				Control.CheckForIllegalCrossThreadCalls = false;
				int offsetskin = Settings.Default.offsetskin1;
				int offsetpick = Settings.Default.offsetpick;
				int offsetback = Settings.Default.offsetback;
				int offsetskin2 = Settings.Default.offsetskin2;
				int offsetemote = Settings.Default.offsetemote;
				int offsetlobby = Settings.Default.offsetlobby;
				int offsetpickmesh = Settings.Default.offsetpickmesh;
				this.revert1Bytes.RunWorkerAsync();
			}
		}

		private void materialRaisedButton1_Click(object sender, EventArgs e)
		{
			string path = Options.GetPaksFolder + "\\pakchunk10_s2-WindowsClient.pak";
			bool flag = !File.Exists(path);
			if (flag)
			{
				paks paks = new paks();
				paks.ShowDialog();
			}
			else
			{



				Control.CheckForIllegalCrossThreadCalls = false;
				int offsetskin = Settings.Default.offsetskin1;
				int offsetpick = Settings.Default.offsetpick;
				int offsetback = Settings.Default.offsetback;
				int offsetskin2 = Settings.Default.offsetskin2;
				int offsetemote = Settings.Default.offsetemote;
				int offsetlobby = Settings.Default.offsetlobby;
				int offsetpickmesh = Settings.Default.offsetpickmesh;
				this.change1Bytes.RunWorkerAsync();

			}
		}
	}
}
