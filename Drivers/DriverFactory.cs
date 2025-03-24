using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Drivers
{
    public static class DriverFactory
    {
        private static ThreadLocal<IWebDriver> driver = new();

        public static IWebDriver GetDriver(string browser = "chrome")
        {
            if (driver.Value == null)
            {
                driver.Value = browser.ToLower() switch
                {
                    "firefox" => new FirefoxDriver(new FirefoxOptions()),
                    "chrome" => new ChromeDriver(new ChromeOptions()),
                    _ => throw new ArgumentException($"Unsupported browser: {browser}")
                };
            }
            return driver.Value;
        }

        public static void Maximize()
        {
            driver.Value?.Manage().Window.Maximize();
        }

        public static void QuitDriver()
        {
            driver.Value?.Quit();
            driver.Dispose();
        }
    }
}