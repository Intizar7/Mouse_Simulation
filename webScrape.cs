/***
 * Download to desktop
 * http://api.256file.com/selenium.webdriverbackedselenium.dll/en-download-438525.html
 * */
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using MouseKeyboardActivityMonitor;
using Microsoft.Win32;
using System.Net.Http;
using System.Xml;
using OpenQA.Selenium.Interactions;

namespace Mouse_Simulation
{
    public partial class webScrape : Form
    {
        private List<Transaction> transactions = new List<Transaction>();
        public string filename;

        // array control
        Regex regex_array = new Regex(@"[\[0-9]+\]");

        // public string CurrentWindowHandle { get;}

        public webScrape()
        {
            InitializeComponent();
            //driver.ElementClicked += HandledEventHandler.Combine;
        }
        //  EventFiringWebDriver driver = new EventFiringWebDriver(webDriver);
        //  EventHandler handler = new EventHandler();
        //  driver.CurrentWindowHandle(handler);
        private bool stopReplay = false;
        private void escapeReplay(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                stopReplay = true;
        }
        private void save_link_Click(object sender, EventArgs e)
        {
   
            ChromeDriver driver = new ChromeDriver();
            //EventFiringWebDriver eventHandler = new EventFiringWebDriver(driver);
            //ChromeOptions options = new ChromeOptions();

            ////IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ////string title = (string)js.ExecuteScript("return document.addEvenListener('click', function(e){ return e.getPathTo(); });");
            //options.AddArguments();
            //driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
           
            if (txtlink.Text != null)
            {
                driver.Navigate().GoToUrl(txtlink.Text); 
            }
           // Console.WriteLine(driver);
        }
        private int GetOrderOfElemeInParent(HtmlElement element)
        {
            HtmlElement parent = element.Parent;
            HtmlElementCollection childNodes = parent.GetElementsByTagName(element.TagName);
            int nthChild = 0;
            foreach (HtmlElement elm in childNodes)
            {
                if (element.Equals(elm))
                    break;
                nthChild++;
            }
            return nthChild;
        }
    }
}
