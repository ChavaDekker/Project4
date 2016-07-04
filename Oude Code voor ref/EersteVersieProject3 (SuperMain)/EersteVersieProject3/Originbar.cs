using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Npgsql;

namespace EersteVersieProject3
{
    class Originbar
    {
        public string QueryEnd;

        public Originbar(string QueryEnd)
        {
            this.QueryEnd = QueryEnd;
        }



        public int GetValue(NpgsqlCommand cmd)
        {
            int value = 0;

            cmd.CommandText = "SELECT COUNT (original_usage) FROM monuments WHERE original_usage != '-----' and original_usage like " + QueryEnd; // fill in query
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

            cmd.CommandText = "SELECT original_usage FROM monuments WHERE original_usage != '-----' and original_usage like " + QueryEnd; // fill in query
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
