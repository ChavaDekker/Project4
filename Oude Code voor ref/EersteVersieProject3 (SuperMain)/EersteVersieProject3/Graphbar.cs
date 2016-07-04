using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Npgsql;


namespace EersteVersieProject3
{
    class ConstrYearGraphBar
    {
        public string identifier; // for example "1940 to 1950".
        public string QueryEnd;

        public ConstrYearGraphBar(string identifier, string QueryEnd)
        {
            this.identifier = identifier;
            this.QueryEnd = QueryEnd;
        }


        public int GetValue(NpgsqlCommand cmd)
        {
            int value = 0;

            cmd.CommandText = "SELECT COUNT (construction_year) FROM monuments WHERE construction_year != '-----' and construction_year like " + QueryEnd; // fill in query
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    value = Int32.Parse(reader.GetString(0));
                }
            }
            return value;
        }

    }
}
