using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DGGF.UI.Forms;
using ProjectBreakout.Objects.Beaters;
using ProjectBreakout.Objects.Balls;
using ProjectBreakout.Objects.Blocks;
using ProjectBreakout.Objects;

namespace ProjectBreakout.UI.Forms
{
	/// <summary>
	/// Summary description for Game.
	/// </summary>
	public class Game : DGGF.UI.Forms.Game
	{		
		private Level level;
		private Text.FireText ft;
		private DGGF.UI.Controls.Mouse.ParticleSystemMouse psMouse;
		private DGGF.UI.Controls.Panel.ParticleSystemPanel psPanel;
		#region Opening
		private DGGF.Drawing.DGGFTexture openingTexture;
		private Vector3 center = new Vector3(0, 0, 0);
		private Vector3 pos = new Vector3(180, 35, 0);	
	
		private DGGF.Effects.ParticleSystem.Sun psComet;
		private DGGF.Effects.ParticleSystem.Fire psFireTop;
		private DGGF.Effects.ParticleSystem.Fire psFireBottom;

		private RectangleF[] openingRectanglesCollision;
		#endregion

		#region Opening
		protected override void DoOpeningStart()
		{			
			string soundFile = AppDomain.CurrentDomain.BaseDirectory + @"Sounds\Opening\opening.mp3";		
			Microsoft.DirectX.AudioVideoPlayback.Audio soundTrack = new Microsoft.DirectX.AudioVideoPlayback.Audio(soundFile);			
			soundTrack.Play();
			soundTrack.Ending += new EventHandler(this.OpeningSoundEnding);
			
			this.openingTexture = new DGGF.Drawing.DGGFTexture(TextureLoader.FromFile(this.videoDevice, AppDomain.CurrentDomain.BaseDirectory + @"\Images\Opening\background.png"));			

			psFireTop = new DGGF.Effects.ParticleSystem.Fire(this.videoDevice, new Vector3(0, this.Top - 50, 0), new Vector3(this.Width, 5, 0), this.Rectangle, 1000);
			this.particleSystemManager.AddParticleSystem(psFireTop);
			psFireTop.ParticleSize = 9;
			psFireTop.Gravity = 0.09f;
			psFireTop.Init();


			psFireBottom = new DGGF.Effects.ParticleSystem.Fire(this.videoDevice, new Vector3(0, this.Bottom - 90, 0), new Vector3(this.Width, 5, 0), this.Rectangle, 1000);
			this.particleSystemManager.AddParticleSystem(psFireBottom);
			psFireBottom.ParticleSize = 9;
			psFireBottom.Gravity = -0.09f;
			psFireBottom.Init();


			psComet = new DGGF.Effects.ParticleSystem.Sun(this.videoDevice, new Vector3(0, 300, 0), new Vector3(5, 5, 0), this.Rectangle, 1000);
			this.particleSystemManager.AddParticleSystem(psComet);
			psComet.ParticleSize = 9;
			psComet.Wind = -0.01f;
			psComet.Enabled = false;
			psComet.Init();

			this.openingRectanglesCollision = new RectangleF[1];
			this.openingRectanglesCollision[0] = new RectangleF(0, psComet.Y - psComet.Height / 2, 50, 50); 

		}


		private void OpeningSoundEnding(object sender, EventArgs args)
		{
			this.state = GameState.Level;
			this.ShowLevel();
		}


		protected override void DoOpeningStep()
		{
			this.sprite.Begin(SpriteFlags.None);
			this.sprite.Draw(this.openingTexture.InternalTexture, this.center, this.pos, Color.White.ToArgb());
			this.sprite.End();


			if(openingStepsCount > 420)
			{
				this.psComet.Enabled = true;
				this.psComet.X += 15;
				this.openingRectanglesCollision[0].X = psComet.X;
				this.particleSystemManager.Wind += 0.05f;				
				//this.particleSystemManager.Gravity = - 0.0f;
				this.particleSystemManager.RectanglesExternalCollision = openingRectanglesCollision;
				psComet.Gravity = 0.0f;
				psComet.Wind = 0.0f;
				
			}

			this.particleSystemManager.Update();
			this.particleSystemManager.Render();
		}


		protected override void DoOpeningFinish()
		{
			this.particleSystemManager.KillAll();
		}



		#endregion


		public override void Init()
		{
			this.Width = 800;
			this.Height = 600;
			base.Init();

			this.MaxOpeningFPS = 1000;

			this.Text = "Projeto Breakout";

			this.level = new Level(this.VideoDevice, this.SoundDevice, this.sprite, this);
			this.level.LoadResources();	
		
			
			if(this.WindowType == DGGF.UI.Forms.WindowType.Windowed)
				this.Hide();
			
			Utilities.Geral.LoadLevel(level);
			
			if(this.WindowType  == DGGF.UI.Forms.WindowType.Windowed)
				this.Show();
				
			this.ft = new ProjectBreakout.Text.FireText(this.VideoDevice, 3);
			this.ft.Init();


			DGGF.Effects.ParticleSystem.Sun psMove = new DGGF.Effects.ParticleSystem.Sun(this.VideoDevice, new Vector3(0, 0, 0), new Vector3(1, 1, 0), new Rectangle(0, 0, 800, 600), 150);
			psMove.ParticleSize = 10;

			DGGF.Effects.ParticleSystem.Explosion psKeyPress = new DGGF.Effects.ParticleSystem.Explosion(this.VideoDevice, new Vector3(0, 0, 0), new Vector3(10, 10, 0), new Rectangle(0, 0, 800, 600), 150);
			psKeyPress.ParticleSize = 10;
			
			this.psMouse = new DGGF.UI.Controls.Mouse.ParticleSystemMouse(psMove, psKeyPress); 
			this.psMouse.Init();

			this.psPanel = new DGGF.UI.Controls.Panel.ParticleSystemPanel(this.VideoDevice, new Rectangle(this.ClientRectangle.Left, this.ClientRectangle.Top + 10, 100, this.ClientRectangle.Height));
			this.psPanel.Init();
			
		}


		public override void Start()
		{
			this.ShowOpening();
			this.ShowLevel();
		}


		public override void DoMenu()
		{
			this.ShowLevel();
			this.state = GameState.Level;
		}


		#region Level
		
		protected override void DoLevelStart()
		{
			string soundFile = AppDomain.CurrentDomain.BaseDirectory + @"\Sounds\Levels\PG_ST_03.wav";		
			if(System.IO.File.Exists(soundFile))
			{
				Microsoft.DirectX.DirectSound.SecondaryBuffer soundTrack = new Microsoft.DirectX.DirectSound.SecondaryBuffer(soundFile, this.SoundDevice);
				soundTrack.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Looping);
			}
		}


		protected override void DoLevelStep()
		{
			this.level.Update();
			this.level.Render();
			this.level.PlaySound();

			
			//this.ft.Update();
			//this.ft.Render();
			
			
			this.psMouse.Update();
			this.psMouse.Render();
			/*
			this.psPanel.Update();
			this.psPanel.Render();
			/**/
			this.GameFont.DrawText(null, "Particle Systems: " + Level.psm.QuantityAliveParticleSystems.ToString(), this.Width - 200, this.Height - 80, System.Drawing.Color.Green);			
			this.GameFont.DrawText(null, "Particles       : " + Level.psm.QuantityParticles.ToString(), this.Width - 200, this.Height - 60, System.Drawing.Color.Green);			
			this.GameFont.DrawText(null, "FPS             : " + DGGF.Algorithm.Util.CalculateFPS(), this.Width - 200, this.Height - 40, System.Drawing.Color.Green);			
		}
		#endregion
	}
}
