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
    public static class GroupedBarChart
    {
        private static Texture2D Pixel;
        public static Texture2D Make(List<Duodata<string, int>> DuodataList, List<Duodata<string, int>> DuodataList2, GraphicsDevice graphdevice, SpriteBatch spriteBatch, string namegroup1, string namegroup2, Color barcolor1, Color barcolor2)
        {
            int width = 800;
            int height = 500;
            Color backroundColor = new Color(0, 0, 0, 0);
            Color barlist1 = barcolor1;
            Color barlist2 = barcolor2;

            int maxvalue = 0;
            int elements = DuodataList.Count;

            int widthofColumn = width / (elements * 3);


            List<Duodata<Duodata<string, int>, Duodata<string, int>>> sameGroup = linkGroup(DuodataList, DuodataList2);

            foreach (Duodata<string, int> i in DuodataList)
            {
                if (i.GetAttr2() > maxvalue)
                {
                    maxvalue = i.GetAttr2();
                }
            }
            foreach (Duodata<string, int> j in DuodataList2)
            {
                if (j.GetAttr2() > maxvalue)
                {
                    maxvalue = j.GetAttr2();
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
            for(int i = 0; i < elements; i++)
            {
                temp = sameGroup[i].GetAttr1();

                spriteBatch.Draw(Pixel, new Rectangle(new Point((i * 3 + 1) * widthofColumn, height - height * temp.GetAttr2() / maxvalue), new Point(widthofColumn, height * temp.GetAttr2() / maxvalue)), barlist1);


                temp = sameGroup[i].GetAttr2();
                spriteBatch.Draw(Pixel, new Rectangle(new Point((i * 3 + 2) * widthofColumn, height - height * temp.GetAttr2() / maxvalue), new Point(widthofColumn, height * temp.GetAttr2() / maxvalue)), barlist2);
            }
            target = Axis(sameGroup, target, spriteBatch, graphdevice, maxvalue, namegroup1, namegroup2);

            spriteBatch.End();
            graphdevice.SetRenderTarget(null);

            return target;
        }

        private static List<Duodata<Duodata<string, int>, Duodata<string, int>>> linkGroup(List<Duodata<string, int>> list1, List<Duodata<string, int>> list2)
        {
            List<Duodata<Duodata<string, int>, Duodata<string, int>>> to_return = new List<Duodata<Duodata<string, int>, Duodata<string, int>>>();
            foreach (Duodata<string, int> i in list1)
            {
                foreach (Duodata<string, int> j in list2)
                {
                    if (i.GetAttr1() == j.GetAttr1())
                    {
                        to_return.Add(new Duodata<Duodata<string, int>, Duodata<string, int>>(i, j));
                    }
                }
            }
            return to_return;
        }

        public static Texture2D Legend(List<Duodata<string, int>> DuodataList1, List<Duodata<string, int>> DuodataList2, GraphicsDevice graphDevice, SpriteBatch spriteBatch, string name1, string name2, Color color1, Color color2)
        {
            List<Duodata<Duodata<string, int>, Duodata<string, int>>> linked = linkGroup(DuodataList1, DuodataList2);

            

            int width = 500;
            int lineheight = 40;
            int height = lineheight * (linked.Count + 4);
            Color BackgroundColor = new Color(0, 0, 0, 0);
            int colorsquaresize = 40;

            RenderTarget2D target = new RenderTarget2D(graphDevice, width, height);
            graphDevice.SetRenderTarget(target);
            graphDevice.Clear(BackgroundColor);

            spriteBatch.Begin();

            for (int i = 0; i < linked.Count; i++)
            {
                TextDrawing.Drawtext(new Point(0, lineheight * i), ((char)(65 + i)).ToString() + "  :  " + linked[i].GetAttr1().GetAttr1(), spriteBatch);
            }

            TextDrawing.Drawtext(new Point(colorsquaresize * 2, lineheight * (linked.Count + 2)), name1, spriteBatch);
            TextDrawing.Drawtext(new Point(colorsquaresize * 2, lineheight * (linked.Count + 3)), name2, spriteBatch);
            spriteBatch.Draw(Pixel, new Rectangle(new Point(0, lineheight * (linked.Count + 2)), new Point(colorsquaresize)), color1);
            spriteBatch.Draw(Pixel, new Rectangle(new Point(0, lineheight * (linked.Count + 3)), new Point(colorsquaresize)), color2);
            spriteBatch.End();
            graphDevice.SetRenderTarget(null);
            return target;
        }

        private static RenderTarget2D Axis(List<Duodata<Duodata<string, int>, Duodata<string, int>>> groupedvalues, RenderTarget2D target, SpriteBatch spriteBatch, GraphicsDevice graphDevice, int maxvalue, string namegroup1, string group2)
        {
            int paddingx = 100;
            int paddingy = 200;
            int linethickness = 5;
            int marklenght = 5;
            int textoffsetyaxis = 80;
            int textoffsetxaxis = 10;
            int widthofColumn = target.Width / (groupedvalues.Count * 3);
            Color backgroundColor =  new Color(0, 0, 0, 0);

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


            for (int i = 0; i < groupedvalues.Count; i++)
            {
                LineChart.drawline(new Point((i * 3 + 2) * widthofColumn + paddingx, target.Height), new Point((i * 3 + 2) * widthofColumn + paddingx, target.Height+marklenght), spriteBatch, linethickness, Pixel);
                TextDrawing.Drawtext(new Point((i * 3 + 2) * widthofColumn + paddingx - textoffsetxaxis, target.Height + textoffsetxaxis), ((char)(65 + i)).ToString(), spriteBatch);
            }

            return NewTarget;
        }
    }
}