using System;
using System.Collections.Generic;

public interface Data {
	List<Duodata<string,int>> Boxbuurt();
	List<Duodata<string,int>> DiefstalPmaand();
	List<Duodata<string,int>> DiefstalPbuurt();
	List<Duodata<string,int>> DiefstalPmerk();
	List<Duodata<string,int>> DiefstalPkleur();
	List<Duodata<float, float>> BoxLoc();

}
