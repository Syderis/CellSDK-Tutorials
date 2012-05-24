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
        private Sprite sprCover, sprCompass;
        private TimeSpan timer;
        private bool isConnected = false;

        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!                        
            SetBackground(ResourceManager.CreateImage("Background"), Adjustment.CENTER);

            sprCover = new Sprite("compass_cover", ResourceManager.CreateImage("compass_cover"));
            sprCompass = new Sprite("compass", ResourceManager.CreateImage("compass"));

            sprCompass.Pivot = Vector2.One / 2;

            AddComponent(sprCompass, Preferences.Width / 2, Preferences.Height / 2);
            AddComponent(sprCover, 48, 183);
            
            isConnected =  LocationSensor.Instance.IsConnected(LocationSensors.COMPASS);
            if (isConnected)
            {
                LocationSensor.Instance.Start(LocationSensors.COMPASS);
                sprCompass.Rotation = -(float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading;
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
                sprCompass.Rotation = -(float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading;
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
