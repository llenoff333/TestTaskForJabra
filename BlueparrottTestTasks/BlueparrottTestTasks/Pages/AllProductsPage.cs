using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BlueparrottTestTasks.Pages
{
    public class AllProductsPage : BasePage
    {
        public AllProductsPage(IWebDriver driver) : base(driver) { }

        public IWebElement SearchProducts => driver.FindElement(By.CssSelector("#page-main-content div.container-fluid > div:nth-child(2) input"));
        public List<IWebElement> AllProducts => driver.FindElements(By.CssSelector(".jbr-btn.jbr-btn-large.jbr-btn--yellow.ng-scope")).ToList();
    }
}
