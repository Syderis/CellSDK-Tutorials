using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace ParticlesSample
{
    class Application : MultitouchApplication
    {
        private ParticleSystem particle1, particle2;
        private Button btnPush;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            Image star1 = Image.CreateImage("star");
            Image star2 = star1.SubImage(0, 0, star1.Width, star1.Height);
            star1.Color = Color.Pink;

            star2.Color = Color.CadetBlue;
            particle1 = new ParticleSystem(star1);

            particle2 = new ParticleSystem(star2);

            AddComponent(particle1, 100f, 200f);

            AddComponent(particle2, 300f, 200f);

            btnPush = new Button("Push me!");

            btnPush.Released += new Component.ComponentEventHandler(btnPush_Released);

            AddComponent(btnPush, 100f, 700f);
        }

        void btnPush_Released(Component source)
        {

            particle1.Play();

            particle2.Play();

        }
    }
}
