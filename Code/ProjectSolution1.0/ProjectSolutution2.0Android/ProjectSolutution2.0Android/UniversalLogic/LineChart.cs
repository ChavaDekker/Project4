using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class LineChart
    {
        private static Texture2D Pixel;

        //Axes logic
        private static RenderTarget2D Axis(List<Duodata<string, int>> aDuodataList, Texture2D target, GraphicsDevice graphdevice, SpriteBatch spriteBatch, int heighestvalue)
        {
            int axisthickness = 3;
            int paddingx = 100;
            int paddingy = 200;
            int marklenght = 5;
            int textoffset = -50;
            int textoffsetxaxis = 10;
            Color backgroundColor = new Color(0, 0, 0, 0);
            drawline(new Point(0), new Point(0, target.Height), spriteBatch, axisthickness, Pixel);
            drawline(new Point(0, target.Height-axisthickness), new Point(target.Width, target.Height - axisthickness), spriteBatch, axisthickness, Pixel);
            spriteBatch.End();
            spriteBatch.Begin();
            RenderTarget2D newRenderTarget = new RenderTarget2D(graphdevice, target.Width + paddingx*2, target.Height + paddingy);
            graphdevice.SetRenderTarget(newRenderTarget);
            graphdevice.Clear(backgroundColor);
            spriteBatch.Draw(target, new Rectangle(new Point(paddingx, 0), new Point(target.Width, target.Height)), Color.White);

            for (int i = 0; i < 10; i++)
            {
                drawline(new Point(paddingx - marklenght, i*target.Height/10), new Point(paddingx, i * target.Height / 10), spriteBatch, axisthickness, Pixel);
                TextDrawing.Drawtext(new Point(paddingx + textoffset, i * target.Height / 10), (heighestvalue - heighestvalue/10*i).ToString(), spriteBatch);
            }

            for(int i = 0; i<aDuodataList.Count; i++)
            {
                drawline(new Point(paddingx + i * (target.Width / (aDuodataList.Count-1)), target.Height), new Point(paddingx + i * (target.Width / (aDuodataList.Count-1)), target.Height + marklenght), spriteBatch, axisthickness, Pixel);
                TextDrawing.Drawtext(new Point(paddingx + i * (target.Width / (aDuodataList.Count - 1)) - textoffsetxaxis, target.Height + textoffsetxaxis), ((char)(65 + i)).ToString(), spriteBatch);
            }

            return newRenderTarget;
        }

        //Legend logic
        public static Texture2D Legenda(List<Duodata<string, int>> aDuodataList, GraphicsDevice graphdevice, SpriteBatch spriteBatch)
        {
            int Lineheight = 40;
            int width = 500;
            int height = Lineheight * aDuodataList.Count;
            Color backgroundColor = new Color(0, 0, 0, 0);
            RenderTarget2D Target = new RenderTarget2D(graphdevice, width, height);
            graphdevice.SetRenderTarget(Target);
            graphdevice.Clear(backgroundColor);
            spriteBatch.Begin();
            for(int i = 0; i< aDuodataList.Count; i++)
            {
                TextDrawing.Drawtext(new Point(0, Lineheight * i), ((char)(65 + i)).ToString() + "  :  " + aDuodataList[i].GetAttr1(), spriteBatch);
            }
            spriteBatch.End();
            graphdevice.SetRenderTarget(null);
            return Target;
        }

        //
        public static Texture2D Make(List<Duodata<string, int>> aDuodataList, GraphicsDevice graphdevice, SpriteBatch spriteBatch)
        {
            int width, height;
            width = 500;
            height = 500;
            Color backgroundColor = new Color(0, 0, 0, 0);
            bool drawdots = false;
            int dotsize = 20;
            int linethickness = 5;



            Pixel = new Texture2D(graphdevice, 1, 1);
            Color[] pixel = new Color[1];
            pixel[0] = Color.White;
            Pixel.SetData<Color>(pixel);

            RenderTarget2D Rendertarget = new RenderTarget2D(graphdevice, width,height);
            graphdevice.SetRenderTarget(Rendertarget);
            graphdevice.Clear(backgroundColor);

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

            if (drawdots)
            {
                foreach (Point i in listofdatapoints)
                {
                    spriteBatch.Draw(Pixel, new Rectangle(i, new Point(dotsize)), Color.Blue);
                }
            }
            for(int i = 0; i< Elements-1; i++)
            {
                drawline(new Point(listofdatapoints[i].X, listofdatapoints[i].Y), new Point(listofdatapoints[i + 1].X, listofdatapoints[i + 1].Y), spriteBatch, linethickness, Pixel);
            }
            Rendertarget = Axis(aDuodataList, Rendertarget, graphdevice, spriteBatch, maxValue);
            spriteBatch.End();
            graphdevice.SetRenderTarget(null);
            return Rendertarget;
        }

        static public void drawline(Point start, Point end, SpriteBatch spriteBatch, int linethickness, Texture2D Pixel)
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

            for(int x = (start.X > end.X ? end.X: start.X); x <= (start.X < end.X ? end.X : start.X); x++)
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
                spriteBatch.Draw(Pixel, new Rectangle(i, new Point(linethickness)), Color.Black);
            }
        }
    }
}