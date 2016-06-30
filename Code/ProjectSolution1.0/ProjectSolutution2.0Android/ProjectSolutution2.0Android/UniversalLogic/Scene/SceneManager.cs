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

namespace ProjectSolutution2._0Android.UniversalLogic.Scene
{
    public static class SceneManager
    {
        private static List<Scene> SceneStack = new List<Scene>();
        private static Dictionary<string, Scene> SceneDict = new Dictionary<string, Scene>();

        public static void ChangeScene(string ID)
        {

            throw new Exception("Not Implemented");
        }

        public static Scene GetCurrentScene()
        {
            return SceneStack[SceneStack.Count - 1];
        }

        public static void AddSceneOnStack(string ID)
        {

            throw new Exception("Not Implemented");
        }
        public static void PopSceneFromStack()
        {

            throw new Exception("Not Implemented");
        }
        public static bool AddSceneToDict(Scene scene)
        {

            throw new Exception("Not Implemented");
        }
        public static Scene GetSceneBelow(string OwnID)
        {

            throw new Exception("Not Implemented");
        }
    }
}