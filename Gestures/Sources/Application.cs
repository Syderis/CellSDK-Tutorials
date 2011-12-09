using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Recognizers.Gestures;
using System.IO;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace Gestures
{
    public class Application : MobileApplication
    {
        GestureRecognition recognizer;
        Label lblText;
        Image idroids, iRethink, iwato;
       
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            
            idroids = Image.CreateImage("Droids");
            iRethink = Image.CreateImage("Rethink");
            iwato = Image.CreateImage("Wato");
            
            // TODO: Replace these comments with your own poetry, and enjoy!
            lblText = new Label("Please try a gesture");
            AddComponent(lblText, 20, Preferences.Height / 8);

            recognizer = new GestureRecognition();
            recognizer.LoadGestureSet(Path.Combine(StaticContent.Content.RootDirectory, "Gestures.gs"));
            recognizer.GestureRecognizerEvent += new GestureRecognition.GestureHandler(recognizer_GestureRecognizerEvent);
        }

        void recognizer_GestureRecognizerEvent(string gestureName, float score, Microsoft.Xna.Framework.Vector2 centroid)
        {           
            if (score>0.8f)
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

            recognizer.Process(Blobs);
        }
        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();

            Program.Instance.Exit();
        }
    }
}
