/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using Microsoft.Xna.Framework.Content;
using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Graphics;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Screens;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Screens.Transitions;

using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using System.Collections.Generic;
using Syderis.CellSDK.Common;
using Microsoft.Xna.Framework.Input;
using Syderis.CellSDK.IO.CameraSystem;
#endregion

namespace Camera
{
	public class CameraScreen : Screen
    {
        #region Variables
        bool started;
		Button btnStartStop, btnType, btTakePhoto;
		
		Label cameraLabel;
		Image cameraImage;
        
        CameraType cType = CameraType.PRIMARY;
        #endregion

        #region Public methods
        public CameraScreen()
		{
            cameraImage = ResourceManager.CreateImage("photocamera");
            
			if(CameraSystem.Instance.IsConnected(CameraType.PRIMARY))
			{
                if (CameraSystem.Instance.IsConnected(CameraType.SECONDARY))
                {
                    btnType = new Button("To Secondary Camera");
                    btnType.Released -= btnType_Released;
                    btnType.Released += btnType_Released;
                    
                    AddComponent(btnType, Preferences.Width - btnType.Size.X, Preferences.Height-btnType.Size.Y);
                }
				CameraSystem.Instance.SetCallbackImage(cameraImage);

                btTakePhoto = new Button("Take a photo");
                btTakePhoto.Released -= btTakePhoto_Released;
                btTakePhoto.Released += btTakePhoto_Released;

                AddComponent(btTakePhoto, 0, Preferences.Height - btTakePhoto.Size.Y);
			}

			btnStartStop = new Button("Start Camera");
            btnStartStop.Released -= btnStartStop_Released;
            btnStartStop.Released += btnStartStop_Released;				
			AddComponent(btnStartStop, Preferences.Width-btnStartStop.Size.X , btnType.Position.Y-btnStartStop.Size.Y);
			
			cameraLabel = new Label(cameraImage);
			cameraLabel.Draggable = true;
			cameraLabel.Scalable = true;
			cameraLabel.Rotable = true;            
			AddComponent(cameraLabel, Preferences.Width/2-cameraLabel.Size.X/2, 0);
            
        }

        public override void BackButtonPressed()
        {
            if (CameraSystem.Instance.IsConnected(CameraType.PRIMARY) || CameraSystem.Instance.IsConnected(CameraType.SECONDARY))
            {
                CameraSystem.Instance.Stop();
            }
            base.BackButtonPressed();
            Program.Instance.Exit();
        }

        #endregion

        #region Private methods

        //Start to capture images from the camera
        void btnStartStop_Released(Component source)
        {
            if (!started)
            {
                CameraSystem.Instance.Start(CameraResolution.LOW, cType);
                btnStartStop.Text = "Stop Camera";
                cameraLabel.Size = new Vector2(640,480);
            }
            else
            {
                CameraSystem.Instance.Stop();
                btnStartStop.Text = "Start Camera";
            }
            started = !started;
        }

        //Change the camera selected 
        void btnType_Released(Component source)
        {
            switch (cType)
            {
                case CameraType.PRIMARY:
                    cType = CameraType.SECONDARY;
                    btnType.Text = "To Primary Camera";
                    break;
                case CameraType.SECONDARY:
                    cType = CameraType.PRIMARY;
                    btnType.Text = "To Secondary Camera";
                    break;
            }
        }

        //Takes a photo
        void btTakePhoto_Released(Component source)
        {
            Texture2D fotoTexture = CameraSystem.Instance.CaptureImage();
            
            Label lbl = new Label(Image.CreateImage(fotoTexture));
            lbl.Rotable = lbl.Draggable = lbl.Scalable = true;
            AddComponent(lbl, 0, 0);           
        }

        #endregion
        
	}
}

