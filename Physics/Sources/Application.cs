using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Physics;

namespace Physics
{
    class Application : MobileApplication
    {
        Label lbl1k, lbl2k, staticLabel;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            SetBackground(Image.CreateImage("background"), Adjustment.STRETCH);

            CreatePhysicWorld(new Vector2(0, -10), true, true, Vector2.Zero);

            //First tutorial
            //Label lbl = new Label("Hello God!");
            
            //AddComponent(lbl, 200, 100, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);

            //Label staticLabel = new Label("I am a static label");

            //AddComponent(staticLabel, 200, 500, BodyShape.SQUARE, BodyType.STATIC, Category.Cat1);
            //staticLabel.Rotation = MathHelper.ToRadians(45f);


            //SecondTutorial
            //lbl1k = new Label(Image.CreateImage("1kg"));
            //AddComponent(lbl1k, 50, 0, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);            
            //lbl1k.PhysicBody.Mass = 1f;
            
            //lbl2k = new Label(Image.CreateImage("2kg"));
            //AddComponent(lbl2k, 200, 0, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);            
            //lbl2k.PhysicBody.Mass = 2f;

            //staticLabel = new Label("I am a static label");            
            //AddComponent(staticLabel, 50, 500, BodyShape.SQUARE, BodyType.STATIC, Category.Cat1);

            //Third tutorial

            lbl1k = new Label(Image.CreateImage("1kg"));
            AddComponent(lbl1k, 50, 0, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
            lbl1k.PhysicBody.Mass = 1f;

            lbl2k = new Label(Image.CreateImage("2kg"));
            AddComponent(lbl2k, 200, 0, BodyShape.SQUARE, BodyType.DYNAMIC, Category.Cat1);
            lbl2k.PhysicBody.Mass = 2f;

            staticLabel = new Label("I am a static label");
            AddComponent(staticLabel, 50, 500, BodyShape.SQUARE, BodyType.STATIC, Category.Cat1);


            Button btn = new Button("Press me!");
            AddComponent(btn, 50, 700, BodyShape.SQUARE, BodyType.STATIC, Category.Cat1);
            btn.Released += new Component.ComponentEventHandler(btn_Released);

            staticLabel.Rotation = MathHelper.ToRadians(20f);
            lbl1k.PhysicBody.Friction = 1f;
            lbl2k.PhysicBody.Friction = 10f;
            
            lbl1k.Draggable = true;
            lbl2k.Draggable = true;

            lbl1k.PhysicBody.Restitution = 1.2f;
            lbl2k.PhysicBody.Restitution = 0.9f;            
        }

        void btn_Released(Component source)
        {
            Vector2 velocity = new Vector2(0, 10);
            lbl1k.PhysicBody.ApplyForce(ActionType.IMPULSE, velocity);
            lbl2k.PhysicBody.ApplyForce(ActionType.IMPULSE, velocity);         
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
