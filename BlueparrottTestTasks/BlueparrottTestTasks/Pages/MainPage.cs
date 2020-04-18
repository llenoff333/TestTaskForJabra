using OpenQA.Selenium;

namespace BlueparrottTestTasks.Pages
{
    public class MainPage: BasePage
    {
        public MainPage(IWebDriver driver) : base(driver){}

        public IWebElement Search => driver.FindElement(By.CssSelector(".search.title"));
        public IWebElement SearchInput => driver.FindElement(By.XPath("//input[@class='site-search__search__input']"));
        public IWebElement AllProducts => driver.FindElement(By.CssSelector(".top-menu__nav a[title='All Products']"));
        
    }
}
