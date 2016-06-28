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

namespace Solution1._0.Universal_Logic.Data_Table_Processing
{
    class FilterOnly : TableDecorator
    {
        string NameColumn;
        string FieldContent;
        
        public FilterOnly(string NameOfColumn, string Field, Table table)
        {

            throw new NotImplementedException();
        }
        public override string[,] GetTable()
        {
            throw new NotImplementedException();
        }
    }
}