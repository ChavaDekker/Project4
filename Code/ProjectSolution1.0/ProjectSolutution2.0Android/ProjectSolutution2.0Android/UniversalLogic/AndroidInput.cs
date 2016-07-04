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
using Microsoft.Xna.Framework.Input.Touch;

namespace ProjectSolutution2._0Android.UniversalLogic
{
    //Defines input for Mobile devices
    class AndroidInput : Input
    {
        TouchCollection Lastinput = TouchPanel.GetState();
        public bool DidClick()
        {
            if (Lastinput.Count == 0) {
                TouchCollection current = TouchPanel.GetState();
                if (current.Count > 0)
                {
                    return true;
                }
            }
            return false;
            
        }

        public bool DidClickInArea(Point LTop, Point RBottom)
        {
            if (DidClick())
            {
                TouchCollection current = TouchPanel.GetState();
                Vector2 locationTouch = current[0].Position;
                if (locationTouch.X>LTop.X && locationTouch.X<RBottom.X && locationTouch.Y>LTop.Y && locationTouch.Y < RBottom.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public Point GetDeltaSwipe()
        {
            TouchCollection current = TouchPanel.GetState();

            if(Lastinput.Count > 0 && current.Count > 0)
            {
                return new Point((int)(current[0].Position.X - Lastinput[0].Position.X), (int)(current[0].Position.Y - Lastinput[0].Position.Y)); //returns the distance of the swipe
            }
            return new Point(0);

        }

        public void Update()
        {
            Lastinput = TouchPanel.GetState();
        }
    }
}