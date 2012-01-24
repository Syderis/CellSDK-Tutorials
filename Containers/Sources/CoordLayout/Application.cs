using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Layouts;
using Microsoft.Xna.Framework;

namespace CoordLayoutSample
{
    class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Container<CoordLayout> coordContainer = new Container<CoordLayout>(new CoordLayout());
            coordContainer.BackgroundColor = Color.Transparent;
            coordContainer.Layout.AddComponent(new Label("One"), 0, 0);
            coordContainer.Layout.AddComponent(new Label("Two"), 200, 1);
            coordContainer.Layout.AddComponent(new Label("Three"), 20, 200);
            coordContainer.Layout.AddComponent(new Label("Four"), 100, 150);
            coordContainer.Layout.AddComponent(new Label("Five"), 200, 280);

            AddComponent(coordContainer, 10, 10);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
