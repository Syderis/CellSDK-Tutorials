using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Graphics;

namespace CellResources
{
    class MainScreen : Screen
    {
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);
           

            Image staticImage= StaticContent.Resources.CreateImage("cell1");
            Image localImage1 = ResourceManager.CreateImage("cell2");
            Image localImage2 = ResourceManager.CreateImage("cell3");

            Sprite sp1 = new Sprite("static",staticImage);
            Sprite sp2 = new Sprite("local1",localImage1);
            Sprite sp3 = new Sprite("local2", localImage2);
            AddComponent(sp1, 10, 10);
            AddComponent(sp2, 10, 100);
            AddComponent(sp3, 10, 200);
            sp1.Draggable = sp2.Draggable = sp3.Draggable = true;
        }

        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
