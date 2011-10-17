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
    class Application : MultitouchApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Container<BorderLayout> borderContainer = new Container<BorderLayout>(new BorderLayout());
            borderContainer.BackgroundColor = Color.Transparent;
            borderContainer.Layout.AddComponent(BorderLayout.Organization.CENTER, new Label("Center"));
            borderContainer.Layout.AddComponent(BorderLayout.Organization.EAST, new Label("East"));
            borderContainer.Layout.AddComponent(BorderLayout.Organization.NORTH, new Label("North"));
            borderContainer.Layout.AddComponent(BorderLayout.Organization.SOUTH, new Label("South"));
            borderContainer.Layout.AddComponent(BorderLayout.Organization.WEST, new Label("West"));

            AddComponent(borderContainer, 10, 10);

        }
    }
}
