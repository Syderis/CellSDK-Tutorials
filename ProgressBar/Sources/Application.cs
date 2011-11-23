using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework;

namespace ProgressBarSample
{
    class Application : MobileApplication
    {

        private ProgressBar pbCharger;

        private bool charged;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            pbCharger = new ProgressBar();

            AddComponent(pbCharger, 0, 0);

            pbCharger.Value = 0;
            pbCharger.EndEvent += delegate
            {

                charged = true;

            };
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);

            if (!charged)

                pbCharger.Value++;

        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
