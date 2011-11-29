using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Physics;
using Syderis.CellSDK.IO.AccelerometerSystem;

namespace Joints
{
    class Application : MobileApplication
    {
        bool accelerometerIsConnected = false;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Image.CreateImage("background"),Adjustment.CENTER);

            CreatePhysicWorld(Vector2.Zero, true, true, new Vector2(-10));

            if (AccelerometerSensor.Instance.IsConnected)
			{
				AccelerometerSensor.Instance.Start();
                accelerometerIsConnected = true;
			}
            CreatesDummy(Width / 2, 0);
        }

        private void CreatesDummy(int offX, int offY)
        {
            // Head            
            Label dummyHead = new Label(Image.CreateImage("head"));
            AddComponent(dummyHead, 64 + offX, -11 + offY);
            PhysicWorld.AddBody(dummyHead);
            dummyHead.PhysicBody.CollisionCategory = Category.Cat1;
            dummyHead.BringToFront = false;
            dummyHead.Draggable = true;

            // Body
            Label dummyBody = new Label(Image.CreateImage("body"));
            AddComponent(dummyBody, 64 + offX, 43 + offY);
            PhysicWorld.AddBody(dummyBody);
            dummyBody.PhysicBody.CollisionCategory = Category.Cat2;
            dummyBody.Draggable = true;
            dummyBody.BringToFront = false;

            IJoint neck = PhysicWorld.AddJoint(dummyHead, dummyBody, new Vector2(86 + offX, 40 + offY), true, -MathHelper.PiOver4, MathHelper.PiOver4, 0.0f, float.MaxValue);

            // Left Arm
            Label dummyLeftArm = new Label(Image.CreateImage("arm_left_1"));
            AddComponent(dummyLeftArm, 0 + offX, 43 + offY);
            PhysicWorld.AddBody(dummyLeftArm);
            dummyLeftArm.PhysicBody.CollisionCategory = Category.Cat3;
            Label dummyLeftMiddleArm = new Label(Image.CreateImage("arm_left_2"));            
            AddComponent(dummyLeftMiddleArm, 32 + offX, 43 + offY);
            PhysicWorld.AddBody(dummyLeftMiddleArm);
            dummyLeftMiddleArm.PhysicBody.CollisionCategory = Category.Cat4;

            IJoint leftElbow = PhysicWorld.AddJoint(dummyLeftArm, dummyLeftMiddleArm, new Vector2(30 + offX, 49 + offY), true, -(5f / 8f) * MathHelper.Pi, (5f / 8f) * MathHelper.Pi, 0.0f, float.MaxValue);
            IJoint leftShoulder = PhysicWorld.AddJoint(dummyLeftMiddleArm, dummyBody, new Vector2(62 + offX, 49 + offY), true, -(15f / 32f) * MathHelper.Pi, (15f / 32f) * MathHelper.Pi, 0.0f, float.MaxValue);

            // Right Arm
            Label dummyRightArm = new Label(Image.CreateImage("arm_right_1"));
            AddComponent(dummyRightArm, 145 + offX, 43 + offY);
            PhysicWorld.AddBody(dummyRightArm);
            dummyRightArm.PhysicBody.CollisionCategory = Category.Cat5;
            Label dummyRightMiddleArm = new Label(Image.CreateImage("arm_right_2"));
            AddComponent(dummyRightMiddleArm, 113 + offX, 43 + offY);
            PhysicWorld.AddBody(dummyRightMiddleArm);
            dummyRightMiddleArm.PhysicBody.CollisionCategory = Category.Cat6;

            IJoint rightElbow = PhysicWorld.AddJoint(dummyRightArm, dummyRightMiddleArm, new Vector2(143 + offX, 49 + offY), true, -(5f / 8f) * MathHelper.Pi, (5f / 8f) * MathHelper.Pi, 0.0f, float.MaxValue);// +-90grados +22,5 grados = +-112,5 
            IJoint rightShoulder = PhysicWorld.AddJoint(dummyRightMiddleArm, dummyBody, new Vector2(111 + offX, 49 + offY), true, -(15f / 32f) * MathHelper.Pi, (15f / 32f) * MathHelper.Pi, 0.0f, float.MaxValue); // +-84grados

            // Left Leg
            Label dummyLeftLeg = new Label(Image.CreateImage("leg_left_1"));
            AddComponent(dummyLeftLeg, 60 + offX, 118 + offY);
            PhysicWorld.AddBody(dummyLeftLeg);
            dummyLeftLeg.PhysicBody.CollisionCategory = Category.Cat7;
            Label dummyLeftBottomLeg = new Label(Image.CreateImage("leg_left_2"));
            AddComponent(dummyLeftBottomLeg, 60 + offX, 168 + offY);
            PhysicWorld.AddBody(dummyLeftBottomLeg);
            dummyLeftBottomLeg.PhysicBody.CollisionCategory = Category.Cat8;

            IJoint leftKnee = PhysicWorld.AddJoint(dummyLeftLeg, dummyLeftBottomLeg, new Vector2(69 + offX, 167 + offY), true, -MathHelper.Pi / 16.0f, MathHelper.Pi / 16.0f, 0.0f, float.MaxValue); // +-5.625 grados
            IJoint leftGroin = PhysicWorld.AddJoint(dummyLeftLeg, dummyBody, new Vector2(69 + offX, 116 + offY), true, -MathHelper.Pi / 8.0f, MathHelper.Pi / 8.0f, 0.0f, float.MaxValue);              // +-22.5 grados

            // Right Leg
            Label dummyRightLeg = new Label(Image.CreateImage("leg_right_1"));
            AddComponent(dummyRightLeg, 93 + offX, 118 + offY);
            PhysicWorld.AddBody(dummyRightLeg);
            dummyRightLeg.PhysicBody.CollisionCategory = Category.Cat9;
            Label dummyRightBottomLeg = new Label(Image.CreateImage("leg_right_2"));
            AddComponent(dummyRightBottomLeg, 93 + offX, 168 + offY);
            PhysicWorld.AddBody(dummyRightBottomLeg);
            dummyRightBottomLeg.PhysicBody.CollisionCategory = Category.Cat10;

            PhysicWorld.AddJoint(dummyRightLeg, dummyRightBottomLeg, new Vector2(102 + offX, 167 + offY), true, -MathHelper.Pi / 16.0f, MathHelper.Pi / 16.0f, 0.0f, float.MaxValue); // +- 5.625 grados
            PhysicWorld.AddJoint(dummyRightLeg, dummyBody, new Vector2(102 + offX, 116 + offY), true, -MathHelper.Pi / 8.0f, MathHelper.Pi / 8.0f, 0.0f, float.MaxValue);  //+- 22.5 grados

            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

           if (accelerometerIsConnected)
                PhysicWorld.Gravity = AccelerometerSensor.Instance.Data2 * 30;
        }


        public override void BackButtonPressed()
        {
            AccelerometerSensor.Instance.Stop();
            Program.Instance.Exit();
        }
    }
}
