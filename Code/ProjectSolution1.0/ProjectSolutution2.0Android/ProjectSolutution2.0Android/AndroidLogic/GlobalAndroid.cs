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

namespace ProjectSolutution2._0Android.AndroidLogic
{
    public static class GlobalAndroid
    {
        public delegate void startActivity(Android.Content.Intent intent);

        public static startActivity globalStartIntent;

        public static void PopulateGlobalAndroid(startActivity delegatedstartactivity)
        {
            globalStartIntent = delegatedstartactivity;
        }
    }
}