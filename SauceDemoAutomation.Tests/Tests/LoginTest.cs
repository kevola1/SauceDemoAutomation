using FluentAssertions;
using SauceDemoAutomation.Pages;
using SauceDemoAutomation.TestData;
using SauceDemoAutomation.Utilities;

namespace SauceDemoAutomation.Tests.Tests;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    public async Task Login_With_Valid_User()
    {
        // Arrange
        var loginPage = new LoginPage(Page);

        // Act
        await loginPage.Login(
            TestUsers.StandardUser,
            TestUsers.Password);

        await Page.WaitForTimeoutAsync(2000);       

        await Page.ScreenshotAsync(new()
            {
                Path = "docs/login-success.png",
                FullPage = true
            });
        // Assert
        Page.Url.Should().Contain("inventory");
    }

    [Test]
    public async Task Login_With_Invalid_Credentials()
    {
        // Arrange
        var loginPage = new LoginPage(Page);

        // Act
        await loginPage.Login(
            "standard_user",
            "secret_sauc");

        await Page.WaitForTimeoutAsync(2000);

        await Page.ScreenshotAsync(new()
            {
                Path = "docs/login-error.png",
                FullPage = true
            });

        var errorMessage = await loginPage.GetErrorMessage();

        // Assert
        Assert.That(
            errorMessage,
            Does.Contain("Username and password do not match"));
    }
}