using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Sounds;
using Syderis.CellSDK.Core.Graphics;

namespace InstanceLovelySound
{
    class Application : MobileApplication
    {
        private SoundInstance lovelyInstance;
         Button playStop ;
         Button balanceLeft;
         Button balanceNormal;
         Button balanceRight;
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            
            lovelyInstance = Sound.CreateSound("lovelySound").CreateInstance();

             playStop = new Button(Image.CreateImage("play"), Image.CreateImage("play_pressed"));
             balanceLeft = new Button(Image.CreateImage("balance_left"), Image.CreateImage("balance_left_pressed"));
             balanceNormal = new Button(Image.CreateImage("balance_normal"), Image.CreateImage("balance_normal_pressed"));
             balanceRight = new Button(Image.CreateImage("balance_right"), Image.CreateImage("balance_right_pressed"));

            AddComponent(playStop, 230, 325);
            AddComponent(balanceLeft, 18, 325);
            AddComponent(balanceNormal, 111, 325);
            AddComponent(balanceRight, 354, 325);

            playStop.Released += new Component.ComponentEventHandler(playStop_Released);
            balanceLeft.Released += new Component.ComponentEventHandler(balanceLeft_Released);
            balanceNormal.Released += new Component.ComponentEventHandler(balanceNormal_Released);
            balanceRight.Released += new Component.ComponentEventHandler(balanceRight_Released);

            

        }

        void playStop_Released(Component source)
        {
            switch (lovelyInstance.State)
            {
                case SoundState.Playing:
                    lovelyInstance.Stop();
                    break;
                case SoundState.Stopped:
                    lovelyInstance.Play();
                    break;
                default:
                    break;
            }
        }

        void balanceLeft_Released(Component source)
        {
            lovelyInstance.Balance = -1f;
        }

        void balanceNormal_Released(Component source)
        {
            lovelyInstance.Balance = 0f;
        }

        void balanceRight_Released(Component source)
        {
            lovelyInstance.Balance = 1f;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }
}
