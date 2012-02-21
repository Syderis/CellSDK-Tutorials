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
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Common; 
#endregion

namespace CellSDKApp
{
    public class MainScreen: Screen
    {
        int count = 0;
        Label clickLabel;
        Button clickButton;

        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.Gray);

            clickLabel = new Label("Click Count");
            clickButton = new Button("Click me!!!");
            clickButton.Released += delegate { clickLabel.Text = string.Format("{0} Clicks!.", ++count); };

            clickLabel.Pivot = Vector2.One / 2;
            clickLabel.Align = Label.AlignType.MIDDLECENTER;
            clickButton.Pivot = Vector2.One / 2;
            clickButton.Align = Label.AlignType.MIDDLECENTER;

            AddComponent(clickLabel, Preferences.Width / 2, Preferences.Height / 2);
            AddComponent(clickButton, Preferences.Width / 2, Preferences.Height / 2 - 100);            
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
