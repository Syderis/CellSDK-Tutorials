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
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core.Controls; 
#endregion

namespace ParticlesSample
{
    public class MainScreen : Screen
    {
        private ParticleSystem particle1, particle2;
        private Button btnPush;

        public override void Initialize()
        {
            base.Initialize();

            Image star1 = ResourceManager.CreateImage("star");
            Image star2 = star1.SubImage(0, 0, star1.Width, star1.Height);

            star1.Color = Color.Pink;
            star2.Color = Color.CadetBlue;

            particle1 = new ParticleSystem(star1);
            particle2 = new ParticleSystem(star2);

            AddComponent(particle1, 100f, 200f);
            AddComponent(particle2, 300f, 200f);

            btnPush = new Button("Push me!");
            btnPush.Released += new Component.ComponentEventHandler(btnPush_Released);
            AddComponent(btnPush, 100f, 700f);
        }

        #region Events
        public void btnPush_Released(Component source)
        {
            particle1.Play();
            particle2.Play();
        } 
        #endregion

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
