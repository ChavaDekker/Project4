using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Solution1._0
{
    [Activity(Label = "Solution1._0", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button m1Button = FindViewById<Button>(Resource.Id.M1Button);
            Button m2Button = FindViewById<Button>(Resource.Id.M2Button);
            Button m3Button = FindViewById<Button>(Resource.Id.M3Button);
            Button m4Button = FindViewById<Button>(Resource.Id.M4Button);
            Button m5Button = FindViewById<Button>(Resource.Id.M5Button);
            Button m6Button = FindViewById<Button>(Resource.Id.M6Button);
            Button s1Button = FindViewById<Button>(Resource.Id.S1Button);
            Button s2Button = FindViewById<Button>(Resource.Id.S2Button);

            m1Button.Click += (object sender, EventArgs e) =>
            {

            };

            m2Button.Click += (object sender, EventArgs e) =>
            {

            };

            m3Button.Click += (object sender, EventArgs e) =>
            {

            };

            m4Button.Click += (object sender, EventArgs e) =>
            {

            };

            m5Button.Click += (object sender, EventArgs e) =>
            {

            };

            m6Button.Click += (object sender, EventArgs e) =>
             {

             };

            s1Button.Click += (object sender, EventArgs e) =>
            {

            };

            s2Button.Click += (object sender, EventArgs e) =>
            {

            };
        }
    }
}

