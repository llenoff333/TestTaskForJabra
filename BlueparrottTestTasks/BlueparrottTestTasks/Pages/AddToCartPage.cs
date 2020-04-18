using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BlueparrottTestTasks.Pages
{
    public class AddToCartPage : BasePage
    {
        public AddToCartPage(IWebDriver driver) : base(driver) { }

        public List<IWebElement> AddedProducts => driver.FindElements(By.CssSelector("tr[class*='Row'] td .dr_formerLink")).ToList();
    }
}
