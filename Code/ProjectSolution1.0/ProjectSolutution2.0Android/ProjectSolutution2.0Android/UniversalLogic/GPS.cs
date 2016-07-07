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
using Java.IO;

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

    //[Activity(Label = "Location Demo")]
    public class ImplementedListner : ILocationListener
    {
        //private TextView _locationText;
        //private LocationManager _locationManager;
        //private StringBuilder _builder;
        //private Geocoder _geocoder;

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

        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    SetContentView(Resource.Layout.location_demo);

        //    _builder = new StringBuilder();
        //    _geocoder = new Geocoder(this);
        //    _locationText = FindViewById<TextView>(Resource.Id.location_text);
        //    _locationManager = (LocationManager)GetSystemService(LocationService);

        //    var criteria = new Criteria { Accuracy = Accuracy.NoRequirement };
        //    string bestProvider = _locationManager.GetBestProvider(criteria, true);

        //    Location lastKnownLocation = _locationManager.GetLastKnownLocation(bestProvider);

        //    if (lastKnownLocation != null)
        //    {
        //        _locationText.Text = string.Format("Last known location, lat: {0}, long {1}",
        //            lastKnownLocation.Latitude, lastKnownLocation.Longitude);

        //    }

        //    _locationManager.RequestLocationUpdates(bestProvider, 5000, 2, this);

        //}

        public void OnLocationChanged(Location location)
        {
            //_builder.AppendLine(
            //     string.Format("Location updated, lat: {0}, long: {1}",
            //                 location.Latitude, location.Longitude)
            // );

            //try
            //{
            //    Address address =
            //        _geocoder
            //            .GetFromLocation(location.Latitude, location.Longitude, 1)
            //            .FirstOrDefault();

            //    if (address != null)
            //    {
            //        _builder.AppendLine(" -> " + address.CountryName);
            //    }
            //}
            //catch (IOException io)
            //{
            //    Android.Util.Log.Debug("LocationActivity", io.Message);
            //}

            //_locationText.Text = _builder.ToString();
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