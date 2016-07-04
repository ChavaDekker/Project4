using System;
using System.Collections.Generic;

namespace Solution1._0.Universal_Logic
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
