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

namespace ProjectSolutution2._0Android.UniversalLogic
{
    public static class GPS
    {
        public static IList<Address> getNearbyPlaces()
        {

            Geocoder geocoder = new Geocoder(Android.App.Application.Context);


            return geocoder.GetFromLocation(43.04584, -3.33142, 5);
        }
        public static void NavToClosest()
        {

            throw new NotImplementedException();
        }

        public static Duodata<float, float> GetLocation()
        {

            throw new NotImplementedException();
        }
    }


    public class ImplementedListner : ILocationListener
    {
        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnLocationChanged(Location location)
        {
            throw new NotImplementedException();
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }


}