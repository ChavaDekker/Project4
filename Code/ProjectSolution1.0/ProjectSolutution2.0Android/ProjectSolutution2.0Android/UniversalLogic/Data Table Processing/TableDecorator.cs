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
    abstract class TableDecorator : Table
    {
        protected Table SavedTable;
        public abstract StringTable GetTable();
    }
}