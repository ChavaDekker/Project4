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
using ProjectSolutution2._0Android.AndroidLogic;

namespace ProjectSolutution2._0Android.UniversalLogic.Scene
{
    public class Button6Scene : Scene
    {
        public Button6Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            graphDevice.Clear(Color.Aquamarine);
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