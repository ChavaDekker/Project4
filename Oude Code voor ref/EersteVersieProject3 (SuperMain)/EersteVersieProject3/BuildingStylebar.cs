using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Npgsql;


namespace EersteVersieProject3
{
    class BuildingStylebar
    {
        public string QueryEnd;

        public BuildingStylebar(string QueryEnd)
        {
            this.QueryEnd = QueryEnd;
        }


        public int GetValue(NpgsqlCommand cmd)
        {
            int value = 0;

            cmd.CommandText = "SELECT COUNT (architectural_style) FROM monuments WHERE architectural_style != '-----' and architectural_style like " + QueryEnd; // fill in query
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    value = Int32.Parse(reader.GetString(0));
                }
            }
            return value;
        }

        public string GetName(NpgsqlCommand cmd)
        {
            string value = "";

            cmd.CommandText = "SELECT architectural_style FROM monuments WHERE architectural_style != '-----' and architectural_style like " + QueryEnd; // fill in query
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    value = reader.GetString(0);
                }
            }
            return value;
        }

    }
}
