using AplicacaoLogar.Utils;
using OpenQA.Selenium;
using System;
using System.Threading;
namespace AplicacaoLogar
{
    public class Login
    {

        //na construtor da classe eu declaro que o drive vai receber o driver do Browser escolhido no Progam.
        public  IWebDriver Driver { get; set; }

        //link que vou acessar!
        public  string baseURL { get; set; } = "https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1576173731&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3d3738eaa5-1954-242a-4270-576cd5d9e819&id=292841&aadredir=1&whr=hotmail.com&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015";

        public Login(IWebDriver driver) => Driver = driver;
       
        /// <summary>
        /// No Maepamento da Página eu declaro que cada xPath/Id/Class é um Elemento que vou manipular depois.
        /// </summary>
        #region Mapeamento da Pagina

        //inserir o Email. sendkeys
        private IWebElement InserirEmail => Driver.FindElement(By.Id("i0116"));

        //proxima página click
        private IWebElement ProximaPagina => Driver.FindElement(By.Id("idSIButton9"));

        //inserir senha sendkeys
        private IWebElement InserirSenha => Driver.FindElement(By.Id("i0118"));


            //clicar menu
        private IWebElement ClicarMenu => Driver.FindElement(By.XPath("//*[@id='O365_MainLink_MePhoto']/div/div/div/div[2]/img"));

        private IWebElement ClicarSair => Driver.FindElement(By.Id("meControlSignoutLink"));

        #endregion

     
           /// <summary>
           /// Faço o login no Outlook com os parametros que é passado para esse método.
           /// </summary>
           /// <param name="email"></param>
           /// <param name="senha"></param>
           /// <returns></returns>
         public bool ExecutarLogin(string email,string senha)
        {
            try
            {
                Driver.Navigate().GoToUrl(baseURL);
                Driver.Manage().Window.Maximize();
                Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                InserirEmail.SendKeys(email);
                ProximaPagina.Click();
                Thread.Sleep(1000);
                InserirSenha.SendKeys(senha);
                Thread.Sleep(1000);
                ProximaPagina.Click();
                Thread.Sleep(TimeSpan.FromSeconds(10));
                ClicarMenu.Click();
                Thread.Sleep(1000);
                ClicarSair.Click();
                return true;
            }
            catch (Exception e )
            {
                Driver.Dispose();
                Console.WriteLine($"Erro ao ExecutarLogin: {e.Message}");
                return false;
            }
        }
            
    }
}
