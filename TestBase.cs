using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestBase
    {
        public IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        public WebDriverWait wait;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.vagas.com.br";
            verificationErrors = new StringBuilder();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            wait = new WebDriverWait(driver, new TimeSpan(0, 2, 9));
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        

       protected void GoToUrl(string pathAndQuery)
        {

        driver.Navigate().GoToUrl(baseURL + pathAndQuery);

        }

      
        public void Login(string login, string senha)
        {   
            driver.FindElement(By.Id("login_candidatos_form_usuario")).SendKeys(login);
            driver.FindElement(By.Id("login_candidatos_form_senha")).SendKeys(senha);
            driver.FindElement(By.Name("commit")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("servicos-id")));
        }

          public void ClicarAtualizarCurriculo()
          
          {
            driver.FindElement(By.ClassName("edit-link-cv")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("nome-candidato")));
          }

           public void EditarNome(string nomecandidato)
        {
            driver.FindElement(By.ClassName("edit-link")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("curriculo_nome_completo")));
            driver.FindElement(By.Id("curriculo_nome_completo")).Clear();
            driver.FindElement(By.Id("curriculo_nome_completo")).SendKeys(nomecandidato);
            driver.FindElement(By.CssSelector(".btn-success")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".nome-candidato")));
            Assert.AreEqual(nomecandidato, driver.FindElement(By.CssSelector(".nome-candidato")).Text);
            
        }

        public void EditarEndereco()
        {

        }





        // Generate Random Email Address 
        public static string GenerateEmailAddress()
        {
            return "teste" + GeraNumeroAleatorio() + "@teste.com";
        }

        //Generate RamdomNumber

       public static int GeraNumeroAleatorio()
        {
            return new Random().Next(1, 99);
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
