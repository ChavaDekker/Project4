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
    abstract class TableDecorator : Table
    {
        Table SavedTable;
        public abstract string[,] GetTable();
    }
}