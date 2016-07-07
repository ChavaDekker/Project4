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
        DynamicButtonHorizontal dynamichome;

        public virtual void SetParaMeters(params string[] args)
        {
            //Could make this a visitor pattern instead? Is it already a visitor pattern?
        }

        //keeps offset within bounds
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
            dynamichome.Click(Offset);
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
            dynamichome.Draw(spritebatch, Offset);
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
            
            dynamichome = new DynamicButtonHorizontal(0, 150, 0, 0.25, Color.Crimson, graphDevice);
            dynamichome.SetDelegate(new Action(() => SceneManager.ChangeScene("MainMenuScene")));
            dynamichome.SetText("Main Menu");
        }

        public Point Maxnegoffset { get { return MaxNegOffset; } set { MaxNegOffset = value; } }
        public Point Maxposoffset { get { return MaxPosOffset; } set { MaxPosOffset = value; } }
        public Color Background { get { return backgroundColor; }set { backgroundColor = value; } }
    }
}