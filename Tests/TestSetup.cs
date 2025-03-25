using OpenQA.Selenium;
using Drivers;

namespace Tests
{
    public class TestSetup : IDisposable
    {
        public IWebDriver Driver { get; }

        public TestSetup()
        {
            Driver = DriverFactory.GetDriver("firefox");
            DriverFactory.Maximize();
        }

        public void Dispose()
        {
            DriverFactory.QuitDriver();
        }
    }
}