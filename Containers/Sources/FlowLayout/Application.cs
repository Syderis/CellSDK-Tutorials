#region Using Stements
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Layouts; 
#endregion

namespace FlowLayoutSample
{
    class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Container<FlowLayout> flowContainer = new Container<FlowLayout>(new FlowLayout());
            flowContainer.BackgroundColor = Color.Transparent;
            flowContainer.Size = new Vector2(150, 10);
            flowContainer.Layout.AddComponent(new Label("One"));
            flowContainer.Layout.AddComponent(new Label("Two"));
            flowContainer.Layout.AddComponent(new Label("Three"));
            flowContainer.Layout.AddComponent(new Label("Four"));
            flowContainer.Layout.AddComponent(new Label("Five"));
            flowContainer.Layout.AddComponent(new Label("Six"));
            flowContainer.Layout.AddComponent(new Label("Seven"));

            AddComponent(flowContainer, 100, 400);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
