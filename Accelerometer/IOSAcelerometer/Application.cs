using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;

namespace IOSAcelerometer
{
	class Application : MultitouchApplication
	{
		public override void Initialize ()
		{
			base.Initialize ();

			// Note: CELL·SDK assemblies (.dll) aren't referenced currently by default. Please, 
			// reference the following ones located at /Library/Frameworks/CellSDK.framework/Libraries/:
			//   FarseerPhysics_331.IOS.dll
			//   MonoGame.Framework.IOS.dll
			//   Syderis.CellSDK.IOS.Common.dll
			//   Syderis.CellSDK.IOS.Core.dll
			//   Syderis.CellSDK.IOS.Launcher.dll
                    
			// TODO: Replace these comments with your own poetry, and enjoy!
			//AddComponent(new Label("Hello, World!"), 0, 0);
		}
	}
}
