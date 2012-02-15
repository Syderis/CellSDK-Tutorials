#region Using Statments
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics; 
#endregion

namespace zBuffering
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
            Label cell1 = new Label(Image.CreateImage("cell1"));
            Label cell2 = new Label(Image.CreateImage("cell2"));
            Label cell3 = new Label(Image.CreateImage("cell3"));

            cell1.Draggable = true;
            cell2.Draggable = true;
            cell3.Draggable = true;

            cell1.BringToFront = false;
            cell3.BringToFront = false;

            cell1.Alpha = cell2.Alpha = cell3.Alpha = 0.8f;

            SendToFront(cell2);

            AddComponent(cell1, Width / 2 - cell1.Size.X / 2, Height / 3);
            AddComponent(cell2, Width / 2 - cell2.Size.X / 2, Height / 3);
            AddComponent(cell3, Width / 2 - cell3.Size.X / 2, Height / 3);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}

