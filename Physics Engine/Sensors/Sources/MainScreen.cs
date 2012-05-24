/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core;

using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Physics; 
#endregion

namespace Sensor
{
    class MainScreen : Screen
    {
        Vector2 offset;
        Image iSupport;
        Image iBall;
        Image iMetalCradle;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
#if IOS
            offset=new Vector2(80,80);
#else
            offset = Vector2.Zero;
#endif

            int ballSize = 78;

            CreatePhysicWorld(Vector2.UnitX * -20f, true, false, Vector2.Zero);

            SetBackground(ResourceManager.CreateImage("background"), Adjustment.CENTER);

            iSupport = ResourceManager.CreateImage(Color.Transparent, 1, 1);
            iBall = ResourceManager.CreateImage("ball");
            iMetalCradle = ResourceManager.CreateImage("metalSupport");

            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 0 * ballSize), 300, true);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 1 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 2 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 3 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 4 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 5 * ballSize), 300, true);

            Sprite lMetalSupport = new Sprite("metal",iMetalCradle);
			lMetalSupport.Pivot = Vector2.One/2;
            AddComponent(lMetalSupport, Preferences.ViewportManager.MiddleCenterAnchor);

            lMetalSupport.Touchable = false;
            PhysicWorld.Iterations = 120;
        }

        public void CreateNewtonBall(Image iGround, Image iSphere, Vector2 vPosition, int ropeLength, bool touchable)
        {
            Label lSupport = new Label(iGround); //Static Label 
            Sprite lBall = new Sprite("ball",iSphere); //Label with the ball texture.

            //We add the lSupport as a static physic object. So it does not interact with anything
            AddComponent(lSupport, vPosition.X + offset.X, vPosition.Y + offset.Y, BodyShape.SQUARE, BodyType.STATIC, Category.Cat1);
            //We add the IBall label 
            AddComponent(lBall, vPosition.X - ropeLength + offset.X, vPosition.Y + offset.Y, BodyShape.CIRCLE, BodyType.DYNAMIC, Category.Cat1);

            lBall.BringToFront = false;
            lBall.PhysicBody.Mass = 4.0f; //ball mass.
            lBall.PhysicBody.Restitution = 1.0f;//ball restitution
            lBall.PhysicBody.Friction = 8.0f; //ball friction
            lBall.Touchable = touchable; // set the Touchable to true or false
            lBall.Draggable = touchable; //set the Draggable to true or false

            PhysicWorld.AddSensor(lSupport, lBall, lSupport.Position + lSupport.Size / 2, lBall.Position + lBall.Size / 2, false, 30, 30, 800.0f, 100.0f);
        }

        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
