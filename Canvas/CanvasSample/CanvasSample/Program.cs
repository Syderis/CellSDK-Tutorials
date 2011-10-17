using System;

using Syderis.CellSDK.WindowsPhone.Launcher;

namespace CanvasSample
{
    public class Program : Kernel
    {
        protected override void Initialize()
        {
            Application application = new Application();
            base.Application = application;
            base.Initialize();
        }
    }
}

