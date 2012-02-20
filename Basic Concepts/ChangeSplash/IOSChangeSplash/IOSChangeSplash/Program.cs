using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Syderis.CellSDK.IOS.Launcher;

namespace IOSChangeSplash
{
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
		public static Program Instance;
		
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}

		public override void FinishedLaunching (UIApplication app)
		{
			Instance = this;
			
			Application application = new Application ();
			Kernel kernel = new Kernel (application);
			kernel.SplashStream =System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("ChangeSplash.DarkC.png");
			string [] s= System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
			kernel.Run ();
		}
		
		public void Exit(){}
	}
}
