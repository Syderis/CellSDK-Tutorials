#region Using Statements
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
#endregion

namespace Labels
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
            AddComponent(new Label("Text . . ."), 0, 0);            
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}