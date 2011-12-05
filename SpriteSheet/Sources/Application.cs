/*
 * Copyright 2010 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;


namespace SpriteSheet
{
    class Application : MobileApplication
    {
       
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.Gray);

            //Loads the sprite sheet
            Image spritesheet = Image.CreateImage("Stuff");
            
            Label lblJmlao = new Label(spritesheet.SubImage(158, 0, 183, 337));
            lblJmlao.Draggable=true;
            AddComponent(lblJmlao, 0, 0);

            Label lblMarcos = new Label(spritesheet.SubImage(0, 0, 144, 299));
            lblMarcos.Draggable = true;
            AddComponent(lblMarcos, 0, 337);

            Label lblMoi = new Label(spritesheet.SubImage(361, 0, 143, 327));
            lblMoi.Draggable = true;
            AddComponent(lblMoi, 183,100 );

        }

        

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
