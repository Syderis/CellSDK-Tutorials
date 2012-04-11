using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;

namespace AndroidChangeSplash
{
    class Application : MobileApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            StaticContent.ScreenManager.GoToScreen(new MainScreen());
        }

        public override void Exit()
        {
            base.Exit();

            Program.Instance.Exit();
        }
    }
}
