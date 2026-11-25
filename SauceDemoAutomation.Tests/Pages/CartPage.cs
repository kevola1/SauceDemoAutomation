using Microsoft.Playwright;

namespace SauceDemoAutomation.Pages;

public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }

    private ILocator CheckoutButton =>
        _page.Locator("#checkout");

    public async Task Checkout()
    {
        await CheckoutButton.ClickAsync();
    }
}