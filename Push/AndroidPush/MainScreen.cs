using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Notifications;

using Syderis.CellSDK.Common;
using Microsoft.Xna.Framework;

namespace AndroidPush
{
    class MainScreen : Screen
    {
        /// <summary>
        /// Sets the screen up (UI components, multimedia content, etc.)
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            NotificationConfiguration configuration = new NotificationConfiguration();
            configuration.WindowsPhone.ChannelName = "My Channel";
            configuration.Android.SenderEmail = "me@email.com";

            ANotificationServerConnector serverConnector = new UrbanArshipServerConnector("AppKey", "AppSecret", "Alias", new string[] { "tag01", "tag02" }); 

            NotificationManager.Register(configuration, serverConnector);
            NotificationManager.OnNotification += new NotificationManager.NotificationMessageHandle(NotificationManager_OnNotification);

        }

        void NotificationManager_OnNotification(Dictionary<string, string> parameters)
        {
            Label myLabel;
            myLabel = new Label("Notification received", Color.White, Color.Transparent);
            AddComponent(myLabel, Preferences.Width / 2 - myLabel.Size.X / 2, Preferences.Height / 2 - myLabel.Size.Y / 2);
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
