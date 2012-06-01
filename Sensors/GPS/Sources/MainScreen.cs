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
using Syderis.CellSDK.IO.LocationSystem; 
#endregion

namespace GPS
{
    class MainScreen : Screen
    {
        private Label lblLatitude, lblLongitude;
        private TimeSpan timer;
        private bool isConnected;

        public override void Initialize()
        {
            base.Initialize();

            SetBackground(ResourceManager.CreateImage("background"), Adjustment.CENTER);

            lblLatitude = new Label("Latitude: 37,427");
            lblLongitude = new Label("Longitude: -5,972");

            AddComponent(lblLatitude, Preferences.ViewportManager.VirtualScreenWidth / 4, Preferences.ViewportManager.VirtualScreenHeight / 8);
            AddComponent(lblLongitude, Preferences.ViewportManager.VirtualScreenWidth / 4, Preferences.ViewportManager.VirtualScreenHeight / 4);

            isConnected = LocationSensor.Instance.IsConnected(LocationSensors.GPS);
            if (isConnected)
                LocationSensor.Instance.Start(LocationSensors.GPS);
            else
                Preferences.App.Alert("GPS sensor is not available on this device", "Warning!");
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
            
            if (!isConnected)
                return;

            timer += gameTime.ElapsedGameTime;
            if (timer > TimeSpan.FromSeconds(1))
            {
                lblLatitude.Text = string.Format("Latitude: {0}", Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.GeoLocation.latitude);
                lblLongitude.Text = string.Format("Longitude: {0}", Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.GeoLocation.longitude);
                timer = TimeSpan.Zero;
            }
        }


        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            
            if(isConnected)
                LocationSensor.Instance.Stop(LocationSensors.GPS);
        }
    }
}
