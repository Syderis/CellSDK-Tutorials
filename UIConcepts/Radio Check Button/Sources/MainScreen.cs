/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syderis.CellSDK.Core.Screens;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework; 
#endregion

namespace SelectOptions
{
    public class MainScreen : Screen
    {
        Label lbl, lblBlue, lblRed;
        RadioButton rbBlue, rbRed;
        RadioButtonGroup group;
        CheckBox check;
        Label lblmessage, lblWhiteRabbit;

        public override void Initialize()
        {
            base.Initialize();

            SetBackground(Color.White);

            lbl = new Label("Select one");
            AddComponent(lbl, 50, 50);

            lblBlue = new Label("Blue Pill");
            rbBlue = new RadioButton();
            AddComponent(rbBlue, 50, 100);
            AddComponent(lblBlue, 90, 100);

            lblRed = new Label("Red Pill");
            rbRed = new RadioButton();
            AddComponent(rbRed, 50, 150);
            AddComponent(lblRed, 90, 150);

            group = new RadioButtonGroup();
            group.Add(rbBlue);
            group.Add(rbRed);

            check = new CheckBox();
            lblmessage = new Label("Remember: all I'm offering is the truth,\n nothing more");
            lblWhiteRabbit = new Label(ResourceManager.CreateImage("whiteRabbit"));

            AddComponent(check, 10, 300);
            AddComponent(lblmessage, 10, 350);
            AddComponent(lblWhiteRabbit, 10, 500);

            lblWhiteRabbit.Visible = lblmessage.Visible = check.Visible = false;

            //Events
            rbRed.Released += rbRed_Released;
            rbBlue.Released += rbBlue_Released;
            check.Released += check_Released;
        }

        #region Events
        void rbRed_Released(Component source)
        {
            lblmessage.Visible = check.Visible = true;
            lblWhiteRabbit.Visible = check.Selected;
        }

        void rbBlue_Released(Component source)
        {
            lblmessage.Visible = check.Visible = false;
            lblWhiteRabbit.Visible = check.Visible && !check.Selected;
        }

        void check_Released(Component source)
        {
            lblWhiteRabbit.Visible = check.Selected;
        } 
        #endregion

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }
}
