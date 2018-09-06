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
        public void AlteraCurriculoCompleto()
        {
           GoToUrl("/login-candidatos");                                         
           Login("drenatus","304050"); 
           //ClicarAtualizarCurriculo();  
           GoToUrl("/servicos/curriculo"); 
           ClicaFoto(); 
           AdicionaFoto("D:/VS/TesteVagas/TesteVagas/bin/Debug/dog_computer.jpg");  //atualizar caminho da foto      
           EditarNome("Diogo Teste Vagas " + GeraNumeroAleatorio());        
           EditarDadosPessoais("01/01/1990",'F',"1",false,"5","1","1",GerarCpf());
           MensagemConfirmacao();
           EditarEndereco("31","04551000","26","88412","Bairro Teste " + GeraNumeroAleatorio(),"Rua Teste, N " + GeraNumeroAleatorio());
           EditarInformacoesDeContato("teste@teste.com","teste@teste.com","11567785"+GeraNumeroAleatorio(),"1","21","9567785"+GeraNumeroAleatorio());
           EditarDeficiencias(false,"250","","Teste Deficiência Física Amostra "+GeraNumeroAleatorio());

           
           
        }

        [Test]
        public void FluxoFoto()
        {
            GoToUrl("/login-candidatos");                                         
            Login("drenatus","304050"); 
            GoToUrl("/servicos/curriculo");
            ClicaFoto();
      //    AdicionaFoto("D:/VS/TesteVagas/TesteVagas/bin/Debug/dog_computer.jpg");
         
            ClicaFoto();
            ExcluiFoto();
        }

        [Test]
        public void AlterarDadosPessoais()
        {
            GoToUrl("/login-candidatos");                                         
            Login("drenatus","304050"); 
            GoToUrl("/servicos/curriculo");
           

        }


        [Test]
          public void AlterarEndereco()
        {

        }


        [Test]
           public void AlterarInformacoesDeContato()
        {

        }


        [Test]
           public void AlterarDeficiencias()
        {

        }


}

}
