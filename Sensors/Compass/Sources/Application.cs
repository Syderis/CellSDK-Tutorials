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
        //private Label lblMagneticNorth, lblRealNorth;
        private Label lblCover, lblCompass;
        private TimeSpan timer;
        private Vector2 offset;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
			offset= Vector2.Zero;
#if IOS
			offset= Vector2.One*80;;
#endif
           
            // TODO: Replace these comments with your own poetry, and enjoy!                        
            SetBackground(Image.CreateImage("Background"), Adjustment.CENTER);
            Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Start(LocationSensors.COMPASS);
   
            lblCover = new Label(Image.CreateImage("compass_cover"));
            lblCompass = new Label(Image.CreateImage("compass"));          
			
			lblCompass.Pivot = Vector2.One / 2;
   
            AddComponent(lblCompass, Preferences.Width/2, Preferences.Height/2);
            AddComponent(lblCover, 48 + offset.X, 183 + offset.Y);
   
            lblCompass.Rotation = -MathHelper.ToRadians((float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            timer += gameTime.ElapsedGameTime;
            if (timer > TimeSpan.FromMilliseconds(100))
            {
                lblCompass.Rotation = -lblCompass.Rotation - (float)Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Compass.magneticHeading;
                timer = TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            Syderis.CellSDK.IO.LocationSystem.LocationSensor.Instance.Stop(LocationSensors.COMPASS);
            Program.Instance.Exit();
        }
    }
}

