using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core.Graphics;


namespace CellLayers
{
    class MainScreen : Screen
    {
        private Sprite sCloud, sMountain1, sMountain2, sGround1,sGround2;
        private Layer lcloud, lmountain, lground;
        private Button btnleft, btnright;
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Image iMountain = ResourceManager.CreateImage("mountain");
            Image iGround = ResourceManager.CreateImage("ground");
            Image icloud = ResourceManager.CreateImage("cloud");
            
            sCloud= new Sprite("cloud", icloud);

            sMountain1= new Sprite("mountain1", iMountain);
            sMountain1.Pivot=Vector2.UnitY; 
            sMountain2 = new Sprite("mountain2", iMountain);
            sMountain2.Pivot = Vector2.UnitY;

            sGround1 = new Sprite("ground1", iGround);
            sGround1.Pivot= Vector2.UnitY;
            sGround2 = new Sprite("ground2", iGround);
            sGround2.Pivot = Vector2.UnitY;

            lcloud = new Layer();
            lcloud.AddSprite(sCloud);

            lmountain = new Layer();
            lmountain.AddSprite(sMountain1);
            lmountain.AddSprite(sMountain2);

            lground = new Layer();
            lground.AddSprite(sGround1);
            lground.AddSprite(sGround2);

            AddComponent(sCloud, 400, 10);

            AddComponent(sGround1, Preferences.ViewportManager.BottomLeftAnchor);
            AddComponent(sGround2, Preferences.ViewportManager.BottomRightAnchor);

            AddComponent(sMountain1, Preferences.ViewportManager.BottomLeftAnchor-Vector2.UnitY*sGround1.Size.Y*0.8f);
            AddComponent(sMountain2, Preferences.ViewportManager.BottomRightAnchor - Vector2.UnitY * sGround1.Size.Y * 0.8f);

      

            SendToFront(sGround1);
            SendToFront(sGround2);

            btnleft = new Button("Move Left");
            AddComponent(btnleft, Vector2.Zero);
            btnright = new Button("Move Right");
            btnright.Pivot = Vector2.UnitX;
            AddComponent(btnright, Preferences.ViewportManager.TopRightAnchor);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (btnright.State == Button.ButtonState.Pressed)
            {
                lmountain.Translate(Vector2.UnitX * (1));
                lground.Translate(Vector2.UnitX * (10));
                lcloud.Translate(Vector2.UnitX * (3));

                lmountain.ApplyTransform();
                lground.ApplyTransform();
                lcloud.ApplyTransform();               
            }

            if (btnleft.State == Button.ButtonState.Pressed)
            {
                lmountain.Translate(Vector2.UnitX * (-1));
                lground.Translate(Vector2.UnitX * (-10));
                lcloud.Translate(Vector2.UnitX * (-3));

                lmountain.ApplyTransform();
                lground.ApplyTransform();
                lcloud.ApplyTransform();                
            }            
        }


        /// <summary>
        /// Pops this screen returning to the previous one, or exiting the app if there is no more left.
        /// This method is called when the hardware back button is pressed (only Windows Phone & Android)
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
