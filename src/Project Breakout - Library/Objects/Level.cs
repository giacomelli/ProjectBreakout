using System;
using System.Drawing;
using System.Xml;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.Collections;
using ProjectBreakout.Objects.Balls;
using ProjectBreakout.Objects.Beaters;
using ProjectBreakout.Objects.Blocks;
using ProjectBreakout.Objects.Bonus;


namespace ProjectBreakout.Objects
{
	/// <summary>
	/// Summary description for Level.
	/// </summary>
	public class Level : DGGF.Objects.Level
	{
		#region Members of Data
		
		private DGGF.Drawing.DGGFTexture background;
		private Vector3 bkCenter = new Vector3(0, 0, 0);
		private Vector3 bkPos = new Vector3(0, 0, 0);

		// Objects
		public static GameObjectCollection blocks;
		public static GameObjectCollection balls;
		private GameObjectCollection bonus;
		public static Beater beater;

		
		
		#endregion
		

		#region Constructors
		public Level(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, System.Windows.Forms.Form form) : base(videoDevice, soundDevice, sprite, form)
		{
			this.mapArea.X = 100;
			this.mapArea.Width -= 100;
			GameObject.ParticleSystemManager = Level.psm;
		}
		#endregion


		#region Properties
		/*
		public static GameObjectCollection Blocks
		{
			get
			{
				return this.blocks;
			}
		}

		*/

		#endregion


		#region Methods
		public override void LoadResources()
		{
			// Load Resources
			DGGF.Effects.ParticleSystem.ParticleSystem.LoadResources(Level.videoDevice);

			Block.LoadResources(Level.soundDevice);
			BlockSimple.LoadResources(Level.videoDevice);
			BlockMultiColor.LoadResources(Level.videoDevice);
			BlockXXX.LoadResources(Level.videoDevice);
			BlockBall.LoadResources(Level.videoDevice);
			BlockSquareHole.LoadResources(Level.videoDevice);
			BlockFire.LoadResources(Level.videoDevice);
			
			Ball.LoadResources(Level.soundDevice);
			BallSimple.LoadResources(Level.videoDevice);
			
			Bonus.Bonus.LoadResources(Level.soundDevice);
			BonusSimple.LoadResources(Level.videoDevice);
			BonusBall.LoadResources(Level.videoDevice);
			
			BeaterSimple.LoadResources(Level.videoDevice);
		}


		public override void Init()
		{
			// Initialize objects
			Level.blocks = new GameObjectCollection(1000);
			Level.balls = new GameObjectCollection(1000);
			this.bonus = new GameObjectCollection(1000);
			Level.beater = new BeaterSimple(Level.videoDevice, Level.soundDevice, Level.sprite, this.mapArea);

			Block.BonusCollection = this.bonus;
			
			
			// Balls
			BallSimple ball = new BallSimple(Level.videoDevice, Level.soundDevice, Level.sprite, mapArea);
			ball.Beater = Level.beater;
			ball.Blocks = Level.blocks.Array;
			Level.balls.Add(ball);

			/**/
			ball = new BallSimple(Level.videoDevice, Level.soundDevice, Level.sprite, mapArea);
			ball.X = 10;
			ball.Y = 10;
			ball.Beater = Level.beater;
			ball.Blocks = Level.blocks.Array;
			Level.balls.Add(ball);	

			ball = new BallSimple(Level.videoDevice, Level.soundDevice, Level.sprite, mapArea);
			ball.X = 100;
			ball.Y = 100;
			ball.Beater = Level.beater;
			ball.Blocks = Level.blocks.Array;			

			Level.balls.Add(ball);
			/**/

			Level.psm.Init(null);	
	

			this.background = new DGGF.Drawing.DGGFTexture(TextureLoader.FromFile(Level.videoDevice, AppDomain.CurrentDomain.BaseDirectory + "Images/Levels/bk_01.png"));			
		}			


		public override void LoadFromXML(XmlDocument xmlLevel)
		{
			// Load objects from XML File
			// Blocks
			if(Convert.ToInt32(xmlLevel.DocumentElement.Attributes["count"].Value) > 0)
			{
				for(int i = 0; i < xmlLevel.DocumentElement.ChildNodes.Count; i++)
				{				
					Level.blocks.Add(Utilities.Geral.CreateBlockInstance(xmlLevel.DocumentElement.ChildNodes[i].Attributes["Type"].Value, Level.videoDevice, Level.soundDevice, Level.sprite, this.mapArea, Convert.ToInt32(xmlLevel.DocumentElement.ChildNodes[i].Attributes["X"].Value), Convert.ToInt32(xmlLevel.DocumentElement.ChildNodes[i].Attributes["Y"].Value)));
				}
			}			
		}


		public override void ToXML(XmlDocument xmlLevel)
		{

		}



		public void AddBlock(Block b)
		{
			Level.blocks.Add(b);
		}

		public void RemoveBlock(int index)
		{
			Level.blocks.Remove(index);
		}

		public override void Update()
		{
			Level.blocks.Update();
			Level.beater.Update();
			Level.balls.Update();			
			this.bonus.Update();
			Level.psm.Update();
		}


		public override void Render()
		{
			Level.sprite.Begin(SpriteFlags.AlphaBlend);			

				Level.sprite.Draw(this.background.InternalTexture, bkCenter, bkPos, System.Drawing.Color.White.ToArgb());
				Level.blocks.Render();
				Level.beater.Render();
				Level.balls.Render();			
				this.bonus.Render();
			
			Level.sprite.End();

			Level.psm.Render();			
		}


		public override void PlaySound()
		{
			Level.blocks.PlaySound();
			Level.beater.PlaySound();
			Level.balls.PlaySound();			
			this.bonus.PlaySound();
		}
		#endregion
	}
}
