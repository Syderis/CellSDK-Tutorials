using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core;

namespace CellResources
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// Property that allows to change the orientation supported by the device.
        /// </summary>
        public override DisplayOrientation SupportedOrientation
        {
            get
            {
                return base.SupportedOrientation;
            }

            set
            {
                base.SupportedOrientation = value;
                Program.Instance.SupportedOrientation = value;
            }
        }

        /// <summary>
        /// Loads the main screen
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            Preferences.ViewportManager.Adjustment = ViewportAdjustment.FIT;
            Preferences.ViewportManager.AlignType = ViewportAlignType.TOPCENTER;
            Preferences.ViewportManager.VirtualWidth = 480;
            Preferences.ViewportManager.VirtualHeight = 800;

            // NOTE: Starting from Cell SDK 1.1 all the resources load within this method are done on a specific Screen object.
            // For instance, the Hello World Label is created on MainScreen
            StaticContent.ScreenManager.GoToScreen(new MainScreen());
        }

        /// <summary>
        /// Exits the app
        /// </summary>
        public override void Exit()
        {
            base.Exit();

            Program.Instance.Exit();
        }
    }
}
