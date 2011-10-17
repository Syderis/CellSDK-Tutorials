using System;

using Syderis.CellSDK.Windows.Launcher;

namespace CellSDKApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Kernel kernel = new Kernel())
            {
                Application application = new Application();
                kernel.Application = application;
                kernel.Run();
            }
        }
    }
}

