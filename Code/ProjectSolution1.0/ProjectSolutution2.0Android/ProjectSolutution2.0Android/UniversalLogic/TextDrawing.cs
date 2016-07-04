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
using Microsoft.Xna.Framework.Content;

namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class TextDrawing
    {
        public static SpriteFont Arial25;

        public static void LoadSpriteFonts(ContentManager content)
        {
            Arial25 = content.Load<SpriteFont>("Textfile");
        }

        public static void Drawtext(Point position, string text, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Arial25, text, position.ToVector2(), Color.White);
        }
    }
}