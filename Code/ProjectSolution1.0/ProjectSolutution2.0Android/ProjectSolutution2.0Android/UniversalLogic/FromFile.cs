using ProjectSolutution2._0Android.UniversalLogic.Data_Table_Processing;
using System;
using System.Collections.Generic;
namespace ProjectSolutution2._0Android.UniversalLogic
{
    public class FromFile : Data
    {
        public List<Duodata<float, float>> BoxLocations()
        {
            //not a must!


            //Table TableChain = DataprocessingInitialisation.BikeBox;

            //StringTable table = TableChain.GetTable();

            //List<string> xcoord, ycoord;
            //xcoord = table.GetColumn("X-Coord.");
            //ycoord = table.GetColumn("Y-Coord.");

            //Duodata<float, float>
            //for(int i = 0; i < xcoord.Count; i++)
            //{

            //}

            //StringTable 
            throw new NotImplementedException();
        }

        public List<Duodata<string, int>> BoxPNeighbourhood()
        {
            try
            {
                Table tablechain = DataprocessingInitialisation.BikeBox;
                tablechain = new CountOnColumnElement("Deelgem.", tablechain);
                StringTable table = tablechain.GetTable();
                List<string> uniqueIDs, amounts;
                uniqueIDs = table.GetColumn("Deelgem.");
                amounts = table.GetColumn("Amount");
                Duodata<string, int> toadd;
                List<Duodata<string, int>> toreturn = new List<Duodata<string, int>>();

                for (int i = 0; i < uniqueIDs.Count; i++)
                {
                    toadd = new Duodata<string, int>(uniqueIDs[i], int.Parse(amounts[i]));
                    toreturn.Add(toadd);
                }

                return toreturn;
            }
            catch(Exception e)
            {
                Scene.SceneManager.getAScene("TestScene").SetParaMeters(e.GetType().ToString() + "\n");
                Scene.SceneManager.getAScene("TestScene").SetParaMeters(e.Message  + " ... " + e.StackTrace+ "\n");
                List<Duodata<string, int>> temp = new List<Duodata<string, int>>();
                temp.Add(new Duodata<string, int>("Error", 10));
                return temp;
            }
        }

        public List<Duodata<string, int>> TheftPBrand()
        {
            Table tablechain = DataprocessingInitialisation.BikeTheft;
            tablechain = new CountOnColumnElement("merk", tablechain);
            StringTable table = tablechain.GetTable();
            List<string> uniqueIDs, amounts;
            uniqueIDs = table.GetColumn("merk");
            amounts = table.GetColumn("Amount");

            Duodata<string, int> toadd;
            List<Duodata<string, int>> toreturn = new List<Duodata<string, int>>();

            for (int i = 0; i < uniqueIDs.Count; i++)
            {
                toadd = new Duodata<string, int>(uniqueIDs[i], int.Parse(amounts[i]));
                toreturn.Add(toadd);
            }
            return toreturn;
        }

        public List<Duodata<string, int>> TheftPColour()
        {
            Table tablechain = DataprocessingInitialisation.BikeTheft;
            tablechain = new CountOnColumnElement("kleur", tablechain);
            StringTable table = tablechain.GetTable();
            List<string> uniqueIDs, amounts;
            uniqueIDs = table.GetColumn("kleur");
            amounts = table.GetColumn("Amount");

            Duodata<string, int> toadd;
            List<Duodata<string, int>> toreturn = new List<Duodata<string, int>>();

            for (int i = 0; i < uniqueIDs.Count; i++)
            {
                toadd = new Duodata<string, int>(uniqueIDs[i], int.Parse(amounts[i]));
                toreturn.Add(toadd);
            }
            return toreturn;
        }

        public List<Duodata<string, int>> TheftPMonth()
        {
            Table tablechain = DataprocessingInitialisation.BikeTheft;
            Scene.SceneManager.getAScene("TestScene").SetParaMeters(tablechain.GetTable().Columns["Kennisname"].Count.ToString() + " default \n");
            tablechain = new MakePerMonth("Kennisname", tablechain);
            Scene.SceneManager.getAScene("TestScene").SetParaMeters(tablechain.GetTable().Columns["Kennisname"].Count.ToString() + " mademonth \n");
            tablechain = new CountOnColumnElement("Kennisname", tablechain);
            Scene.SceneManager.getAScene("TestScene").SetParaMeters(tablechain.GetTable().Columns["Kennisname"].Count.ToString() + " countedonelement \n");

            StringTable table = tablechain.GetTable();
            List<string> uniqueIDs, amounts;
            uniqueIDs = table.GetColumn("Kennisname");
            amounts = table.GetColumn("Amount");

            Duodata<string, int> toadd;
            List<Duodata<string, int>> toreturn = new List<Duodata<string, int>>();

            for (int i = 0; i < uniqueIDs.Count; i++)
            {
                toadd = new Duodata<string, int>(uniqueIDs[i], int.Parse(amounts[i]));
                toreturn.Add(toadd);
            }
            return toreturn;
        }

        public List<Duodata<string, int>> TheftPMonthInNeighbourhood(string Neighbourhood)
        {
            Table tablechain = DataprocessingInitialisation.BikeTheft;
            tablechain = new MakePerMonth("Kennisname", tablechain);
            tablechain = new FilterOnly("Werkgebied", Neighbourhood, tablechain);
            tablechain = new CountOnColumnElement("Kennisname", tablechain);

            StringTable table = tablechain.GetTable();
            List<string> uniqueIDs, amounts;
            uniqueIDs = table.GetColumn("Kennisname");
            amounts = table.GetColumn("Amount");

            Duodata<string, int> toadd;
            List<Duodata<string, int>> toreturn = new List<Duodata<string, int>>();

            for (int i = 0; i < uniqueIDs.Count; i++)
            {
                toadd = new Duodata<string, int>(uniqueIDs[i], int.Parse(amounts[i]));
                toreturn.Add(toadd);
            }
            return toreturn;
        }
    }
}
