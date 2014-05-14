using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Effects.ParticleSystem;

namespace ProjectBreakout.Effects.ParticleSystem
{
	/// <summary>
	/// Summary description for BlockExplosion.
	/// </summary>
	public class BlockExplosion : DGGF.Effects.ParticleSystem.ParticleSystem
	{
		private int r, g, b;

		public BlockExplosion(Device videoDevice, Vector3 position, Vector3 size, Rectangle area, int r, int g, int b) : base(videoDevice, position, size, area, 150)
		{		
			this.Reborn = false;
			this.ParticleSize = 8;
				
			this.MinLifeTime = 10;
			this.MaxLifeTime = 50;
				
			this.MinSpeedX = -5;
			this.MaxSpeedX = 5;

			this.MinSpeedY = -5;
			this.MaxSpeedY = 5;

			this.r = r;
			this.g = g;
			this.b = b;
		}


		protected override void DefineParticle(int i)
		{				
			double r = rnd.NextDouble();			
			
			this.particles[i].X = rnd.Next((int)(this.position.X - this.size.X), (int)(this.position.X + this.size.X));
			this.particles[i].Y = rnd.Next((int)(this.position.Y - this.size.Y), (int)(this.position.Y + this.size.Y));
			
			this.particles[i].SpeedX = rnd.Next(this.MinSpeedX, this.MaxSpeedX) * 0.5f;
			this.particles[i].SpeedY = rnd.Next(this.MinSpeedY, this.MaxSpeedY) * 0.5f;

			this.particles[i].AccelerationX = this.wind;
			this.particles[i].AccelerationY = this.gravity;
			
			this.particles[i].Red = this.r;
			this.particles[i].Green = this.g;
			this.particles[i].Blue = this.b;
						
			this.particles[i].LifeTime = rnd.Next(this.MinLifeTime, this.MaxLifeTime);			
			this.particles[i].Alpha = (int)(0.6f + (0.2f * this.particles[i].LifeTime));
		}

		
		public override void Update()
		{
			base.Update (this.area);
		}

	}
}
