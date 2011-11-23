using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Layouts;

namespace BorderLayoutSample
{
    class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
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

            AddComponent(borderContainer, 10, 10);
            borderContainer.Size = new Vector2(400, 200);

        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
