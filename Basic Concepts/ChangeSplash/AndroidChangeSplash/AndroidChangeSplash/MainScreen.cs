using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;

namespace AndroidChangeSplash
{
    class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
