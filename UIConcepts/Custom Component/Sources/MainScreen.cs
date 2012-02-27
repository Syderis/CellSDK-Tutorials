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
#endregion

namespace ComboBox
{
    public class MainScreen : Screen
    {
        ComboBox combo;

        public override void Initialize()
        {
            base.Initialize();

            combo = new ComboBox();

            combo.AddItem("Fruit");
            combo.AddItem("Milk");
            combo.AddItem("Wine");
            combo.AddItem("Ice");
            combo.AddItem("Ice cream");
            combo.AddItem("Carrots");
            combo.AddItem("Potatoes");
            combo.AddItem("Ketchup");
            combo.AddItem("Tomatoes");

            AddComponent(combo, 10, 100);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
