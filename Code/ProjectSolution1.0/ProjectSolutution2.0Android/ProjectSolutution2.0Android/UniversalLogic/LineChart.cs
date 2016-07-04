using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class LineChart
    {
        private static Texture2D Pixel;

        private static ARGB[,] Axis(List<Duodata<string, int>> aDuodataList)
        {
            throw new System.Exception("Not implemented");
        }
        public static ARGB[,] Legenda(List<Duodata<string, int>> aDuodataList)
        {
            throw new System.Exception("Not implemented");
        }
        public static Texture2D Make(List<Duodata<string, int>> aDuodataList, GraphicsDevice graphdevice, SpriteBatch spriteBatch)
        {
            int width, height;
            width = 500;
            height = 500;


            Pixel = new Texture2D(graphdevice, 1, 1);
            Color[] pixel = new Color[1];
            pixel[0] = Color.White;
            Pixel.SetData<Color>(pixel);

            RenderTarget2D Rendertarget = new RenderTarget2D(graphdevice, width,height);
            graphdevice.SetRenderTarget(Rendertarget);
            graphdevice.Clear(Color.Red);//new Color(0, 0, 0, 0));

            int maxValue = 0;
            int Elements = aDuodataList.Count;

            foreach(Duodata<string, int> i in aDuodataList)
            {
                if (i.GetAttr2() > maxValue)
                {
                    maxValue = i.GetAttr2();
                }
            }

            List<Point> listofdatapoints = new List<Point>();

            for(int i = 0; i< Elements; i++)
            {
                listofdatapoints.Add(new Point((width / (Elements-1)) * i, height - (int)((double)height * ((double)aDuodataList[i].GetAttr2() / (double)maxValue))));
            }

            spriteBatch.Begin();
            TextDrawing.Drawtext(new Point(0), "testtext", spriteBatch);
            foreach(Point i in listofdatapoints)
            {
                spriteBatch.Draw(Pixel, new Rectangle(i, new Point(20)), Color.Blue);
            }
            for(int i = 0; i< Elements-1; i++)
            {
                drawline(new Point(listofdatapoints[i].X, listofdatapoints[i].Y), new Point(listofdatapoints[i + 1].X, listofdatapoints[i + 1].Y), spriteBatch);
            }
            spriteBatch.End();
            graphdevice.SetRenderTarget(null);
            return Rendertarget;
        }

        static private void drawline(Point start, Point end, SpriteBatch spriteBatch)
        {
            double dx, dy;
            double a, b;
            bool isinverted = false;
            List<Point> pixelsOfLine = new List<Point>();

            dx = start.X - end.X;
            dy = start.Y - end.Y;

            a = dy / dx;

            if (Math.Abs(a) > 1)
            {
                start = new Point(start.Y, start.X);
                end = new Point(end.Y, end.X);
                isinverted = true;
                a = dx / dy;
            }

            b = -(a * start.X) + start.Y;

            for(int x = start.X; x <= end.X; x++)
            {
                Point newpoint = new Point(x, (int)(a * x + b/* + 0.5*/));
                pixelsOfLine.Add(newpoint);
            }

            if (isinverted)
            {
                for (int i = 0; i < pixelsOfLine.Count; i++)
                {
                    pixelsOfLine[i] = new Point(pixelsOfLine[i].Y, pixelsOfLine[i].X);
                }
            }

            foreach(Point i in pixelsOfLine)
            {
                spriteBatch.Draw(Pixel, new Rectangle(i, new Point(5)), Color.Black);
            }
        }
    }
}