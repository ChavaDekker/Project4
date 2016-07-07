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
        Picture Legend;
        List<Duodata<string, int>> Dataa;
        public Button2Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            try
            {
                Dataa = DataAccess.dataAccess.TheftPMonth();
                int index = -1;
                for(int i = 0; i<Dataa.Count; i++)
                {
                    if(Dataa[i].GetAttr1() == "")
                    {
                        index = i;
                    }
                }
                if (index >= 0)
                {
                    Dataa.RemoveAt(index);
                }
            }
            catch(Exception e)
            {
                SceneManager.getAScene("TestScene").SetParaMeters(e.GetType().ToString() + "\n");
                SceneManager.getAScene("TestScene").SetParaMeters(e.Message + "\n");
                SceneManager.getAScene("TestScene").SetParaMeters(e.StackTrace + "\n");
            }
            //SceneManager.getAScene("TestScene").SetParaMeters(Dataa.Count.ToString());
            //Dataa.Add(new Duodata<string, int>("een", 10));
            //Dataa.Add(new Duodata<string, int>("twee", 21));
            //Dataa.Add(new Duodata<string, int>("drie", 60));
            //Dataa.Add(new Duodata<string, int>("vier", 41));
            //Dataa.Add(new Duodata<string, int>("vijf", 50));
            //Dataa.Add(new Duodata<string, int>("zes", 10));
            //Dataa.Add(new Duodata<string, int>("zeven", 20));
            //Dataa.Add(new Duodata<string, int>("acht", 30));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            if(LineGraph == null)
            {
                spritebatch.End();
                Texture2D chart = LineChart.Make(Dataa, graphDevice, spritebatch);
                LineGraph = new Picture(chart, new Point(200), new Point(chart.Width, chart.Height));
                spritebatch.Begin();
            }
            if(Legend == null)
            {
                spritebatch.End();
                Texture2D legenda = LineChart.Legenda(Dataa, graphDevice, spritebatch);
                Legend = new Picture(legenda, new Point(0,200), new Point(legenda.Width, legenda.Height));
                spritebatch.Begin();
            }
            LineGraph.draw(spritebatch, Offset);
            Legend.draw(spritebatch, Offset);


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