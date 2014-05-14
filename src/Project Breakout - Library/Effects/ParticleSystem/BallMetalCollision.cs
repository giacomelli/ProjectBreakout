using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace ProjectBreakout.Effects.ParticleSystem
{
	/// <summary>
	/// Summary description for BallMetalCollision.
	/// </summary>
	public class BallMetalCollision : DGGF.Effects.ParticleSystem.ParticleSystem
	{
		public BallMetalCollision(Device videoDevice, Vector3 position, Vector3 size, Rectangle area) : base(videoDevice, position, size, area, 25)
		{
			this.reborn = false;
			this.particleSize = 4;

			this.MinLifeTime = 50;
			this.MaxLifeTime = 100;

			this.MinSpeedX = -2;
			this.MaxSpeedX = 2;

			this.MinSpeedY = -2;
			this.MaxSpeedY = 2;

			this.size = new Vector3(5, 5, 1);
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
					
			this.particles[i].Red = 128;
			this.particles[i].Green = 128;
			this.particles[i].Blue = 200;
								
			this.particles[i].LifeTime = rnd.Next(this.MinLifeTime, this.MaxLifeTime);			
			this.particles[i].Alpha = (int)(0.6f + (0.2f * this.particles[i].LifeTime));
		}

			
		public override void Update()
		{
			base.Update (this.area);
		}
	}
}
