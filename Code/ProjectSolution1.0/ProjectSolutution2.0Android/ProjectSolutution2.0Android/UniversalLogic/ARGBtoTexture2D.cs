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
    public static class ARGBtoTexture2D
    {
        public static Texture2D ARGBtoTexture2d(ARGB[,] Image, GraphicsDevice graphDevice)
        {
            int x, y;
            x = Image.GetLength(0);
            y = Image.GetLength(1);

            Texture2D finalImage = new Texture2D(graphDevice, x, y);
            Color[] colorarray = new Color[x * y];

            int index = 0;

            for(int yi = 0; yi<y; yi++)
            {
                for (int xi = 0; xi < y; xi++)
                {
                    colorarray[index] = new Color(Image[xi, yi]);
                    index++;
                }
            }
            finalImage.SetData<Color>(colorarray);
            return finalImage;
        }
    }
}