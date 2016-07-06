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

namespace ProjectSolutution2._0Android.AndroidLogic
{
    class Appointment
    {
        public static void CreateNewAppointment()
        {
            Calendar beginTime = Calendar.GetInstance(Java.Util.TimeZone.Default);
            beginTime.Set(2017, 0, 19, 7, 30);
            Calendar endTime = Calendar.GetInstance(Java.Util.TimeZone.Default);
            endTime.Set(2017, 0, 19, 8, 30);
            Intent intent = new Intent(Intent.ActionInsert)
                    .SetData(Events.ContentUri)
                    .PutExtra(CalendarContract.ExtraEventBeginTime, beginTime.TimeInMillis)
                    .PutExtra(CalendarContract.ExtraEventEndTime, endTime.TimeInMillis)
                    .PutExtra(Events.InterfaceConsts.Title, "Yoga")
                    .PutExtra(Events.InterfaceConsts.Description, "Group class")
                    .PutExtra(Events.InterfaceConsts.EventLocation, "The gym")
                    //.PutExtra(Events.InterfaceConsts.Availability, Events.InterfaceConsts.AvailabilityBusy)
                    .PutExtra(Intent.ExtraEmail, "rowan@example.com,trevor@example.com");
            GlobalAndroid.globalStartIntent(intent);
        }
    }
}