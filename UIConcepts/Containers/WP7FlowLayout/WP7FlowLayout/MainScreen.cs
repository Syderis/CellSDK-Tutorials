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

namespace FlowLayoutSample
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            Container<FlowLayout> flowContainer = new Container<FlowLayout>(new FlowLayout());
            flowContainer.BackgroundColor = Color.Transparent;
            flowContainer.Size = new Vector2(150, 10);
            flowContainer.Layout.AddComponent(new Label("One"));
            flowContainer.Layout.AddComponent(new Label("Two"));
            flowContainer.Layout.AddComponent(new Label("Three"));
            flowContainer.Layout.AddComponent(new Label("Four"));
            flowContainer.Layout.AddComponent(new Label("Five"));
            flowContainer.Layout.AddComponent(new Label("Six"));
            flowContainer.Layout.AddComponent(new Label("Seven"));

            AddComponent(flowContainer, 100, 400);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
