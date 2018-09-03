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
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("servicos-id")));
        }

        public void ClicarAtualizarCurriculo()
          
        {
            driver.FindElement(By.ClassName("edit-link-cv")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("nome-candidato")));
        }

        public void BotaoSalvar()
        {
           driver.FindElement(By.CssSelector(".btn-success")).Click();
        }

        public void BotaoCancelar()
        {
           driver.FindElement(By.CssSelector(".btn-danger")).Click();
        }

        public void AtualizaFoto()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cv-edit-foto")));
            driver.FindElement(By.ClassName("cv-foto")).Click();
            driver.FindElement(By.Id("adicionar-foto")).Click();
            driver.FindElement(By.Id("candidato_imagem")).SendKeys("C:/bia dog.jpg");
        }



          public void EditarNome(string nomecandidato)
        {
            //driver.FindElement(By.ClassName("edit-link")).Click();
            driver.FindElement(By.Id("cv-nome")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("curriculo_nome_completo")));
            driver.FindElement(By.Id("curriculo_nome_completo")).Clear();
            driver.FindElement(By.Id("curriculo_nome_completo")).SendKeys(nomecandidato);
            BotaoSalvar();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".nome-candidato")));
            Assert.AreEqual(nomecandidato, driver.FindElement(By.CssSelector(".nome-candidato")).Text);      
        }

           
            public void AdicinarFoto()
           
        {

        }


       public void EditarDadosPessoais(string dtnascimento, string genero, string estadocivil, string filhos, string nacionalidade, string paisdocs, string tipodoc, string doc)
        {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cv-dados")));
                driver.FindElement(By.Id("cv-dados")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dados_pessoais_data_de_nascimento")));
                driver.FindElement(By.Id("dados_pessoais_data_de_nascimento")).SendKeys(dtnascimento);
                //decidir como clicar no genero, radio button 
                new SelectElement(driver.FindElement(By.Id("dados_pessoais_estado_civil"))).SelectByText(estadocivil);
                //decidir como clicar no filhos, radio button 
                new SelectElement(driver.FindElement(By.Id("dados_pessoais_pais_de_nacionalidade"))).SelectByText(nacionalidade);      
        }



      public void  EditarEndereco(string pais, string cep, string uf, string cidade, string bairro, string endereco)
        {
          wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='cv-endereco']/a")));
          driver.FindElement(By.XPath("//*[@id='cv-endereco']/a")).Click();
          wait.Until(ExpectedConditions.ElementIsVisible(By.Id("endereco_pais_id")));
          new SelectElement(driver.FindElement(By.Id("endereco_pais_id"))).SelectByValue(pais);
          driver.FindElement(By.Id("endereco_cep")).SendKeys(cep);
          Thread.Sleep(1000);
          new SelectElement(driver.FindElement(By.Id("endereco_uf_id"))).SelectByValue(uf);
          Thread.Sleep(1000);
          new SelectElement(driver.FindElement(By.Id("endereco_cidade_id"))).SelectByValue(cidade);
          driver.FindElement(By.Id("endereco_bairro")).Clear();
          driver.FindElement(By.Id("endereco_bairro")).SendKeys(bairro);
          driver.FindElement(By.Id("endereco_logradouro")).Clear();  
          driver.FindElement(By.Id("endereco_logradouro")).SendKeys(endereco);        
          driver.FindElement(By.XPath("//*[@id='edit_endereco_']/div[3]/button")).Click();
        }

         public void EditarInformacoesDeContato(string email, string confemail, string telefone, string paiscel, string dddcel, string numcel)
        {  
             wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='informacoes-de-contato']/a")));
             driver.FindElement(By.XPath("//*[@id='informacoes-de-contato']/a")).Click();
             wait.Until(ExpectedConditions.ElementIsVisible(By.Id("informacoes_de_contato_email")));
             driver.FindElement(By.Id("informacoes_de_contato_email")).SendKeys(email);
             driver.FindElement(By.Id("informacoes_de_contato_confirmacao_de_email")).SendKeys(confemail);
            // driver.FindElement(By.Id("informacoes_de_contato_telefone_numero")).SendKeys(telefone);
           //  new SelectElement(driver.FindElement(By.Id("informacoes_de_contato_celular_pais_id"))).SelectByText(paiscel);
           //  driver.FindElement(By.Id("informacoes_de_contato_celular_ddd")).SendKeys(dddcel);
           //  driver.FindElement(By.Id("informacoes_de_contato_celular_numero")).SendKeys(numcel);
           //  driver.FindElement(By.Id("informacoes_de_contato_aceita_receber_sms_de_empresas")).Click();
             driver.FindElement(By.Id("edit_informacoes_de_contato_")).Click();
        }
                
                
            
        

          public void EditarDeficiencias()
        {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='deficiencias']/a")));
                driver.FindElement(By.XPath("//*[@id='deficiencias']/a")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("deficiencias_possui_alguma_deficiencia_true")));
                //decidir deficiencias sim nao radio button
        }

       


        // Generate Random Email Address 
        public static string GenerateEmailAddress()
        {
            return "teste.diogo" + GeraNumeroAleatorio() + "@testevagas.com";
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
