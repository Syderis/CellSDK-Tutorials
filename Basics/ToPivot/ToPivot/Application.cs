using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace ToPivot
{
    class Application : MultitouchApplication
    {
        private Label lbl1, lbl2, lbl3;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            //Add your code here   
            SetBackground(Color.White);

            lbl1 = new Label(Image.CreateImage("cell1"));
            lbl2 = new Label(Image.CreateImage("cell2"));
            lbl3 = new Label(Image.CreateImage("cell3"));


            lbl1.Draggable = lbl2.Draggable = lbl3.Draggable = true;
            Button rotate = new Button("Rotate");
            rotate.Released += new Component.ComponentEventHandler(rotate_Released);

            lbl2.Pivot = Vector2.One / 2;
            lbl3.Pivot = new Vector2(1, 1);


            AddComponent(lbl1, 10, 10);
            AddComponent(lbl2, 10, 150);
            AddComponent(lbl3, 200, 150);
            AddComponent(rotate, 10, 700);

        }

        void rotate_Released(Component source)
        {
            lbl1.Rotation = lbl2.Rotation = lbl3.Rotation = 0.2f;
        }


        
    }
}
