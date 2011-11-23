using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Common;

namespace TabPanelSample
{
    class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            TabPanel tab;
            tab = new TabPanel(Preferences.Width, Preferences.Height);


            tab.AddTab("mytab1", new Label(Image.CreateImage("cell_jekyll")));
            tab.AddTab("mytab2", new Label(Image.CreateImage("cell_hyde")));

            AddComponent(tab, 0, 0);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
