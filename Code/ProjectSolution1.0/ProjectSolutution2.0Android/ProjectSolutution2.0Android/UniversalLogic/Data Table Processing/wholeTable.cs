using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace ProjectSolutution2._0Android.UniversalLogic.Data_Table_Processing
{
    public class WholeTableGeneric : Table
    {
        protected StringTable savedtable;
        protected string stringpath;
        private string filePath;

        public WholeTableGeneric(string FilePath, ContentManager content)
        {
            stringpath = FilePath;
            ParseFile(content);
        }
        

        private void ParseFile(ContentManager content)
        {
            var filepath = Path.Combine(content.RootDirectory, stringpath);
            Stream file = TitleContainer.OpenStream(filepath);
            StreamReader tempo = new StreamReader(file);


            string thewholething = tempo.ReadToEnd();
            savedtable = new StringTable();
            int line = 0;
            int column = 0;
            string fieldToEnter = "";
            List<string> Columnsbyindex = new List<string>();
            //string currentline = tempo.ReadLine();

            for (int i = 0; i < thewholething.Length; i++)
            {
                if (thewholething[i] != ",".ToCharArray()[0] && thewholething[i] != "\n".ToCharArray()[0] && thewholething[i] != "\r".ToCharArray()[0])
                {
                    fieldToEnter += thewholething[i];
                }
                else
                {
                    if (thewholething[i] == ",".ToCharArray()[0] && thewholething[i + 1] != "\n".ToCharArray()[0])
                    {
                        if (line == 0)
                        {
                            if (fieldToEnter == "")
                            {
                                savedtable.NewColumn("Empty");
                                Columnsbyindex.Add("Empty");
                            }
                            else
                            {
                                savedtable.NewColumn(fieldToEnter);
                                Columnsbyindex.Add(fieldToEnter);
                            }
                        }
                        else
                        {
                            if (column < Columnsbyindex.Count)
                            {
                                savedtable.AddValueToColumn(Columnsbyindex[column], fieldToEnter);
                            }
                        }
                        fieldToEnter = "";
                        column++;

                    }
                    if (thewholething[i] == "\n".ToCharArray()[0] || thewholething[i] == "\r".ToCharArray()[0])
                    {

                        if (line == 0)
                        {
                            savedtable.NewColumn(fieldToEnter);
                            Columnsbyindex.Add(fieldToEnter);
                        }
                        else
                        {
                            if (column < Columnsbyindex.Count)
                            {
                                savedtable.AddValueToColumn(Columnsbyindex[column], fieldToEnter);
                            }
                        }
                        fieldToEnter = "";
                        column = 0;
                        line++;
                    }
                }
            }
                
            
            savedtable.RemoveColumn("Empty");
            tempo.Close();
        }

        public StringTable GetTable()
        {
            return savedtable;
        }
        public String StringPath { set { stringpath = value; }get { return stringpath; } }
    }
}