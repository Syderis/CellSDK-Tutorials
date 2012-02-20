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
using Syderis.CellSDK.Common; 
#endregion

namespace OpenUri
{
    class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!            
            Button openUri = new Button("Open uri");
            openUri.Released += new Component.ComponentEventHandler(openUri_Released);
            AddComponent(openUri, Preferences.Width / 2 - openUri.Size.X / 2, Preferences.Height / 2 - openUri.Size.Y / 2);

        }

        #region Events
        void openUri_Released(Component source)
        {
            Preferences.App.OpenURI(new Uri("http://www.cellsdk.com"));
        } 
        #endregion

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
