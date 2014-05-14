using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Effects.ParticleSystem;

namespace ProjectBreakout.Effects.ParticleSystem
{
	/// <summary>
	/// Summary description for SquareFire.
	/// </summary>
	public class SquareFire : DGGF.Effects.ParticleSystem.ParticleSystem
	{
		public SquareFire(Device videoDevice, Vector3 position, Vector3 size, RectangleF area, int particlesQuantity) : base(videoDevice, position, size, area, particlesQuantity)
		{
			this.ParticleSize = 5;
			this.gravity = -0.001f;
		}


		protected override void DefineParticle(int i)
		{	
			double r = rnd.NextDouble();
			this.particles[i].X = (float)(this.position.X + (r * this.size.X));
			this.particles[i].Y = (float)(this.position.Y + (rnd.NextDouble() * this.size.Y));
			this.particles[i].SpeedX = 0;
			this.particles[i].SpeedY = 0;
			this.particles[i].AccelerationX = 0;
			this.particles[i].AccelerationY = (float)(-(r * 0.3f));
					
			this.particles[i].Red = 255;
			this.particles[i].Green = 100;
			this.particles[i].Blue = 51;
			this.particles[i].Alpha = (int)(0.6f + (0.2f * r));
					
			this.particles[i].LifeTime = rnd.Next(50, 250);
		}		
	}
}
