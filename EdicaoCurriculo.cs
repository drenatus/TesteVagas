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
           //ClicarAtualizarCurriculo();  
           GoToUrl("/servicos/curriculo");
          // EditarNome("Teste Vagas " + GeraNumeroAleatorio());  
           AtualizaFoto();
           //EditarDadosPessoais()
           EditarInformacoesDeContato("teste@teste.com","teste@teste.com","1155555533","","","");
           EditarEndereco("31","04551000","26","88412","Bairro Teste " + GeraNumeroAleatorio(),"Rua Teste, N " + GeraNumeroAleatorio());  
           
        }



}

}
