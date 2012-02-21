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

namespace Slider_Sample
{
    public class MainScreen : Screen
    {
        private Slider slider;
        private Label value;

        public override void Initialize()
        {
            base.Initialize();

            slider = new Slider();
            value = new Label("");

            AddComponent(value, 75f, 400f);
            AddComponent(slider, 100f, 200f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            value.Text = slider.Value.ToString();
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
