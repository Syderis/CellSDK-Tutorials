using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;

namespace Camera
{
    class MainScreen : Screen
    {
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.White);
            Sprite sprite = new Sprite("farSprite", ResourceManager.CreateImage("sprite"));
            sprite.Pivot = Vector2.One / 2f;
            this.AddComponent(sprite, -400, -200);

            this.Camera.Target = new Vector2(-400, -200);
            this.Camera.Center = new Vector2(240, 400);

            Button zoomButton = new Button("Zoom");
            zoomButton.BlobPressed += OnZoomButtonPressed;
            zoomButton.CameraFixed = true;
            zoomButton.Pivot = new Vector2(0, 1);
            this.AddComponent(zoomButton, Preferences.ViewportManager.BottomLeftAnchor);

            Button resetButton = new Button("Reset");
            resetButton.BlobPressed += OnResetButtonPressed;
            resetButton.CameraFixed = true;
            resetButton.Pivot = new Vector2(0.5f, 1);
            this.AddComponent(resetButton, Preferences.ViewportManager.BottomCenterAnchor);

            Button rotateButton = new Button("Rotate");
            rotateButton.BlobPressed += OnRotateButtonPressed;
            rotateButton.CameraFixed = true;
            rotateButton.Pivot = Vector2.One;
            this.AddComponent(rotateButton, Preferences.ViewportManager.BottomRightAnchor);
        }

        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }

        private void OnZoomButtonPressed(Component component, IBlob blob)
        {
            Camera.Zoom += 0.1f;
        }

        private void OnResetButtonPressed(Component component, IBlob blob)
        {   
            Camera.Zoom = 1;
            Camera.Rotation = 0;
        }

        private void OnRotateButtonPressed (Component component, IBlob blob)
        {
            Camera.Rotation += 0.1f;
        }
    }
}
