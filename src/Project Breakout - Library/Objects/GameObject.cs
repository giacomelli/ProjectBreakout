using System;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using DGGF.Objects;
using DGGF.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace ProjectBreakout.Objects
{
	/*
	public enum GameObjectType
	{
		Ball,
		Beater,
		BlockSimple,
		BlockMultiColor,
		Bonus

	}
	*/
	/// <summary>
	/// Summary description for GameObject.
	/// </summary>
	public abstract class GameObject : DGGF.Objects.GameObject
	{			
		protected static DGGF.Effects.ParticleSystem.Manager psm;

		public GameObject(Device videoDevice, Microsoft.DirectX.DirectSound.Device soundDevice, Sprite sprite, Rectangle area, DGGFTexture texture, int columnsFrames, int rowsFrames, float x, float y, int psQuantity) : base(videoDevice, soundDevice, sprite, texture, columnsFrames, rowsFrames, x, y)
		{
			this.CollisionArea = area;
		}


		public static DGGF.Effects.ParticleSystem.Manager ParticleSystemManager
		{
			set
			{
				GameObject.psm = value;
			}
		}

		public override void Init()
		{

		}

		public override void Update()
		{
			base.Update ();
		}


		public override void Render()
		{
			if(this.Visible)
			{
				base.Render();
			}
		}



		public override void Collide()
		{
		}


		public override void ToXML(System.Xml.XmlDocument doc)
		{	
			XmlElement e = doc.CreateElement("object");	
			// ID
			XmlAttribute att = doc.CreateAttribute("ID");
			att.Value = this.ID.ToString();
			e.Attributes.Append(att);

			// X
			att = doc.CreateAttribute("X");
			att.Value = this.X.ToString();
			e.Attributes.Append(att);

			// Y
			att = doc.CreateAttribute("Y");
			att.Value = this.Y.ToString();
			e.Attributes.Append(att);

			// Type
			att = doc.CreateAttribute("Type");
			att.Value = this.GetType().ToString();
			e.Attributes.Append(att);

			doc.DocumentElement.AppendChild(e);			
		}

	}
}
