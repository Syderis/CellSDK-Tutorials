using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Microsoft.Xna.Framework;

namespace Orientation
{
    class MainScreen : Screen
    {
        Label label;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new L    abel("Hello, World!"), 0, 0);

            SetBackground(ResourceManager.CreateImage("Background"), Adjustment.STRETCH_VIEWPORT);

            label = new Label("Landscape orientation");
            AddComponent(label, 100, 100);
        }

        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }

        public override void OnChangeOrientation(Microsoft.Xna.Framework.DisplayOrientation orientation)
        {
            base.OnChangeOrientation(orientation);
            label.Text = orientation.ToString();
        }
    }
}
