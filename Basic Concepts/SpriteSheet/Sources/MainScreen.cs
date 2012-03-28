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
#endregion

namespace SpriteSheet
{
    class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.Gray);
            //Loads the sprite sheet
            Syderis.CellSDK.Core.Graphics.SpriteSheet spritesheet= ResourceManager.CreateSpriteSheet("Resources");

            Label lblJmlao = new Label(spritesheet["Stuff1"]);
            lblJmlao.Draggable = true;
            AddComponent(lblJmlao, 0, 0);

            Label lblMarcos = new Label(spritesheet["Stuff2"]);
            lblMarcos.Draggable = true;
            AddComponent(lblMarcos, 0, 337);

            Label lblMoi = new Label(spritesheet["Stuff3"]);
            lblMoi.Draggable = true;
            AddComponent(lblMoi, 183, 100);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
