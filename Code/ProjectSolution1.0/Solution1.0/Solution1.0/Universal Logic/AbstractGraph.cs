using System;
using System.Collections.Generic;
public abstract class AbstractGraph {
	public abstract ARGB[] Make(ref List<Duodata<string,int>> aDuodataList);
	public abstract ARGB[] Legenda(ref List<Duodata<string,int>> aDuodataList);

}
