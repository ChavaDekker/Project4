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
    public class Button2Scene : Scene
    {
        Picture LineGraph;
        List<Duodata<string, int>> testdata;
        public Button2Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            testdata = new List<Duodata<string, int>>();
            testdata.Add(new Duodata<string, int>("Lol", 10));
            testdata.Add(new Duodata<string, int>("Lol", 21));
            testdata.Add(new Duodata<string, int>("Lol", 30));
            testdata.Add(new Duodata<string, int>("Lol", 41));
            testdata.Add(new Duodata<string, int>("Lol", 50));
            testdata.Add(new Duodata<string, int>("Lol", 10));
            testdata.Add(new Duodata<string, int>("Lol", 20));
            testdata.Add(new Duodata<string, int>("Lol", 30));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            if(LineGraph == null)
            {
                spritebatch.End();
                Texture2D chart = LineChart.Make(testdata, graphDevice, spritebatch);
                LineGraph = new Picture(chart, new Point(0,200), new Point(chart.Width*2, chart.Height*2));
                spritebatch.Begin();
            }
            LineGraph.draw(spritebatch, Offset);


        }
        public override void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        protected override void AndroidLogic()
        {

        }
        protected override void WindowsLogic()
        {

        }
    }
}