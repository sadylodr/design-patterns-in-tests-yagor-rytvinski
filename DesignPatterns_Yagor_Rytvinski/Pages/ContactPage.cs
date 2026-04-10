using OpenQA.Selenium;

namespace DesignPatterns_Yagor_Rytvinski.Pages;

public class ContactPage : BasePage
{
    private const string PageUrl = "https://en.ehuniversity.lt/research/projects/contact-us/";

    private readonly By _contactListLocator = By.CssSelector("ul.wp-block-list");

    public ContactPage(IWebDriver driver) : base(driver) { }

    public void Navigate()
    {
        Driver.Navigate().GoToUrl(PageUrl);
    }

    public string GetContactListText()
    {
        return Wait.Until(d => d.FindElement(_contactListLocator)).Text;
    }

    public bool IsEmailPresent(string email)
    {
        return GetContactListText().Contains(email);
    }
}