using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Blocks
{
	/// <summary>
	/// Summary description for BlockXXX.
	/// </summary>
	public class BlockXXX : Block
	{
		private static DGGFTexture globalTexture = null;

		public static void LoadResources(Device videoDevice)
		{
			BlockXXX.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Blocks/blockXXX.png"));
		}


		public BlockXXX(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BlockXXX.globalTexture, 1, 1, x, y)
		{
			this.Energy = 2;

			this.explosionRed = 100;
			this.explosionGreen = 255;
			this.explosionBlue = 50;
		}

	}
}
