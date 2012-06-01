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
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework; 
#endregion

namespace CanvasSample
{
    public class MainScreen : Screen
    {
        List<Label> colors;
        MyCanvas canv;

        public override void Initialize()
        {
            base.Initialize();

            SetBackground(ResourceManager.CreateImage("Background"), Adjustment.NONE);

            canv = new MyCanvas((int)Preferences.ViewportManager.VirtualScreenWidth, (int)Preferences.ViewportManager.VirtualScreenHeight);
            canv.BringToFront = false;
            AddComponent(canv, 0, 0);

            colors = new List<Label>();
            Image img = ResourceManager.CreateImage("color");
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
                AddComponent(colors[i], i * colors[i].Size.X, Preferences.ViewportManager.VirtualScreenHeight - colors[i].Size.Y);
                colors[i].Released -= Application_Released;
                colors[i].Released += new Component.ComponentEventHandler(Application_Released);

            }
        }

        #region Events
        public void Application_Released(Component source)
        {
            canv.PaintColor = ((Label)source).Image.Color;
        } 
        #endregion

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }

    }
}
