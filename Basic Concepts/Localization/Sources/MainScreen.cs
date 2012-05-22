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
using Syderis.CellSDK.Core.Utils;

using Syderis.CellSDK.Common;
#endregion

namespace LocalizedStrings
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

            Preferences.DeviceInfo.CurrentCulture = new System.Globalization.CultureInfo("EN-us");

            AddComponent(new Label(I18N.GetString("label1")), 10, 0);
            AddComponent(new Label(I18N.GetString("label2")), 10, 50);            

            Preferences.DeviceInfo.CurrentCulture = new System.Globalization.CultureInfo("ES-es");

            AddComponent(new Label(I18N.GetString("label1")), 300, 0);
            AddComponent(new Label(I18N.GetString("label2")), 300, 50);            
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
