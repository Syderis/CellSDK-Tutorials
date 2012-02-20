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
using Syderis.CellSDK.Common; 
#endregion

namespace Vibrate
{
    class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            Button vibrate = new Button(ResourceManager.CreateImage("Woody"));
            vibrate.Pressed += new Component.ComponentEventHandler(vibrate_Pressed);
            AddComponent(vibrate, Preferences.Width / 2 - vibrate.Size.X / 2, Preferences.Height / 2 - vibrate.Size.Y / 2);

        }

        #region Events
        void vibrate_Pressed(Component source)
        {
            (Preferences.App as MobileApplication).Vibrate(500);
        } 
        #endregion

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
