using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Interfaces;

namespace SampleListBox
{
    class Application : MultitouchApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            ListBox descriptions = new ListBox(MultitouchStaticContent.Width, 200);
            descriptions.AddItem(new ListItem("Electronic Gadget"));

            descriptions.AddItem(new ListItem("Plastic Guy"));

            descriptions.AddItem(new ListItem("I-beleive-have-a-laser"));

            descriptions.AddItem(new ListItem("My-helment-is-a-fishbowl"));

            descriptions.AddItem(new ListItem("I-have-sort-of-wings"));

            descriptions.AddItem(new ListItem("To-the-infinity-and-beyond"));

            descriptions.AddItem(new ListItem("I-am-the-Andy's-second"));

            AddComponent(descriptions, 0, 0);
        }
    }

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
}
