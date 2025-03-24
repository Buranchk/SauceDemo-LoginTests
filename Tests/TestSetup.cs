using OpenQA.Selenium;
using Drivers;

namespace Tests
{
    public abstract class TestSetup : IDisposable
    {
        public IWebDriver Driver { get; }

        protected TestSetup()
        {
            Driver = DriverFactory.GetDriver("firefox");
            DriverFactory.Maximize();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                DriverFactory.QuitDriver();
            }
        }

        ~TestSetup()
        {
            Dispose(false);
        }
    }
}