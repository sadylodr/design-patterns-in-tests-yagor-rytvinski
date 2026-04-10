using DesignPatterns_Yagor_Rytvinski.Core;
using DesignPatterns_Yagor_Rytvinski.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DesignPatterns_Yagor_Rytvinski.Tests;

[Parallelizable(ParallelScope.Children)]
[TestFixture]
public class EHUTests
{
    private const string BaseUrl = "https://en.ehuniversity.lt/";

    [SetUp]
    public void Setup() => DriverManager.Instance.GetDriver().Navigate().GoToUrl(BaseUrl);

    [TearDown]
    public void Teardown() => DriverManager.Instance.QuitDriver();

    [Test]
    public void Test_Case_1_NavigateToAboutPage()
    {
        var mainPage = new MainPage(DriverManager.Instance.GetDriver());
        mainPage.OpenAboutPage();

        Assert.That(DriverManager.Instance.GetDriver().Url, Is.EqualTo("https://en.ehuniversity.lt/about/"));
    }

    [Test]
    [TestCase("admission")]
    public void Test_Case_2_SearchFunctionality(string searchTerm)
    {
        var mainPage = new MainPage(DriverManager.Instance.GetDriver());
        mainPage.Search(searchTerm);

        Assert.That(DriverManager.Instance.GetDriver().Url, Does.Contain(searchTerm));
    }

    [Test]
    public void Test_Case_3_LanguageChange()
    {
        var mainPage = new MainPage(DriverManager.Instance.GetDriver());
        mainPage.SwitchToLithuanian();

        Assert.That(DriverManager.Instance.GetDriver().Url, Does.Contain("lt.ehuniversity.lt"));
    }

    [Test]
    public void Test_Case_4_VerifyContactInfo()
    {
        var contactPage = new ContactPage(DriverManager.Instance.GetDriver());
    
        contactPage.Navigate();
        string contactText = contactPage.GetContactListText();

        Assert.That(contactText, Does.Contain("franciskscarynacr@gmail.com"));
    }
}