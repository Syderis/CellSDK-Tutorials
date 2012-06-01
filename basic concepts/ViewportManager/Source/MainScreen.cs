using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;

namespace ViewportManager
{
    class MainScreen : Screen
    {
        Label trLabel, blLabel; 
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);

            // Blue color background with an image stretched to the viewport.
            SetBackground(Color.Blue);
            SetBackground(ResourceManager.CreateImage("Background"), Adjustment.CENTER);

            //Label placed on the top left corner of the viewport.
            Label viewportCornerTL = new Label("Viewport TL");
            viewportCornerTL.Pivot = Vector2.Zero;
            AddComponent(viewportCornerTL, 0, 0);

            //Label placed on the bottom right corner of the viewport.
            Label viewportCornerBR = new Label("Viewport BR");
            viewportCornerBR.Pivot = Vector2.One;
            AddComponent(viewportCornerBR, 300, 400);

            Button switchButton = new Button("Switch adjustment");
            switchButton.Pivot = Vector2.One / 2f;
            switchButton.Pressed += new Component.ComponentEventHandler(btn_Pressed);
            this.AddComponent(switchButton, 150, 200);

            trLabel = new Label("TR");
            trLabel.Pivot = new Vector2(1, 0);
            this.AddComponent(trLabel, Preferences.ViewportManager.TopRightAnchor);

            blLabel = new Label("BL");
            blLabel.Pivot = new Vector2(0, 1);
            this.AddComponent(blLabel, Preferences.ViewportManager.BottomLeftAnchor);
        }

        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }

        int count = 0;

        void btn_Pressed(Component source)
        {
            switch (count++ % 4)
            {   
                case 0:
                    Preferences.ViewportManager.Adjustment = ViewportAdjustment.FILL;
                    break;
                case 1:
                    Preferences.ViewportManager.Adjustment = ViewportAdjustment.STRETCH;
                    break;
                case 2:
                    Preferences.ViewportManager.Adjustment = ViewportAdjustment.NONE;
                    break;
                case 3:
                    Preferences.ViewportManager.Adjustment = ViewportAdjustment.FIT;
                    break;
            }

            trLabel.Position = Preferences.ViewportManager.TopRightAnchor;
            blLabel.Position = Preferences.ViewportManager.BottomLeftAnchor;
        }
    }
}
