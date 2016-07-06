using Android.App;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Views;
using ProjectSolutution2._0Android.AndroidLogic;

namespace ProjectSolutution2._0Android
{
    [Activity(Label = "ProjectSolutution2.0Android"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.Portrait
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var g = new Game1();
            SetContentView((View)g.Services.GetService(typeof(View)));
            LocationManager locMgr;
            locMgr = GetSystemService(LocationService) as LocationManager;
            GlobalAndroid.PopulateGlobalAndroid(new GlobalAndroid.startActivity(StartActivity), locMgr, this.ApplicationContext);
            
            g.Run();
        }
    }
}

