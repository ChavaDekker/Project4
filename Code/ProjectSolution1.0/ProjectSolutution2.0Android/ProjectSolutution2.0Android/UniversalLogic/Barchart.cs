using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class BarChart
    {
        private static Texture2D Pixel;
        private static RenderTarget2D Axis(List<Duodata<string, int>> aDuodataList, RenderTarget2D target, SpriteBatch spriteBatch, GraphicsDevice graphDevice, int maxvalue)
        {
            int paddingx = 100;
            int paddingy = 200;
            int linethickness = 5;
            int marklenght = 5;
            int textoffsetyaxis = 50;
            int textoffsetxaxis = 10;
            int widthofColumn = target.Width / (aDuodataList.Count * 2);
            Color backgroundColor = new Color(0, 0, 0, 0);

            RenderTarget2D NewTarget = new RenderTarget2D(graphDevice, target.Width + paddingx * 2, target.Height + paddingy * 2);

            LineChart.drawline(new Point(0), new Point(0, target.Height), spriteBatch, linethickness, Pixel);
            LineChart.drawline(new Point(0, target.Height - linethickness), new Point(target.Width, target.Height - linethickness), spriteBatch, linethickness, Pixel);

            spriteBatch.End();
            graphDevice.SetRenderTarget(NewTarget);
            graphDevice.Clear(backgroundColor);
            spriteBatch.Begin();

            spriteBatch.Draw(target, new Rectangle(new Point(paddingx, 0), new Point(target.Width, target.Height)), Color.White);


            for (int i = 0; i < 10; i++)
            {
                LineChart.drawline(new Point(paddingx - marklenght, i * target.Height / 10), new Point(paddingx, i * target.Height / 10), spriteBatch, linethickness, Pixel);
                TextDrawing.Drawtext(new Point(paddingx - textoffsetyaxis, i * target.Height / 10), (maxvalue - maxvalue / 10 * i).ToString(), spriteBatch);
            }


            for (int i = 0; i < aDuodataList.Count; i++)
            {
                LineChart.drawline(new Point((i * 2 + 1) * widthofColumn + paddingx, target.Height), new Point((i * 2 + 1) * widthofColumn + paddingx, target.Height + marklenght), spriteBatch, linethickness, Pixel);
                TextDrawing.Drawtext(new Point((i * 2 + 1) * widthofColumn + paddingx - textoffsetxaxis, target.Height + textoffsetxaxis), ((char)(65 + i)).ToString(), spriteBatch);
            }

            return NewTarget;
        }
        public static Texture2D Legend(List<Duodata<string, int>> aDuodataList, GraphicsDevice graphDevice, SpriteBatch spriteBatch)
        {
            int width = 500;
            int lineheight = 40;
            int height = lineheight * (aDuodataList.Count);
            Color BackgroundColor = new Color(0, 0, 0, 0);

            RenderTarget2D target = new RenderTarget2D(graphDevice, width, height);
            graphDevice.SetRenderTarget(target);
            graphDevice.Clear(BackgroundColor);

            spriteBatch.Begin();

            for (int i = 0; i < aDuodataList.Count; i++)
            {
                TextDrawing.Drawtext(new Point(0, lineheight * i), ((char)(65 + i)).ToString() + "  :  " + aDuodataList[i].GetAttr1(), spriteBatch);
            }
            spriteBatch.End();
            graphDevice.SetRenderTarget(null);
            return target;
        }

        public static Texture2D Make2(List<Duodata<string, int>> DuodataList, GraphicsDevice graphdevice, SpriteBatch spriteBatch)
        {
            int width = 500;
            int height = 500;
            Color backroundColor = new Color(0, 0, 0, 0);
            Color barcolor = Color.Red;

            int maxvalue = 0;
            int elements = DuodataList.Count;

            int widthofColumn = width / (elements * 2);

            foreach(Duodata<string, int> i  in DuodataList)
            {
                if(i.GetAttr2() > maxvalue)
                {
                    maxvalue = i.GetAttr2();
                }
            }


            Pixel = new Texture2D(graphdevice, 1, 1);
            Color[] pixel = new Color[1];
            pixel[0] = Color.White;
            Pixel.SetData<Color>(pixel);

            RenderTarget2D target = new RenderTarget2D(graphdevice, width, height);
            graphdevice.SetRenderTarget(target);
            graphdevice.Clear(backroundColor);
            spriteBatch.Begin();

            Duodata<string, int> temp;
            for (int i = 0; i < elements; i++)
            {
                temp = DuodataList[i];

                spriteBatch.Draw(Pixel, new Rectangle(new Point((i * 2 + 1) * widthofColumn, height - height * temp.GetAttr2() / maxvalue), new Point(widthofColumn, height * temp.GetAttr2() / maxvalue)), barcolor);
                
            }

            target = Axis(DuodataList, target, spriteBatch, graphdevice, maxvalue);


            spriteBatch.End();
            graphdevice.SetRenderTarget(null);

            return target;
        }

        public static ARGB[,] Make(List<Duodata<string, int>> aDuodataList)
        {
            int GHeight = 500;
            int GWidth = 500;
            int GIndex = aDuodataList.Count; //amount of bars
            int GBarSize = (GHeight / GIndex) - 10; //individual bar size (vertical) (previously '''' -10 * GIndex)

            Random rnd = new Random();
            ARGB[,] barchart = new ARGB[GHeight, GWidth];
            int total = 0;
            int iteration = 0;

            foreach (Duodata<string, int> i in aDuodataList)
            {
                total += i.GetAttr2();
            }

            for (int x = 0; x < GWidth; x++)
            {
                for (int y = 0; y < GWidth; y++)
                {
                    barchart[x, y] = new ARGB(0, 0, 0, 0); //draw transparent array
                }
            }

            foreach (Duodata<string, int> i in aDuodataList)
            {
                double percentage = i.GetAttr2() / total;
                for (int x = 0; x < GWidth; x++)
                {
                    for (int y = 0; y < GHeight; y++)
                    {
                        //old x logic ' x < percentage * GWidth / 100 '
                        if ((x < i.GetAttr2() * 5) && y > iteration * (GBarSize + 10) && y < ((iteration + 1) * (GBarSize + 10) - 10)) //if pixel on [x,y] falls within drawable bounds of the bar in the current iteration
                        {
                            barchart[x, y] = new ARGB(255, 0, 0, 0);
                        }
                        else if (x > 490)
                        {
                            barchart[x, y] = new ARGB(255, 50, 50, 50);
                        }
                        else
                        {
                            ;
                        }
                    }
                }
                iteration += 1; //because I'm too bad to figure out how to call the iterator count in a foreach-loop
            }
            return barchart;

            //ARGB[,] barchart = new ARGB[GHeight, GWidth];
            //int GCurrentIndex = 1;
            //int total = 0;
            //foreach (Duodata<string, int> i in aDuodataList)
            //{
            //    GBarColor = new ARGB(255, Convert.ToByte(rnd.Next(256)), Convert.ToByte(rnd.Next(256)), Convert.ToByte(rnd.Next(256)));
            //    GBarName = i.GetAttr1();
            //    GBarAmount = i.GetAttr2();
            //    total += i.GetAttr2();
            //    GCurrentIndex += 1;
            //}
            //throw new System.Exception("Not implemented");
        }

    }
}