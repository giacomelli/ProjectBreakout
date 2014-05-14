using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Blocks
{
	/// <summary>
	/// Summary description for BlockFire.
	/// </summary>
	public class BlockFire : Block
	{
		private static DGGFTexture globalTexture = null;
		private ProjectBreakout.Effects.ParticleSystem.SquareFire ps;

		public static void LoadResources(Device videoDevice)
		{
			BlockFire.globalTexture = new DGGFTexture(TextureLoader.FromFile(videoDevice, "Images/Blocks/BlockFire.png"));
		}


		public BlockFire(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area,  float x, float y) : base(videoDevice, soundDevice, sprite, area, BlockFire.globalTexture, 1, 1, x, y)
		{
			this.Energy = 1;
            
			this.explosionRed = 255;
			this.explosionGreen = 100;
			this.explosionBlue = 10;	
		
			this.ps = new ProjectBreakout.Effects.ParticleSystem.SquareFire(this.videoDevice, this.Position, this.Size, this.CollisionArea, 75);			
			ps.Init();
			Level.psm.AddParticleSystem(ps);			
		}

		
		public override void Update()
		{
			if(!this.Visible)
			{
				ps.Died = true;
			}
		}


		public override void Render()
		{
		}

		public override void Destroy()
		{
			ps.Died = true;
		}


	}
}
