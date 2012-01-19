using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;

namespace Basics
{
    class Application : MobileApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            // Replace this comment with your own poetry, and enjoy!
            SetBackground(Image.CreateImage("Background"), MobileApplication.Adjustment.CENTER);
        }
         public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
