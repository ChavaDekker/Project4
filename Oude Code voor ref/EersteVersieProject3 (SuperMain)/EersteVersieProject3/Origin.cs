using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteVersieProject3
{
    class Origin
    {
        public List<Originbar> Bars = new List<Originbar>();

        public Origin(List<Originbar> bars)
        {
            Bars = bars;
        }

    }
}
