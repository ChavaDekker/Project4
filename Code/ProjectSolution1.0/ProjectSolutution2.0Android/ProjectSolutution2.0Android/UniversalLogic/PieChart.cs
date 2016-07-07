using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//Marcel
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class PieChart
    {
        public static List<ARGB> ListOfColorsToUse = createColorList();

        //define list of colors
        public static List<ARGB> createColorList()
        {
            Random RNG = new Random();
            List<ARGB> listofcolorstouse = new List<ARGB>();
            listofcolorstouse.Add(new ARGB(255, 255, 0, 0));//red
            listofcolorstouse.Add(new ARGB(255, 0, 255, 0));//green
            listofcolorstouse.Add(new ARGB(255, 0, 0, 255));//blue

            listofcolorstouse.Add(new ARGB(255, 255, 255, 0));//yellow
            listofcolorstouse.Add(new ARGB(255, 255, 0, 255));//purple
            listofcolorstouse.Add(new ARGB(255, 0, 255, 255));//cyan

            for (int i = 0; i < 1000; i++)
            {
                listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255))); //random colours to be generated upon starting of program. Consisten for use in legend and piechart.
            }
            return listofcolorstouse;
        }


        //draw legend
        public static void DrawLegenda(List<Duodata<string, int>> aDuodataList, Point position, GraphicsDevice graphDevice, SpriteBatch spritebatch)
        {
            int sizeSqaures = 30;
            int spacing = 50;

            Texture2D Pixel = new Texture2D(graphDevice, 1, 1);
            Color[] temp2 = new Color[1];
            temp2[0] = Color.White;
            Pixel.SetData<Color>(temp2);
            Color todrawin;
            ARGB coloroo;
            for(int i = 0; i<aDuodataList.Count; i++)
            {
                coloroo = ListOfColorsToUse[i];
                todrawin = new Color((float)coloroo.r, (float)coloroo.g, (float)coloroo.b);
                spritebatch.Draw(Pixel, new Rectangle(position + new Point(0, i * 2 * sizeSqaures), new Point(sizeSqaures)), todrawin);
                TextDrawing.Drawtext(position + new Point(spacing, i * 2 * sizeSqaures), aDuodataList[i].GetAttr1(), spritebatch);
            }
        }

        //draw pie slice
        public static ARGB[,] DrawSlice(ARGB[,] Target, double startangle, double angletodraw, ARGB color)
        {
            int sizepiechart = Target.GetLength(0);
            SimpleVector oldVec, newVec;
            oldVec = new SimpleVector();
            newVec = new SimpleVector();
            newVec.x = Math.Cos(angletodraw);
            newVec.y = Math.Sin(angletodraw);
            oldVec.x = Math.Cos(startangle);
            oldVec.y = Math.Sin(startangle);
            SimpleVector point;
            for (int x = 0; x < sizepiechart; x++)
            {
                for (int y = 0; y < sizepiechart; y++)
                {
                    if (Math.Sqrt(Math.Pow(x - sizepiechart / 2, 2) + Math.Pow(y - sizepiechart / 2, 2)) < sizepiechart / 2)
                    {
                        point = new SimpleVector(x - sizepiechart / 2, y - sizepiechart / 2);
                        if (isCounterClockwise(newVec, point) && !isCounterClockwise(oldVec, point))
                        {
                            Target[x, y] = color;
                        }
                    }
                }
            }
            return Target;
        }

        //draw pie chart
        public static ARGB[,] Make(List<Duodata<string, int>> aDuodataList)
        {
            int sizepiechart = 500;
            ARGB[,] piechart = new ARGB[sizepiechart, sizepiechart];

            double lastAngle = 0;
            double newangle;
            double percentage;
            ARGB colortofill;



            for (int x = 0; x < sizepiechart; x++)
            {
                for (int y = 0; y < sizepiechart; y++)
                {
                    piechart[x, y] = new ARGB(0, 0, 0, 0);
                }
            }

            int total = 0;
            foreach (Duodata<string, int> i in aDuodataList)
            {
                total += i.GetAttr2();
            }

            for (int j = 0; j < aDuodataList.Count; j++)
            {
                Duodata<string, int> i = aDuodataList[j];

                colortofill = ListOfColorsToUse[j];
                if (i.GetAttr2() > total / 2)
                {

                    percentage = (double)i.GetAttr2() / (double)total/2;
                    newangle = lastAngle + 2 * Math.PI * percentage;
                    piechart = DrawSlice(piechart, lastAngle, newangle, colortofill);
                    lastAngle = newangle;


                    percentage = (double)i.GetAttr2() / (double)total/2;
                    newangle = lastAngle + 2 * Math.PI * percentage;
                    piechart = DrawSlice(piechart, lastAngle, newangle, colortofill);
                    lastAngle = newangle;
                }
                else
                {
                    percentage = (double)i.GetAttr2() / (double)total;
                    newangle = lastAngle + 2 * Math.PI * percentage;
                    piechart = DrawSlice(piechart, lastAngle, newangle, colortofill);
                    lastAngle = newangle;
                }
            }

            return piechart;
        }
        

        public static bool isCounterClockwise(SimpleVector line, SimpleVector point)
        {
            SimpleVector normal = new SimpleVector(-line.y, line.x);
            double projection = point.x * line.x + point.y * line.y;
            if (projection >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class SimpleVector
    {
        /// <summary>
        /// Used in calculations. Chose to make my own to enable cross platform calculations.
        /// </summary>
        public double x, y;
        public SimpleVector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public SimpleVector()
        {
            this.x = 0;
            this.y = 0;
        }
    }
}