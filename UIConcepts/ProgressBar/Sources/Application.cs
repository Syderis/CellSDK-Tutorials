#region Using Statements
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
#endregion

namespace ProgressBarSample
{
    public class Application : MobileApplication
    {
        private ProgressBar charger;
        private bool charged;

        public override void Initialize()
        {
            base.Initialize();

            Label message = new Label("Charging...");
            AddComponent(message, 0, 100);

            Button shot = new Button("Shot!");
            shot.Pressed += delegate
            {
                if (charged)
                {
                    charger.Value = 0;
                    charged = false;
                    message.Text = "Charging...";
                }
            };
            AddComponent(shot, 150, 100);

            charger = new ProgressBar();
            charger.Value = 0;
            charger.EndEvent += delegate
            {
                charged = true;
                message.Text = "Charged!";
            };
            AddComponent(charger, 0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!charged)
                charger.Value++;

        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}