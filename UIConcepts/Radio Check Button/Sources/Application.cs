/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Common;
#endregion

namespace SelectOptions
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Preferences.ViewportManager.Adjustment = ViewportAdjustment.FIT;
            Preferences.ViewportManager.AlignType = ViewportAlignType.MIDDLECENTER;
            Preferences.ViewportManager.VirtualWidth = 480;
            Preferences.ViewportManager.VirtualHeight = 800;

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            StaticContent.ScreenManager.GoToScreen(new MainScreen());
        }

        public override void Exit()
        {
            base.Exit();

            Program.Instance.Exit();
        }
    }
}
