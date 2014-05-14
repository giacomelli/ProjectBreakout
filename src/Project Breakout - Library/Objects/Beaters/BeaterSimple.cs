using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Objects;
using DGGF.Drawing;
using System.Drawing;

namespace ProjectBreakout.Objects.Beaters
{
	/// <summary>
	/// Summary description for BeaterSimple.
	/// </summary>
	public class BeaterSimple : Beater
	{
		#region Members of Data
		private static DGGFTexture globalTexture = null;	
		#endregion

		
		public static void LoadResources(Device videoDevice)
		{
			BeaterSimple.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Beaters/beaterSimple.png"));
		}

		#region Constructors
		public BeaterSimple(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area) : base(videoDevice, soundDevice, sprite, area, BeaterSimple.globalTexture, 3, 1)
		{
			this.AnimationDelay = 75;				
			this.CycleType = AnimatedObjectCycleType.Circular;						
		}
		#endregion
	}
}
