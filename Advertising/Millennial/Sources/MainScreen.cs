/*
 * Copyright 2011 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Advertising;
using Syderis.CellSDK.Common;
using Microsoft.Xna.Framework;

#endregion
namespace Millenial
{
    class MainScreen : Screen
    {

        #region Variables
        #endregion

        #region Properties
        #endregion

        #region Public methods
        public override void Initialize()
        {
            base.Initialize();
            SetBackground(Color.Blue);
            // TODO: Replace these comments with your own poetry, and enjoy!
            IAdvertising ads = AdvertisingFactory.CreateAds(AdvertisingType.MILLENIAL, "78802");
            ads.Test = true;
            Banner milleniall = new Banner(ads, 300, 100,"127.0.0.1");
            AddComponent(milleniall,
                Preferences.Width / 2 - milleniall.Width / 2,
                Preferences.Height / 2 - milleniall.Height / 2);

        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
        #endregion

        #region Private methods
        #endregion
    }
}
