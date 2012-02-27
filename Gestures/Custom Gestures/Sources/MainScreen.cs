/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core;

using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Animations;
using Syderis.CellSDK.Core.Sounds;
using Syderis.CellSDK.Recognizers.Gestures; 
#endregion

namespace Gestures
{
    class MainScreen : Screen
    {
        GestureRecognition recognizer;
        Label lblText;
        Image idroids, iRethink, iwato;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            idroids = ResourceManager.CreateImage("Droids");
            iRethink = ResourceManager.CreateImage("Rethink");
            iwato = ResourceManager.CreateImage("Wato");

            // TODO: Replace these comments with your own poetry, and enjoy!
            lblText = new Label("Please try a gesture");
            AddComponent(lblText, 20, Preferences.Height / 8);

            recognizer = new GestureRecognition();
            recognizer.LoadGestureSet("Gestures.gs");
            recognizer.GestureRecognizerEvent -= recognizer_GestureRecognizerEvent;
            recognizer.GestureRecognizerEvent += recognizer_GestureRecognizerEvent;
        }

        void recognizer_GestureRecognizerEvent(string gestureName, float score, Vector2 centroid)
        {
            if (score > 0.8f)
            {
                if (gestureName == "Gesture1")
                {
                    lblText.Text = "These aren't the droids you're \n looking for";
                    SetBackground(idroids, Adjustment.CENTER);
                }
                else if (gestureName == "Gesture2")
                {
                    lblText.Text = "You want to go home and \n rethink your life.";
                    SetBackground(iRethink, Adjustment.CENTER);
                }
            }
            else
            {
                lblText.Text = "Those Jedi tricks doesn't work with me";
                SetBackground(iwato, Adjustment.CENTER);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            recognizer.Process((Preferences.App as MobileApplication).Blobs);
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
