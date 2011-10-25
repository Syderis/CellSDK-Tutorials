using System;

using Syderis.CellSDK.WindowsPhone.Launcher;
using AnimatedImages;

namespace WP7AnimatedImages
{
    public class Program : Kernel
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        protected override void Initialize()
        {
            MyApplication application = new MyApplication();
            base.Application = application;
            base.Initialize();
        }
    }
}

