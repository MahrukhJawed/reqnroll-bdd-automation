using log4net;
using log4net.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Reqnroll;
using reqnroll_c__bdd.Hooks;
using reqnroll_c__bdd.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace reqnroll_c__bdd.Helpers
{
    
    public class BaseHelper
    {
        public IWebDriver driver;

        // Helper for ScenarioContext
        protected T GetScenario<T>(string key) => (T)ScenarioContext.Current[key];
        protected void SetScenario(string key, object value) => ScenarioContext.Current[key] = value;

        // Helper for FeatureContext
        protected T GetFeature<T>(string key) => (T)FeatureContext.Current[key];
        protected void SetFeature(string key, object value) => FeatureContext.Current[key] = value;

        // Central access to all objects
        protected Objects Objects => GetScenario<Objects>("objects");

        public IWebDriver CreateDriver(ILog log, Setup context)
        {
            log.Info("Setting up the browser...");
            string browser = context.Browser;

            try
            {
                switch (browser)
                {
                    case "Chrome":
                        var driverDir = new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                        var options = new ChromeOptions();
                        options.AddArguments("headless");
                        driver = new ChromeDriver(driverDir, options);
                        driver.Manage().Window.Maximize();
                        return driver;


                    case "Firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        driver.Manage().Window.Maximize();
                        return driver;
                }

            }
            catch (Exception e)
            {
                throw new ArgumentException("Unsupported browser", e.Message);
            }
            return null;
        }

       



    }
}
