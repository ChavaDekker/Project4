using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Npgsql;


namespace EersteVersieProject3
{
    class Architectbar
    {
        public string QueryEnd;

        public Architectbar(string QueryEnd)
        {
            this.QueryEnd = QueryEnd;
        }


        public int GetValue(NpgsqlCommand cmd)
        {
            int value = 0;

            cmd.CommandText = "SELECT COUNT (architect) FROM monuments WHERE architect != '-----' and architect like " + QueryEnd; // fill in query
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

            cmd.CommandText = "SELECT architect FROM monuments WHERE architect != '-----' and architect like " + QueryEnd; // fill in query
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

