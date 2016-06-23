using System;
using System.Collections.Generic;

//Marcel

public class Piechart : AbstractGraph  {
	private static ARGB[] _Circle;

	private ARGB[] Cut(ref object aARGB) {
		throw new System.Exception("Not implemented");
	}
	public override ARGB[] Legenda(ref List<Duodata<string,int>> aDuodataList) {
		throw new System.Exception("Not implemented");
	}
	public override ARGB[] Make(ref List<Duodata<string,int>> aDuodataList) {
        int sizepiechart = 500;
        ARGB[,] piechart = new ARGB[sizepiechart, sizepiechart];

        float lastAngle = 0;

        int total = 0;
        foreach(Duodata<string, int> i in aDuodataList)
        {
            total += i.GetAttr2();
        }

        foreach(Duodata<string, int> i in aDuodataList)
        {
            if(i.GetAttr2() > total / 2)
            {
                throw new System.Exception("Not implemented");
            }
            else
            {
                for(int x = 0; x<sizepiechart; x++)
                {
                    for(int y = 0; y<sizepiechart; y++)
                    {
                        if(Math.Sqrt(Math.Pow(x-sizepiechart/2, 2) + Math.Pow(y-sizepiechart/2, 2)) < sizepiechart / 2)
                        {

                        }
                        else
                        {
                            piechart[x, y] = new ARGB(0, 0, 0, 0);
                        }
                    }
                }
            }
        }


		throw new System.Exception("Not implemented");
	}

}
