/*
 * Copyright 2012 Syderis Technologies S.L. All rights reserved.
 * Use is subject to license terms.
 */

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Syderis.CellSDK.Core.Controls;
using Syderis.CellSDK.Core.Interfaces;
using Syderis.CellSDK.Core.Layouts; 
#endregion

namespace ComboBox
{
    class ComboBox: Container<CoordLayout>
    {
        private ListBox itemList;
        private Label actualItem;
        private DateTime timeoff;
        private bool countWatchDog;
        private TimeSpan watchDog;

        public ComboBox()
            : base(new CoordLayout())
        {  
            itemList = new ListBox(200, 200,ListBox.Orientation.VERTICAL);
            itemList.Visible = false;
            
            actualItem = new Label("");
            actualItem.Size=new Vector2(200,40);

            actualItem.Pressed += new ComponentEventHandler(actualItem_Pressed);
            actualItem.Released += new ComponentEventHandler(actualItem_Released);

            Layout.AddComponent(itemList, 0, 0);
            Layout.AddComponent(actualItem,0,0);
            
            this.Size = actualItem.Size;

            this.BackgroundColor = Color.Transparent;

            //itemList.AddItem(new Item(this,""));
        }

        #region Events
        public void actualItem_Released(Component source)
        {
            countWatchDog = false;
        }

        public void actualItem_Pressed(Component source)
        {
            watchDog = TimeSpan.Zero;
            countWatchDog = true;
        }

        public void itemAux_Released(Component source)
        {
            SelectElement(((Label)source).Text);
        } 
        #endregion

        public void AddItem(string element)
        {
            Item itemAux = new Item(element);
            itemAux.Released -= itemAux_Released;
            itemAux.Released += new ComponentEventHandler(itemAux_Released);
            itemList.AddItem(itemAux);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (countWatchDog)
            {
                watchDog += gameTime.ElapsedGameTime;
                if (watchDog > TimeSpan.FromSeconds(1))
                {
                    actualItem.Visible = false;
                    itemList.Visible = true;
                    this.Size = itemList.Size;
                    SendToFront(itemList);
                    countWatchDog = false;
                }
            }
        }

        internal void SelectElement(string text)
        {
            actualItem.Text = text;
            itemList.Visible = false;
            actualItem.Visible = true;
            actualItem.Size = new Vector2(200, 40);
            this.Size = actualItem.Size;

            SendToFront(actualItem);
        }
    }

    internal class Item:Label, IListBoxObject
    {
        public Item( string text): base(text)
        {
        }

        #region IListBoxObject Members

        public Component CellRenderer()
        {
            return this;
        }

        #endregion
    }
}
