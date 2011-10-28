using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;

namespace TabPanelSample
{
    class MyApplication : MultitouchApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            TabPanel tab;
            tab = new TabPanel(MultitouchStaticContent.Width, MultitouchStaticContent.Height);


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
