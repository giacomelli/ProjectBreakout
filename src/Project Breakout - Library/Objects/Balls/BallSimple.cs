using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Objects;
using DGGF.Drawing;
using System.Drawing;

namespace ProjectBreakout.Objects.Balls
{
	/// <summary>
	/// BallSimple
	/// </summary>
	public class BallSimple : Ball
	{		
		private static DGGFTexture globalTexture = null;

		public static void LoadResources(Device videoDevice)
		{
			BallSimple.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Balls/BallMetal.png"));
		}

		public BallSimple(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area) : base(videoDevice, soundDevice, sprite, area, BallSimple.globalTexture, 4, 1)
		{			
		}	


	}
}
