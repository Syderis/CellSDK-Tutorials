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
using Syderis.CellSDK.Advertising.Beans;

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
            
            AdsConfig cfg= new AdsConfig("push your code",1);

            IAdvertising ads = AdvertisingFactory.CreateAds(AdvertisingType.MILLENNIAL,cfg);
            ads.Test = true;

            Banner millennial = new Banner(ads, 300, 50,"127.0.0.1");
            millennial.DefaultImage = ResourceManager.CreateImage("banner_zombeee");
            millennial.EventClick += new Banner.DefaultClick(millennial_EventClick);

            AddComponent(millennial,
                Preferences.Width / 2 - millennial.Width / 2,
                Preferences.Height / 2 - millennial.Height / 2);

        }

        void millennial_EventClick(object sender)
        {
            Preferences.App.Alert("Click on default banner", "Custom action");
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
