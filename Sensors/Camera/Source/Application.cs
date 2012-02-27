using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;

using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Layouts;
using Syderis.CellSDK.Core.Graphics;

namespace Camera
{
    class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
           
            base.Initialize();

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            StaticContent.ScreenManager.GoToScreen(new CameraScreen());
        }
    }
}