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

namespace Adfonic
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
            AdsConfig cfg = new AdsConfig("push your code", 1);
            IAdvertising ads = AdvertisingFactory.CreateAds(AdvertisingType.ADFONIC, cfg);

            ads.Test = true;

            Banner bannerAdfonnic = new Banner(ads, 300, 50,"127.0.0.1");
            bannerAdfonnic.DefaultImage = ResourceManager.CreateImage("banner_zombeee");
            bannerAdfonnic.EventClick += new Banner.DefaultClick(bannerAdfonnic_EventClick);

            AddComponent(bannerAdfonnic,
                Preferences.Width / 2 - bannerAdfonnic.Width / 2,
                Preferences.Height / 2 - bannerAdfonnic.Height / 2);
        }

        void bannerAdfonnic_EventClick(object sender)
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
