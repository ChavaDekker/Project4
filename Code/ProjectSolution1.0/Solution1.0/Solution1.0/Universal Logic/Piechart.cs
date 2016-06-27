using System;
using System.Collections.Generic;

//Marcel

public class Piechart : AbstractGraph  {
	private static ARGB[,] _Circle;

	private ARGB[,] Cut(ref object aARGB) {
		throw new System.Exception("Not implemented");
	}
	public override ARGB[,] Legenda(ref List<Duodata<string,int>> aDuodataList) {
		throw new System.Exception("Not implemented");
	}
	public override ARGB[,] Make(ref List<Duodata<string,int>> aDuodataList) {
        int sizepiechart = 500;
        ARGB[,] piechart = new ARGB[sizepiechart, sizepiechart];

        float lastAngle = 0;
        double newangle;
        float percentage;
        SimpleVector oldVec, newVec;
        oldVec = new SimpleVector();
        newVec = new SimpleVector();
        ARGB colortofill;

        int total = 0;
        foreach(Duodata<string, int> i in aDuodataList)
        {
            total += i.GetAttr2();
        }

        foreach(Duodata<string, int> i in aDuodataList)
        {
            colortofill = new ARGB(/*random values*/)
            if(i.GetAttr2() > total / 2)
            {
                throw new System.Exception("Not implemented");
            }
            else
            {
                percentage = (float)i.GetAttr2() / (float)total * 100f;
                newangle = lastAngle + 2 * Math.PI * percentage;
                newVec.x = Math.Cos(newangle);
                newVec.y = Math.Sin(newangle);
                oldVec.x = Math.Cos(lastAngle);
                oldVec.y = Math.Sin(lastAngle);
                for (int x = 0; x<sizepiechart; x++)
                {
                    for(int y = 0; y<sizepiechart; y++)
                    {
                        if(Math.Sqrt(Math.Pow(x-sizepiechart/2, 2) + Math.Pow(y-sizepiechart/2, 2)) < sizepiechart / 2)
                        {
                            if(isCounterClockwise(newVec, new SimpleVector(x,y)) && !isCounterClockwise(oldVec, new SimpleVector(x, y)))
                            {
                                piechart[x, y] = new ARGB(255, 0, 0, 0);
                            }

                            
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

    public bool isCounterClockwise(SimpleVector line, SimpleVector point)
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
