using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Graphics;

namespace Buttons
{
    class Application : MultitouchApplication
    {
        private Button ball,secondball;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);
            //Add your code here

            CreatePhysicWorld();
            Button btn = new Button("Push me");
            AddComponent(btn, Width / 2, Height / 2);
            btn.Pivot = Vector2.One / 2;
            btn.Pressed += new Component.ComponentEventHandler(btn_Pressed);

        }

        void btn_Pressed(Component source)
        {
            if (ball == null)
            {
                ball = new Button(Image.CreateImage("ball"), Image.CreateImage("ballpressed"));
                AddComponent(ball, 50, 50);
                ball.Draggable = true;
                ball.Released += new Component.ComponentEventHandler(ball_Released);
            }

        }
        void ball_Released(Component source)
        {
            if (secondball == null)
            {
                secondball = new Button(Image.CreateImage("ball"), Image.CreateImage("ballpressed"));
                AddComponent(secondball, 10, 500);
                secondball.Draggable = true;
            }
        }


    }
}
