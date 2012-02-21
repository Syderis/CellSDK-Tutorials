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

namespace Sounds
{
    class MainScreen : Screen
    {
        private Sound lovelySound;

        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            lovelySound = ResourceManager.CreateSound("lovelySound");
            Button btn = new Button("Pretty button. Touch me to play!");
            btn.Released += btn_Released;
            AddComponent(btn, 10, 300);

        }

        #region Events
        void btn_Released(Component source)
        {
            lovelySound.Play();
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
