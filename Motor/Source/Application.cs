using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Physics;

using Syderis.CellSDK.IO.AccelerometerSystem;

namespace Motor
{
	class Application : MobileApplication
	{
        IMotionWheel tractionWheel, passiveWheel;

		Image iCar;
		Image iWheel;
		
		
		bool accerometerActivated = false;
		
		public override void Initialize ()
		{
			base.Initialize ();
			
			SetBackground(Image.CreateImage("background"),Adjustment.CENTER);
			
			if(AccelerometerSensor.Instance.IsConnected)
			{
				AccelerometerSensor.Instance.Start();
				accerometerActivated = true;
			}
			CreatePhysicWorld(new Vector2(-20, 0), false, true, Vector2.UnitX*-100);
			
			iCar = Image.CreateImage("car");
			iWheel = Image.CreateImage("wheel");
			
			Label lCar = new Label(iCar);
			lCar.Draggable = true;
			lCar.Rotable = true;
			Label lWheel1 = new Label(iWheel);
			lWheel1.Touchable = false;
			Label lWheel2 = new Label(iWheel);
			lWheel2.Touchable = false;
			
			AddComponent(lCar, 18, 0);
			AddComponent(lWheel1, 0, 44);
			AddComponent(lWheel2, 0, 137);
			
			lCar.BringToFront = false;
			lWheel1.BringToFront = false;
			lWheel2.BringToFront = false;
			
			PhysicWorld.AddBody(lCar);
			PhysicWorld.AddBody(lWheel1, BodyType.DYNAMIC, BodyShape.CIRCLE,Category.Cat1);
			PhysicWorld.AddBody(lWheel2, BodyType.DYNAMIC, BodyShape.CIRCLE, Category.Cat1);
			
			lCar.PhysicBody.Mass = 150.0f;
			lCar.PhysicBody.Restitution = 0.1f;
			
			lWheel1.PhysicBody.Friction = 1.0f;
			lWheel1.PhysicBody.Restitution = 0.1f;
			lWheel1.PhysicBody.Mass = 25.0f;
			
			lWheel2.PhysicBody.Friction = 1.0f;
			lWheel2.PhysicBody.Restitution = 0.1f;
			lWheel2.PhysicBody.Mass = 50.0f;
			
			passiveWheel = PhysicWorld.AddMotionWheel(lCar, lWheel1, Vector2.UnitY, false, 0.0f, 1f, 1500.0f, 350.0f);
			tractionWheel= PhysicWorld.AddMotionWheel(lCar, lWheel2, Vector2.UnitY, true,  0.0f, 1f, 1500.0f, 350.0f);
			
			Button btnLeft = new Button("Engine LEFT");
			btnLeft.Released += HandleBtnLeftReleased;
			AddComponent(btnLeft, Width/2, 100);
			btnLeft.Rotation = MathHelper.PiOver2;
			
			Button btnStop = new Button("Engine STOP");
			btnStop.Released += HandleBtnStopReleased;
			AddComponent(btnStop, Width/2, 300);
			btnStop.Rotation = MathHelper.PiOver2;
			
			Button btnRight = new Button("Engine RIGHT");
			btnRight.Released += HandleBtnRightReleased;
			AddComponent(btnRight, Width/2, 500);
			btnRight.Rotation = MathHelper.PiOver2;
		}

		void HandleBtnRightReleased (Component source)
		{
			tractionWheel.MotorSpeed  = -70.0f;
		}

		void HandleBtnStopReleased (Component source)
		{
			tractionWheel.MotorSpeed = 0.0f;			
		}

		void HandleBtnLeftReleased (Component source)
		{
			tractionWheel.MotorSpeed = 70.0f;			
		}
		
		public override void Update (GameTime gameTime)
		{
			base.Update (gameTime);
			
			if(accerometerActivated)
				PhysicWorld.Gravity = AccelerometerSensor.Instance.Data2 * 20;
		}

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            if (accerometerActivated)
                AccelerometerSensor.Instance.Stop();
            Program.Instance.Exit();
        }

	}
}