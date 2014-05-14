using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using ProjectBreakout.Effects.ParticleSystem;

namespace ProjectBreakout.Text
{
	/// <summary>
	/// Summary description for FireText.
	/// </summary>
	public class FireText
	{
		Device videoDevice;		
		private int maxQuantityChars;
		protected Texture texture;
		protected System.Random rnd;
		protected DGGF.Effects.ParticleSystem.Manager psm;

		public FireText(Device videoDevice, int maxQuantityChars)
		{
			this.videoDevice = videoDevice;
			this.maxQuantityChars = 4;		

		}


		public void Init()
		{
			this.psm = new DGGF.Effects.ParticleSystem.Manager(this.videoDevice, this.maxQuantityChars);
			// Top
			DGGF.Effects.ParticleSystem.Smoke ps = new DGGF.Effects.ParticleSystem.Smoke(this.videoDevice, new Vector3(200, 100, 0), new Vector3(200, 5, 0), new Rectangle(0, 0, 800, 600), 250);
			ps.ParticleSize = 16;
			this.psm.AddParticleSystem(ps);

			// Bottom
			ps = new DGGF.Effects.ParticleSystem.Smoke(this.videoDevice, new Vector3(200, 300, 0), new Vector3(200, 5, 0), new Rectangle(0, 0, 800, 600), 250);
			ps.ParticleSize = 16;
			this.psm.AddParticleSystem(ps);

			// Left
			ps = new DGGF.Effects.ParticleSystem.Smoke(this.videoDevice, new Vector3(200, 100, 0), new Vector3(5, 200, 0), new Rectangle(0, 0, 800, 600), 250);
			ps.ParticleSize = 16;
			this.psm.AddParticleSystem(ps);

			// Right
			ps = new DGGF.Effects.ParticleSystem.Smoke(this.videoDevice, new Vector3(400, 100, 0), new Vector3(5, 200, 0), new Rectangle(0, 0, 800, 600), 250);
			ps.ParticleSize = 16;
			this.psm.AddParticleSystem(ps);

			this.psm.Init(null);

			
		}


		public void Update()
		{
			this.psm.Update();
		}


		public void Render()
		{
			this.psm.Render();
		}
	}
}
