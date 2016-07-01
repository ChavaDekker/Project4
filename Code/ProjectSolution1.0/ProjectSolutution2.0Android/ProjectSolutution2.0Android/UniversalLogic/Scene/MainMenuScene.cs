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
        DynamicButtonHorizontal dynamiclol1;
        DynamicButtonHorizontal dynamiclol2;
        DynamicButtonHorizontal dynamiclol3;
        DynamicButtonHorizontal dynamiclol4;
        DynamicButtonHorizontal dynamiclol5;
        DynamicButtonHorizontal dynamiclol6;
        DynamicButtonHorizontal dynamiclol7;
        DynamicButtonHorizontal dynamiclol8;

        public MainMenuScene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            Maxnegoffset = new Point(0, -1000);
            Maxposoffset = new Point(0, 0);
            dynamiclol1 = new DynamicButtonHorizontal(200, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol2 = new DynamicButtonHorizontal(410, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol3 = new DynamicButtonHorizontal(620, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol4 = new DynamicButtonHorizontal(830, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol5 = new DynamicButtonHorizontal(1040, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol6 = new DynamicButtonHorizontal(1250, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol7 = new DynamicButtonHorizontal(1460, 200, 0, 0.50, Color.Crimson, graphDevice);
            dynamiclol8 = new DynamicButtonHorizontal(1680, 200, 0, 0.50, Color.Crimson, graphDevice);

            dynamiclol1.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol2.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol3.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol4.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol5.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol6.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol7.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
            dynamiclol8.SetDelegate(new Delegates.SimpleDelegate(ExampleMoveButtons));
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            dynamiclol1.Draw(spritebatch, Offset);
            dynamiclol2.Draw(spritebatch, Offset);
            dynamiclol3.Draw(spritebatch, Offset);
            dynamiclol4.Draw(spritebatch, Offset);
            dynamiclol5.Draw(spritebatch, Offset);
            dynamiclol6.Draw(spritebatch, Offset);
            dynamiclol7.Draw(spritebatch, Offset);
            dynamiclol8.Draw(spritebatch, Offset);
        }

        public override void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }

        protected override void AndroidLogic()
        {
            dynamiclol1.Click(Offset);
            dynamiclol2.Click(Offset);
            dynamiclol3.Click(Offset);
            dynamiclol4.Click(Offset);
            dynamiclol5.Click(Offset);
            dynamiclol6.Click(Offset);
            dynamiclol7.Click(Offset);
            dynamiclol8.Click(Offset);
        }

        protected override void WindowsLogic()
        {

        }
        public void ExampleMoveButtons()
        {
            SceneManager.ChangeScene(ID);
        }
    }
}