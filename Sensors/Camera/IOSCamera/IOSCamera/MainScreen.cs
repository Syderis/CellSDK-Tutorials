/*
* Copyright 2011 Syderis Technologies S.L. All rights reserved.
* Use is subject to license terms.
*/
                    
#region Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;

#endregion
namespace IOSCamera
{
	class MainScreen : Screen
	{
        #region Variables
        #endregion
                    
        #region Properties
        #endregion
                   
        #region Public methods
		/// <summary>
		/// Sets the screen up (UI components, multimedia content, etc.)
		/// </summary>
		public override void Initialize ()
		{
			base.Initialize ();

			// Note: Cell SDK assemblies (.dll) aren't referenced currently by default. Please, 
			// reference the following ones located at /Library/Frameworks/CellSDK.framework/Libraries/:
			//   MonoGame.Framework.dll
			//   Syderis.CellSDK.IOS.Common.dll
			//   Syderis.CellSDK.IOS.Core.dll
			//   Syderis.CellSDK.IOS.Launcher.dll

			// TODO: Replace these comments with your own poetry, and enjoy!
			//AddComponent(new Label("Hello, World!"), 0, 0);
		}

		/// <summary>
		/// Pops this screen returning to the previous one, or exiting the app if there is no more left.
		/// This method is called when the hardware back button is pressed (only Windows Phone & Android)
		/// </summary>
		public override void BackButtonPressed ()
		{
			base.BackButtonPressed ();
		}
        #endregion
        
		#region Private methods
        #endregion
	}
}
