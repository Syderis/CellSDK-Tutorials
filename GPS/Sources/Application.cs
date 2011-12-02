using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.IO.LocationSystem;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Graphics;

namespace WP7GPS
{
    public class Application : MobileApplication
    {
        private Label lblLatitude, lblLongitude;
        private TimeSpan timer;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!            
            SetBackground(Image.CreateImage("background"), Adjustment.CENTER);
            
            lblLatitude = new Label("Latitude: 37,427");
            lblLongitude = new Label("Longitude: -5,972");

            AddComponent(lblLatitude, Preferences.Width / 4, Preferences.Height / 8);
            AddComponent(lblLongitude, Preferences.Width / 4, Preferences.Height / 4);

            LocationSensor.Instance.Start(LocationSensors.GPS);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            timer += gameTime.ElapsedGameTime;
            if (timer > TimeSpan.FromSeconds(1))
            {
                lblLatitude.Text = string.Format("Latitude: {0}", LocationSensor.Instance.GeoLocation.latitude);
                lblLongitude.Text = string.Format("Longitude: {0}", LocationSensor.Instance.GeoLocation.longitude);
                timer = TimeSpan.Zero;
            }

        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            LocationSensor.Instance.Stop(LocationSensors.GPS);
            Program.Instance.Exit();
        }
    }
}

