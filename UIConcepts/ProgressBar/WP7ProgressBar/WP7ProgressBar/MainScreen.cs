/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework; 
#endregion

namespace ProgressBarSample
{
    public class MainScreen : Screen
    {
        private ProgressBar charger;
        private bool charged;

        public override void Initialize()
        {
            base.Initialize();

            Label message = new Label("Charging...");
            AddComponent(message, 0, 100);

            Button shot = new Button("Shot!");
            shot.Pressed += delegate
            {
                if (charged)
                {
                    charger.Value = 0;
                    charged = false;
                    message.Text = "Charging...";
                }
            };
            AddComponent(shot, 150, 100);

            charger = new ProgressBar();
            charger.Value = 0;
            charger.EndEvent += delegate
            {
                charged = true;
                message.Text = "Charged!";
            };
            AddComponent(charger, 0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!charged)
                charger.Value++;

        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
