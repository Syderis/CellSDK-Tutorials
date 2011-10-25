using System;

using Syderis.CellSDK.WindowsPhone.Launcher;
using CanvasSample;

namespace WP7Canvas
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

