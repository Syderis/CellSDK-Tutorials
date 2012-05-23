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

using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Animations; 
#endregion

namespace AnimatedImages
{
    class MainScreen : Screen
    {
        private AnimatedImage img;
        int numberPlayed;
        Label playNumbers;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(ResourceManager.CreateImage("bg_mobile"), Adjustment.CENTER);
            
            StripAnimation animation = new StripAnimation(1020, 868, 204, 217, 19);
            animation.FramesPerSecond = 40;
            img = ResourceManager.CreateAnimatedImage("ball");

            img.AddAnimation("bounce", animation);
            img.EndedCurrentStripAnimation += new EventHandler(img_EndedCurrentStripAnimation);
            numberPlayed = 0;
            AddComponent(new Label(img), 10, 100);
            Button play = new Button("Play");
            Button stop = new Button("Stop");
            Button pause = new Button("Pause");
            play.Released += new Component.ComponentEventHandler(play_Released);
            stop.Released += new Component.ComponentEventHandler(stop_Released);
            pause.Released += new Component.ComponentEventHandler(pause_Released);

            playNumbers = new Label("0");

            AddComponent(play, 150, 100);
            AddComponent(stop, 150, 150);
            AddComponent(pause, 150, 200);
            AddComponent(playNumbers, 10, 50);

        }

        #region Events
        void img_EndedCurrentStripAnimation(object sender, EventArgs e)
        {
            numberPlayed++;
            playNumbers.Text = numberPlayed.ToString();
        }

        void play_Released(Component source)
        {
            img.Play(true);
        }

        void stop_Released(Component source)
        {
            img.Stop();
        }

        void pause_Released(Component source)
        {
            img.Pause();
        } 
        #endregion

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
