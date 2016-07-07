using System;
using System.Collections.Generic;

namespace ProjectSolutution2._0Android.UniversalLogic
{//Storing data in a list
    public interface Data
    {
        List<Duodata<string, int>> BoxPNeighbourhood();
        List<Duodata<string, int>> TheftPMonth();
        List<Duodata<string, int>> TheftPMonthInNeighbourhood(string Neighbourhood);
        List<Duodata<string, int>> TheftPBrand();
        List<Duodata<string, int>> TheftPColour();
        List<Duodata<float, float>> BoxLocations();
    }
}
