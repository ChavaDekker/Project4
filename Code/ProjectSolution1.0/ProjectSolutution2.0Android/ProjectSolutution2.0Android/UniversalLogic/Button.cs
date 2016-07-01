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
using Microsoft.Xna.Framework.Graphics;

namespace ProjectSolutution2._0Android.UniversalLogic
{
    interface Button
    {
        bool isClicked(Point offset);
        void Draw(SpriteBatch spriteBatch, Point offset);
        void Click(Point offset);
        void SetPosition(Point NewPosition);
        void SetText(string text);
        void SetDelegate(Action _delegate);
    }
}