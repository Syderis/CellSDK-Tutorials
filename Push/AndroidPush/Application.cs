using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Common;

namespace MyPush
{
    class Application : MobileApplication
    {
        /// <summary>
        /// Loads the main screen
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            //Setup Viewport Manager
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
