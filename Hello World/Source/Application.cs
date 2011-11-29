using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework;

namespace CellSDKApp
{
    class Application : MobileApplication
    {
        int count = 0;
        Label clickLabel;
        Button clickButton;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.Gray);

            clickLabel = new Label("Click Count");
            clickButton = new Button("Click me!!!");

            clickButton.Released += delegate { clickLabel.Text = string.Format("{0} Clicks!.", ++count); };

            clickLabel.Pivot = Vector2.One / 2;
            clickLabel.Align = Label.AlignType.MIDDLECENTER;
            clickButton.Pivot = Vector2.One / 2;
            clickButton.Align = Label.AlignType.MIDDLECENTER;


            AddComponent(clickLabel, Width / 2 - clickLabel.Size.X/2, Height / 2);
            AddComponent(clickButton, Width / 2 - clickButton.Size.X/2, Height / 2 - 100);            
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}