using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteVersieProject3
{
    class BuildingStyle
    {
        public List<BuildingStylebar> Bars = new List<BuildingStylebar>();

        public BuildingStyle(List<BuildingStylebar> bars)
        {
            Bars = bars;
        }

    }
}
