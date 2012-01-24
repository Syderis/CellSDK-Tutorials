#region Using Statements
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Layouts; 
#endregion

namespace GridLayoutSample
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
            //Add your code here
            Container<GridLayout> gridContainer = new Container<GridLayout>(new GridLayout(6, 2, 10, 10));
            gridContainer.BackgroundColor = Color.Transparent;
            gridContainer.Layout.AddComponent(new Label("One"));
            gridContainer.Layout.AddComponent(new Label("Two"));
            gridContainer.Layout.AddComponent(new Label("Three"));
            gridContainer.Layout.AddComponent(new Label("Four"));
            gridContainer.Layout.AddComponent(new Label("Five"));
            gridContainer.Layout.AddComponent(new Label("Six"));
            gridContainer.Layout.AddComponent(new Label("Seven"));
            gridContainer.Layout.AddComponent(new Label("Eight"));
            gridContainer.Layout.AddComponent(new Label("Nine"));
            gridContainer.Layout.AddComponent(new Label("Ten"));
            gridContainer.Layout.AddComponent(new Label("Eleven"));
            gridContainer.Layout.AddComponent(new Label("Twelve"));
            gridContainer.Size = new Vector2(400, 400);

            AddComponent(gridContainer, 50, 50);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
