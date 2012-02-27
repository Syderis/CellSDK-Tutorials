/*
 * Copyright 2011 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using statements
using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Microsoft.Xna.Framework;

using Syderis.CellSDK.Android.Launcher;
using Syderis.CellSDK.Common;
using Syderis.CellSDK.Core;
#endregion
namespace Camera
{
    [Activity(Label = "AndroidCamera", MainLauncher = true, Icon = "@drawable/icon")]
    public class Program : AndroidGameActivity
    {

        #region Variables
        public static Program Instance;
        private Kernel kernel;
        #endregion

        #region Properties
        #endregion

        #region Public methods
        /// <summary>
        /// The main method which loads Application.
        /// </summary>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Kernel.Activity = this;

            kernel = new Kernel(this);
            SetContentView(kernel.Window);

            Instance = this;
            Preferences.SkinXMLFileStream = Assets.Open("Content/Skin/Skin.xml");
            Preferences.ApplicationActivity = this;

            Application application = new Application();
            kernel.Application = application;
            kernel.Run();
        }

        /// <summary>
        /// Exit Method.
        /// </summary>
        public void Exit()
        {
            Finish();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// The application's activity pauses the execution
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();

            kernel.OnPause();
        }

        /// <summary>
        /// The application's activity resumes the execution
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            kernel.OnResume();
        }
        #endregion

        #region Private methods
        #endregion
    }
}