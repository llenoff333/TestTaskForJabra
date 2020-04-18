using BlueparrottTestTasks.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace BlueparrottTestTasks.Tests
{
    [TestFixture]
    public class TestSuite: BaseTest
    {
        [Test]
        public void TestAccessAndAddToCardViaSearch()
        {
            // Arrange
            var expectedItem = "BlueParrott S450-XT";

            // Act
            driver.Navigate().GoToUrl("https://www.blueparrott.com/");
            var blueparrottMainPage = new MainPage(driver);
            blueparrottMainPage.Search.Click();
            blueparrottMainPage.SearchInput.SendKeys(expectedItem);
            blueparrottMainPage.SearchInput.SendKeys(Keys.Enter);

            var searchResultPage = new SearchResultPage(driver);
            var parentHandle = driver.CurrentWindowHandle;
            searchResultPage.SearchResults.Where(item => item.Text == expectedItem).First().Click();
            var allWindowHandles = driver.WindowHandles;

            foreach (var handle in allWindowHandles)
            {
                if (handle != parentHandle)
                {
                    driver.SwitchTo().Window(handle);
                }
            }

            var s450XtPage = new S450_XtPage(driver);
            s450XtPage.AddToCartButton.Click();
            var addToCartButtonPage = new AddToCartPage(driver);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until(driver => addToCartButtonPage.AddedProducts.Count != 0 && addToCartButtonPage.AddedProducts.First().Displayed);
            var addedItemText = addToCartButtonPage.AddedProducts.First().Text;
            var addedItemsCount = addToCartButtonPage.AddedProducts.Count;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.True(addedItemsCount == 1, $"Actual added items count {addedItemsCount} is not 1 as expected.");

                Assert.True(addedItemText == expectedItem, $"Actual added item '{addedItemText}' is not equal '{expectedItem}'.");
            });
        }

        [Test]
        public void TestAccessAndAddToCardViaAllProducts()
        {
            // Arrange
            var expectedItem = "BlueParrott S450-XT";

            // Act
            driver.Navigate().GoToUrl("https://www.blueparrott.com/");
            var blueparrottMainPage = new MainPage(driver);
            Actions action = new Actions(driver);
            action.MoveToElement(blueparrottMainPage.AllProducts).Click().Perform();

            var allProductsPage = new AllProductsPage(driver);
            allProductsPage.SearchProducts.SendKeys(expectedItem);
            allProductsPage.SearchProducts.SendKeys(Keys.Enter);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => allProductsPage.AllProducts.Count == 1);
            allProductsPage.AllProducts.First().Click();

            var s450XtPage = new S450_XtPage(driver);
            s450XtPage.AddToCartButton.Click();
            var addToCartButtonPage = new AddToCartPage(driver);

            wait.IgnoreExceptionTypes(typeof(Exception));
            wait.Until(driver => addToCartButtonPage.AddedProducts.Count != 0 && addToCartButtonPage.AddedProducts.First().Displayed);
            var addedItemText = addToCartButtonPage.AddedProducts.First().Text;
            var addedItemsCount = addToCartButtonPage.AddedProducts.Count;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.True(addedItemsCount == 1, $"Actual added items count {addedItemsCount} is not 1 as expected.");

                Assert.True(addedItemText == expectedItem, $"Actual added item '{addedItemText}' is not equal '{expectedItem}'.");
            });
        }
    }
}
