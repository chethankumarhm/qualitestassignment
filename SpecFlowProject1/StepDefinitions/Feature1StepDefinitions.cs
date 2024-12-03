using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecFlowProject1.helper;
using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.CommonModels;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class Feature1StepDefinitions
    {
        private IWebDriver driver;


        [Given(@"launch the browser")]
        public void GivenLaunchTheBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [When(@"Enter the url")]
        public void WhenEnterTheUrl()
        {
            driver.Url = "https://www.bbc.co.uk/weather";
        }

        [Then(@"Enter the city name text into Enter a city textfield")]
        public void ThenEnterTheCityNameTextIntoEnterACityTextfield()
        {
            IWebElement search_input_box = driver.FindElement(By.XPath("//input[@id=\"ls-c-search__input-label\"]"));
            search_input_box.SendKeys(helpermethods.get_value_from_json("search input text"));
            Console.WriteLine(helpermethods.get_value_from_json("search input text"));

        }


        [Then(@"Click on search icon")]
        public void ThenClickOnSearchIcon()
        {

            IWebElement searchbutton = driver.FindElement(By.XPath("//button[@title='Search for a location']"));
            searchbutton.Click();
        }


        [Then(@"Click on the result which matches the city name")]
        public void ThenClickOnTheResultWhichMatchesTheCityName()
        {
            IReadOnlyCollection<IWebElement> searchresults = driver.FindElements(By.XPath("//div[@data-testid='search-results-list']//span"));


            foreach (IWebElement result in searchresults)
            {
                Console.WriteLine(result.Text);
                if (result.Text == helpermethods.get_value_from_json("city_expected"))
                {
                    Thread.Sleep(5000);
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", result);
                    break;
                } 
            }
        }



        [Then(@"Validate Maximum temperature of the day should be greater than minimum temperature of the day")]
        public void ThenValidateMaximumTemperatureOfTheDayShouldBeGreaterThanMinimumTemperatureOfTheDay()
        {
            string maxTempOfDay = driver.FindElement(By.XPath("(//a[@id=\"daylink-0\"]//span[@class='wr-value--temperature--c'])[1]")).Text;
            string minTempOfDay = driver.FindElement(By.XPath("(//a[@id=\"daylink-0\"]//span[@class='wr-value--temperature--c'])[2]")).Text;
            
            int maxtemp= int.Parse(maxTempOfDay.TrimEnd('°'));
            int mimtemp = int.Parse(minTempOfDay.TrimEnd('°'));

            Console.WriteLine(maxtemp);
            Console.WriteLine(mimtemp);

            if (maxtemp > mimtemp)
            {
                Console.WriteLine("Maximum tempreture of the day is greater than minimum tempreture = "+ maxtemp);
            }
            else
            {
                Console.WriteLine("failed");
            }
        }


        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            
        }


    }
}
      
    


        


    



