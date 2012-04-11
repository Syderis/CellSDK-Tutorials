/*
 * Copyright 2011 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using statements
using System;

using Syderis.CellSDK.WindowsPhone.Launcher;
#endregion

namespace WP7ChangeSplash
{
    public class Program : Kernel
    {

        #region Variables
        #endregion

        #region Properties
        #endregion

        #region Public methods
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        protected override void Initialize()
        {
            SplashStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ChangeSplash.DarkC.png");
            Application application = new Application();
            FramesPerSecond = 50;
            base.Application = application;
            base.Initialize();
        }
        #endregion

        #region Private methods
        #endregion
    }
}

