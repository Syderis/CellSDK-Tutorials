/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Common; 
#endregion

namespace TabPanelSample
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            TabPanel tab;
            tab = new TabPanel(Preferences.Width, Preferences.Height);
            tab.AddTab("mytab1", new Label(ResourceManager.CreateImage("cell_jekyll")));
            tab.AddTab("mytab2", new Label(ResourceManager.CreateImage("cell_hyde")));

            AddComponent(tab, 0, 0);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
