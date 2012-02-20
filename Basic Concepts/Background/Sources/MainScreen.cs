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
#endregion

namespace Background
{
    class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            // Replace this comment with your own poetry, and enjoy!
            SetBackground(ResourceManager.CreateImage("cell1"), Adjustment.CENTER);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
