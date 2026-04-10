using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace DesignPatterns_Yagor_Rytvinski.Pages;

public class MainPage : BasePage
{
    public MainPage(IWebDriver driver) : base(driver) { }

    private IWebElement BurgerMenu => Wait.Until(d => d.FindElement(By.ClassName("toggle-header-menu")));
    private IWebElement SearchTrigger => Driver.FindElement(By.ClassName("header-search"));
    private IWebElement LanguageSwitcher => Wait.Until(d => d.FindElement(By.CssSelector("ul.language-switcher")));

    public void OpenAboutPage()
    {
        BurgerMenu.Click();
        var aboutLink = Wait.Until(d => d.FindElement(By.XPath("//ul[contains(@class, 'menu')]//a[contains(text(), 'About')]")));
        aboutLink.Click();
    }

    public void Search(string text)
    {
        new Actions(Driver).MoveToElement(SearchTrigger).Perform();
        var searchInput = Wait.Until(d => d.FindElement(By.CssSelector(".header-search__form input[name='s']")));
        searchInput.SendKeys(text + Keys.Enter);
    }

    public void SwitchToLithuanian()
    {
        new Actions(Driver).MoveToElement(LanguageSwitcher).Perform();
        var ltLink = Wait.Until(d => d.FindElement(By.XPath("//ul[contains(@class, 'language-switcher')]//a[contains(@href, 'lt.ehuniversity.lt')]")));
        ltLink.Click();
    }
}