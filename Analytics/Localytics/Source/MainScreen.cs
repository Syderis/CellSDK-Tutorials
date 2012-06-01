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
using Syderis.CellSDK.Analytics;
#endregion

namespace Localytics
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

            AnalyticsManager.CreateAnalytics(AnalyticsType.LOCALYTICS, "MyLocalyticsCode");

            Dictionary<string, string> myParams = new Dictionary<string, string>();
            myParams.Add("first", "my event occured");
            AnalyticsManager.LogEvent("MyEvent", myParams);
            

            Button b = new Button("Push me");
            b.Released += new Component.ComponentEventHandler(b_Released);

            AddComponent(b, Preferences.Width / 2 - b.Size.X, Preferences.Height / 2 - b.Size.Y / 2);            
        }

        void b_Released(Component source)
        {
            Dictionary<string, string> myParams = new Dictionary<string, string>();
            myParams.Add("first", "my event occured");
            AnalyticsManager.LogEvent("buttonClicked", myParams);
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
