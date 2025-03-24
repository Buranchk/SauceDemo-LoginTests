SauceDemo Login Tests

This project contains automated UI tests for the SauceDemo Login Page, validating various user login scenarios using Selenium WebDriver, xUnit, FluentAssertions, and Serilog for logging.

 Test Scenarios

UC-1: Login with Empty Credentials
1.	Navigate to the login page.
2.	Type any values into “Username” and “Password” fields.
3.	Clear both inputs.
4.	Click the Login button.
5.	Assert that the error message “Username is required” is displayed.

UC-2: Login with Empty Password
1.	Navigate to the login page.
2.	Type any value into the Username field.
3.	Enter a value into the Password field.
4.	Clear the Password input.
5.	Click the Login button.
6.	Assert that the error message “Password is required” is displayed.

UC-3: Login with Valid Credentials
1.	Use one of the accepted usernames (e.g., standard_user, locked_out_user, etc.).
2.	Enter the password: secret_sauce.
3.	Click the Login button.
4.	Assert that the page title is “Swag Labs”.

️ Features
1.	 Parallel test execution
2.	 Logging with Serilog
3.	 Parameterized tests using Data Providers ([Theory] / [InlineData])
4.	 Page Object Model structure

 Project Structure
1.	LoginPage.cs – Page Object for the login form
2.	LoginTests.cs – Contains test cases for UC-1, UC-2, and UC-3
3.	Logger.cs – Serilog logger configuration
4.	DriverFactory.cs – Manages WebDriver initialization
5.	TestSetup.cs – xUnit test fixture for setup and teardown