using System;
using System.Collections.Generic;

namespace ProjectSolutution2._0Android.UniversalLogic
{
    public interface Data
    {
        List<Duodata<string, int>> BoxPNeighbourhood();
        List<Duodata<string, int>> TheftPMonth();
        List<Duodata<string, int>> TheftPMonthInNeighbourhood();
        List<Duodata<string, int>> TheftPBrand();
        List<Duodata<string, int>> TheftPColour();
        List<Duodata<float, float>> BoxLocations();
    }
}
