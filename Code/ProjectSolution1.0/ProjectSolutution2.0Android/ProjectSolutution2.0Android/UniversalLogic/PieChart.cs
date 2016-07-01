using System;
using System.Collections.Generic;

//Marcel
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class PieChart
    {
        public static List<ARGB> ListOfColorsToUse = createColorList();

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

            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255))); //random colours to be generated upon starting of program. Consisten for use in legend and piechart.
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));
            listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255)));

            return listofcolorstouse;
        }

        public static ARGB[,] Legenda(List<Duodata<string, int>> aDuodataList)
        {
            throw new System.Exception("Not implemented");
        }

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
            for (int x = 0; x < sizepiechart; x++)
            {
                for (int y = 0; y < sizepiechart; y++)
                {
                    if (Math.Sqrt(Math.Pow(x - sizepiechart / 2, 2) + Math.Pow(y - sizepiechart / 2, 2)) < sizepiechart / 2)
                    {
                        if (isCounterClockwise(newVec, new SimpleVector(x, y)) && !isCounterClockwise(oldVec, new SimpleVector(x, y)))
                        {
                            Target[x, y] = color;
                        }
                    }
                }
            }
            return Target;
        }

        public static ARGB[,] Make(List<Duodata<string, int>> aDuodataList)
        {
            int sizepiechart = 500;
            ARGB[,] piechart = new ARGB[sizepiechart, sizepiechart];
            
            double lastAngle = 0;
            double newangle;
            double percentage;
            ARGB colortofill;



            for (int x = 0; x<sizepiechart; x++)
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

            for(int j=0; j<aDuodataList.Count; j++)
            {
                Duodata<string, int> i = aDuodataList[j];

                colortofill = ListOfColorsToUse[j];
                if (i.GetAttr2() > total / 2)
                {

                    percentage = (double)i.GetAttr2() / (double)total * 100 / 2;
                    newangle = lastAngle + 2 * Math.PI * percentage;
                    piechart = DrawSlice(piechart, lastAngle, newangle, colortofill);
                    lastAngle = newangle;


                    percentage = (double)i.GetAttr2() / (double)total * 100 / 2;
                    newangle = lastAngle + 2 * Math.PI * percentage;
                    piechart = DrawSlice(piechart, lastAngle, newangle, colortofill);
                    lastAngle = newangle;
                }
                else
                {
                    percentage = (double)i.GetAttr2() / (double)total * 100;
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