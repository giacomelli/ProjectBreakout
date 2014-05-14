using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Data;
using DGGF.UI.Forms;
using DGGF.Collections;
using Microsoft.DirectX.Direct3D;
using System.IO;
using System.Xml;
using ProjectBreakout.Objects;
using ProjectBreakout.Objects.Blocks;

namespace ProjectBreakout.LevelEditor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMap : DGGF.UI.Forms.Screen
	{
		private frmToolBar toolBar;
		private bool animation = false;
		private Sprite sprite;
		private Level level;

		public frmMap(frmToolBar toolBar)
		{
			this.toolBar = toolBar;
			this.StartPosition = FormStartPosition.Manual;
			this.Left = this.toolBar.Right + 1;
			this.Top = this.toolBar.Top;
			this.Text = "Project Breakout - Level Editor - Map";
		}


		public override void Init()
		{
			this.WindowType = WindowType.Windowed;			
			base.Init();

			sprite = new Sprite(this.VideoDevice);
			
			this.level = new Level(this.VideoDevice, this.SoundDevice, this.sprite, this);						
			this.level.LoadResources();
			this.level.Init();
		}





		public override void DoStep()
		{
			
			if(animation)
				this.level.Update();

			this.level.Render();
				
		
			// Insert the blocks
			if(DGGF.UI.Mouse.Button != MouseButtons.None)
			{
				int x = DGGF.UI.Mouse.X - (DGGF.UI.Mouse.X % 33);
				int y = DGGF.UI.Mouse.Y - (DGGF.UI.Mouse.Y % 17);

				
				Block obj = Utilities.Geral.CreateBlockInstance(this.toolBar.GetSelectedObjectType(), this.VideoDevice, this.SoundDevice, sprite, this.Rectangle, x, y);

				bool dispose = true;
				if(obj.CheckCollision(this.level.MapArea))
				{
					
					if(DGGF.UI.Mouse.Button == MouseButtons.Left && !obj.CheckCollision(Level.blocks.Array))
					{
						this.level.AddBlock(obj);		
						dispose = false;
					}
					else if(DGGF.UI.Mouse.Button == MouseButtons.Right && obj.CheckCollision(Level.blocks.Array)) 	
					{						
						((ProjectBreakout.Objects.Blocks.Block) Level.blocks.Array[obj.IndexCollidedObject]).Destroy();
						this.level.RemoveBlock(obj.IndexCollidedObject);
					}

					this.UpdateObjectsCount();
				}	
				
				if(dispose)
					obj.Destroy();
	
			}
		}


		public void Open(string filename)
		{
			
			XmlDocument doc = new XmlDocument();
			TextReader tr = File.OpenText(filename);

			doc.Load(tr);
			tr.Close();	
	
			this.level.Init();
			this.level.LoadFromXML(doc);

			this.UpdateObjectsCount();
		}


		public void New()
		{
			this.level = new Level(this.VideoDevice, this.SoundDevice, this.sprite, this);	
			this.level.Init();					
			this.UpdateObjectsCount();			
		}


		public void Save(string filename)
		{
			Objects.Blocks.BlockSimple b = new Objects.Blocks.BlockSimple(this.VideoDevice, this.SoundDevice, sprite, this.Rectangle, 0, 1);

			System.IO.TextWriter tw = File.CreateText(filename);
						
			System.Xml.XmlTextWriter xml = new System.Xml.XmlTextWriter(tw);
				
			XmlDocument doc = new XmlDocument();								

			doc.LoadXml("<?xml version='1.0' ?>" +
				"<Objects count=\"" + Level.blocks.Count + "\" >" +
				"</Objects>");

			Level.blocks.ToXML(doc);
			
			doc.WriteTo(xml);

			xml.Close();
			tw.Close();			
		}


		public bool Animation
		{
			get
			{
				return this.animation;
			}
			set
			{
				this.animation = value;
			}
		}


		private void UpdateObjectsCount()
		{
			this.toolBar.Objects = Level.blocks.Count;
		}
	}
}
