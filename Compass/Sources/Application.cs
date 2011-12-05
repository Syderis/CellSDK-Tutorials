using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.IO.LocationSystem;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace Compass
{
    public class Application : MobileApplication
    {
        private Label lblMagneticNorth, lblRealNorth;
        private TimeSpan timer;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!                        
            Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Start(Syderis.CellSDK.Common.LocationSensor.COMPASS);

            lblMagneticNorth = new Label("Magnetic Heading: ");
            lblRealNorth = new Label("True Heading: ");

            AddComponent(lblMagneticNorth, Preferences.Width / 2, Preferences.Height / 8);
            AddComponent(lblRealNorth, Preferences.Width / 2, 6*Preferences.Height / 8);
            
            lblRealNorth.Pivot = Vector2.One/2;
            lblMagneticNorth.Pivot = Vector2.One / 2;            

            lblRealNorth.Rotation = -MathHelper.ToRadians((float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.trueHeading);
            lblMagneticNorth.Rotation = -MathHelper.ToRadians((float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            timer += gameTime.ElapsedGameTime;
            if (timer > TimeSpan.FromMilliseconds(500))
            {
                lblMagneticNorth.Text = string.Format("Magnetic Heading: {0}", Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading);
                lblRealNorth.Text = string.Format("True Heading: {0}", Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.trueHeading);

                lblRealNorth.Rotation = -lblRealNorth.Rotation - MathHelper.ToRadians((float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.trueHeading);
                lblMagneticNorth.Rotation = -lblMagneticNorth.Rotation - MathHelper.ToRadians((float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading);
                timer = TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Stop(Syderis.CellSDK.Common.LocationSensor.COMPASS);
            Program.Instance.Exit();
        }
    }
}

