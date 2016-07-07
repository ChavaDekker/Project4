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
using Android.Locations;

namespace ProjectSolutution2._0Android.AndroidLogic
{
    public static class GlobalAndroid
    {
        public delegate void startActivity(Android.Content.Intent intent);

        public static startActivity globalStartIntent;
        public static LocationManager LocationService;
        public static Context GlobalContext;

        public static void PopulateGlobalAndroid(startActivity delegatedstartactivity, LocationManager Locationservice, Context globalcontext)
        {
            globalStartIntent = delegatedstartactivity;
            LocationService = Locationservice;
            GlobalContext = globalcontext;
        }
    }
}