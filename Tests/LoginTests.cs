using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using Pages;
using TestLogs;
using Xunit.Abstractions;

namespace Tests
{
    public class LoginTests : IClassFixture<TestSetup>
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;


        public LoginTests(TestSetup setup, ITestOutputHelper testOutputHelper)
        {
            _driver = setup.Driver;
            _loginPage = new LoginPage(_driver);
        }
    
        [Fact]
        public void UC1_Should_ShowUsernameRequired_When_CredentialsEmpty()
        {
            Logger.Log.Information("Running UC1 - Username Required validation");

            _loginPage.ResetToLogin();
            _loginPage.ClickLogin();
            
            var errorMsg = _loginPage.GetErrorMessage();
            Logger.Log.Information("Captured error message: {ErrorMessage}", errorMsg); //No levels!


            _loginPage.GetErrorMessage().Should().Contain("Username is required");
        }

        [Fact]
        public void UC2_Should_ShowPasswordRequired_When_PasswordMissing()
        {
            Logger.Log.Information("Running UC2 - Password Required validation");

            _loginPage.ResetToLogin();
            _loginPage.EnterUsername("standard_user");
            _loginPage.ClickLogin();

            var errorMsg = _loginPage.GetErrorMessage();
            Logger.Log.Information("Captured error message: {ErrorMessage}", errorMsg);

            _loginPage.GetErrorMessage().Should().Contain("Password is required");
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("locked_out_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        [InlineData("error_user", "secret_sauce")]
        [InlineData("visual_user", "secret_sauce")]
        public void UC3_Should_LoginSuccessfully_With_ValidCredentials(string username, string password)
        {
            Logger.Log.Information("Running UC3 - Login with user: {Username}", username);

            _loginPage.ResetToLogin();
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();
            
            string title = _driver.Title;
            Logger.Log.Information("Page title after login: {Title}", title);
        
            _driver.Title.Should().Be("Swag Labs");
        }
    }
}