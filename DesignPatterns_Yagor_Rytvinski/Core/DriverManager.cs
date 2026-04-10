using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DesignPatterns_Yagor_Rytvinski.Core;

// singleton realization
public class DriverManager
{
    private static readonly ThreadLocal<IWebDriver> _driver = new();
    private static DriverManager _instance;

    private DriverManager() { }

    public static DriverManager Instance => _instance ??= new DriverManager();

    public IWebDriver GetDriver()
    {
        if (_driver.Value == null)
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _driver.Value = new ChromeDriver(options);
        }
        return _driver.Value;
    }

    public void QuitDriver()
    {
        _driver.Value?.Quit();
        _driver.Value?.Dispose();
        _driver.Value = null;
    }
}