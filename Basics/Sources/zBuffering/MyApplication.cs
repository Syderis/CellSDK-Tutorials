using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace zBuffering
{
    class MyApplication : MultitouchApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            Label green = new Label(Image.CreateImage("cell1"));
            Label red = new Label(Image.CreateImage("cell2"));
            Label yellow = new Label(Image.CreateImage("cell3"));
            green.Draggable = true;
            red.Draggable = true;
            yellow.Draggable = true;
            yellow.BringToFront = false;
            green.BringToFront = false;

            green.Alpha = red.Alpha = yellow.Alpha = 0.8f;
            AddComponent(green, 100, 100);
            AddComponent(red, 100, 100);
            AddComponent(yellow, 100, 100);


        }
    }
}

