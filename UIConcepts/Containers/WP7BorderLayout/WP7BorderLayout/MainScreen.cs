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
using Syderis.CellSDK.Common; 
#endregion

namespace BorderLayoutSample
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            Label lblCenter;
            Label lblEast;
            Label lblNorth;
            Label lblSouth;
            Label lblWest;

            lblCenter = new Label("Center");
            lblEast = new Label("East");
            lblNorth = new Label("North");
            lblSouth = new Label("South");
            lblWest = new Label("West");

            lblCenter.Align = Label.AlignType.MIDDLECENTER;
            lblEast.Align = Label.AlignType.MIDDLECENTER;
            lblNorth.Align = Label.AlignType.MIDDLECENTER;
            lblSouth.Align = Label.AlignType.MIDDLECENTER;
            lblWest.Align = Label.AlignType.MIDDLECENTER;

            Container<BorderLayout> borderContainer = new Container<BorderLayout>(new BorderLayout());
            borderContainer.BackgroundColor = Color.Transparent;
            borderContainer.Layout.AddComponent(BorderLayout.Organization.CENTER, lblCenter);
            borderContainer.Layout.AddComponent(BorderLayout.Organization.EAST, lblEast);
            borderContainer.Layout.AddComponent(BorderLayout.Organization.NORTH, 25, lblNorth);
            borderContainer.Layout.AddComponent(BorderLayout.Organization.SOUTH, 25, lblSouth);
            borderContainer.Layout.AddComponent(BorderLayout.Organization.WEST, lblWest);

            AddComponent(borderContainer, 0, 0);
            borderContainer.Size = new Vector2(Preferences.Width, Preferences.Height / 2);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }

    }
}
