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
        protected Point Offset;
        private string Id;
        private Point MaxPosOffset = new Point(0);
        private Point MaxNegOffset = new Point(0);
        Color backgroundColor = Color.CornflowerBlue;

        private void ScreenOffset()
        {
            Offset += InputAcces.input.GetDeltaSwipe();
            if (Offset.X < MaxNegOffset.X)
            {
                Offset.X = MaxNegOffset.X;
            }
            if (Offset.Y < MaxNegOffset.Y)
            {
                Offset.Y = MaxNegOffset.Y;
            }
            if (Offset.X > MaxPosOffset.X)
            {
                Offset.X = MaxPosOffset.X;
            }
            if (Offset.Y > MaxPosOffset.Y)
            {
                Offset.Y = MaxPosOffset.Y;
            }
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
        public void AndroidDrawBase(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            graphDevice.Clear(backgroundColor);
            AndroidDraw(spritebatch, graphDevice);
        }
        public void WindowsDrawBase(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            graphDevice.Clear(backgroundColor);
            WindowsDraw(spritebatch, graphDevice);
        }
        virtual public void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        virtual public void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        public string ID { get { return Id; } }

        public Scene(GraphicsDevice graphDevice, string ID)
        {
            this.Id = ID;
        }

        public Point Maxnegoffset { get { return MaxNegOffset; } set { MaxNegOffset = value; } }
        public Point Maxposoffset { get { return MaxPosOffset; } set { MaxPosOffset = value; } }
        public Color Background { get { return backgroundColor; }set { backgroundColor = value; } }
    }
}