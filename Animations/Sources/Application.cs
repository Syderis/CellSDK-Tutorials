using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Graphics;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Animations;

namespace Animations
{
    class Application : MobileApplication
    {
        private Label lbl;
        private Animation anim;
        private Button playStop;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            SetBackground(Image.CreateImage("bg_mobile"), Adjustment.CENTER);
            // TODO: Replace these comments with your own poetry, and enjoy!
            lbl = new Label(Image.CreateImage("cell_car"));
            AddComponent(lbl, Width / 2, Height / 2);
            
            anim = Animation.CreateAnimation(20);

            anim.AnimationType = AnimationType.Relative;
            anim.AddKey(new KeyFrame(0, 0.1f));
            anim.AddKey(new KeyFrame(5, 0.5f));
            anim.AddKey(new KeyFrame(10, 0.9f));
            anim.AddKey(new KeyFrame(15, 0.5f));
            anim.AddKey(new KeyFrame(anim.NumFrames - 1, 0.1f));


            anim.IsLooped = true;

          //  anim.Play(lbl);

            anim.KeyEvent += new Animation.AnimationHandler(anim_KeyEvent);
            playStop = new Button("Play/Stop");
            AddComponent(playStop, 100, 200);
            playStop.Released += new Component.ComponentEventHandler(playStop_Released);

            keyEventLabel = new Label("Event Raised!!");
            AddComponent(keyEventLabel, Width / 2, 620);
            keyEventLabel.Visible = false;



        }
        private void playStop_Released(Component source)
        {
            switch (anim.State)
            {
                case AnimationState.Paused:
                    anim.Resume();
                    break;
                case AnimationState.Playing:
                    anim.Pause();
                    break;
                case AnimationState.Stopped:
                    anim.Play(lbl);
                    break;
                default:
                    break;
            }
        }

        private Label keyEventLabel;
        void anim_KeyEvent(Animation animation)
        {
            
                keyEventLabel.Visible = true;
            
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
