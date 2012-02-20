/*
* Copyright 2011 Syderis Technologies S.L. All rights reserved.
* Use is subject to license terms.
*/
                    
#region Using statements
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Syderis.CellSDK.IOS.Launcher;

#endregion
namespace Alert
{
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
        #region Variables
        #endregion
                    
        #region Properties
        #endregion
                   
        
		public static Program Instance;
		private Kernel kernel;
		
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}
#region Public methods
		public override void FinishedLaunching (UIApplication app)
		{
			Instance = this;
			Application application = new Application ();
			kernel = new Kernel (application);
			kernel.Run ();
		}

		public void Exit ()
		{
			kernel.Exit ();
		}
		
		public override void DidEnterBackground (UIApplication application)
		{
			kernel.OnDeactivated ();
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
			kernel.OnActivated ();
		}
		
		public override void WillTerminate (UIApplication application)
		{
			kernel.OnExiting ();
		}#endregion
        
		#region Private methods
        #endregion
	}
}
