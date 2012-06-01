using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Syderis.CellSDK.IOS.Launcher;

namespace MyPush
{
	[Register("AppDelegate")]
	class Program : UIApplicationDelegate
	{
		public static Program Instance;
		private Kernel kernel;
		private Application application;
		
		static void Main (string[] args)
		{
			UIApplication.Main (args, null, "AppDelegate");
		}

		public override void FinishedLaunching (UIApplication app)
		{
			Instance = this;
			application = new Application ();
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
		
		public override void RegisteredForRemoteNotifications (UIApplication uiApplication, NSData deviceToken)
		{
			application.RegisteredForRemoteNotifications(deviceToken);
		}
		
		public override void ReceivedRemoteNotification (UIApplication uiApplication, NSDictionary userInfo)
		{
			application.ReceivedRemoteNotification(userInfo);
		}
		
		public override void FailedToRegisterForRemoteNotifications (UIApplication uiApplication, NSError error)
		{
			application.FailedToRegisterForRemoteNotifications(error);
		}
	}
}
