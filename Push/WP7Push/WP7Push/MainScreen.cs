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
using Syderis.CellSDK.Notifications;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Common;
using System.Diagnostics;
#endregion
namespace WP7Push
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
            NotificationConfiguration configuration = new NotificationConfiguration();
            configuration.WindowsPhone.ChannelName = "My Channel";
            ANotificationServerConnector serverConnector = new MyServerConnector();

			NotificationManager.OnNotification += new NotificationManager.NotificationMessageHandle(NotificationManager_OnNotification);
            NotificationManager.Register(configuration, serverConnector);
           

        }

        void NotificationManager_OnNotification(Dictionary<string, string> parameters)
        {
            Label myLabel;
            myLabel = new Label("Notification received", Color.White, Color.Transparent);
            AddComponent(myLabel, Preferences.Width / 2 - myLabel.Size.X / 2, Preferences.Height / 2 - myLabel.Size.Y / 2);
        }


        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
        #endregion

        #region Private methods

        internal class MyServerConnector : ANotificationServerConnector
        {
            public override void Initialize()
            {
                Debug.WriteLine("MyServerConnector()");
            }

            public override void UpdateChannelId(string channelId)
            {
                Debug.WriteLine("ChannelId: " + channelId);
                Preferences.App.Alert(channelId, "Notification Channel ID:");
            }

            public override void NotificationError(string errorMessage)
            {
                Debug.WriteLine("Error: " + errorMessage);

            }

            public override Dictionary<string, string> ProcessMessage(Dictionary<string, string> parameters)
            {
                StringBuilder builder = new StringBuilder();
                foreach (KeyValuePair<string, string> pair in parameters)
                {
                    builder.Append(pair.Key).Append(": ").Append(pair.Value).Append("\n");
                }
                Debug.WriteLine(builder);

                return parameters;

            }

            public override string GetAndroidNotificationDetails(Dictionary<string, string> parameters)
            {
                return "Description";
            }
        }

        #endregion
    }
}
