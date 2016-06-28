using System;
using System.Collections.Generic;
public class Barchart : AbstractGraph  {
	private ARGB[,] Axis(ref List<Duodata<string,int>> aDuodataList)
    {

		throw new System.Exception("Not implemented");
	}
	public override ARGB[,] Legenda(ref List<Duodata<string,int>> aDuodataList) {
		throw new System.Exception("Not implemented");
	}
	public override ARGB[,] Make(ref List<Duodata<string,int>> aDuodataList)
    {
        int GHeight = 500;
        int GWidth = 500;
        int GIndex = aDuodataList.Count; //amount of bars
        int GBarSize = (GHeight / GIndex) - 10 * GIndex; //individual bar size (vertical)
        string GBarName; //nametag for specific bar
        int GBarAmount; //value for specific bar
        double GBarLength; //Length of bar in %

        ARGB GBarColor;
        Random rnd = new Random();
        ARGB[,] barchart = new ARGB[GHeight, GWidth];
        int total = 0;

        foreach (Duodata<string, int> i in aDuodataList)
        {
            total += i.GetAttr2();
        }

        foreach (Duodata<string, int> i in aDuodataList)
        {
            double percentage = i.GetAttr2() / total * 100;
            for (int x = 0; x < GWidth; x++)
            {
                for (int y = 0; y < GHeight; y++)
                {
                    if (x < percentage * (GWidth / 100) && (y % GHeight / GIndex <= GBarSize))
                    {
                        barchart[x, y] = new ARGB(255, 0, 0, 0);
                    }
                    else
                    {
                        ;
                    }
                }
            }
        }

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

        throw new System.Exception("Not implemented");
	}

}
