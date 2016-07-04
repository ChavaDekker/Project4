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

            for (int i = 0; i < 50; i++)
            {
                listofcolorstouse.Add(new ARGB(255, (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255), (Byte)RNG.Next(0, 255))); //random colours to be generated upon starting of program. Consisten for use in legend and piechart.
            }
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

        private static double CalculateAngle(int x, int y, int sizepiechart)
        {
            //double sinangle, cosangle, othersinangle, othercosangle, 
            double atan2angle;
            double scalefactor, normalizedx, normalizedy;

            x -= sizepiechart / 2;
            y -= sizepiechart / 2;

            scalefactor = 1 / Math.Sqrt(x * x + y * y);
            normalizedx = (double)x * scalefactor;
            normalizedy = (double)y * scalefactor;

            atan2angle = Math.Atan2(normalizedy, normalizedx);

            while (atan2angle < 0)
            {
                atan2angle += 2 * Math.PI;
            }

            return atan2angle;

            //cosangle = Math.Acos(normalizedx);
            //sinangle = Math.Asin(normalizedy);

            //while (sinangle < 0)
            //{
            //    sinangle += 2 * Math.PI;
            //}
            //while (cosangle < 0)
            //{
            //    cosangle += 2 * Math.PI;
            //}

            //othercosangle = Math.PI - cosangle;
            //othersinangle = -sinangle;

            //while (othercosangle < 0)
            //{
            //    othercosangle += 2 * Math.PI;
            //}
            //while (othersinangle < 0)
            //{
            //    othersinangle += 2 * Math.PI;
            //}

            //if (sinangle == cosangle)
            //{
            //    return sinangle;
            //}
            //if (othersinangle == cosangle)
            //{
            //    return othersinangle;
            //}
            //if (sinangle == othercosangle)
            //{
            //    return sinangle;
            //}
            //else
            //{
            //    return othercosangle;
            //}

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