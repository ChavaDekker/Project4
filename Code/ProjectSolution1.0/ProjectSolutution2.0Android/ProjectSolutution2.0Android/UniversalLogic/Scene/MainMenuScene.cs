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
    public class MainMenuScene : Scene
    {
        GenericButton genericlol1;
        GenericButton genericlol2;
        GenericButton genericlol3;
        GenericButton genericlol4;
        GenericButton genericlol5;
        GenericButton genericlol6;
        GenericButton genericlol7;
        GenericButton genericlol8;

        public MainMenuScene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            Maxnegoffset = new Point(0, -400);
            Maxposoffset = new Point(0, 0);
            genericlol1 = new GenericButton(new Point(10), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol2 = new GenericButton(new Point(10, 70), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol3 = new GenericButton(new Point(10,130), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol4 = new GenericButton(new Point(10,190), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol5 = new GenericButton(new Point(10,250), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol6 = new GenericButton(new Point(10,310), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol7 = new GenericButton(new Point(10,370), new Point(100, 50), Color.Crimson, graphDevice);
            genericlol8 = new GenericButton(new Point(10,430), new Point(100, 50), Color.Crimson, graphDevice);

            Texture2D temp = new Texture2D(graphDevice, 1, 1);
            Color[] lolz = new Color[1];
            lolz[0] = new Color(255, 0, 255, 255);
            temp.SetData<Color>(lolz);
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

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