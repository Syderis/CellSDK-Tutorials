#region Using Statements
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
#endregion 

namespace TextAlignment
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            Image img = Image.CreateImage("posit");
            Label lbl = new Label(img);
            lbl.FitToText = false;
            lbl.Text = "My note";
            lbl.Align = Label.AlignType.MIDDLECENTER;

            lbl.Draggable = true;
            AddComponent(lbl,0,0);
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
