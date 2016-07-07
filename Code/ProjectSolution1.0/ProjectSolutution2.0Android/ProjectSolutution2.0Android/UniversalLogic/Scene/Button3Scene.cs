using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectSolutution2._0Android.UniversalLogic.Scene
{
    public class Button3Scene : Scene
    {
        Picture GroupedBarchart;
        Picture Legend;
        List<Duodata<string, int>> data1;
        List<Duodata<string, int>> data2;
        string namedata1 = "Theft Per Month";
        string namedata2 = "Installed Boxes";
        Color data1color = Color.Red;
        Color data2color = Color.Blue;
        DynamicButtonHorizontal ChooseNeighbourhood;
        string chosenneighbourhood = "";

        //Button 3 scene
        public Button3Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            Maxnegoffset = new Point(0, -1000);

            ChooseNeighbourhood = new DynamicButtonHorizontal(800, 200, 0.5, 1, Color.Crimson, graphDevice);
            ChooseNeighbourhood.SetText("Choose neighbourhood");
            ChooseNeighbourhood.SetDelegate(new Action(() => SceneManager.AddSceneOnStack("ChooseNeighbourhoodScene")));

            List<Duodata<string, int>> temp = DataAccess.dataAccess.BoxPNeighbourhood();
            string[] neighbourhoods = new string[temp.Count];
            for(int i = 0; i<temp.Count; i++)
            {
                neighbourhoods[i] = temp[i].GetAttr1();
            }
            SceneManager.getAScene("ChooseNeighbourhoodScene").SetParaMeters(neighbourhoods);
            data1 = new List<Duodata<string, int>>();
            data2 = new List<Duodata<string, int>>();

            data1.Add(new Duodata<string, int>("een", 10));
            data1.Add(new Duodata<string, int>("twee", 21));
            data1.Add(new Duodata<string, int>("drie", 60));
            data1.Add(new Duodata<string, int>("vier", 41));
            data1.Add(new Duodata<string, int>("vijf", 50));
            data1.Add(new Duodata<string, int>("zes", 10));
            data1.Add(new Duodata<string, int>("zeven", 20));
            data1.Add(new Duodata<string, int>("acht", 30));

            data2.Add(new Duodata<string, int>("een", 50));
            data2.Add(new Duodata<string, int>("twee", 21));
            data2.Add(new Duodata<string, int>("drie", 60));
            data2.Add(new Duodata<string, int>("vier", 41));
            data2.Add(new Duodata<string, int>("vijf", 50));
            data2.Add(new Duodata<string, int>("zes", 50));
            data2.Add(new Duodata<string, int>("zeven", 20));
            data2.Add(new Duodata<string, int>("acht", 16));
        }

        //Draw Bar Chart
        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            if (GroupedBarchart == null)
            {
                spritebatch.End();
                Texture2D temp = GroupedBarChart.Make(data1, data2, graphDevice, spritebatch, namedata1, namedata2, data1color, data2color);
                GroupedBarchart = new Picture(temp, new Point(10,200), new Point(temp.Width, temp.Height));
                spritebatch.Begin();
            }
            if (Legend == null)
            {
                spritebatch.End();
                Texture2D temp = GroupedBarChart.Legend(data1, data2, graphDevice, spritebatch, namedata1, namedata2, data1color, data2color);
                Legend = new Picture(temp, new Point(10,800), new Point(temp.Width, temp.Height));
                spritebatch.Begin();
            }
            GroupedBarchart.draw(spritebatch, Offset);
            Legend.draw(spritebatch, Offset);
            ChooseNeighbourhood.Draw(spritebatch, Offset);
        }
        public override void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        protected override void AndroidLogic()
        {
            ChooseNeighbourhood.Click(Offset);
        }
        protected override void WindowsLogic()
        {

        }

        public override void SetParaMeters(params string[] args)
        {
            int index = 0;
            if(args.Length > index)
            {
                chosenneighbourhood = args[index]; //index 0
                index++;
                //SceneManager.PopSceneFromStack();
                SceneManager.ChangeScene("Button3Scene");
                data1 = DataAccess.dataAccess.TheftPMonthInNeighbourhood(chosenneighbourhood);
                data2 = DataAccess.dataAccess.BoxPNeighbourhood();
                Duodata<string, int> temp = new Duodata<string, int>("", 0);
                foreach(Duodata<string, int> i in data2)
                {
                    if(i.GetAttr1() == chosenneighbourhood)
                    {
                        temp = i;
                    }
                }
                data2 = new List<Duodata<string, int>>();
                for(int i = 0; i<data1.Count; i++)
                {
                    data2.Add(new Duodata<string, int>(data1[i].GetAttr1(), temp.GetAttr2()));
                }

                GroupedBarchart = null;
                Legend = null;

            }
        }
    }
}