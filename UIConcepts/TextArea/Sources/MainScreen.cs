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

namespace TextAreaSample
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            TextArea loveletter = new TextArea("Hello, World!", 1, 20);
            AddComponent(loveletter, 20, 200);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
