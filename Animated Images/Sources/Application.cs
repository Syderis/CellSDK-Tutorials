using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Animations;
using Syderis.CellSDK.Core.Graphics;

namespace AnimatedImages
{
    class Application : MultitouchApplication
    {
        private AnimatedImage img;
        int numberPlayed;
        Label playNumbers;


        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            SetBackground(Image.CreateImage("bg_mobile"), false);
            // TODO: Replace these comments with your own poetry, and enjoy!
            StripAnimation animation = new StripAnimation(1020,868,204, 217, 19);
            animation.FramesPerSecond = 40;
            img = AnimatedImage.CreateImage("ball");
            
            img.AddAnimation("bounce", animation);
            img.EndedCurrentStripAnimation += new EventHandler(img_EndedCurrentStripAnimation);
            numberPlayed = 0;
            AddComponent(new Label(img), 10, 100);
            Button play = new Button("Play");
            Button stop = new Button("Stop");
            Button pause = new Button("Pause");
            play.Released += new Component.ComponentEventHandler(play_Released);
            stop.Released += new Component.ComponentEventHandler(stop_Released);
            pause.Released += new Component.ComponentEventHandler(pause_Released);

            playNumbers = new Label("0");

            AddComponent(play, 150, 100);
            AddComponent(stop, 150, 150);
            AddComponent(pause, 150, 200);
            AddComponent(playNumbers, 10, 50);

        }

        void img_EndedCurrentStripAnimation(object sender, EventArgs e)
        {
            numberPlayed++;
            playNumbers.Text = numberPlayed.ToString();
        }

        void play_Released(Component source)
        {
            img.Play(true);
        }

        void stop_Released(Component source)
        {
            img.Stop();
        }

        void pause_Released(Component source)
        {
            img.Pause();
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }

    }
}
