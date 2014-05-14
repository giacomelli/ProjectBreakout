using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Blocks
{
	/// <summary>
	/// Summary description for BlockSquareHole.
	/// </summary>
	public class BlockSquareHole : Block
	{
		private static DGGFTexture globalTexture = null;

		public static void LoadResources(Device videoDevice)
		{
			BlockSquareHole.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Blocks/BlockSquareHole.png"));
		}


		public BlockSquareHole(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BlockSquareHole.globalTexture, 8, 1, x, y)
		{
			this.Energy = 1;

			this.AnimationDelay = 60;
			this.CycleType = DGGF.Objects.AnimatedObjectCycleType.Circular;
            
			this.explosionRed = 50;
			this.explosionGreen = 100;
			this.explosionBlue = 10;
		}
	}
}
