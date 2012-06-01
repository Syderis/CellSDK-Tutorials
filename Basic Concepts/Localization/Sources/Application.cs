/*
 * Copyright 2011 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Common;
#endregion

namespace LocalizedStrings
{
    public class Application : MobileApplication
    {

        #region Variables
        #endregion

        #region Properties
        #endregion

        #region Public methods
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

        #endregion

        #region Private methods
        #endregion
    }
}
