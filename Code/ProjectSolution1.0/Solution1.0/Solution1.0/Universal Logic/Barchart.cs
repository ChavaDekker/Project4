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
        throw new System.Exception("Not implemented");
	}

}
