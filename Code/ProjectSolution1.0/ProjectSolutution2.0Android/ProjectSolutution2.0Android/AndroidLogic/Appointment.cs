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
using Java.Util;
using static Android.Provider.CalendarContract;
using Android.Provider;
using Android.Locations;

namespace ProjectSolutution2._0Android.AndroidLogic
{
    class Appointment
    {
        public static void button6action()
        {
            Location temp = LocationApplication.getLocation();
            string longtitude, latitude;
            longtitude = temp.Longitude.ToString();
            latitude = temp.Latitude.ToString();
            string newlongtitude, newlatitude;
            newlatitude = "";
            newlongtitude = "";
            for (int i = 0; i < longtitude.Length; i++)
            {
                if (longtitude[i] == ",".ToCharArray()[0])
                {
                    newlongtitude += ".";
                }
                else
                {
                    newlongtitude += longtitude[i];
                }
            }
            for (int i = 0; i < latitude.Length; i++)
            {
                if (latitude[i] == ",".ToCharArray()[0])
                {
                    newlatitude += ".";
                }
                else
                {
                    newlatitude += latitude[i];
                }
            }
            CreateNewAppointment(newlatitude + ", " + newlongtitude);
        }
        private static void CreateNewAppointment(string locationBike)
        {
            Calendar beginTime = Calendar.GetInstance(Java.Util.TimeZone.Default);
            beginTime.Set(2017, 0, 19, 7, 30);
            Calendar endTime = Calendar.GetInstance(Java.Util.TimeZone.Default);
            endTime.Set(2017, 0, 19, 8, 30);
            Intent intent = new Intent(Intent.ActionInsert)
                    .SetData(Events.ContentUri)
                    .PutExtra(CalendarContract.ExtraEventBeginTime, beginTime.TimeInMillis)
                    .PutExtra(CalendarContract.ExtraEventEndTime, endTime.TimeInMillis)
                    .PutExtra(Events.InterfaceConsts.Title, "Pick up bike")
                    .PutExtra(Events.InterfaceConsts.Description, "Pick up your bike!")
                    .PutExtra(Events.InterfaceConsts.EventLocation, locationBike)
                    //.PutExtra(Events.InterfaceConsts.Availability, Events.InterfaceConsts.AvailabilityBusy)
                    //.PutExtra(Intent.ExtraEmail, "rowan@example.com,trevor@example.com")
                    ;
            GlobalAndroid.globalStartIntent(intent);
        }
    }
}