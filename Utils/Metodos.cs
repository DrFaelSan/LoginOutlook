using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
namespace AplicacaoLogar.Utils
{
    public class SetarBrowser 
    {
        private  IWebDriver Driver { get; set; }

        
        public IWebDriver BuscarDriverLocal(Browsers browsers)
        {
            switch (browsers)
            {
                case Browsers.Chrome: Driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory); break;
                case Browsers.FireFox: Driver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory); break;
                case Browsers.Edge: Driver = new EdgeDriver(AppDomain.CurrentDomain.BaseDirectory); break;
            }

            return Driver;
        }

        public void FinalizarTeste() => Driver.Dispose();
      

        #region JavaScript
        public static void ExecutarJavaScript(IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteAsyncScript(script);
        }
        #endregion
    }
}
