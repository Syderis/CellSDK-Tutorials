using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Advertising;
using Microsoft.Xna.Framework;

namespace MSAdvertising
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            SetBackground(Color.Blue);

            IAdvertising ads = AdvertisingFactory.CreateAds(AdvertisingType.MICROSOFT_ADS, "8c89c892-2003-43fd-b7a1-db3d1ab6b56d/10030126");
            
            ads.Test = true;
            
            Banner bannerMsAdvertising = new Banner(ads, 300, 50);

            bannerMsAdvertising.AdsIntervalRequest = 10;

            AddComponent(bannerMsAdvertising,
                Width / 2 - bannerMsAdvertising.Width / 2, 
                Height/2-bannerMsAdvertising.Height/2);
        }
        
        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();

            Program.Instance.Exit();
        }
    }
}
