using Microsoft.Playwright;

namespace SauceDemoAutomation.Utilities;

public class BaseTest
{
    protected IPlaywright Playwright;
    protected IBrowser Browser;
    protected IBrowserContext Context;
    protected IPage Page;

    [SetUp]
    public async Task Setup()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        var config = new ConfigurationManager();

        Browser = await Playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = config.Headless,
            });

        Context = await Browser.NewContextAsync();

        Page = await Context.NewPageAsync();

        await Page.GotoAsync(config.BaseUrl);   
    }

    [TearDown]
    public async Task TearDown()
    {
        await Browser.CloseAsync();
    }
}