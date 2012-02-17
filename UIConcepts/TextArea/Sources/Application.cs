#region Using Statements
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
#endregion

namespace TextAreaSample
{
    class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);

            TextArea loveletter = new TextArea("Hello, World!", 1, 20);
            AddComponent(loveletter, 20, 200);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
