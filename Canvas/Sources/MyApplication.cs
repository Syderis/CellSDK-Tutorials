using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;

namespace CanvasSample
{
    class MyApplication : MultitouchApplication
    {
        List<Label> colors;
        MyCanvas canv;
        public override void Initialize()
        {

            SetBackground(Image.CreateImage("Background"), false);

            canv = new MyCanvas(MultitouchStaticContent.Width, MultitouchStaticContent.Height);
            canv.BringToFront = false;
            AddComponent(canv, 0, 0);

            colors = new List<Label>();
            Image img = Image.CreateImage("color");
            Image aux = img.SubImage(0, 0, img.Width, img.Height);
            aux.Color = Color.Red;
            colors.Add(new Label(aux));
            aux = img.SubImage(0, 0, img.Width, img.Height);
            aux.Color = Color.Gray;
            colors.Add(new Label(aux));
            aux = img.SubImage(0, 0, img.Width, img.Height);
            aux.Color = Color.Yellow;
            colors.Add(new Label(aux));
            aux = img.SubImage(0, 0, img.Width, img.Height);
            aux.Color = Color.Blue;
            colors.Add(new Label(aux));

            for (int i = 0; i < colors.Count; i++)
            {
                AddComponent(colors[i], i * colors[i].Size.X, MultitouchStaticContent.Height - colors[i].Size.Y);
                colors[i].Released -= Application_Released;
                colors[i].Released += new Component.ComponentEventHandler(Application_Released);

            }

        }

        void Application_Released(Component source)
        {
            canv.PaintColor = ((Label)source).Image.Color;
        }

   
    }
}