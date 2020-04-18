using OpenQA.Selenium;

namespace BlueparrottTestTasks.Pages
{
    public class S450_XtPage : BasePage
    {
        public S450_XtPage(IWebDriver driver) : base(driver) { }

        public IWebElement AddToCartButton => driver.FindElement(By.CssSelector("product-action[p-id='selection.productId'] span"));
    }
}
