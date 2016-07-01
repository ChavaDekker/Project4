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
    public class GenericButton : Button
    {
        Point Position;
        Point WidthHeight;
        Texture2D Texture;
        string Text;
        Action clickFunction = Delegates.DoesNothing;
        public void Click(Point Offset)
        {
            if (isClicked(Offset))
            {
                clickFunction();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point offset)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position + offset, WidthHeight), Color.White);
        }

        public bool isClicked(Point offset)
        {
            return InputAcces.input.DidClickInArea(Position + offset, WidthHeight);
        }

        public void SetDelegate(Action _delegate)
        {
            clickFunction = _delegate;
        }

        public void SetPosition(Point NewPosition)
        {
            Position = NewPosition;
        }

        public void SetText(string text)
        {
            Text = text;
        }
        public GenericButton(Point Position, Point WidthHeight, Color color, GraphicsDevice GraphDevice)
        {
            this.Position = Position;
            this.WidthHeight = WidthHeight;
            Color[] temparray = new Color[WidthHeight.X * WidthHeight.Y];
            for(int i = 0; i<WidthHeight.X*WidthHeight.Y; i++)
            {
                temparray[i] = color;
            }
            this.Texture = new Texture2D(GraphDevice, WidthHeight.X, WidthHeight.Y);
            this.Texture.SetData<Color>(temparray);
        }
    }
}