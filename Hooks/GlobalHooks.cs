using log4net;
using log4net.Config;
using OpenQA.Selenium;
using Reqnroll;
using reqnroll_c__bdd.Helpers;
using reqnroll_c__bdd.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace reqnroll_c__bdd.Hooks
{
    [Binding]
    public class GlobalHooks 
    {
       protected FeatureContext featureContext;
       protected ScenarioContext scenarioContext;


        public GlobalHooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void ConfigureLogging()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var projectRoot = Path.GetFullPath(Path.Combine(baseDir, @"..\..\.."));
            var configPath = Path.Combine(projectRoot, "Config", "LoggerConfigure.xml");

            // Ensure the Logs directory exists in the output directory
            var logsDir = Path.Combine(baseDir, "Logs");
            System.IO.Directory.CreateDirectory(logsDir);

            // Path to the log file in the output directory
            var logFilePath = Path.Combine(logsDir, "TestLogs.log");

            // Clear the log file before logging starts
            if (System.IO.File.Exists(logFilePath))
            {
                System.IO.File.WriteAllText(logFilePath, string.Empty);
            }

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(configPath));
        }


        [BeforeFeature]
        public static void InitializeFeature(FeatureContext featureContext)
        {
            var log = LogManager.GetLogger("TestLogger");
            var context = Setup.GetInstance();
            featureContext["log"] = log;
            featureContext["context"] = context;
        }

        [BeforeScenario]
        public void InitializeScenario()
        {
            
            var log = featureContext.Get<ILog>("log");
            var context = featureContext.Get<Setup>("context");
            var driver = new BaseHelper().CreateDriver(log, context);
            var pageHelperObject = new PageHelper(driver);
            var loginPageObject = new LoginPage(driver, pageHelperObject, context);
            var infoPageObject = new MyInfoPage(driver, pageHelperObject, context);
            var logoutPageObject = new LogoutPage(driver, pageHelperObject, context);

            // Centralize all objects in the Objects container
            var objects = new Objects
            {
                loginPageObject = loginPageObject,
                infoPageObject = infoPageObject,
                logoutPageObject = logoutPageObject,
                pageHelperObject = pageHelperObject
            };

            scenarioContext["driver"] = driver;
            scenarioContext["objects"] = objects;
            }
        

        [AfterScenario]
        public void CleanupScenario()
        {
            if (scenarioContext.TryGetValue("driver", out object driverObj) && driverObj is IWebDriver driver)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}

