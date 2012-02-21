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
using Syderis.CellSDK.Common;
#endregion
namespace PhoneState
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

            AddComponent(new Label("DeviceId:      " + Preferences.DeviceInfo.DeviceId), 0, 0);
            AddComponent(new Label("Manufacturer:  " + Preferences.DeviceInfo.DeviceManufacturer), 0, 50);
            AddComponent(new Label("OS Version:    " + Preferences.DeviceInfo.DeviceOSVersion), 0, 100);
            AddComponent(new Label("Platform:      " + Preferences.DeviceInfo.DevicePlatform), 0, 150);
            AddComponent(new Label("Battery lvl:   " + Preferences.DeviceInfo.BatteryLevel), 0, 200);
            AddComponent(new Label("Battery state: " + Preferences.DeviceInfo.BatteryState), 0, 250);
            AddComponent(new Label("User Agent:    " + Preferences.DeviceInfo.DeviceUserAgent), 0, 300);
            AddComponent(new Label("Network Stat:  " + Preferences.DeviceInfo.NetworkStatus), 0, 350);
            AddComponent(new Label("IP Address:    " + Preferences.DeviceInfo.ExternalIPAddress), 0, 400);
            AddComponent(new Label("Locale:        " + Preferences.DeviceInfo.Locale), 0, 450);
            AddComponent(new Label("LocaleCulture: " + Preferences.DeviceInfo.LocaleCulture), 0, 500);


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
