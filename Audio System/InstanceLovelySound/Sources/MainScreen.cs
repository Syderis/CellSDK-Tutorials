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
#endregion

namespace InstanceLovelySound
{
    class MainScreen : Screen
    {
        private SoundInstance lovelyInstance;
        private Button playStop;
        private Button balanceLeft;
        private Button balanceNormal;
        private Button balanceRight;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            lovelyInstance = ResourceManager.CreateSound("lovelySound").CreateInstance();

            playStop = new Button(ResourceManager.CreateImage("play"), ResourceManager.CreateImage("play_pressed"));
            balanceLeft = new Button(ResourceManager.CreateImage("balance_left"), ResourceManager.CreateImage("balance_left_pressed"));
            balanceNormal = new Button(ResourceManager.CreateImage("balance_normal"), ResourceManager.CreateImage("balance_normal_pressed"));
            balanceRight = new Button(ResourceManager.CreateImage("balance_right"), ResourceManager.CreateImage("balance_right_pressed"));

            AddComponent(playStop, 230, 325);
            AddComponent(balanceLeft, 18, 325);
            AddComponent(balanceNormal, 111, 325);
            AddComponent(balanceRight, 354, 325);

            playStop.Released += new Component.ComponentEventHandler(playStop_Released);
            balanceLeft.Released += new Component.ComponentEventHandler(balanceLeft_Released);
            balanceNormal.Released += new Component.ComponentEventHandler(balanceNormal_Released);
            balanceRight.Released += new Component.ComponentEventHandler(balanceRight_Released);
        }

        #region Events
        void playStop_Released(Component source)
        {
            switch (lovelyInstance.State)
            {
                case SoundState.Playing:
                    lovelyInstance.Stop();
                    break;
                case SoundState.Stopped:
                    lovelyInstance.Play();
                    break;
                default:
                    break;
            }
        }

        void balanceLeft_Released(Component source)
        {
            lovelyInstance.Balance = -1f;
        }

        void balanceNormal_Released(Component source)
        {
            lovelyInstance.Balance = 0f;
        }

        void balanceRight_Released(Component source)
        {
            lovelyInstance.Balance = 1f;
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
