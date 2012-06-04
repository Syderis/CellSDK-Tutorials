using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;

namespace IOSViewportManager
{
	class MainScreen : Screen
	{
		/// <summary>
		/// Sets the screen up (UI components, multimedia content, etc.)
		/// </summary>
		public override void Initialize ()
		{
			base.Initialize ();

			#region MONODEVELOP USERS, PLEASE READ THIS!
			// Cell SDK assemblies (.dll) aren't referenced currently by default. Please, 
			// reference the following ones located at 
			// {Program Files folder}\Syderis\CellSDK.framework\Versions\X.Y\Android\Libraries (Windows) or 
			// /Library/Frameworks/CellSDK.framework/Libraries (Mac):
			//   MonoGame.Framework.dll
			//   Syderis.CellSDK.Android.Common.dll
			//   Syderis.CellSDK.Android.Core.dll
			//   Syderis.CellSDK.Android.Launcher.dll
			//
			// Sorry for the inconveniences.
			#endregion

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
	}
}

