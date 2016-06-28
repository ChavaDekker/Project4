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
        Button m1Button;
        Button m2Button;
        Button m3Button;
        Button m4Button;
        Button m5Button;
        Button m6Button;
        Button s1Button;
        Button s2Button;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            m1Button = FindViewById<Button>(Resource.Id.M1Button);
            m2Button = FindViewById<Button>(Resource.Id.M2Button);
            m3Button = FindViewById<Button>(Resource.Id.M3Button);
            m4Button = FindViewById<Button>(Resource.Id.M4Button);
            m5Button = FindViewById<Button>(Resource.Id.M5Button);
            m6Button = FindViewById<Button>(Resource.Id.M6Button);
            s1Button = FindViewById<Button>(Resource.Id.S1Button);
            s2Button = FindViewById<Button>(Resource.Id.S2Button);

            m1Button.Click += m1Button_Click;
            m2Button.Click += m2Button_Click;
            m3Button.Click += m3Button_Click;
            m4Button.Click += m4Button_Click;
            m5Button.Click += m5Button_Click;
            m6Button.Click += m6Button_Click;
            s1Button.Click += s1Button_Click;
            s2Button.Click += s2Button_Click;

        }

        void m1Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof (M1Activity));
            this.StartActivity(intent);
        }

        void m2Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(M2Activity));
            this.StartActivity(intent);
        }

        void m3Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(M3Activity));
            this.StartActivity(intent);
        }

        void m4Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(M4Activity));
            this.StartActivity(intent);
        }

        void m5Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(M5Activity));
            this.StartActivity(intent);
        }

        void m6Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(M6Activity));
            this.StartActivity(intent);
        }

        void s1Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(S1Activity));
            this.StartActivity(intent);
        }

        void s2Button_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(S2Activity));
            this.StartActivity(intent);
        }
        
    }
}

