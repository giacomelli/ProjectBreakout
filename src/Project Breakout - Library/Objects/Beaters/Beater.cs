using System;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Objects;
using DGGF.Drawing;
using System.Windows.Forms;

namespace ProjectBreakout.Objects.Beaters
{
	/// <summary>
	/// Summary description for Beater.
	/// </summary>
	public class Beater : GameObject
	{
		private DGGF.Effects.ParticleSystem.FireJet leftFireJet;
		private DGGF.Effects.ParticleSystem.FireJet rightFireJet;
		private BasicObject[] collisionAreas; 

		public Beater(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area, DGGFTexture texture, int columnsFrames, int rowsFrames) : base(videoDevice, soundDevice, sprite, area, texture, columnsFrames, rowsFrames, (area.X + area.Width / 2) - ((texture.Width / columnsFrames) / 2), area.Bottom - texture.Height - 10, 2)
		{
			this.SpeedX = 7;

			Vector3 psSize = new Vector3(7, this.Height / 10, 0);
			
			leftFireJet = new DGGF.Effects.ParticleSystem.FireJet(videoDevice, new Vector3(this.X2, this.YHalfHeight, 0), psSize, area, 150);
			rightFireJet = new DGGF.Effects.ParticleSystem.FireJet(videoDevice, new Vector3(this.X2, this.YHalfHeight, 0), psSize, area, 150);
			psm.AddParticleSystem(leftFireJet);
			psm.AddParticleSystem(rightFireJet);

			this.leftFireJet.ParticleSize = 10;
			this.rightFireJet.ParticleSize = 10;
			this.leftFireJet.ToggleEnabled();
			this.rightFireJet.ToggleEnabled();


			// Define the collision with the ball
			float areaWidth = this.Width / 3;
			this.collisionAreas = new BasicObject[3];
			for(int i = 0; i < this.collisionAreas.Length; i++)
			{
				this.collisionAreas[i] = new BasicObject(0,	0, areaWidth, 1);
			}
		}



		/// <summary>
		/// Implements the treatment on the ball and it collide with some areas of the beater
		/// </summary>
		/// <param name="ball">Ball that collide</param>
		public void DoCollisionByBall(Balls.Ball ball)
		{
			for(int i = 0; i < this.collisionAreas.Length; i++)
			{	
				this.collisionAreas[i].X = this.X + (this.collisionAreas[i].Width * i);

				if(ball.CheckXCollision(this.collisionAreas[i]))
				{			
					ball.DirectionY = -1;

					switch(i)
					{
						case 0:
							if(ball.DirectionX <= -1)
								ball.DirectionX = -2;
							else if(ball.DirectionX == 0)
								ball.DirectionX = -1;
							else
								ball.DirectionX = 1;

							break;

						case 1:
							ball.DirectionX = 0;
							break;

						case 2:
							if(ball.DirectionX >= 1)
								ball.DirectionX = 2;
							else if(ball.DirectionX == 0)
								ball.DirectionX = 1;
							else
								ball.DirectionX = -1;
							break;
					}
				}
			}
			 
			

		}


		public override void Update()
		{
			
			switch(DGGF.UI.Keyboard.KeyCode)
			{
				case Keys.Left:
					this.MoveLeft();
					//this.leftFireJet.Enabled = false;
					this.rightFireJet.Enabled = true;
					break;

				case Keys.Right:
					this.MoveRight();
					this.leftFireJet.Enabled = true;
					//this.rightFireJet.Enabled = false;
					break;
				/*
				default:
					this.leftFireJet.Enabled = false;
					this.rightFireJet.Enabled = false;
				break;
				*/
			}			

			this.leftFireJet.X = this.X;
			this.leftFireJet.Y = this.YHalfHeight;

			this.rightFireJet.X = this.X2;
			this.rightFireJet.Y = this.YHalfHeight;

			base.Update ();			
		}
	}
}
