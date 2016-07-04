using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Npgsql;


namespace EersteVersieProject3
{
    class ConstrYearGraph
    {
        public List<ConstrYearGraphBar> Bars = new List<ConstrYearGraphBar>();

        public ConstrYearGraph(List<ConstrYearGraphBar> bars)
        {
            Bars = bars;
        }

    }
}
