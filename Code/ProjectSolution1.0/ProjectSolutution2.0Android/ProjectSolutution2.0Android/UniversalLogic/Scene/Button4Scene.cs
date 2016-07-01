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
        DynamicButtonHorizontal backtoMainmenu;
        public Button4Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            List<Duodata<string, int>> testdata = new List<Duodata<string, int>>();
            testdata.Add(new Duodata<string, int>("lol", 10));
            testdata.Add(new Duodata<string, int>("lol", 10));
            testdata.Add(new Duodata<string, int>("lol", 10));
            testdata.Add(new Duodata<string, int>("lol", 10));
            testdata.Add(new Duodata<string, int>("lol", 10));
            testdata.Add(new Duodata<string, int>("lol", 10));
            Texture2D testo = ARGBtoTexture2D.ARGBtoTexture2d(PieChart.Make(testdata), graphDevice);
            memes = new Picture(testo, new Point(0), new Point(500));

            backtoMainmenu = new DynamicButtonHorizontal(400, 200, 0.10, 0.10, Color.YellowGreen, graphDevice);
            backtoMainmenu.SetDelegate(new Action(() => SceneManager.ChangeScene("MainMenuScene")));
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
            backtoMainmenu.Click(Offset);
        }
        protected override void WindowsLogic()
        {

        }
    }
}