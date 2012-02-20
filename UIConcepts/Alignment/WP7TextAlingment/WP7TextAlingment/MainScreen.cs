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
using Syderis.CellSDK.Core.Graphics; 
#endregion

namespace TextAlignment
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();
            
            Image img = ResourceManager.CreateImage("posit");
            Label lbl = new Label(img);
            lbl.FitToText = false;
            lbl.Text = "My note";
            lbl.Align = Label.AlignType.MIDDLECENTER;

            lbl.Draggable = true;
            AddComponent(lbl, 0, 0);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
