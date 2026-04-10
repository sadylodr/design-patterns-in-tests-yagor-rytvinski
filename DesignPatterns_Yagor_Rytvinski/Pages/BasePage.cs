using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DesignPatterns_Yagor_Rytvinski.Pages;

// page object realization
public abstract class BasePage
{
    protected IWebDriver Driver;
    protected WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
}