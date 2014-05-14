using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace ProjectBreakout.Objects.Blocks
{
	/// <summary>
	/// Summary description for BlockSimple.
	/// </summary>
	public class BlockSimple : Block
	{
		private static DGGFTexture globalTexture = null;

		public static void LoadResources(Device videoDevice)
		{
			BlockSimple.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Blocks/blockSimple.png"));
		}


		public BlockSimple(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BlockSimple.globalTexture, 4, 1, x, y)
		{
			this.AnimationDelay = 75;

			this.explosionRed = 255;
			this.explosionGreen = 100;
			this.explosionBlue = 50;
		}
	}
}
