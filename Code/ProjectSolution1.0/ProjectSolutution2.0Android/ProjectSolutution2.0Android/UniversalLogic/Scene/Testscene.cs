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
    public class Testscene : Scene
    {
        GenericButton genericlol;
        DynamicButtonHorizontal dynamiclol;
        DynamicButtonHorizontal dynamiclol2;
        Picture memes;
        public Testscene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            Maxnegoffset = new Point(0, -400);
            Maxposoffset = new Point(0, 0);
            genericlol = new GenericButton(new Point(10), new Point(100, 50), Color.Aquamarine, graphDevice);
            dynamiclol = new DynamicButtonHorizontal(200, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol2 = new DynamicButtonHorizontal(400, 200, 0.5, 1, Color.DarkOliveGreen, graphDevice);

            Texture2D temp = new Texture2D(graphDevice, 1, 1);
            Color[] lolz = new Color[1];
            lolz[0] = new Color(255, 0, 255, 255);
            temp.SetData<Color>(lolz);

            memes = new Picture(temp, new Point(300, 500), new Point(300));

            dynamiclol.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol2.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            genericlol.Draw(spritebatch, Offset);
            dynamiclol.Draw(spritebatch, Offset);
            dynamiclol2.Draw(spritebatch, Offset);
            memes.draw(spritebatch, Offset);
        }
        public override void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        protected override void AndroidLogic()
        {
            dynamiclol.Click(Offset);
            dynamiclol2.Click(Offset);
        }
        protected override void WindowsLogic()
        {

        }

        public void ExampleMoveButtons()
        {
            SceneManager.ChangeScene("Button1Scene");
        }
    }
}