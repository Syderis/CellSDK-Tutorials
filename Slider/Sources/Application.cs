using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework;

namespace Slider_Sample
{
    class Application : MultitouchApplication
    {
        private Slider slider;

        private Label value;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
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
            Program.Instance.Exit();
        }
    }
}
