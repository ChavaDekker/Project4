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
    public static class LocationApplication
    {
        private static string currentlyon;
        private static Location getLocation()
        {
            IList<string> providerson = GlobalAndroid.LocationService.GetProviders(true);
            if (providerson.Count < 1)
            {
                currentlyon = null;
                return null;
            }

            currentlyon = providerson[0];

            return GlobalAndroid.LocationService.GetLastKnownLocation(currentlyon);
        }

        public static string GetHumanReadableLocation()
        {
            Location current = getLocation();
            if (current == null)
            {
                return "Can't get location";
            }

            Geocoder geocoder = new Geocoder(GlobalAndroid.GlobalContext);
            IList<Address> addresses = geocoder.GetFromLocation(current.Latitude, current.Longitude, 1);
            string currentlocation = "";
            for (int i = 0; i < addresses[0].MaxAddressLineIndex; i++)
            {
                currentlocation += addresses[0].GetAddressLine(i);
            }
            return currentlocation;
        }
    }
}