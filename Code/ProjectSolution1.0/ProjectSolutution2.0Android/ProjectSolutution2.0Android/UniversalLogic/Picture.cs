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

namespace ProjectSolutution2._0Android.UniversalLogic
{
    public class Picture
    {
        private Texture2D Texture;
        private Point Position;
        private Point WidthHeight;

        public void draw(SpriteBatch spriteBatch, Point offset)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position + offset, WidthHeight), Color.White);
        }
        public Picture(Texture2D texture, Point position, Point widthHeight)
        {
            Texture = texture;
            Position = position;
            WidthHeight = widthHeight;
        }
    }
}