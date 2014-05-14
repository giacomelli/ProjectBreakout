using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Objects;
using DGGF.Drawing;
using ProjectBreakout.Objects.Beaters;
using System.Drawing;

namespace ProjectBreakout.Objects.Balls
{
	/// <summary>
	/// Summary description for Ball.
	/// </summary>
	public class Ball : GameObject
	{
		#region Members of Data
		private Beater beater = null;		
		private DGGF.Objects.GameObject[] blocks;
		private int energy = -1;
		#endregion


		public static void LoadResources(Microsoft.DirectX.DirectSound.Device soundDevice)
		{
		}


		#region Constructors
		public Ball(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area, DGGFTexture texture, int columnsFrames, int rowsFrames) : base(videoDevice, soundDevice, sprite, area, texture, columnsFrames, rowsFrames, 400, 550, 50)
		{
			this.DirectionX = 1;
			this.DirectionY = 1;

			this.SpeedX = 3f;
			this.SpeedY = 3f;	
		
			this.CycleType = DGGF.Objects.AnimatedObjectCycleType.Circular;	

			this.sounds = new DGGF.Collections.SoundCollection(1);
			Microsoft.DirectX.DirectSound.SecondaryBuffer sb = new Microsoft.DirectX.DirectSound.SecondaryBuffer("Sounds/Balls/collision.wav", soundDevice);
		
			Microsoft.DirectX.DirectSound.EffectDescription[] effects = new Microsoft.DirectX.DirectSound.EffectDescription[1];
			effects[0].GuidEffectClass = Microsoft.DirectX.DirectSound.DSoundHelper.StandardEchoGuid;
			sb.SetEffects(effects);			
			
			this.sounds.Add(sb);
		}
		#endregion


		#region Properties
		public Beater Beater
		{
			get
			{
				return this.beater;
			}

			set
			{
				this.beater = value;
			}
		}


		public DGGF.Objects.GameObject[] Blocks
		{
			get
			{
				return this.blocks;
			}

			set
			{
				this.blocks = value;
			}
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
				if(value == 0)
				{
					this.Enabled = false;
					this.Visible = false;
					this.died = true;
				}
			}
		}
		#endregion


		#region Methods
		public override void Update()
		{	
			// Blocks collision
			this.CheckCollisionBlocks();

			// Beater collision
			if(this.CheckCollision(this.beater))
			{				
				this.beater.DoCollisionByBall(this);
				this.DoExplosion();				
			}	
			
			// Edges collision (map area)
			if(!this.MoveX())
			{
				this.DirectionX *= -1;
				this.DoExplosion();
			}

			if(!this.MoveY())
			{
				this.DirectionY *= -1;
				this.DoExplosion();
			}
					
		
			base.Update();						
		}


		private void DoExplosion()
		{			
			Effects.ParticleSystem.BallMetalCollision ps = new Effects.ParticleSystem.BallMetalCollision (videoDevice, new Vector3(this.X2, this.YHalfHeight, 0),  this.Size, CollisionArea);
			ps.Init();
			
			GameObject.psm.AddParticleSystem(ps);	
			this.sounds.EnableIt(0);			
		}


		private void CheckCollisionBlocks()
		{			
			if(this.blocks != null)
			{		
								
				if(this.CheckRightCollision(this.blocks) || this.CheckLeftCollision(this.blocks))
				{
					this.DoExplosion();
					this.DirectionX *= -1;					 
					this.blocks[this.IndexCollidedObject].Collide();
					this.Energy--;
				}
				
				if(this.CheckTopCollision(this.blocks) || this.CheckBottomCollision(this.blocks))
				{
					this.DoExplosion();
					this.DirectionY *= -1;					
					this.blocks[this.IndexCollidedObject].Collide();
					this.Energy--;
				}

			}
		}
		#endregion
	}
}

