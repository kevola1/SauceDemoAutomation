using FluentAssertions;
using SauceDemoAutomation.Pages;
using SauceDemoAutomation.Utilities;
using SauceDemoAutomation.Components;

namespace SauceDemoAutomation.Tests.Tests;

[TestFixture]
public class InventoryTests : BaseTest

{
[Test]
public async Task Complete_Order()
{
    var loginPage =
        new LoginPage(Page);

    var inventory =
        new InventoryPage(Page);

    var cart =
        new CartPage(Page);

    var checkout =
        new CheckoutPage(Page);

    var header =
        new HeaderComponent(Page);

    await loginPage.Login(
        "standard_user",
        "secret_sauce");

    await inventory.AddBackpackToCart();

    await header.OpenCart();

    await cart.Checkout();

    await checkout.CompleteCheckout(
        "John",
        "Doe",
        "10001");

    // Screenshot of successful order
        await TakeScreenshot("complete-order");

    var message =
        await checkout.GetConfirmation();

    message.Should()
        .Be("Thank you for your order!");
}

}