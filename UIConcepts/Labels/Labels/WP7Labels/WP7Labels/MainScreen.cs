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
#endregion

namespace Labels
{
    public class MainScreen : Screen
    {

        public override void Initialize()
        {
            base.Initialize();

            AddComponent(new Label("Text . . ."), 0, 0);            
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
