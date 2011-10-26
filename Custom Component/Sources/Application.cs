using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;

namespace ComboBo
{
    class Application : MultitouchApplication
    {
        ComboBox combo;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            combo = new ComboBox();
            
            
            combo.AddItem("Fruit");
            combo.AddItem("Milk");
            combo.AddItem("Wine");
            combo.AddItem("Ice");
            combo.AddItem("Ice cream");
            combo.AddItem("Carrots");
            combo.AddItem("Potatoes");
            combo.AddItem("Ketchup");
            combo.AddItem("Tomatoes");
            

            AddComponent(combo, 10, 100);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
