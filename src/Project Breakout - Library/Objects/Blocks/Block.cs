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
	/// Summary description for Block.
	/// </summary>
	public class Block : GameObject
	{
		private int energy = 1;
		protected static DGGF.Collections.GameObjectCollection staticBonus;
		protected int explosionRed, explosionGreen, explosionBlue = 255;
		protected bool isCreatedBonus = false;

		
		public static void LoadResources(Microsoft.DirectX.DirectSound.Device soundDevice)
		{
		}


		public static DGGF.Collections.GameObjectCollection BonusCollection
		{
			set
			{
				Block.staticBonus = value;
			}
		}


		public Block(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area, DGGFTexture texture, int columnsFrames, int rowsFrames, float x, float y) : base(videoDevice, soundDevice, sprite, area, texture, columnsFrames, rowsFrames, x, y, 10)
		{
			this.sounds = new DGGF.Collections.SoundCollection(1);
			this.sounds.Add(new Microsoft.DirectX.DirectSound.SecondaryBuffer(@"Sounds\Blocks\explosion.wav", soundDevice));
		}

		
		public int Energy
		{
			get
			{
				return this.energy;
			}

			set
			{
				this.energy = value;
				if(this.energy <= 0)
					this.Enabled = false;	

			}
		}

		public override void Collide()
		{
			if((this.energy - 1) == 0)
			{
				ProjectBreakout.Effects.ParticleSystem.BlockExplosion ps = new ProjectBreakout.Effects.ParticleSystem.BlockExplosion(videoDevice, new Vector3(this.X2, this.YHalfHeight, 0), new Vector3((int)this.Width/2, (int)this.Height/2, 0), this.CollisionArea, this.explosionRed, this.explosionGreen, this.explosionBlue);
				

				ps.DiedHandler += new DGGF.Effects.ParticleSystem.ParticleSystem.ParticleSystemDiedHandler(this.Kill);
				ps.Init();
			
				GameObject.psm.AddParticleSystem(ps);
				this.Visible = false;				

				this.sounds.EnableIt(0);
			}
			this.energy--;
			
		}


		public virtual void Kill()
		{
			this.Enabled = false;
		}		


		protected void LaunchBonus(Bonus.Bonus bonus)
		{
			if(!this.Visible && !isCreatedBonus)
			{
				isCreatedBonus = true;
				Block.staticBonus.Add(bonus);				
			}
		}


		public virtual void Destroy()
		{
		}
	}
}
