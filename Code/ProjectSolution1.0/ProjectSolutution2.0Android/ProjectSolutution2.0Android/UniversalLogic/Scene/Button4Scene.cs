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
        Picture memes;
        Picture directiontest;
        public Button4Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            List<Duodata<string, int>> testdata = new List<Duodata<string, int>>();
            testdata.Add(new Duodata<string, int>("lol", 25));
            testdata.Add(new Duodata<string, int>("lol", 6));
            testdata.Add(new Duodata<string, int>("lol", 15));
            testdata.Add(new Duodata<string, int>("lol", 20));
            testdata.Add(new Duodata<string, int>("lol", 50));
            Texture2D testo = ARGBtoTexture2D.ARGBtoTexture2d(PieChart.Make(testdata), graphDevice);
            memes = new Picture(testo, new Point(0), new Point(500));
            

        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            memes.draw(spritebatch, Offset);
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