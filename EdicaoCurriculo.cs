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
    public class EdicaoCurriculo : TestBase
    {

       [Test]
        public void EditarCurriculo()
        {
           GoToUrl("/login-candidatos");                                         
           Login("drenatus","304050"); 
           ClicarAtualizarCurriculo();  
           //GoToUrl("servicos/curriculo");
           EditarNome("Teste Vagas " + GeraNumeroAleatorio());   
           EditarEndereco("Brasil","04551000","SP","Sao Paulo","","Rua Teste");  

           
        }


        [Test]

        public void EdicaoDadosPessoais()
        {

        }

        [Test]
     public void EdicaoEndereco()
        {

        }

        [Test]
     public void EdicaoInfoContatos()
        {

        }

        [Test]
         public void EdicaoDeficiencias()
        {

        }


}

}
