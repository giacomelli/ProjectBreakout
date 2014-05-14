using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;
using System.Xml;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace ProjectBreakout.Utilities
{
	/// <summary>
	/// Summary description for Geral.
	/// </summary>
	public class Geral
	{
		public static void LoadLevel(ProjectBreakout.Objects.Level level)
		{	
			System.Windows.Forms.OpenFileDialog ofdLevel = new OpenFileDialog();

			if(ofdLevel.ShowDialog() == DialogResult.OK)
			{
				XmlDocument doc = new XmlDocument();
				TextReader tr = File.OpenText(ofdLevel.FileName);

				doc.Load(tr);
				tr.Close();	
	
				level.Init();
				level.LoadFromXML(doc);
			}
			
			/*
			XmlDocument doc = new XmlDocument();
			TextReader tr = File.OpenText(@"Levels\test_01.xml");

			doc.Load(tr);
			tr.Close();	
	
			level.Init();
			level.LoadFromXML(doc);
			/**/
		}


		public static Objects.Blocks.Block CreateBlockInstance(string fullName, Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area, float x, float y)
		{
			System.Reflection.Assembly asb =  System.Reflection.Assembly.GetAssembly(typeof(ProjectBreakout.Objects.GameObject));
			System.Type t = asb.GetType(fullName);			
			System.Reflection.Assembly cls = System.Reflection.Assembly.GetAssembly(t);

			object[] args = new object[6];
			args[0] = videoDevice;
			args[1] = soundDevice;
			args[2] = sprite;
			args[3] = area;
			args[4] = x;
			args[5] = y;
            
            return (Objects.Blocks.Block) Activator.CreateInstance(t, args);
		}
	}
}
