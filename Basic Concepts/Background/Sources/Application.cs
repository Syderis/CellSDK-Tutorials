using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Graphics;

namespace Background
{
    class Application : MobileApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            // Replace this comment with your own poetry, and enjoy!
            SetBackground(Image.CreateImage("cell1"), MobileApplication.Adjustment.CENTER);
        }
         public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
