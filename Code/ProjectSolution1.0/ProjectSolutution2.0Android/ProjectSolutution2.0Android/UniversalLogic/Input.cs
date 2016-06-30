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
using Microsoft.Xna.Framework;

namespace ProjectSolutution2._0Android.UniversalLogic
{
    public interface Input
    {
        bool DidClick();
        Point GetDeltaSwipe();
        bool DidClickInArea(Point LTop, Point RBottom);
        void Update();
    }
}