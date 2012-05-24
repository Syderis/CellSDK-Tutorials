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
using Syderis.CellSDK.IO.AccelerometerSystem;
using Syderis.CellSDK.Common; 
#endregion

namespace Accelerometer
{
    class MainScreen : Screen
    {
        int accelfactor = 10;
        List<Sprite> sprites = new List<Sprite>();
        float maxX;
        float maxY;
        Vector2 centerposition;

        public override void Initialize()
        {
            base.Initialize();

            SetBackground(ResourceManager.CreateImage("bg_mobile"), Adjustment.CENTER);

            AccelerometerSensor.Instance.Start();

            sprites.Add(new Sprite("cell1", ResourceManager.CreateImage("cell1")));
            sprites.Add(new Sprite("cell2", ResourceManager.CreateImage("cell2")));
            sprites.Add(new Sprite("cell3", ResourceManager.CreateImage("cell3")));
            sprites.Add(new Sprite("cell4", ResourceManager.CreateImage("cell4")));

            maxX = Preferences.ViewportManager.VirtualScreenWidth - sprites[0].Size.X;
            maxY = Preferences.ViewportManager.VirtualScreenHeight - sprites[0].Size.Y;

            AddComponent(sprites[0], 10, 10);
            AddComponent(sprites[1], 250, 10);
            AddComponent(sprites[2], 10, 600);
            AddComponent(sprites[3], 250, 600);

            foreach (Sprite lbl in sprites)
            {
                lbl.Draggable = true;
            }



        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (Sprite lbl in sprites)
            {
                if (lbl.Position.X >= 0 && lbl.Position.X <= maxX && lbl.Position.Y >= 0 && lbl.Position.Y <= maxY)
                {
                    Vector2 actualPosition = new Vector2(lbl.Position.X, lbl.Position.Y);
                    actualPosition.X += AccelerometerSensor.Instance.Data2.X * (accelfactor);
                    actualPosition.Y -= AccelerometerSensor.Instance.Data2.Y * (accelfactor);

                    lbl.Position = actualPosition;
                }
                else
                {
                    lbl.Position = centerposition;
                }
            }
        }

        public override void BackButtonPressed()
        {
            AccelerometerSensor.Instance.Stop();
            base.BackButtonPressed();
        }
    }
}
