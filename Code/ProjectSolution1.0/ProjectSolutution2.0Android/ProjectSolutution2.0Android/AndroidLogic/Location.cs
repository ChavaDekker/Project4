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
using Android.Locations;
using Java.IO;
using ProjectSolutution2._0Android.UniversalLogic.Scene;

namespace ProjectSolutution2._0Android.AndroidLogic
{
    public static class LocationApplication
    {
        private static string locationFile = GlobalAndroid.GlobalContext.FilesDir.AbsolutePath;
        private static string filename = "/location.txt";
        private static string currentlyon;
        private static Location getLocation()
        {
            IList<string> providerson = GlobalAndroid.LocationService.GetProviders(true);
            if (providerson.Count < 1)
            {
                currentlyon = null;
                return null;
            }

            currentlyon = providerson[0];

            return GlobalAndroid.LocationService.GetLastKnownLocation(currentlyon);
        }

        public static string GetHumanReadableLocation()
        {
            Location current = getLocation();
            if (current == null)
            {
                return "Can't get location";
            }

            Geocoder geocoder = new Geocoder(GlobalAndroid.GlobalContext);
            IList<Address> addresses = geocoder.GetFromLocation(current.Latitude, current.Longitude, 1);
            string currentlocation = "";
            for (int i = 0; i < addresses[0].MaxAddressLineIndex; i++)
            {
                currentlocation += addresses[0].GetAddressLine(i);
            }
            return currentlocation;
        }

        public static void SaveCurrentLocationToFile()
        {
            string location = GetHumanReadableLocation();

            try
            {
                //FileOutputStream openputStream;
                //openputStream = new FileOutputStream(locationFile + filename);
                //openputStream.Write(location.)
                OutputStreamWriter outputStreamWriter = new OutputStreamWriter(GlobalAndroid.GlobalContext.OpenFileOutput(locationFile + filename, FileCreationMode.Private));
                outputStreamWriter.Write(location);
                outputStreamWriter.Close();
            }
            catch (FileNotFoundException e)
            {
                File newfile = new File(locationFile, filename);
                newfile.CreateNewFile();
                SaveCurrentLocationToFile();
            }
            catch
            {
                SceneManager.ChangeScene("TestScene");
            }
        }

        public static string ReadCurrentLocationFromFile()
        {
            string toreturn = "";
            try
            {
                FileInputStream input = new FileInputStream(locationFile + filename);
                try
                {
                    while(input.Available() > 0)
                    {
                        toreturn += ((char)input.Read()).ToString();
                    }
                }
                catch
                {
                    toreturn = "Found File, but can't read it.";
                }
                input.Close();
                return toreturn;
            }
            catch (FileNotFoundException e)
            {
                toreturn = "No location saved yet";
            }
            catch (IOException e)
            {
                toreturn = "Error";
            }
            return toreturn + "\nSaved at: " + locationFile;
        }

        public static void DeleteLocationFile()
        {
            File file = new File(locationFile, filename);
            file.Delete();
            
        }
    }
}