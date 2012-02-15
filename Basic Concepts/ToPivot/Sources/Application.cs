using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace ToPivot
{
    class Application : MobileApplication
    {
        private Label lbl1, lbl2, lbl3;
        private float angle = MathHelper.ToRadians(9); // nine degrees

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            //Add your code here
           
            lbl1 = new Label(Image.CreateImage("cell1"));
            lbl2 = new Label(Image.CreateImage("cell2"));
            lbl3 = new Label(Image.CreateImage("cell3"));


            lbl1.Draggable = lbl2.Draggable = lbl3.Draggable = true;
            Button rotate = new Button("Rotate");
            rotate.Pivot = Vector2.One / 2;
            rotate.Released += new Component.ComponentEventHandler(rotate_Released);

            lbl2.Pivot = Vector2.One / 2;
            lbl3.Pivot = new Vector2(1, 1);


            AddComponent(lbl1, Width/2, Height/6);
            AddComponent(lbl2, Width/2, 2*Height/6);
            AddComponent(lbl3, Width/2, 3*Height/6);
            AddComponent(rotate, Width/2, Height - 2*rotate.Size.Y);

        }

        void rotate_Released(Component source)
        {
            lbl1.Rotation = lbl2.Rotation = lbl3.Rotation = angle;
        }


         public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
