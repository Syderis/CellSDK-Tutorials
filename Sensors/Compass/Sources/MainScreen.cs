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
using Syderis.CellSDK.Common;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.IO.LocationSystem; 
#endregion

namespace Compass
{
    class MainScreen : Screen
    {
        //private Label lblMagneticNorth, lblRealNorth;
        private Label lblCover, lblCompass;
        private TimeSpan timer;
        private Vector2 offset;
        private bool isConnected = false;

        public override void Initialize()
        {
            base.Initialize(); offset = Vector2.Zero;
#if IOS
			offset= Vector2.One*80;
#endif
            // TODO: Replace these comments with your own poetry, and enjoy!                        
            SetBackground(ResourceManager.CreateImage("Background"), Adjustment.CENTER);
            
            lblCover = new Label(ResourceManager.CreateImage("compass_cover"));
            lblCompass = new Label(ResourceManager.CreateImage("compass"));

            lblCompass.Pivot = Vector2.One / 2;

            AddComponent(lblCompass, Preferences.Width / 2, Preferences.Height / 2);
            AddComponent(lblCover, 48 + offset.X, 183 + offset.Y);
            
            isConnected =  LocationSensor.Instance.IsConnected(LocationSensors.COMPASS);
            if (isConnected)
            {
                LocationSensor.Instance.Start(LocationSensors.COMPASS);
                lblCompass.Rotation = -(float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading;
            }
            else
            {
                Preferences.App.Alert("Compass sensor is not available on this device", "Warning!");
            }
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            if (!isConnected)
                return;

            timer += gameTime.ElapsedGameTime;
            if (timer > TimeSpan.FromMilliseconds(100))
            {
                lblCompass.Rotation = -lblCompass.Rotation - (float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading;
                timer = TimeSpan.Zero;
            }
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            if (isConnected)
                LocationSensor.Instance.Stop(LocationSensors.COMPASS);
        }
    }
}
