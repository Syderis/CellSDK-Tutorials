#region Using Statements
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core.Physics;
#endregion

namespace Buttons
{
    class Application : MobileApplication
    {
        private Button ball,secondball;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            //AddComponent(new Label("Hello, World!"), 0, 0);
            //Add your code here

            CreatePhysicWorld();

            Button btn = new Button("Push me");
            AddComponent(btn, Width / 2, Height / 2, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
            btn.Pivot = Vector2.One / 2;
            btn.Pressed += new Component.ComponentEventHandler(btn_Pressed);
        }

        void btn_Pressed(Component source)
        {
            if (ball == null)
            {
                ball = new Button(Image.CreateImage("ball"), Image.CreateImage("ballpressed"));
                ball.Pivot = Vector2.One / 2;
                AddComponent(ball, Width / 2, Height / 5, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
                ball.Draggable = true;
                ball.Released += new Component.ComponentEventHandler(ball_Released);
            }
        }

        void ball_Released(Component source)
        {
            if (secondball == null)
            {
                secondball = new Button(Image.CreateImage("ball"), Image.CreateImage("ballpressed"));
                secondball.Pivot = Vector2.One / 2;
                AddComponent(secondball, Width / 2, 4 * Height / 5, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
                secondball.Draggable = true;
            }
        }
        
        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
