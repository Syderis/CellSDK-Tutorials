using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;

namespace IOSChangeSplash
{
	public class Application : MobileApplication
	{
		/// <summary>
		/// The main method for loading controls and resources.
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
		/// Exits the application.
		/// </summary>
		public override void BackButtonPressed ()
		{
			base.BackButtonPressed ();

			Program.Instance.Exit ();
		}
	}
}
