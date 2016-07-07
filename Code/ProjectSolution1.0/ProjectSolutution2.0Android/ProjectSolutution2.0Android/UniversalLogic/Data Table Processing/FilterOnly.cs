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
    class FilterOnly : TableDecorator
    {
        string NameColumn;
        string FieldContent;
        
        public FilterOnly(string NameOfColumn, string Field, Table table)
        {
            NameColumn = NameOfColumn;
            FieldContent = Field;
            SavedTable = table;
        }
        public override StringTable GetTable()
        {
            StringTable temp = SavedTable.GetTable();
            List<String> Column = temp.GetColumn(NameColumn);
            List<int> Toremove = new List<int>();
            for (int i = 0; i < Column.Count; i++)
            {
                if (Column[i] != FieldContent)
                {
                    Toremove.Add(i);
                }
            }
            int amountofitems = Toremove.Count - 1;
            for (int i = amountofitems; i >= 0; i--)
            {
                Column.RemoveAt(Toremove[i]);
            }
            return temp;
        }
    }
}