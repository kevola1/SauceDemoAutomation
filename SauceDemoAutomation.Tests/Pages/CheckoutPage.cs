using Microsoft.Playwright;

namespace SauceDemoAutomation.Pages;

public class CheckoutPage
{
    private readonly IPage _page;

    public CheckoutPage(IPage page)
    {
        _page = page;
    }

    public async Task CompleteCheckout(
        string firstName,
        string lastName,
        string zip)
    {
        await _page.FillAsync("#first-name", firstName);
        await _page.FillAsync("#last-name", lastName);
        await _page.FillAsync("#postal-code", zip);

        await _page.ClickAsync("#continue");

        await _page.ClickAsync("#finish");
    }

    public async Task<string> GetConfirmation()
    {
        return await _page
            .Locator(".complete-header")
            .TextContentAsync() ?? "";
    }
}