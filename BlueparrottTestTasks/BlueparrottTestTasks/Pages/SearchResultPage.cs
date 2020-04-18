using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BlueparrottTestTasks.Pages
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver driver) : base(driver) { }

        public List<IWebElement> SearchResults => driver.FindElements(By.CssSelector(".search-result__products__name")).ToList();


    }
}
