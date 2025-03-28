using OpenQA.Selenium;

namespace Pages
{
    public class LoginPage(IWebDriver driver)
    {
        private const string LoginUrl = "https://www.saucedemo.com/";
        private IWebElement UsernameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//h3[@data-test='error']"));

        public LoginPage EnterUsername(string username)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
            return this;
        }

        public LoginPage ClickLogin()
        {
            LoginButton.Click();
            return this;
        }

        public string GetErrorMessage() => ErrorMessage.Text;
    
        public LoginPage ResetToLogin()
        {
            driver.Navigate().GoToUrl(LoginUrl);
            return this;
        }
    }
}