using System;

using Microsoft.Xna.Framework;

using Syderis.CellSDK.WindowsPhone.Launcher;

namespace WP7ViewportManager
{
    public class Program : Kernel
    {
        /// <summary>
        /// Initial orientation supported.
        /// </summary>
        private const DisplayOrientation SUPPORTED_ORIENTATION = DisplayOrientation.Portrait;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        protected override void Initialize()
        {
            Application application = new Application();
            FramesPerSecond = 50;
            base.Application = application;
            application.SupportedOrientation = SUPPORTED_ORIENTATION;
            base.Initialize();
        }
    }
}

