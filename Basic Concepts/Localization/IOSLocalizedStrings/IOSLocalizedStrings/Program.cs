using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Syderis.CellSDK.IOS.Launcher;

namespace LocalizedStrings
{
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
		public static Program Instance;
		private Kernel kernel;
		
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}

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
		}

		public override void OnResignActivation (UIApplication application)
		{
			kernel.OnResignActivation ();
		}           
	}
}
