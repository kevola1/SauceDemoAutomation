using Microsoft.Playwright;

namespace SauceDemoAutomation.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    private ILocator Username =>
        _page.Locator("#user-name");

    private ILocator Password =>
        _page.Locator("#password");

    private ILocator LoginButton =>
        _page.Locator("#login-button");

    private ILocator ErrorMessage =>
        _page.Locator("[data-test='error']");

    public async Task Login(string username, string password)
    {
        await Username.FillAsync(username);
        await Password.FillAsync(password);
        await LoginButton.ClickAsync();
    }

    public async Task<string> GetErrorMessage()
    {
        return await ErrorMessage.TextContentAsync() ?? "";
    }
}