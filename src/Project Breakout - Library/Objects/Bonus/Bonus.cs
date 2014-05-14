using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using DGGF.Objects;
using DGGF.Drawing;

namespace ProjectBreakout.Objects.Bonus
{
	/// <summary>
	/// Summary description for Bounus.
	/// </summary>
	public abstract class Bonus : GameObject
	{
		private static DGGF.Collections.SoundCollection staticSounds;
		protected bool deliveredBonus = false;


		public static void LoadResources(Microsoft.DirectX.DirectSound.Device soundDevice)
		{
			staticSounds = new DGGF.Collections.SoundCollection(1);
			//staticSounds.Add(new Microsoft.DirectX.DirectSound.SecondaryBuffer(@"Sounds\Blocks\explosion.wav", soundDevice));
		}

		public Bonus(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area, DGGFTexture texture, int columnsFrames, int rowsFrames, float x, float y) : base(videoDevice, soundDevice, sprite, area, texture, columnsFrames, rowsFrames, x, y, 10)
		{
			this.sounds = staticSounds;
		}


		public override void Update()
		{
			if(!this.deliveredBonus && this.CheckCollision(Level.beater))		
			{
				this.DeliveryBonus();
				this.deliveredBonus = true;
			}
		}

		
		protected abstract void DeliveryBonus();
	}
}
