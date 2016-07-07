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
        public static Location getLocation()
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

            Geocoder geocoder = new Geocoder(GlobalAndroid.GlobalContext, Java.Util.Locale.English);
            IList<Address> addresses = geocoder.GetFromLocation(current.Latitude, current.Longitude, 5);
            string currentlocation = "";
            string temp;
            List<string> adresses = new List<string>();
            foreach (Address x in addresses)
            {
                string localaddresave = "";
                for (int i = 0; i < x.MaxAddressLineIndex; i++)
                {
                    temp = x.GetAddressLine(i);
                    if (temp != null)
                    {
                        localaddresave += temp + ", ";
                    }
                }
                //localaddresave += x.Thoroughfare;
                adresses.Add(localaddresave);
            }
            int largeststring = 0;
            for(int i = 0; i<adresses.Count; i++)
            {
                if(adresses[i].Length > adresses[largeststring].Length)
                {
                    largeststring = i;
                }
            }
            currentlocation = adresses[largeststring];
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
                File newfile = new File(locationFile, filename);
                newfile.CreateNewFile();
                FileOutputStream fileoutput = new FileOutputStream(newfile);
                foreach(char i in location)
                {
                    fileoutput.Write((Byte)i);
                }
                fileoutput.Close();                
                //OutputStreamWriter outputStreamWriter = new OutputStreamWriter(GlobalAndroid.GlobalContext.OpenFileOutput((locationFile + filename, FileCreationMode.Private));
                //outputStreamWriter.Write(location);
                //outputStreamWriter.Close();
            }
            catch (FileNotFoundException e)
            {
                File newfile = new File(locationFile, filename);
                newfile.CreateNewFile();
                SaveCurrentLocationToFile();
            }
            catch (Exception e)
            {
                string[] seterror = new string[1];
                seterror[0] = e.GetType().ToString();
                SceneManager.GetCurrentScene().SetParaMeters(seterror);
                //SceneManager.ChangeScene("TestScene");
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
            return toreturn;
        }

        public static void DeleteLocationFile()
        {
            File file = new File(locationFile, filename);
            file.Delete();
            
        }
    }
}