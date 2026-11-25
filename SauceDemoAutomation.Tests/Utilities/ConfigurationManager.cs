using Microsoft.Extensions.Configuration;

namespace SauceDemoAutomation.Utilities;

public class ConfigurationManager
{
    private readonly IConfiguration _configuration;

    public ConfigurationManager()
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public string BaseUrl =>
        _configuration["ApplicationSettings:BaseUrl"]!;

    public bool Headless =>
        bool.Parse(
            _configuration["ApplicationSettings:Headless"]!);

    public int SlowMo =>
        int.Parse(
            _configuration["ApplicationSettings:SlowMo"]!);
}