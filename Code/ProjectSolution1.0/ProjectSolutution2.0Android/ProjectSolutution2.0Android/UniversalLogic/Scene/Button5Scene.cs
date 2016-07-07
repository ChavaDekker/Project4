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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ProjectSolutution2._0Android.AndroidLogic;

namespace ProjectSolutution2._0Android.UniversalLogic.Scene
{
    public class Button5Scene : Scene
    {
        DynamicButtonHorizontal Save;
        DynamicButtonHorizontal Delete;
        string ErrorShow= "";
        public Button5Scene(GraphicsDevice graphDevice, string ID) : base(graphDevice, ID)
        {
            Save = new DynamicButtonHorizontal(200, 200, 0.25, 0.75, Color.Red, graphDevice);
            Delete = new DynamicButtonHorizontal(400, 200, 0.25, 0.75, Color.Red, graphDevice);

            Save.SetText("Save Location");
            Delete.SetText("Delete Location");

            Save.SetDelegate(new Action(() => LocationApplication.SaveCurrentLocationToFile()));
            Delete.SetDelegate(new Action(() => LocationApplication.DeleteLocationFile()));

            //Save.SetDelegate(new Action(() => SceneManager.ChangeScene("MainMenuScene")));
            //Delete.SetDelegate(new Action(() => SceneManager.ChangeScene("MainMenuScene")));
            Maxnegoffset = new Point(-1000, 0);
        }

        public override void AndroidDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {
            Save.Draw(spritebatch, Offset);
            Delete.Draw(spritebatch, Offset);
            TextDrawing.Drawtext(new Point(400, 650) + Offset, LocationApplication.ReadCurrentLocationFromFile(), spritebatch);
            TextDrawing.Drawtext(new Point(400, 800) + Offset, ErrorShow, spritebatch);
        }
        public override void WindowsDraw(SpriteBatch spritebatch, GraphicsDevice graphDevice)
        {

        }
        protected override void AndroidLogic()
        {
            Save.Click(Offset);
            Delete.Click(Offset);
        }
        protected override void WindowsLogic()
        {

        }

        public override void SetParaMeters(params string[] args)
        {
            int currentindex = 0;
            if (currentindex < args.Length)
            {
                ErrorShow = args[currentindex];
                currentindex++;
            }
        }
    }
}