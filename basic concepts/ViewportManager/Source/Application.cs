using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Common;

namespace ViewportManager
{
    public class Application : MobileApplication
    {
        public override Microsoft.Xna.Framework.DisplayOrientation SupportedOrientation
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
            Preferences.ViewportManager.AlignType = ViewportAlignType.MIDDLECENTER;
            Preferences.ViewportManager.VirtualWidth = 300;
            Preferences.ViewportManager.VirtualHeight = 400;


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
