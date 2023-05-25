using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium.DevTools.V111.Network;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Selenium_Automation
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            var navigate = driver.Navigate();
            navigate.GoToUrl("https://cms.demo.katalon.com");
            driver.Manage().Window.Maximize();
            var list = driver.FindElements(By.ClassName("ellie-thumb-wrapper"));
            int i = 0;
            foreach (var element in list)
            {
                i++;
                if (i <= 4)
                {
                    element.FindElement(By.ClassName("ajax_add_to_cart")).Click();
                }
            }
            var val = driver.FindElement(By.Id("primary-menu")).FindElement(By.TagName("ul")).FindElement(By.TagName("li")).FindElement(By.TagName("a"));
            var href = val.GetAttribute("href");
            if (href.Contains("cart"))
            {
                val.Click();
            }

            var elements = driver.FindElements(By.ClassName("woocommerce-cart-form"));


            var tableRow = elements[0].FindElement(By.TagName("table"))
            .FindElement(By.TagName("tbody")).FindElements(By.TagName("tr"));

            foreach (var item in tableRow)
            {
                var isLowest = item;
                var tds = item.FindElements(By.TagName("td"));
                foreach (var t in tds)
                {
                    if (t.GetAttribute("class").Contains("product-price"))
                    {

                    }
                    if (t.GetAttribute("class").Contains("product-remove"))
                    {
                        t.FindElement(By.TagName("a")).Click();
                        break;
                    }
                }
                break;
            }
            Console.WriteLine($"Table Count{tableRow.Count}");

            ////driver.Quit();

            
        }

    }

}