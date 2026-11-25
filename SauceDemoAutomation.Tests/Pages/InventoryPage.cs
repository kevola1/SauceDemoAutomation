using Microsoft.Playwright;

namespace SauceDemoAutomation.Pages;

public class InventoryPage
{
    private readonly IPage _page;

    public InventoryPage(IPage page)
    {
        _page = page;
    }

    private ILocator BackpackAddButton =>
        _page.Locator("#add-to-cart-sauce-labs-backpack");

    private ILocator CartBadge =>
        _page.Locator(".shopping_cart_badge");

    public async Task AddBackpackToCart()
    {
        await BackpackAddButton.ClickAsync();
    }

    public async Task<int> GetCartCount()
    {
        var text = await CartBadge.TextContentAsync();

        return int.Parse(text!);
    }
}