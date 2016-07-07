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

        public static Scene getAScene(string ID)
        {
            if (SceneDict.ContainsKey(ID))
            {
                return SceneDict[ID];
            }
            return null;
        }

        public static void ChangeScene(string ID)
        {
            PopSceneFromStack();
            AddSceneOnStack(ID);
        }

        public static Scene GetCurrentScene()
        {
            return SceneStack[SceneStack.Count - 1];
        }

        public static void AddSceneOnStack(string ID)
        {
            if (SceneDict.ContainsKey(ID))
            {
                SceneStack.Add(SceneDict[ID]);
            }
            else
            {
                throw new Exception("Scene does not exist! Scene: " + ID);
            }
        }
        public static void PopSceneFromStack()
        {
            SceneStack.RemoveAt(SceneStack.Count - 1);
        }
        public static bool AddSceneToDict(Scene scene)
        {
            if (SceneDict.ContainsKey(scene.ID))
            {
                return false;
            }
            SceneDict.Add(scene.ID, scene);
            return true;
        }
        public static Scene GetSceneBelow(string OwnID)
        {
            if(SceneStack.IndexOf(SceneDict[OwnID]) == 0)
            {
                return null;
            }
            return SceneStack[SceneStack.IndexOf(SceneDict[OwnID]) - 1];
        }
    }
}