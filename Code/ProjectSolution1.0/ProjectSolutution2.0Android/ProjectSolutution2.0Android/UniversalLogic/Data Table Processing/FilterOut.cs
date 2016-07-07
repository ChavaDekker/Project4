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
    class FilterOut : TableDecorator
    {
        string NameColumn;
        string FieldContent;

        public FilterOut(string NameOfColumn, string Field, Table table)
        {
            SavedTable = table;
            NameColumn = NameOfColumn;
            FieldContent = Field;
        }
        public override StringTable GetTable()
        {
            StringTable temp = SavedTable.GetTable();
            List<String> Column = temp.GetColumn(NameColumn);
            List<int> Toremove = new List<int>();
            for(int i = 0; i<Column.Count; i++)
            {

            }
            throw new NotImplementedException();
        }
    }
}