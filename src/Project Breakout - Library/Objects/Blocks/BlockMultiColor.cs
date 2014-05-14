using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Blocks
{
	/// <summary>
	/// Summary description for BlockMultiColor.
	/// </summary>
	public class BlockMultiColor : Block
	{
		private static DGGFTexture globalTexture = null;		

		public static void LoadResources(Device videoDevice)
		{
			BlockMultiColor.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Blocks/blockMultiColor.png"));
		}


		public BlockMultiColor(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BlockMultiColor.globalTexture, 1, 1, x, y)
		{
			this.explosionRed = 255;
			this.explosionGreen = 50;
			this.explosionBlue = 255;
		}


		public override void Collide()
		{
			base.Collide();
			this.LaunchBonus(new Bonus.BonusSimple(this.videoDevice, this.soundDevice, this.Sprite, this.CollisionArea, this.XHalfWidth, this.YHalfHeight));
		}


	}
}
