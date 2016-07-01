using System;
using System.Collections.Generic;
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class BarChart
    {
        private static ARGB[,] Axis(List<Duodata<string, int>> aDuodataList)
        {

            throw new System.Exception("Not implemented");
        }
        public static ARGB[,] Legenda(List<Duodata<string, int>> aDuodataList)
        {
            throw new System.Exception("Not implemented");
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
                double percentage = i.GetAttr2() / total * 100;
                for (int x = 0; x < GWidth; x++)
                {
                    for (int y = 0; y < GHeight; y++)
                    {
                        //old x logic ' percentage * GWidth / 100 '
                        if ((x < 50) && y > iteration * (GBarSize + 10) && y < ((iteration + 1) * (GBarSize + 10) - 10)) //if pixel on [x,y] falls within drawable bounds of the bar in the current iteration
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