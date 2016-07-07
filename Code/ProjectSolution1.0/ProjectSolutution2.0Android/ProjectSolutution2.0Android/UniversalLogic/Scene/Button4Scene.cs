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
        Picture graph1;
        Picture graph2;
        Picture directiontest;
        List<Duodata<string, int>> Data1 = new List<Duodata<string, int>>();
        List<Duodata<string, int>> Data2 = new List<Duodata<string, int>>();

        //button 4 scene
        public Button4Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            Data1 = DataAccess.dataAccess.TheftPBrand();
            Data2 = DataAccess.dataAccess.TheftPColour();
            Texture2D testo = ARGBtoTexture2D.ARGBtoTexture2d(PieChart.Make(Data1), graphDevice);
            graph1 = new Picture(testo, new Point(0), new Point(500));
            testo = ARGBtoTexture2D.ARGBtoTexture2d(PieChart.Make(Data2), graphDevice);
            graph2 = new Picture(testo, new Point(500,0), new Point(500));
        }

        //Pie chart
        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            graph1.draw(spritebatch, Offset);
            PieChart.DrawLegenda(Data1, new Point(0,500) + Offset, graphDevice, spritebatch);
            graph2.draw(spritebatch, Offset);
            PieChart.DrawLegenda(Data2, new Point(500) + Offset, graphDevice, spritebatch);
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