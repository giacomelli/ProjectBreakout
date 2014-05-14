using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using ProjectBreakout.Objects;

namespace ProjectBreakout.LevelEditor
{
	/// <summary>
	/// Summary description for frmMain.
	/// </summary>
	public class frmToolBar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem mniFile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtObjects;
		private System.Windows.Forms.MenuItem mniWindows;
		private System.Windows.Forms.MenuItem mniMap;
		private System.Windows.Forms.MenuItem mniView;
		private System.Windows.Forms.MenuItem mniAnimation;
		private frmMap map;
		private System.Windows.Forms.MenuItem mniOpen;
		private System.Windows.Forms.MenuItem mniSave;
		private System.Windows.Forms.MenuItem mniExit;
		private System.Windows.Forms.MenuItem mniNew;
		private System.Windows.Forms.MenuItem mniSaveAs;
		private System.Windows.Forms.SaveFileDialog sfdLevel;
		private System.Windows.Forms.OpenFileDialog ofdLevel;
		private string currentLevelFile = "";
		private System.Windows.Forms.MenuItem mniObjects;
		private System.Windows.Forms.MenuItem mniBlocks;
		private System.Windows.Forms.GroupBox grpBlocks;
		private System.Windows.Forms.PictureBox pbxMutiColor;
		private System.Windows.Forms.PictureBox pbxSimple;
		private string selectedObjectType = "ProjectBreakout.Objects.Blocks.BlockSimple";
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MenuItem mniBeater;
		private System.Windows.Forms.GroupBox grpBeater;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox grpSelectedObject;
		private System.Windows.Forms.PictureBox pbxSelectedObject;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmToolBar()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			sfdLevel.Filter = "XML Files (*.xml)|*.xml";
			this.mniBlocks.Checked = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}



		[STAThread]
		static void Main() 
		{
			Application.Run(new frmToolBar());
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmToolBar));
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mniFile = new System.Windows.Forms.MenuItem();
			this.mniNew = new System.Windows.Forms.MenuItem();
			this.mniOpen = new System.Windows.Forms.MenuItem();
			this.mniSave = new System.Windows.Forms.MenuItem();
			this.mniSaveAs = new System.Windows.Forms.MenuItem();
			this.mniExit = new System.Windows.Forms.MenuItem();
			this.mniView = new System.Windows.Forms.MenuItem();
			this.mniAnimation = new System.Windows.Forms.MenuItem();
			this.mniWindows = new System.Windows.Forms.MenuItem();
			this.mniMap = new System.Windows.Forms.MenuItem();
			this.mniObjects = new System.Windows.Forms.MenuItem();
			this.mniBlocks = new System.Windows.Forms.MenuItem();
			this.mniBeater = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.txtObjects = new System.Windows.Forms.TextBox();
			this.sfdLevel = new System.Windows.Forms.SaveFileDialog();
			this.ofdLevel = new System.Windows.Forms.OpenFileDialog();
			this.grpBlocks = new System.Windows.Forms.GroupBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pbxSimple = new System.Windows.Forms.PictureBox();
			this.pbxMutiColor = new System.Windows.Forms.PictureBox();
			this.grpBeater = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.grpSelectedObject = new System.Windows.Forms.GroupBox();
			this.pbxSelectedObject = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.grpBlocks.SuspendLayout();
			this.grpBeater.SuspendLayout();
			this.grpSelectedObject.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mniFile,
																					this.mniView,
																					this.mniWindows,
																					this.mniObjects});
			// 
			// mniFile
			// 
			this.mniFile.Index = 0;
			this.mniFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mniNew,
																					this.mniOpen,
																					this.mniSave,
																					this.mniSaveAs,
																					this.mniExit});
			this.mniFile.Text = "&File";
			// 
			// mniNew
			// 
			this.mniNew.Index = 0;
			this.mniNew.Text = "&New...";
			this.mniNew.Click += new System.EventHandler(this.mniNew_Click);
			// 
			// mniOpen
			// 
			this.mniOpen.Index = 1;
			this.mniOpen.Text = "&Open...";
			this.mniOpen.Click += new System.EventHandler(this.mniOpen_Click);
			// 
			// mniSave
			// 
			this.mniSave.Index = 2;
			this.mniSave.Text = "&Save";
			this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
			// 
			// mniSaveAs
			// 
			this.mniSaveAs.Index = 3;
			this.mniSaveAs.Text = "Save &As...";
			this.mniSaveAs.Click += new System.EventHandler(this.mniSaveAs_Click);
			// 
			// mniExit
			// 
			this.mniExit.Index = 4;
			this.mniExit.Text = "&Exit";
			this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
			// 
			// mniView
			// 
			this.mniView.Index = 1;
			this.mniView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mniAnimation});
			this.mniView.Text = "&View";
			// 
			// mniAnimation
			// 
			this.mniAnimation.Index = 0;
			this.mniAnimation.RadioCheck = true;
			this.mniAnimation.Text = "&Animation";
			this.mniAnimation.Click += new System.EventHandler(this.mniAnimation_Click);
			// 
			// mniWindows
			// 
			this.mniWindows.Index = 2;
			this.mniWindows.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mniMap});
			this.mniWindows.Text = "&Window";
			this.mniWindows.Visible = false;
			// 
			// mniMap
			// 
			this.mniMap.Index = 0;
			this.mniMap.Text = "&Map";
			this.mniMap.Click += new System.EventHandler(this.mniMap_Click);
			// 
			// mniObjects
			// 
			this.mniObjects.Index = 3;
			this.mniObjects.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mniBlocks,
																					   this.mniBeater});
			this.mniObjects.Text = "&Objects";
			// 
			// mniBlocks
			// 
			this.mniBlocks.Index = 0;
			this.mniBlocks.Text = "&Blocks";
			this.mniBlocks.Click += new System.EventHandler(this.mniBlocks_Click);
			// 
			// mniBeater
			// 
			this.mniBeater.Index = 1;
			this.mniBeater.Text = "B&eater";
			this.mniBeater.Click += new System.EventHandler(this.mniBeater_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Objects: ";
			// 
			// txtObjects
			// 
			this.txtObjects.Location = new System.Drawing.Point(56, 8);
			this.txtObjects.Name = "txtObjects";
			this.txtObjects.ReadOnly = true;
			this.txtObjects.Size = new System.Drawing.Size(56, 20);
			this.txtObjects.TabIndex = 1;
			this.txtObjects.Text = "0";
			// 
			// grpBlocks
			// 
			this.grpBlocks.Controls.Add(this.pictureBox5);
			this.grpBlocks.Controls.Add(this.pictureBox4);
			this.grpBlocks.Controls.Add(this.pictureBox3);
			this.grpBlocks.Controls.Add(this.pictureBox1);
			this.grpBlocks.Controls.Add(this.pbxSimple);
			this.grpBlocks.Controls.Add(this.pbxMutiColor);
			this.grpBlocks.Location = new System.Drawing.Point(8, 40);
			this.grpBlocks.Name = "grpBlocks";
			this.grpBlocks.Size = new System.Drawing.Size(224, 320);
			this.grpBlocks.TabIndex = 2;
			this.grpBlocks.TabStop = false;
			this.grpBlocks.Text = "Blocks";
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(168, 16);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(32, 16);
			this.pictureBox4.TabIndex = 4;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Tag = "ProjectBreakout.Objects.Blocks.BlockSquareHole";
			this.pictureBox4.Click += new System.EventHandler(this.SetSelectedObjectType);
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(128, 16);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(32, 16);
			this.pictureBox3.TabIndex = 3;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Tag = "ProjectBreakout.Objects.Blocks.BlockBall";
			this.pictureBox3.Click += new System.EventHandler(this.SetSelectedObjectType);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(88, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 16);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "ProjectBreakout.Objects.Blocks.BlockXXX";
			this.pictureBox1.Click += new System.EventHandler(this.SetSelectedObjectType);
			// 
			// pbxSimple
			// 
			this.pbxSimple.Image = ((System.Drawing.Image)(resources.GetObject("pbxSimple.Image")));
			this.pbxSimple.Location = new System.Drawing.Point(8, 16);
			this.pbxSimple.Name = "pbxSimple";
			this.pbxSimple.Size = new System.Drawing.Size(32, 16);
			this.pbxSimple.TabIndex = 1;
			this.pbxSimple.TabStop = false;
			this.pbxSimple.Tag = "ProjectBreakout.Objects.Blocks.BlockSimple";
			this.pbxSimple.Click += new System.EventHandler(this.SetSelectedObjectType);
			// 
			// pbxMutiColor
			// 
			this.pbxMutiColor.Image = ((System.Drawing.Image)(resources.GetObject("pbxMutiColor.Image")));
			this.pbxMutiColor.Location = new System.Drawing.Point(48, 16);
			this.pbxMutiColor.Name = "pbxMutiColor";
			this.pbxMutiColor.Size = new System.Drawing.Size(32, 16);
			this.pbxMutiColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbxMutiColor.TabIndex = 0;
			this.pbxMutiColor.TabStop = false;
			this.pbxMutiColor.Tag = "ProjectBreakout.Objects.Blocks.BlockMultiColor";
			this.pbxMutiColor.Click += new System.EventHandler(this.SetSelectedObjectType);
			// 
			// grpBeater
			// 
			this.grpBeater.Controls.Add(this.pictureBox2);
			this.grpBeater.Location = new System.Drawing.Point(8, 40);
			this.grpBeater.Name = "grpBeater";
			this.grpBeater.Size = new System.Drawing.Size(224, 320);
			this.grpBeater.TabIndex = 3;
			this.grpBeater.TabStop = false;
			this.grpBeater.Text = "Beater";
			this.grpBeater.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 24);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(48, 9);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			// 
			// grpSelectedObject
			// 
			this.grpSelectedObject.Controls.Add(this.pbxSelectedObject);
			this.grpSelectedObject.Location = new System.Drawing.Point(8, 368);
			this.grpSelectedObject.Name = "grpSelectedObject";
			this.grpSelectedObject.Size = new System.Drawing.Size(224, 72);
			this.grpSelectedObject.TabIndex = 4;
			this.grpSelectedObject.TabStop = false;
			this.grpSelectedObject.Text = "Selected Object";
			// 
			// pbxSelectedObject
			// 
			this.pbxSelectedObject.Image = ((System.Drawing.Image)(resources.GetObject("pbxSelectedObject.Image")));
			this.pbxSelectedObject.Location = new System.Drawing.Point(16, 24);
			this.pbxSelectedObject.Name = "pbxSelectedObject";
			this.pbxSelectedObject.Size = new System.Drawing.Size(192, 40);
			this.pbxSelectedObject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pbxSelectedObject.TabIndex = 0;
			this.pbxSelectedObject.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
			this.pictureBox5.Location = new System.Drawing.Point(8, 40);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(32, 16);
			this.pictureBox5.TabIndex = 5;
			this.pictureBox5.TabStop = false;
			this.pictureBox5.Tag = "ProjectBreakout.Objects.Blocks.BlockFire";
			this.pictureBox5.Click += new System.EventHandler(this.SetSelectedObjectType);
			// 
			// frmToolBar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(240, 449);
			this.Controls.Add(this.grpSelectedObject);
			this.Controls.Add(this.txtObjects);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grpBlocks);
			this.Controls.Add(this.grpBeater);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.Menu = this.mnuMain;
			this.Name = "frmToolBar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Tool Bar";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.grpBlocks.ResumeLayout(false);
			this.grpBeater.ResumeLayout(false);
			this.grpSelectedObject.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmMain_Load(object sender, System.EventArgs e)
		{			
			map = new frmMap(this);
			map.Show();
			map.Init();
		}

		private void mniMap_Click(object sender, System.EventArgs e)
		{
			frmMain_Load(sender, e);
		}

		private void mniAnimation_Click(object sender, System.EventArgs e)
		{
			map.Animation = !map.Animation;
			((MenuItem) sender).Checked = map.Animation;
		}


		private void mniBlocks_Click(object sender, System.EventArgs e)
		{
			this.ShowHideBlocksPanel(!((MenuItem) sender).Checked);
			
		}


		private void mniBeater_Click(object sender, System.EventArgs e)
		{ 
			ShowHideBlocksPanel(((MenuItem) sender).Checked);
		}


		private void ShowHideBlocksPanel(bool show)
		{
			this.mniBlocks.Checked = show;
			this.grpBlocks.Visible = show;

			this.mniBeater.Checked = !show;
			this.grpBeater.Visible = !show;

		}


		private void mniExit_Click(object sender, System.EventArgs e)
		{
			this.map.Hide();
			DialogResult r = MessageBox.Show(this, "Do you want to save this level before exit level editor?", this.Text, MessageBoxButtons.YesNoCancel);
			this.map.Show();
			if(r == DialogResult.Yes)
			{
				this.Save();					
			}
			else if(r == DialogResult.Cancel)
			{
				return;
			}

			Application.Exit();
		}

		private void SetCurrentLevelFile(string fileName)
		{
			currentLevelFile = fileName;
			mniSave.Text = "&Save " + fileName;
		}


		private void mniOpen_Click(object sender, System.EventArgs e)
		{
			if(ofdLevel.ShowDialog() == DialogResult.OK)
			{
				this.map.Open(ofdLevel.FileName);
				SetCurrentLevelFile(ofdLevel.FileName);
			}			
		}


		private void Save()
		{
			if(currentLevelFile.Length == 0)
			{
				this.SaveAs();							
			}			
			else
				this.map.Save(currentLevelFile);
		}


		private void mniSave_Click(object sender, System.EventArgs e)
		{
			this.Save();
		}

		private void mniNew_Click(object sender, System.EventArgs e)
		{
			this.map.New();
		}


		private void SaveAs()
		{
			if(sfdLevel.ShowDialog(this) == DialogResult.OK)
			{					
				this.map.Save(sfdLevel.FileName);
				SetCurrentLevelFile(sfdLevel.FileName);
			}
		}


		private void mniSaveAs_Click(object sender, System.EventArgs e)
		{
			this.SaveAs();								
		}

		
		private void SetSelectedObjectType(object sender, System.EventArgs e)
		{
			this.selectedObjectType = ((System.Windows.Forms.PictureBox) sender).Tag.ToString();
			this.pbxSelectedObject.Image =  ((System.Windows.Forms.PictureBox) sender).Image;
		}


		public string GetSelectedObjectType()
		{
			return this.selectedObjectType;
		}


		public int Objects
		{
			set
			{
				this.txtObjects.Text = value.ToString();
				this.txtObjects.Refresh();
			}
		}

		
	}
}
