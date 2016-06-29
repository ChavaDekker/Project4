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
using Android.Graphics;
using Android.Media;

namespace Solution1._0
{
    [Activity(Label = "M4Activity")]
    public class M4Activity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ImageView imageviewtest = FindViewById<ImageView>(Resource.Id.imageView1);

            //imageviewtest.SetImageResource()

            //BitmapFactory.
            // Create your application here
            SetContentView(Resource.Layout.M4Activity);
        }
    }
}