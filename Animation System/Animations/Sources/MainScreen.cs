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
#endregion

namespace Animations
{
    class MainScreen : Screen
    {
        private Label lbl;
        private Label keyEventLabel;
        private Animation anim;
        private Button playStop;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(ResourceManager.CreateImage("bg_mobile"), Adjustment.CENTER);
            
            lbl = new Label(ResourceManager.CreateImage("cell_car"));
            AddComponent(lbl, Preferences.Width / 2, Preferences.Height / 2);

            anim = Animation.CreateAnimation(20);

            anim.AnimationType = AnimationType.Relative;
            anim.AddKey(new KeyFrame(0, 0.1f));
            anim.AddKey(new KeyFrame(5, 0.5f));
            anim.AddKey(new KeyFrame(10, 0.9f));
            anim.AddKey(new KeyFrame(15, 0.5f));
            anim.AddKey(new KeyFrame(anim.NumFrames - 1, 0.1f));


            anim.IsLooped = true;

            AddAnimation(anim);
            //  anim.Play(lbl);

            anim.KeyEvent += new Animation.AnimationHandler(anim_KeyEvent);
            playStop = new Button("Play/Stop");
            AddComponent(playStop, 100, 200);
            playStop.Released += new Component.ComponentEventHandler(playStop_Released);

            keyEventLabel = new Label("Event Raised!!");
            AddComponent(keyEventLabel, Preferences.Width / 2, 620);
            keyEventLabel.Visible = false;



        }

        #region Events
        private void playStop_Released(Component source)
        {
            switch (anim.State)
            {
                case AnimationState.Paused:
                    anim.Resume();
                    break;
                case AnimationState.Playing:
                    anim.Pause();
                    break;
                case AnimationState.Stopped:
                    anim.Play(lbl);
                    break;
                default:
                    break;
            }
        }

        void anim_KeyEvent(Animation animation)
        {

            keyEventLabel.Visible = true;

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
