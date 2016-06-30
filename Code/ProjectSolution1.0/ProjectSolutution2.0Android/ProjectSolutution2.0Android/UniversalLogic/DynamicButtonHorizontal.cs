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

namespace ProjectSolutution2._0Android.UniversalLogic
{
    public class DynamicButtonHorizontal : Button
    {
        int YPositionTop, height;
        Texture2D Texture;
        string Text;
        Delegates.SimpleDelegate clickFunction;
        double LeftPercentage, RightPercentage;
        Point ScreenDimentions;
        public Rectangle calculateDimentions()
        {
            Point topleft = new Point();
            Point bottomright = new Point();

            topleft.Y = YPositionTop;
            topleft.X = (int)((double)ScreenDimentions.X * LeftPercentage);
            bottomright.Y = height;
            bottomright.X = (int)((double)ScreenDimentions.X * RightPercentage - (double)ScreenDimentions.X * LeftPercentage);

            return new Rectangle(topleft, bottomright);
        }
        public void Click(Point offset)
        {
            if (isClicked(offset))
            {
                clickFunction();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            Rectangle dimentions = calculateDimentions();
            spriteBatch.Draw(Texture, new Rectangle(dimentions.X+offset.X, dimentions.Y + offset.Y, dimentions.Width, dimentions.Height), Color.White);
        }

        public bool isClicked(Point offset)
        {
            Rectangle temp = calculateDimentions();
            Point Tleft = new Point(temp.X, temp.Y) + offset;
            return InputAcces.input.DidClickInArea(Tleft, Tleft +  new Point(temp.Width, temp.Height));
        }

        public void SetDelegate(Delegates.SimpleDelegate _delegate)
        {
            clickFunction = _delegate;
        }

        public void SetPosition(Point NewPosition)
        {
            YPositionTop = NewPosition.Y;
        }

        public void SetText(string text)
        {
            Text = text;
        }
        public DynamicButtonHorizontal(int YPositionTop, int height, double leftPercentage, double rightPercentage, Color color, GraphicsDevice GraphDevice)
        {
            this.YPositionTop = YPositionTop;
            this.height = height;
            this.LeftPercentage = leftPercentage;
            this.RightPercentage = rightPercentage;
            this.ScreenDimentions = new Point(GraphDevice.Viewport.Width, GraphDevice.Viewport.Height);
            
            Color[] temparray = new Color[1];
            temparray[0] = color;
            this.Texture = new Texture2D(GraphDevice, 1,1);
            this.Texture.SetData<Color>(temparray);
        }
    }
}