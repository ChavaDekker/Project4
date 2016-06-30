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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectSolutution2._0Android.UniversalLogic.Scene
{
    public class Scene
    {
        Point Offset;
        string Id;

        private void ScreenOffset()
        {
            throw new Exception("Not Implemented");
        }

        public void AndroidUpdate()
        {
            ScreenOffset();
            AndroidLogic();
        }
        public void WindowsUpdate()
        {
            ScreenOffset();
            WindowsLogic();
        }
        virtual protected void AndroidLogic()
        {

        }
        virtual protected void WindowsLogic()
        {

        }
        virtual public void AndroidDraw(SpriteBatch spritebatch)
        {

        }
        virtual public void WindowsDraw(SpriteBatch spritebatch)
        {

        }
        public string ID { get { return Id; } }

        public Scene(GraphicsDevice graphDevice, string ID)
        {
            this.Id = ID;
        }
    }
}