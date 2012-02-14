/*
 * Copyright 2010 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */
using System;

using Syderis.CellSDK.WindowsPhone.Launcher;

namespace SpriteSheet
{
    public class Program : Kernel
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        protected override void Initialize()
        {
            Application application = new Application();
            FramesPerSecond = 50;
            base.Application = application;
            base.Initialize();
        }
    }
}

