using Microsoft.Playwright;

namespace SauceDemoAutomation.Components;

public class HeaderComponent
{
    private readonly IPage _page;

    public HeaderComponent(IPage page)
    {
        _page = page;
    }

    private ILocator CartIcon =>
        _page.Locator(".shopping_cart_link");

    public async Task OpenCart()
    {
        await CartIcon.ClickAsync();
    }
}