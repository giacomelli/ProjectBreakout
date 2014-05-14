using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF;
using DGGF.Effects;
using DGGF.Effects.ParticleSystem;
using DGGF.UI.Forms;
using ProjectBreakout.Objects.Beaters;
using ProjectBreakout.Objects.Balls;
using ProjectBreakout.Objects.Blocks;
using ProjectBreakout.Objects;


namespace ProjectBreakout
{
	/// <summary>
	/// Summary description for frmProjectBreakout.
	/// </summary>
	public class frmProjectBreakout : ProjectBreakout.UI.Forms.Game
	{
		[STAThread]
		static void Main() 
		{
			using(frmProjectBreakout frm = new frmProjectBreakout())
			{							
				frm.Init();
				frm.Show();
				frm.Start();				
			}
		}
	}
}
