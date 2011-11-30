using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using Microsoft.Xna.Framework;

namespace Skins
{
    public class Application : MobileApplication
    {
        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            Button button = new Button("Button");
          
            ToggleButton toggleButton = new ToggleButton("Toggle");
            toggleButton.Scalable = true;
            toggleButton.Rotable = true;
            toggleButton.Draggable = true;

            Label label = new Label("Label");

            CheckBox checkbox1 = new CheckBox();
            CheckBox checkbox2 = new CheckBox();
            CheckBox checkbox3 = new CheckBox();

            RadioButton radioButton1 = new RadioButton();
            RadioButton radioButton2 = new RadioButton();
            RadioButton radioButton3 = new RadioButton();

            RadioButtonGroup group = new RadioButtonGroup();
            group.Add(radioButton1);
            group.Add(radioButton2);
            group.Add(radioButton3);

            ProgressBar progressBar = new ProgressBar();
            progressBar.Value = 50;
            
            
            Slider slider = new Slider();

            string[] array = new string[] { "Listbox1", "Listbox2", "Listbox3", "Listbox4", "Listbox5", 
                                            "Listbox6", "Listbox7", "Listbox8", "Listbox9", "Listbox10" };
            ListBox listbox = new ListBox(array, 460, 200, ListBox.Orientation.VERTICAL);

           
            TextArea text = new TextArea("Text", 1, 10);
            ////Buttons & Toggle
            AddComponent(button, 10, 10);
            AddComponent(toggleButton, 100, 10);

            ////Label
            AddComponent(label, 10, 80);

            ////Checkbox
            AddComponent(checkbox1, 300, 10);
            AddComponent(checkbox2, 300, 50);
            AddComponent(checkbox3, 300, 90);

            ////RadioButton
            AddComponent(radioButton1, 350, 10);
            AddComponent(radioButton2, 350, 50);
            AddComponent(radioButton3, 350, 90);

            //ProgressBar
            AddComponent(progressBar, 10, 150);

            //Slider
            AddComponent(slider, 10, 200);

            //ListBox
            AddComponent(listbox, 10, 250);           

            AddComponent(text, 10, 500);
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        public override void BackButtonPressed()
        {
            base.BackButtonPressed();

            Program.Instance.Exit();
        }
    }
}
