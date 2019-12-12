using AplicacaoLogar.Utils;
using OpenQA.Selenium;
using System;

namespace AplicacaoLogar
{
    public class Program
    { 
        static void Main(string[] args)
        {
            try
            {
                SetarBrowser set = new SetarBrowser();
                
                Login _login = new Login(set.BuscarDriverLocal(Browsers.Chrome));

                if (!_login.ExecutarLogin("email", "senha"))
                    Console.WriteLine("Erro ao Executar o login.");

                else
                Console.WriteLine("\n\nLogin realizado com sucesso...");

                set.FinalizarTeste();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro : {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
