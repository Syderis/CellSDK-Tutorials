using System;

using Syderis.CellSDK.WindowsPhone.Launcher;
using Sounds;

namespace Sounds
{
    public class Program : Kernel
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        protected override void Initialize()
        {
            Application application = new Application();
            base.Application = application;
            base.Initialize();
        }
    }
}
