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
        List<Duodata<string, int>> Data = new List<Duodata<string, int>>();
        public Button4Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            
            Data.Add(new Duodata<string, int>("Vijfentwintig", 25));
            Data.Add(new Duodata<string, int>("Zes", 6));
            Data.Add(new Duodata<string, int>("Vijftien", 15));
            Data.Add(new Duodata<string, int>("Twintig", 20));
            Data.Add(new Duodata<string, int>("Vijftig", 50));
            Texture2D testo = ARGBtoTexture2D.ARGBtoTexture2d(PieChart.Make(Data), graphDevice);
            memes = new Picture(testo, new Point(0), new Point(500));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            memes.draw(spritebatch, Offset);
            PieChart.DrawLegenda(Data, new Point(500) + Offset, graphDevice, spritebatch);
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