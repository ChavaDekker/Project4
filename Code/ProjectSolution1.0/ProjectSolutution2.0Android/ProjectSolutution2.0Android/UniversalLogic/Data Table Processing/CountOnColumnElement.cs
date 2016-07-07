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

namespace ProjectSolutution2._0Android.UniversalLogic.Data_Table_Processing
{
    class CountOnColumnElement : TableDecorator
    {
        string NameColumn;

        public CountOnColumnElement(string NameOfColumn, Table table)
        {
            SavedTable = table;
            NameColumn = NameOfColumn;
        }

        public override StringTable GetTable()
        {
            
            StringTable temp = SavedTable.GetTable();
            List<string> columntocount = temp.GetColumn(NameColumn);
            StringTable newtable = new StringTable();
            newtable.NewColumn(NameColumn);
            newtable.NewColumn("Amount");
            List<string> uniquellabels = new List<string>();
            List<int> amounts = new List<int>();

            for(int i = 0; i < columntocount.Count; i++)
            {
                if (uniquellabels.Contains(columntocount[i])){
                    amounts[uniquellabels.IndexOf(columntocount[i])] += 1;
                }
                else
                {
                    uniquellabels.Add(columntocount[i]);
                    amounts.Add(1);
                }
            }
            foreach(string i in uniquellabels)
            {
                newtable.AddValueToColumn(NameColumn, i);
            }
            foreach(int i in amounts)
            {
                newtable.AddValueToColumn("Amount", i.ToString());
            }
            
            return newtable;
        }
    }
}