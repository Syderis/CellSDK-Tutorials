/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Storage;
using Syderis.CellSDK.Common;
#endregion

namespace StorageSample
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

            Preferences.ViewportManager.Adjustment = ViewportAdjustment.FIT;
            Preferences.ViewportManager.AlignType = ViewportAlignType.MIDDLECENTER;
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
