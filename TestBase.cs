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

      
        public void Login(string Login, string Senha)
        {   
            driver.FindElement(By.Id("login_candidatos_form_usuario")).SendKeys(Login);
            driver.FindElement(By.Id("login_candidatos_form_senha")).SendKeys(Senha);
            driver.FindElement(By.Name("commit")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("servicos-id")));
        }

        public void ClicarAtualizarCurriculo()
          
        {
            driver.FindElement(By.ClassName("edit-link-cv")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("nome-candidato")));
        }

        public void ClicaFoto()
        {
            wait.Until(ExpectedConditions.ElementExists(By.Id("cv-edit-foto")));
            driver.FindElement(By.ClassName("cv-foto")).Click();
        }


        public void MensagemConfirmacao()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("bt-fecha-confirmacao")));
            Assert.AreEqual("Dados salvos com sucesso.", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Não preenchido.'])[9]/following::p[1]")).Text);//não consegui fazer com elemento melhor
            driver.FindElement(By.Id("bt-fecha-confirmacao")).Click();
            Thread.Sleep(1000);
        }

        public void AdicionaFoto(string CaminhoFoto)
        {
          //wait.Until(ExpectedConditions.ElementExists(By.Id("adicionar-foto")));
          //driver.FindElement(By.Id("adicionar-foto")).Click();
            driver.FindElement(By.Id("candidato_imagem")).SendKeys(CaminhoFoto); 
        }

        public void ExcluiFoto()
        {
           wait.Until(ExpectedConditions.ElementExists(By.Id("cvRemoverFoto")));
           driver.FindElement(By.Id("cvRemoverFoto")).Click();
        }



          public void EditarNome(string NomeCandidato)
        {
            //driver.FindElement(By.ClassName("edit-link")).Click();
            driver.FindElement(By.XPath("//*[@id='cv-nome']/a")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.Id("curriculo_nome_completo")));
            driver.FindElement(By.Id("curriculo_nome_completo")).Clear();
            driver.FindElement(By.Id("curriculo_nome_completo")).SendKeys(NomeCandidato);
            driver.FindElement(By.XPath("//*[@id='nome-completo-edit']/div[2]/div/div/button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".nome-candidato")));
            Assert.AreEqual(NomeCandidato, driver.FindElement(By.CssSelector(".nome-candidato")).Text);      
           
        }  

           
   


       public void EditarDadosPessoais(string DtNascimento, char Genero, string EstCivil, bool Filhos, string Nacionalidade, string PaisDocs, string TipoDoc, string Doc)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='cv-dados']/a")));
            driver.FindElement(By.XPath("//*[@id='cv-dados']/a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dados_pessoais_data_de_nascimento")));
            driver.FindElement(By.Id("dados_pessoais_data_de_nascimento")).SendKeys(DtNascimento);
                
            if (Genero=='M')
                driver.FindElement(By.Id("dados_pessoais_genero_masculino")).Click();
            else
                driver.FindElement(By.Id("dados_pessoais_genero_feminino")).Click();
                           
            new SelectElement(driver.FindElement(By.Id("dados_pessoais_estado_civil"))).SelectByValue(EstCivil);
                
            if (Filhos)
                driver.FindElement(By.Id("filhos_sim")).Click();
            else
                driver.FindElement(By.Id("filhos_nao")).Click();
         
            new SelectElement(driver.FindElement(By.Id("dados_pessoais_pais_de_nacionalidade"))).SelectByValue(Nacionalidade);      
            new SelectElement(driver.FindElement(By.Id("dados_pessoais_documentos_attributes_0_pais_id"))).SelectByValue(PaisDocs);
            Thread.Sleep(1000);
            new SelectElement(driver.FindElement(By.Id("dados_pessoais_documentos_attributes_0_tipo_id"))).SelectByValue(TipoDoc);
            driver.FindElement(By.Id("dados_pessoais_documentos_attributes_0_numero")).Clear();
            driver.FindElement(By.Id("dados_pessoais_documentos_attributes_0_numero")).SendKeys(Doc);
            //driver.FindElement(By.Id("btn-add-doc")).Click();
            driver.FindElement(By.XPath("//*[@id='edit_dados_pessoais_63553688']/div[3]/button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='cv-dados']/a")));
        }



        public void  EditarEndereco(string Pais, string CEP, string UF, string Cidade, string Bairro, string Endereco)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='cv-endereco']/a")));
            driver.FindElement(By.XPath("//*[@id='cv-endereco']/a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("endereco_pais_id")));
            new SelectElement(driver.FindElement(By.Id("endereco_pais_id"))).SelectByValue(Pais);
            driver.FindElement(By.Id("endereco_cep")).SendKeys(CEP);
            Thread.Sleep(1000);
            new SelectElement(driver.FindElement(By.Id("endereco_uf_id"))).SelectByValue(UF);
            Thread.Sleep(1000);
            new SelectElement(driver.FindElement(By.Id("endereco_cidade_id"))).SelectByValue(Cidade);
            driver.FindElement(By.Id("endereco_bairro")).Clear();
            driver.FindElement(By.Id("endereco_bairro")).SendKeys(Bairro);
            driver.FindElement(By.Id("endereco_logradouro")).Clear();  
            driver.FindElement(By.Id("endereco_logradouro")).SendKeys(Endereco);        
            driver.FindElement(By.XPath("//*[@id='edit_endereco_']/div[3]/button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='cv-endereco']/a")));
        }

         public void EditarInformacoesDeContato(string Email, string ConfEmail, string Telefone, string PaisCel, string DDDCel, string NumCel)
        {  
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='informacoes-de-contato']/a")));
            driver.FindElement(By.XPath("//*[@id='informacoes-de-contato']/a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("informacoes_de_contato_email")));
            driver.FindElement(By.Id("informacoes_de_contato_email")).Clear();
            driver.FindElement(By.Id("informacoes_de_contato_email")).SendKeys(Email);
            driver.FindElement(By.Id("informacoes_de_contato_confirmacao_de_email")).Clear();
            driver.FindElement(By.Id("informacoes_de_contato_confirmacao_de_email")).SendKeys(ConfEmail);
            driver.FindElement(By.Id("informacoes_de_contato_telefone_numero")).Clear();
            driver.FindElement(By.Id("informacoes_de_contato_telefone_numero")).SendKeys(Telefone);
            new SelectElement(driver.FindElement(By.Id("informacoes_de_contato_celular_pais_id"))).SelectByValue(PaisCel);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("informacoes_de_contato_celular_ddd")));
            driver.FindElement(By.Id("informacoes_de_contato_celular_ddd")).Clear();
            driver.FindElement(By.Id("informacoes_de_contato_celular_ddd")).SendKeys(DDDCel);
            driver.FindElement(By.Id("informacoes_de_contato_celular_numero")).Clear();
            driver.FindElement(By.Id("informacoes_de_contato_celular_numero")).SendKeys(NumCel);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("informacoes_de_contato_aceita_receber_sms_de_empresas")));
            driver.FindElement(By.Id("informacoes_de_contato_aceita_receber_sms_de_empresas")).Click();
            driver.FindElement(By.XPath("//*[@id='edit_informacoes_de_contato_']/div[3]/button")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='informacoes-de-contato']/a")));
        }
                
                
            
        

          public void EditarDeficiencias(bool PossuiDef, string TipoDef, string TipoDefDetalhe, string DefObs)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='deficiencias']/a")));
            driver.FindElement(By.XPath("//*[@id='deficiencias']/a")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("deficiencias_possui_alguma_deficiencia_true")));

            if (PossuiDef)
            {
                driver.FindElement(By.Id("deficiencias_possui_alguma_deficiencia_true")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("caixa-deficiencia"))); 
                driver.FindElement(By.Id("deficiencias_possui_deficiencia_fisica")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='deficiencias_tipo_de_deficiencia_fisica']")));
                new SelectElement(driver.FindElement(By.Id("deficiencias_tipo_de_deficiencia_fisica"))).SelectByValue(TipoDef);
                driver.FindElement(By.Id("deficiencias_observacoes")).Clear();  
                driver.FindElement(By.Id("deficiencias_observacoes")).SendKeys(DefObs);  

            }
                                                    
            else 
                driver.FindElement(By.Id("deficiencias_possui_alguma_deficiencia_false")).Click();

                driver.FindElement(By.XPath("//*[@id='edit_deficiencias_63553688']/div[3]/button")).Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='deficiencias']/a")));
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

         //Gera um CPF aleatório
        public String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
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
