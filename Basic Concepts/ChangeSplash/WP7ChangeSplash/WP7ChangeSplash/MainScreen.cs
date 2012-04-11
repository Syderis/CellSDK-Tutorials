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
#endregion
namespace WP7ChangeSplash
{
    class MainScreen : Screen
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
            //AddComponent(new Label("Hello, World!"), 0, 0);
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
