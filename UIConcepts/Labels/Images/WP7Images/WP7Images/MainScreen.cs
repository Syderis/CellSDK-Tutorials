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
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Physics;
using Microsoft.Xna.Framework; 
#endregion

namespace Images
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatePhysicWorld(Vector2.Zero,true,true, new Vector2(20,20));

            base.Initialize();

            Image img = ResourceManager.CreateImage("Image");
            Image img2 = ResourceManager.CreateImage("MyDir/Image2");

            Label lbl = new Label(img);
            Label lbl2 = new Label(img2);
            lbl.Draggable = true;
            lbl2.Draggable = true;

            AddComponent(lbl, 10, 10,BodyShape.SQUARE,BodyType.DYNAMIC,Category.Cat1);
            AddComponent(lbl2, 10, 400, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);

            img.Effect = Image.EffectType.FLIP_HORIZONTAL_VERTICAL;
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
