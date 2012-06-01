/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Common; 
#endregion

namespace CanvasSample
{
    class Application : MobileApplication
    {    
        public override void Initialize()
        {

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            //Setup Viewport Manager
            Preferences.ViewportManager.Adjustment = ViewportAdjustment.FIT;
            Preferences.ViewportManager.AlignType = ViewportAlignType.TOPCENTER;
            Preferences.ViewportManager.VirtualWidth = 480;
            Preferences.ViewportManager.VirtualHeight = 800;

            StaticContent.ScreenManager.GoToScreen(new MainScreen());

        }       

        public override void Exit()
        {
            base.Exit();

            Program.Instance.Exit();
        }
    }
}
