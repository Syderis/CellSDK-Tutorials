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
        List<Label> labels = new List<Label>();
        float maxX;
        float maxY;
        Vector2 centerposition;

        public override void Initialize()
        {
            base.Initialize();

            SetBackground(ResourceManager.CreateImage("bg_mobile"), Adjustment.CENTER);

            AccelerometerSensor.Instance.Start();

            labels.Add(new Label(ResourceManager.CreateImage("cell1")));
            labels.Add(new Label(ResourceManager.CreateImage("cell2")));
            labels.Add(new Label(ResourceManager.CreateImage("cell3")));
            labels.Add(new Label(ResourceManager.CreateImage("cell4")));

            centerposition = new Vector2(Preferences.Width / 2 - labels[0].Size.X / 2, Preferences.Height / 2 - labels[0].Size.Y / 2);
            maxX = Preferences.Width - labels[0].Size.X;
            maxY = Preferences.Height - labels[0].Size.Y;

            AddComponent(labels[0], 10, 10);
            AddComponent(labels[1], 250, 10);
            AddComponent(labels[2], 10, 600);
            AddComponent(labels[3], 250, 600);

            foreach (Label lbl in labels)
            {
                lbl.Draggable = true;
            }



        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (Label lbl in labels)
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
