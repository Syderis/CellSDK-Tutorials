/*
* Copyright 2011 Syderis Technologies S.L. All rights reserved.
* Use is subject to license terms.
*/
                    
#region Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;

#endregion

namespace IOSChangeSplash
{
	public class Application : MobileApplication
	{
        #region Variables
        #endregion
                    
        #region Properties
        #endregion
                   
        #region Public methods
		/// <summary>
		/// Loads the main screen
		/// </summary>
		public override void Initialize ()
		{
			base.Initialize ();

			// NOTE: Starting from Cell SDK 1.1 all the resources load within this method are done on a specific Screen object.
			// For instance, the Hello World Label is created on MainScreen
			StaticContent.ScreenManager.GoToScreen (new MainScreen ());
		}

		/// <summary>
		/// Exits the app
		/// </summary>
		public override void Exit ()
		{
			base.Exit ();

			Program.Instance.Exit ();
		}
        #endregion
        
		#region Private methods
        #endregion
	}
}
