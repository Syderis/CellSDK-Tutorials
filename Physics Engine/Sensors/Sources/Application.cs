#region Using Statements
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core.Physics;
#endregion

namespace Sensor
{
    class Application : MobileApplication
    {
        Vector2 offset;
        Image iSupport;
        Image iBall;
        Image iMetalCradle;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
#if IOS
            offset=new Vector2(80,80);
#else
            offset = Vector2.Zero;
#endif

            int ballSize = 78;

            CreatePhysicWorld(Vector2.UnitX * -20f, true, false, Vector2.Zero);

            SetBackground(Image.CreateImage("background"),Adjustment.CENTER);

            iSupport = Image.CreateImage(Color.Transparent, 1, 1);
            iBall = Image.CreateImage("ball");
            iMetalCradle = Image.CreateImage("metalSupport");

            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 0 * ballSize), 300, true);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 1 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 2 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 3 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 4 * ballSize), 300, false);
            CreateNewtonBall(iSupport, iBall, new Vector2(420, 200 + 5 * ballSize), 300, true);

            Label lMetalSupport = new Label(iMetalCradle);
            AddComponent(lMetalSupport, 0, 0);
            
            lMetalSupport.Touchable = false;
            PhysicWorld.Iterations = 120;
        }

        public void CreateNewtonBall(Image iGround, Image iSphere, Vector2 vPosition, int ropeLength, bool touchable)
        {
            Label lSupport = new Label(iGround); //Static Label 
            Label lBall = new Label(iSphere); //Label with the ball texture.

            //We add the lSupport as a static physic object. So it does not interact with anything
            AddComponent(lSupport, vPosition.X+offset.X, vPosition.Y+offset.Y, BodyShape.SQUARE, BodyType.STATIC, Category.Cat1);
            //We add the IBall label 
            AddComponent(lBall, vPosition.X - ropeLength+offset.X, vPosition.Y+offset.Y, BodyShape.CIRCLE, BodyType.DYNAMIC, Category.Cat1);

            lBall.BringToFront = false;
            lBall.PhysicBody.Mass = 4.0f; //ball mass.
            lBall.PhysicBody.Restitution = 1.0f;//ball restitution
            lBall.PhysicBody.Friction = 8.0f; //ball friction
            lBall.Touchable = touchable; // set the Touchable to true or false
            lBall.Draggable = touchable; //set the Draggable to true or false

            PhysicWorld.AddSensor(lSupport, lBall, lSupport.Position + lSupport.Size / 2, lBall.Position + lBall.Size / 2, false, 30, 30, 800.0f, 100.0f);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
            Program.Instance.Exit();
        }
    }
}
