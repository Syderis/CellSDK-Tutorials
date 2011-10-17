using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Sounds;

namespace Sounds
{
    class Application : MultitouchApplication
    {

        private Sound lovelySound;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);
            lovelySound = Sound.CreateSound("lovelySound");
            Button btn = new Button("Pretty button. Touch me to play!");
            btn.Released += new Component.ComponentEventHandler(btn_Released);
            AddComponent(btn, 10, 300);

        }

        void btn_Released(Component source)
        {
            lovelySound.Play();
        }

    }
}
