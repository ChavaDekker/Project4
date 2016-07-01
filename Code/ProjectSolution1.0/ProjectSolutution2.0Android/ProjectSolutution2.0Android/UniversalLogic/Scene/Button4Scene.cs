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
    public class Button4Scene : Scene
    {
        Picture PiechartBrands;
        public Button4Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {

            Texture2D test;
            List<Duodata<string, int>> testvalues = new List<Duodata<string, int>>();
            testvalues.Add(new Duodata<string, int>("een", 22));
            testvalues.Add(new Duodata<string, int>("twee", 33));
            testvalues.Add(new Duodata<string, int>("drie", 5));
            testvalues.Add(new Duodata<string, int>("vier", 16));
            testvalues.Add(new Duodata<string, int>("vijf", 9));
            testvalues.Add(new Duodata<string, int>("zes", 25));
            testvalues.Add(new Duodata<string, int>("zeven", 8));

            test = ARGBtoTexture2D.ARGBtoTexture2d(PieChart.Make(testvalues), graphDevice);
            PiechartBrands = new Picture(test, new Point(400), new Point(500));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            graphDevice.Clear(Color.CornflowerBlue);
            PiechartBrands.draw(spritebatch, Offset);
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