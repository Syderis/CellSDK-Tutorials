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
using Syderis.CellSDK.Core.Interfaces;
using Syderis.CellSDK.Common; 
#endregion

namespace SampleListBox
{
    public class MainScreen : Screen
    {
        public override void Initialize()
        {
            base.Initialize();
            
            ListBox descriptions = new ListBox((int)Preferences.Width, 200);

            descriptions.AddItem(new ListItem("Electronic Gadget"));
            descriptions.AddItem(new ListItem("Plastic Guy"));
            descriptions.AddItem(new ListItem("I-beleive-have-a-laser"));
            descriptions.AddItem(new ListItem("My-helment-is-a-fishbowl"));
            descriptions.AddItem(new ListItem("I-have-sort-of-wings"));
            descriptions.AddItem(new ListItem("To-the-infinity-and-beyond"));
            descriptions.AddItem(new ListItem("I-am-the-Andy's-second"));

            AddComponent(descriptions, 0, 0);
        }

        public override void BackButtonPressed()
        {
            base.BackButtonPressed();
        }
    }

    #region InternalClass
    internal class ListItem : IListBoxObject
    {
        Label l;

        public ListItem(string label)
        {
            l = new Label(label);
        }

        public Component CellRenderer()
        {
            return l;
        }
    } 
    #endregion
}
