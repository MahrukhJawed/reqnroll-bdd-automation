using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Internal.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.Helpers
{
    public class Setup
    {

        public  string Browser { get; set; }
        public  string BaseURL { get; set; }
        public  string Username { get; set; }
        public  string Password { get; set; }
        public string EnvironmentFile { get; set; } = @"../../../resources/environment.properties";
    
        public Setup() {

            SetupEnvProperties();
        }
        public static Setup GetInstance()
        {
           
            var instance = new Setup();
            return instance;

        }

        public void SetupEnvProperties()
        {
            LoadEnvironmentProperties();
        }

        private void LoadEnvironmentProperties()
        {
            Hashtable environmentData = GetEnvironmentData();
            if (environmentData.ContainsKey("Browser"))
            {
                Browser = (string)environmentData["Browser"];
            }
            if (environmentData.ContainsKey("BaseURL"))
            {
                BaseURL = (string)environmentData["BaseURL"];
            }
            if (environmentData.ContainsKey("Username"))
            {
                Username = (string)environmentData["Username"];
            }
            if (environmentData.ContainsKey("Password"))
            {
                Password = (string)environmentData["Password"];
            }
        }

        private Hashtable GetEnvironmentData()
        {
            Hashtable enviromentData = LoadProperties();
            return enviromentData;
        }

        public Hashtable LoadProperties()
        {
            StreamReader properties = new(EnvironmentFile);
            Hashtable fileData = new();
            string line;
            while ((line = properties.ReadLine()) != null)
            {
                string[] lineData = line.Split(new char[] { '=' }, 2);

                if (!string.IsNullOrEmpty(lineData[0].Trim()) && !lineData[0].Trim().StartsWith("#"))
                {
                    fileData.Add(lineData[0].Trim(), lineData[1].Trim());
                }
            }

            properties.Close();
            return fileData;
        }
    }
}

