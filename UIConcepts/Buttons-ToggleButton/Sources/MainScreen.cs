/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Physics;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common; 
#endregion

namespace Buttons
{
    public class MainScreen : Screen
    {
        private Button ball, secondball;

        public override void Initialize()
        {
            base.Initialize();

            CreatePhysicWorld();

            Button btn = new Button("Push me");
            btn.Pivot = Vector2.One / 2;
            btn.Pressed += new Component.ComponentEventHandler(btn_Pressed);
            AddComponent(btn, Preferences.ViewportManager.MiddleCenterAnchor, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
            
        }

        #region Events
        public void btn_Pressed(Component source)
        {
            if (ball == null)
            {
                ball = new Button(ResourceManager.CreateImage("ball"), ResourceManager.CreateImage("ballpressed"));
                ball.Pivot = Vector2.One / 2;
                AddComponent(ball, Preferences.ViewportManager.VirtualScreenWidth / 2, Preferences.ViewportManager.VirtualScreenHeight / 5, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
                ball.Draggable = true;
                ball.Released += new Component.ComponentEventHandler(ball_Released);
            }
        }

        public void ball_Released(Component source)
        {
            if (secondball == null)
            {
                secondball = new Button(ResourceManager.CreateImage("ball"), ResourceManager.CreateImage("ballpressed"));
                secondball.Pivot = Vector2.One / 2;
                AddComponent(secondball, Preferences.ViewportManager.VirtualScreenWidth / 2, 4 * Preferences.ViewportManager.VirtualScreenHeight / 5, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
                secondball.Draggable = true;
            }
        } 
        #endregion

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
