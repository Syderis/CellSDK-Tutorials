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

namespace zBuffering
{
    class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            Label cell1 = new Label(ResourceManager.CreateImage("cell1"));
            Label cell2 = new Label(ResourceManager.CreateImage("cell2"));
            Label cell3 = new Label(ResourceManager.CreateImage("cell3"));

            cell1.Draggable = true;
            cell2.Draggable = true;
            cell3.Draggable = true;

            cell1.BringToFront = false;
            cell3.BringToFront = false;

            cell1.Alpha = cell2.Alpha = cell3.Alpha = 0.8f;



            AddComponent(cell1, Preferences.Width / 2 - cell1.Size.X / 2, Preferences.Height / 3);
            AddComponent(cell2, Preferences.Width / 2 - cell2.Size.X / 2, Preferences.Height / 3);
            AddComponent(cell3, Preferences.Width / 2 - cell3.Size.X / 2, Preferences.Height / 3);

            SendToFront(cell2);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
