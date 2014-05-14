using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Blocks
{
	/// <summary>
	/// Summary description for BlockBall.
	/// </summary>
	public class BlockBall : Block
	{
		private static DGGFTexture globalTexture = null;

		public static void LoadResources(Device videoDevice)
		{
			BlockBall.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Blocks/BlockBall.png"));
		}


		public BlockBall(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BlockBall.globalTexture, 8, 1, x, y)
		{
			this.Energy = 1;

            this.AnimationDelay = 60;
			this.CycleType = DGGF.Objects.AnimatedObjectCycleType.Linear;
            
			this.explosionRed = 128;
			this.explosionGreen = 128;
			this.explosionBlue = 128;
		}


		public override void Collide()
		{
			base.Collide();
			this.LaunchBonus(new Bonus.BonusBall(this.videoDevice, this.soundDevice, this.Sprite, this.CollisionArea, this.XHalfWidth, this.YHalfHeight));
		}
	}
}
