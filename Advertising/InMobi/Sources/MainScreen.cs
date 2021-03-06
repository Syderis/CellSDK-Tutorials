/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core;

using Microsoft.Xna.Framework;
using Syderis.CellSDK.Advertising;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Advertising.Beans; 
#endregion

namespace Inmobi
{
    class MainScreen : Screen
    {
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.Blue);
            AdsConfig cfg= new AdsConfig("push your code", 1);
            IAdvertising ads = AdvertisingFactory.CreateAds(AdvertisingType.INMOBI,cfg);

            ads.Test = true;

            Banner bannerInmobi = new Banner(ads, 300, 50,"127.0.0.1");
            bannerInmobi.DefaultImage = ResourceManager.CreateImage("banner_zombeee");
            bannerInmobi.EventClick += new Banner.DefaultClick(bannerInmobi_EventClick);

            AddComponent(bannerInmobi,
                Preferences.Width / 2 - bannerInmobi.Width / 2,
                Preferences.Height / 2 - bannerInmobi.Height / 2);
        }

        void bannerInmobi_EventClick(object sender)
        {
            Preferences.App.Alert("Click on default banner", "Custom action");
        }

        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
