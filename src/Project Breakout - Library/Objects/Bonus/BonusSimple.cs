using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;
using DGGF.Effects.ParticleSystem;

namespace ProjectBreakout.Objects.Bonus
{
	/// <summary>
	/// Summary description for BonusSimple.
	/// </summary>
	public class BonusSimple : Bonus
	{
		private static DGGFTexture globalTexture = null;
		private CircularExplosion ps;
		private int lifeTimeExplosion = 20;

		public static void LoadResources(Device videoDevice)
		{
			BonusSimple.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Bonus/bonusSimple.png"));
		}


		public BonusSimple(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BonusSimple.globalTexture,  1, 1, x, y)
		{
			this.AnimationDelay = 75;
			this.ps = new CircularExplosion(Level.videoDevice, this.Position, this.Size, this.CollisionArea, 50);
			this.ps.Init();
			GameObject.psm.AddParticleSystem(ps);
			ps.ParticleSize = 7;
			this.SpeedY = 1.3f;
			this.DirectionY = 1;
			this.ps.Reborn = true;
		}


		public override void Update()
		{
			if(!this.deliveredBonus)
			{
				base.Update();

				if(!this.MoveY())
				{
					this.Enabled = false;
					this.Visible = false;
					this.ps.Died = true;
					return;
				}

			
				this.ps.X = this.X;
				this.ps.Y = this.Y;
				this.ps.Radix = 4;					
			}
			else
			{
				if(this.lifeTimeExplosion == 0)
				{
					this.ps.Died = true;
					this.lifeTimeExplosion--;
				}
				else
					this.lifeTimeExplosion--;

			}
		}


		public override void Render()
		{
			
		}


		protected override void DeliveryBonus()		
		{	
			this.ps.ParticleSize = 12;
			this.ps.Area = Level.beater.BoundingBox;
		}


	}
}
