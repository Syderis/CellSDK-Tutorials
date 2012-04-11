using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Common;

namespace Alert
{
    public class MainScreen:Screen
    {
        public override void Initialize()
        {
            base.Initialize();
            
            Button alert = new Button("Push me!");
            alert.Pressed += new Component.ComponentEventHandler(alert_Pressed);
            AddComponent(alert, Preferences.Width / 2 - alert.Size.X / 2, Preferences.Height / 2 - alert.Size.Y / 2);
        }

        void alert_Pressed(Component source)
        {
            Preferences.App.Alert("Hi guy!","Message");
        }
    }
}
