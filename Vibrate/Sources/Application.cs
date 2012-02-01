using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;

namespace Vibrate
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            // TODO: Replace these comments with your own poetry, and enjoy!
            Button vibrate = new Button(Image.CreateImage("Woody"));
            vibrate.Pressed += new Component.ComponentEventHandler(vibrate_Pressed);
            AddComponent(vibrate, Width / 2-vibrate.Size.X/2, Height / 2-vibrate.Size.Y/2);

        }

        void vibrate_Pressed(Component source)
        {
            Vibrate(500);            
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();

            Program.Instance.Exit();
        }
    }
}
