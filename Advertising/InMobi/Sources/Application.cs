using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Advertising;
using Microsoft.Xna.Framework;

namespace Inmobi
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

            IAdvertising ads = AdvertisingFactory.CreateAds(AdvertisingType.INMOBI, "push your code");
            
            ads.Test = true;

            Banner bannerInmobi = new Banner(ads, 300, 50);

            AddComponent(bannerInmobi,
                Width / 2 - bannerInmobi.Width / 2, 
                Height/2-bannerInmobi.Height/2);
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
