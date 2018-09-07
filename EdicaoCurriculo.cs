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
        public void AlteraDadosPessoais()
        {

           GoToUrl("/login-candidatos");                                         
           Login("drenatus","304050"); 
           //ClicarAtualizarCurriculo();  
           GoToUrl("/servicos/curriculo"); 
           ClicaFoto(); 
           AdicionaFoto("D:/VS/TesteVagas/TesteVagas/bin/Debug/dog_computer.jpg"); //atualizar caminho da foto      
           EditarNome("Diogo Teste Vagas " + GeraNumeroAleatorio());
           MensagemConfirmacao();        
           EditarDadosPessoais("01/01/1990",'M',"1",false,"5","31","1",GerarCpf());
           MensagemConfirmacao();
           EditarEndereco("31","04551000","26","88412","Bairro Teste " + GeraNumeroAleatorio(),"Rua Teste, N " + GeraNumeroAleatorio()); 
           MensagemConfirmacao();
           EditarInformacoesDeContato("teste@teste.com","teste@teste.com","11567785"+GeraNumeroAleatorio(),"1","21","9567785"+GeraNumeroAleatorio());
           MensagemConfirmacao();
           EditarDeficiencias(true,"250","","Teste Deficiência Física Amostra "+GeraNumeroAleatorio());
           MensagemConfirmacao();

           
           
        }

        [Test]
        public void AlteraExcluiFoto()
        {
            GoToUrl("/login-candidatos");                                         
            Login("drenatus","304050"); 
            GoToUrl("/servicos/curriculo");
            ClicaFoto();
            AdicionaFoto("D:/VS/TesteVagas/TesteVagas/bin/Debug/dog_computer.jpg"); //Atualizar caminho da foto
            ClicaFoto();
            ExcluiFoto();
        }

      //   [Test]
      //   public void AlteraObjetivos()
      //  {
            
      //  }


      //    [Test]
      //    public void AlteraResumoProfissional()
      //   {
            
      //   }

       //    [Test]
      //    public void AlteraFormacao()
      //   {
            
      //   }

          //    [Test]
      //    public void AlteraIdiomas()
      //   {
            
      //   }

          //    [Test]
      //    public void AlteraHistoricoProfissional()
      //   {
            
      //   }

          //    [Test]
      //    public void AlteraInformacoesComplementares()
      //   {
            
      //   }
        
         //    [Test]
      //    public void AlteraCurriculoCompleto()
      //   {
            
      //   }
}

}
