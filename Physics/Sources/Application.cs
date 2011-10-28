using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;

namespace Physics
{
    class Application : MultitouchApplication
    {
        Label lbl1k, lbl2k, staticLabel;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            SetBackground(Image.CreateImage("background"), true);

            CreatePhysicWorld(new Vector2(0, -10), true, Vector2.Zero);

            lbl1k = new Label(Image.CreateImage("1kg"));
            AddComponent(lbl1k, 50, 400);
            lbl1k.ComponentPhysics.Mass = 1f;

            lbl2k = new Label(Image.CreateImage("2kg"));
            AddComponent(lbl2k, 200, 400);
            lbl2k.ComponentPhysics.Mass = 2f;

            staticLabel = new Label("I am a static label");
            AddComponent(staticLabel, 50, 500, PhysicPrimitive.Square, PhysicType.Static);

            Button btn = new Button("Press me!");
            AddComponent(btn, 50, 700, PhysicPrimitive.Square, PhysicType.Static);
            btn.Released += new Component.ComponentEventHandler(btn_Released);

            staticLabel.Rotation = MathHelper.ToRadians(20f);

            lbl1k.ComponentPhysics.ComponentFixture.Friction = 1f;
            lbl2k.ComponentPhysics.ComponentFixture.Friction = 10f;

            lbl1k.Draggable = true;
            lbl2k.Draggable = true;

            lbl1k.ComponentPhysics.Restitution = 1.2f;
            lbl2k.ComponentPhysics.Restitution = 0.9f;

        }

        void btn_Released(Component source)
        {
            Vector2 velocity = new Vector2(0, 10);
            lbl1k.ComponentPhysics.ComponentFixture.Body.ApplyLinearImpulse(ref velocity);
            lbl2k.ComponentPhysics.ComponentFixture.Body.ApplyLinearImpulse(ref velocity);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
