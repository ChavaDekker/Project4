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
    public class Button1Scene : Scene
    {
        Picture Graph;
        Picture Legend;
        //GenericButton testo;
        //DynamicButtonHorizontal backtoMainmenu;
        List<Duodata<string, int>> data;
        public Button1Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            data = DataAccess.dataAccess.BoxPNeighbourhood();

            Duodata<string, int> one, two, three, four, five;
            one = new Duodata<string, int>("", -1);
            two = new Duodata<string, int>("", -1);
            three = new Duodata<string, int>("", -1);
            four = new Duodata<string, int>("", -1);
            five = new Duodata<string, int>("", -1);

            foreach (Duodata<string, int> i in data)
            {
                if (i.GetAttr2() > one.GetAttr2())
                {
                    one = i;
                }
            }

            foreach (Duodata<string, int> i in data)
            {
                if (i.GetAttr2() > two.GetAttr2())
                {
                    if (i != one)
                    {
                        two = i;
                    }
                }
            }
            foreach (Duodata<string, int> i in data)
            {
                if (i.GetAttr2() > three.GetAttr2())
                {
                    if (i != one && i != two)
                    {
                        three = i;
                    }
                }
            }
            foreach (Duodata<string, int> i in data)
            {
                if (i.GetAttr2() > four.GetAttr2())
                {
                    if (i != one && i != two && i != three)
                    {
                        four = i;
                    }
                }
            }
            foreach (Duodata<string, int> i in data)
            {
                if (i.GetAttr2() > five.GetAttr2())
                {
                    if (i != one && i != two && i != three && i != four)
                    {
                        five = i;
                    }
                }
            }
            data = new List<Duodata<string, int>>();
            data.Add(one);
            data.Add(two);
            data.Add(three);
            data.Add(four);
            data.Add(five);





            //data.Add(new Duodata<string, int>("lol", 10));
            //data.Add(new Duodata<string, int>("lol", 33));
            //data.Add(new Duodata<string, int>("lol", 10));
            //data.Add(new Duodata<string, int>("lol", 10));
            //Texture2D temp = ARGBtoTexture2D.ARGBtoTexture2d(BarChart.Make(testdata), graphDevice);
            //meme = new Picture(temp, new Point(0), new Point(temp.Width, temp.Height));

            //testo = new GenericButton(new Point(0), new Point(10), Color.Azure, graphDevice);
            //backtoMainmenu = new DynamicButtonHorizontal(1000, 200, 0.10, 0.90, Color.YellowGreen, graphDevice);
            //backtoMainmenu.SetDelegate(new Action(() => SceneManager.ChangeScene("MainMenuScene")));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            if(Legend == null)
            {
                spritebatch.End();
                Texture2D temp = BarChart.Legend(data, graphDevice, spritebatch);
                Legend = new Picture(temp, new Point(800, 0), new Point(temp.Width, temp.Height));
                spritebatch.Begin();
            }
            if(Graph == null)
            {
                spritebatch.End();
                Texture2D temp = BarChart.Make2(data, graphDevice, spritebatch);
                Graph = new Picture(temp, new Point(300, 0), new Point(temp.Width, temp.Height));
                spritebatch.Begin();
            }
            Graph.draw(spritebatch, Offset);
            Legend.draw(spritebatch, Offset);
            //testo.Draw(spritebatch, Offset);
            //backtoMainmenu.Draw(spritebatch, Offset);
        }
        public override void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        protected override void AndroidLogic()
        {
            //backtoMainmenu.Click(Offset);
        }
        protected override void WindowsLogic()
        {

        }
    }
}