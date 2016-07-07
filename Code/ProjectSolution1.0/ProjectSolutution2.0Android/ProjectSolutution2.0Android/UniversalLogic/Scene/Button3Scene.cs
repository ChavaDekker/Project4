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
        string namedata1 = "group1";
        string namedata2 = "group2";
        Color data1color = Color.Red;
        Color data2color = Color.Blue;
        DynamicButtonHorizontal ChooseNeighbourhood;
        string chosenneighbourhood = "";
        public Button3Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            ChooseNeighbourhood = new DynamicButtonHorizontal(400, 200, 0.25, 0.75, Color.Crimson, graphDevice);
            ChooseNeighbourhood.SetText("Choose neighbourhood");
            ChooseNeighbourhood.SetDelegate(new Action(() => SceneManager.AddSceneOnStack("ChooseNeighbourhoodScene")));
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

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            if (GroupedBarchart == null)
            {
                spritebatch.End();
                Texture2D temp = GroupedBarChart.Make(data1, data2, graphDevice, spritebatch, namedata1, namedata2, data1color, data2color);
                GroupedBarchart = new Picture(temp, new Point(200), new Point(temp.Width, temp.Height));
                spritebatch.Begin();
            }
            if (Legend == null)
            {
                spritebatch.End();
                Texture2D temp = GroupedBarChart.Legend(data1, data2, graphDevice, spritebatch, namedata1, namedata2, data1color, data2color);
                Legend = new Picture(temp, new Point(200,800), new Point(temp.Width, temp.Height));
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
                SceneManager.PopSceneFromStack();
            }
        }
    }
}