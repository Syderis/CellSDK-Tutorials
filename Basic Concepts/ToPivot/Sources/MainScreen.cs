/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common; 
#endregion

namespace ToPivot
{
    class MainScreen : Screen
    {
        private Label lbl1, lbl2, lbl3;
        private float angle = MathHelper.ToRadians(9); // nine degrees

        public override void Initialize()
        {
            base.Initialize();

            // Replace this comment with your own poetry, and enjoy!
            lbl1 = new Label(ResourceManager.CreateImage("cell1"));
            lbl2 = new Label(ResourceManager.CreateImage("cell2"));
            lbl3 = new Label(ResourceManager.CreateImage("cell3"));


            lbl1.Draggable = lbl2.Draggable = lbl3.Draggable = true;
            Button rotate = new Button("Rotate");
            rotate.Pivot = Vector2.One / 2;
            rotate.Released += new Component.ComponentEventHandler(rotate_Released);

            lbl2.Pivot = Vector2.One / 2;
            lbl3.Pivot = new Vector2(1, 1);


            AddComponent(lbl1, Preferences.Width / 2, Preferences.Height / 6);
            AddComponent(lbl2, Preferences.Width / 2, 2 * Preferences.Height / 6);
            AddComponent(lbl3, Preferences.Width / 2, 3 * Preferences.Height / 6);
            AddComponent(rotate, Preferences.Width / 2, Preferences.Height - 2 * rotate.Size.Y);

        }

        void rotate_Released(Component source)
        {
            lbl1.Rotation = lbl2.Rotation = lbl3.Rotation = angle;
        }



        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
