using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Syderis.CellSDK.Core;
using Syderis.CellSDK.Core.Controls;
using System.Xml.Linq;
using System.Xml.Serialization;
using Syderis.CellSDK.Core.Storage;

namespace StorageSample
{
    class Application : MobileApplication
    {
        Button btGetNotice;

        Label lblTime;

        Label lblNotice;

        int index;

        /// <summary>
        /// The main method for loading controls and resources.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: Replace these comments with your own poetry, and enjoy!
            List<Notice> list = new List<Notice>();

            list.Add(new Notice() { Year = 1972, News = "PLATO IV: First computer with \n a touchable screen." });

            list.Add(new Notice() { Year = 1985, News = "Home Manager: First home computer \n with a touchable screen." });

            list.Add(new Notice() { Year = 1992, News = "SIMON. First smartphone." });

            list.Add(new Notice() { Year = 1999, News = "Edge: Voting machine." });

            list.Add(new Notice() { Year = 2000, News = "iPhone: Firts multitouch smartphone." });

            XDocument doc = new XDocument();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Notice>));

            System.Xml.XmlWriter writer = doc.CreateWriter();

            serializer.Serialize(writer, list);

            writer.Close();

            IsolatedStorage.SaveFile(doc, "myFile");

            btGetNotice = new Button("Get next notice");

            AddComponent(btGetNotice, 50, 600);

            btGetNotice.Released += new Component.ComponentEventHandler(btnOpenBox_Released);

            lblTime = new Label(list[0].Year.ToString());

            lblNotice = new Label(list[0].News);

            AddComponent(lblTime, 50, 100);

            AddComponent(lblNotice, 50, 200);

            index = 1;

        }

        void btnOpenBox_Released(Component source)
        {

            XDocument doc = IsolatedStorage.LoadFile("myFile");

            XmlSerializer serializer = new XmlSerializer(typeof(List<Notice>));

            List<Notice> list = serializer.Deserialize(doc.CreateReader()) as List<Notice>;

            Notice not;

            if (index < list.Count)
            {

                not = list[index];

                index++;

            }

            else
            {

                index = 0;

                not = list[index];

            }

            lblTime.Text = not.Year.ToString();

            lblNotice.Text = not.News;

        }

        public override void BackButtonPressed()
        {
            Program.Instance.Exit();
        }
    }


    public class Notice
    {

        public int Year { get; set; }

        public string News { get; set; }

    }
}
