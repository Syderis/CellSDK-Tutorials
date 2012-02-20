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
using Syderis.CellSDK.Core.Layouts;
using Microsoft.Xna.Framework; 
#endregion

namespace GridLayoutSample
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            Container<GridLayout> gridContainer = new Container<GridLayout>(new GridLayout(6, 2, 10, 10));
            gridContainer.BackgroundColor = Color.Transparent;
            gridContainer.Layout.AddComponent(new Label("One"));
            gridContainer.Layout.AddComponent(new Label("Two"));
            gridContainer.Layout.AddComponent(new Label("Three"));
            gridContainer.Layout.AddComponent(new Label("Four"));
            gridContainer.Layout.AddComponent(new Label("Five"));
            gridContainer.Layout.AddComponent(new Label("Six"));
            gridContainer.Layout.AddComponent(new Label("Seven"));
            gridContainer.Layout.AddComponent(new Label("Eight"));
            gridContainer.Layout.AddComponent(new Label("Nine"));
            gridContainer.Layout.AddComponent(new Label("Ten"));
            gridContainer.Layout.AddComponent(new Label("Eleven"));
            gridContainer.Layout.AddComponent(new Label("Twelve"));
            gridContainer.Size = new Vector2(400, 400);

            AddComponent(gridContainer, 50, 50);

        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
