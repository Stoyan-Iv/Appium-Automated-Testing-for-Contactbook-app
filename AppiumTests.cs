using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumTestsForExam
{
    public class AppiumTests
    {
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions() { PlatformName = "Android" };
            appiumOptions.AddAdditionalCapability("app", @"C:\Users\stoia\Desktop\Projects\contactbook-androidclient.apk");
            driver = new AndroidDriver<AndroidElement>(
               new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [Test]
        public void TestForContactBook()
        {

            var connectionButton = driver.FindElementById("contactbook.androidclient:id/buttonConnect");
            connectionButton.Click();

            var searchField = driver.FindElementById("contactbook.androidclient:id/editTextKeyword");
            searchField.SendKeys("steve");

            var searchButton = driver.FindElementById("contactbook.androidclient:id/buttonSearch");
            searchButton.Click();

            var firstNameResult = driver.FindElementById("contactbook.androidclient:id/textViewFirstName");
            var lastNameResult = driver.FindElementById("contactbook.androidclient:id/textViewLastName");

            // Assert is Steve Jobs dislpayed
            Assert.AreEqual("Steve", firstNameResult.Text);
            Assert.AreEqual("Jobs", lastNameResult.Text);

        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}