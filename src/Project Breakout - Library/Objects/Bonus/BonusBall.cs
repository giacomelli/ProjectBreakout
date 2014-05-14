using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Bonus
{
	/// <summary>
	/// Summary description for BonusBall.
	/// </summary>
	public class BonusBall : Bonus
	{
		private static DGGFTexture globalTexture = null;

		
		public static void LoadResources(Device videoDevice)
		{
			BonusBall.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Bonus/bonusSimple.png"));
		}

		public BonusBall(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BonusBall.globalTexture,  1, 1, x, y)
		{
			Balls.BallSimple ballLeft = new ProjectBreakout.Objects.Balls.BallSimple(videoDevice, soundDevice, sprite, area);
			ballLeft.X = x - 16;
			ballLeft.Y = y;
			ballLeft.Beater = Level.beater;
			ballLeft.Blocks = Level.blocks.Array;
			ballLeft.Energy = 1;
			ballLeft.DirectionX = -1;
			ballLeft.Init();

			Balls.BallSimple ballRight = new ProjectBreakout.Objects.Balls.BallSimple(videoDevice, soundDevice, sprite, area);
			ballRight.X = x + 16;
			ballRight.Y = y;
			ballRight.Beater = Level.beater;
			ballRight.Blocks = Level.blocks.Array;
			ballRight.Energy = 1;
			ballRight.DirectionX = 1;
			ballRight.Init();

			// Insert the ball in the level's collection
			Level.balls.Add(ballLeft);
			Level.balls.Add(ballRight);


			// Do the bonus disabled
			this.Enabled = false;
			this.Visible = false;
		}

	
		protected override void DeliveryBonus()
		{
			
		}
	}
}
