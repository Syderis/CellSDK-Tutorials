using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;

namespace OpenUri
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            StaticContent.Graphics.IsFullScreen = true;
            StaticContent.Graphics.ApplyChanges();

            // TODO: Replace these comments with your own poetry, and enjoy!            
            Button openUri = new Button("Open uri");
            openUri.Released += new Component.ComponentEventHandler(openUri_Released);
            AddComponent(openUri, Width / 2 - openUri.Size.X / 2, Height / 2 - openUri.Size.Y / 2);

        }

        void openUri_Released(Component source)
        {
            OpenURI(new Uri("http://www.cellsdk.com"));
        }


        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();

            Program.Instance.Exit();
        }
    }
}
