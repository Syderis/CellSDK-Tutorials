using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;

namespace Images
{
    class Application : MultitouchApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            CreatePhysicWorld();

            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);
            Image img = Image.CreateImage("Image");
            Image img2 = Image.CreateImage("MyDir/Image2");
            Label lbl = new Label(img);
            Label lbl2 = new Label(img2);
            lbl.Draggable = true;
            lbl2.Draggable = true;

            AddComponent(lbl, 10, 10);
            AddComponent(lbl2, 10, 400);

        }
    }
}
