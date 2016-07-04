using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Npgsql;


namespace EersteVersieProject3
{
    class MonumentenMaker
    {
        NpgsqlCommand cmd;
        Textures All_textures;

        List<Monument> Monumentenlijst = new List<Monument>();

        int ID_place; // place = place in table (the how much'th column)
        int name_place;
        int constr_yr_place;
        int original_usage_place;
        int architect_place;
        int building_style_place;
        int streetname_place;
        int longitude_place;
        int latitude_place;

        public MonumentenMaker(NpgsqlCommand cmd, int ID_place, int name_place, int constr_yr_place, int original_usage_place, int architect_place, int building_style_place, int streetname_place, int longitude_place, int latitude_place, Textures All_textures)
        {
            this.cmd = cmd;

            this.ID_place = ID_place;
            this.name_place = name_place;
            this.constr_yr_place = constr_yr_place;
            this.original_usage_place = original_usage_place;
            this.architect_place = architect_place;
            this.building_style_place = building_style_place;
            this.streetname_place = streetname_place;
            this.longitude_place = longitude_place;
            this.latitude_place = latitude_place;

            this.All_textures = All_textures;
        }

        // 1. Checks in database if monuments are on our map
        // 2. Gets attributes of those monuments from database
        // 3. Creates instances of class Monument with those attributes
        // 4. Adds those instances to a list on creation
        // 5. returns that list
        public List<Monument> MaakMonumenten()
        {
            string ID;
            string Monument_naam;
            string Bouwjaar;
            string Oorspronkelijk_gebouw;
            string Architect;
            string Bouwstijl;
            string Straatnaam;
            double longitude;
            double latitude;

            cmd.CommandText = "select * from monuments join street on street = streetname;";

            using (var reader = cmd.ExecuteReader()) // 2.
            {
                while (reader.Read())
                {
                    ID = reader.GetString(ID_place);
                    Monument_naam = reader.GetString(name_place);
                    Bouwjaar = reader.GetString(constr_yr_place);
                    Oorspronkelijk_gebouw = reader.GetString(original_usage_place);
                    Architect = reader.GetString(architect_place);
                    Bouwstijl = reader.GetString(building_style_place);
                    Straatnaam = reader.GetString(streetname_place);

                    Console.WriteLine(reader.GetString(longitude_place));
                    longitude = Convert.ToDouble(reader.GetString(longitude_place));
                    Console.WriteLine(reader.GetString(latitude_place));
                    latitude = Convert.ToDouble(reader.GetString(latitude_place));

                   // if ((longitude >= 4.4628055 && longitude <= 4.4922865) && (latitude >= 51.9147015 && latitude <= 51.9258755)) // 1.
                    {
                        // 3. & 4.
                        Monumentenlijst.Add(new Monument(ID, Monument_naam, Straatnaam, Oorspronkelijk_gebouw, Bouwjaar, Architect, Bouwstijl, latitude, longitude, All_textures.Monumentlogo, All_textures.tekstvak));
                    }
                }
            }
            return Monumentenlijst; // 5.
        }
    }    
}
