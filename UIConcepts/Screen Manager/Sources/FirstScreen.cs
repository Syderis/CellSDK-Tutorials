/*
 * Copyright 2011 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Screens.Transitions;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;
#endregion
namespace MyScreenManager
{
    class FirstScreen : Screen
    {

        #region Variables
        #endregion

        #region Properties
        #endregion

        #region Public methods
        public override void Initialize()
        {
            base.Initialize();
            // TODO: Replace these comments with your own poetry, and enjoy!
            SetBackground(Color.Blue);
            Button left = new Button("Go Left");
            left.Released += new Component.ComponentEventHandler(left_Released);
            AddComponent(left, 0, Preferences.Height / 2 - left.Size.Y / 2);

            Button bottom = new Button("Botton");
            bottom.Released += new Component.ComponentEventHandler(bottom_Released);
            AddComponent(bottom, Preferences.Width / 2 - bottom.Size.X / 2, Preferences.Height - bottom.Size.Y);

            Button toWhite = new Button("Go Black");
            toWhite.Released += new Component.ComponentEventHandler(toWhite_Released);
            AddComponent(toWhite, Preferences.Width / 2 - toWhite.Size.X / 2, Preferences.Height / 2 - toWhite.Size.Y / 2);

            Button cross = new Button("Go Cross");
            cross.Released += new Component.ComponentEventHandler(cross_Released);
            AddComponent(cross, toWhite.Position.X, toWhite.Position.Y + 2 * cross.Size.Y);

            Button right = new Button("Go Right");
            right.Released += new Component.ComponentEventHandler(right_Released);
            AddComponent(right, Preferences.Width - right.Size.X, Preferences.Height / 2 - right.Size.Y / 2);

            Button up = new Button("Go Up");
            up.Released += new Component.ComponentEventHandler(up_Released);
            AddComponent(up, Preferences.Width / 2 - up.Size.X / 2, 0);


        }

        void cross_Released(Component source)
        {
            StaticContent.ScreenManager.PopScreen(TransitionType.FADE_CROSS);
        }

        void up_Released(Component source)
        {
            StaticContent.ScreenManager.PopScreen( TransitionType.MOVE_IN_BOTTOM);
        }

        void right_Released(Component source)
        {
            StaticContent.ScreenManager.PopScreen(TransitionType.MOVE_IN_LEFT);
        }

        void left_Released(Component source)
        {
            StaticContent.ScreenManager.PopScreen(TransitionType.MOVE_IN_RIGHT);
        }

        void bottom_Released(Component source)
        {
            StaticContent.ScreenManager.PopScreen(TransitionType.MOVE_IN_TOP);
        }

        void toWhite_Released(Component source)
        {
            StaticContent.ScreenManager.PopScreen(TransitionType.FADE_BLACK);
        }
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
        #endregion


        #region Private methods
        #endregion
    }
}
