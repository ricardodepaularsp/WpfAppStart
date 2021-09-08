using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfAppStart.ViewModel;
using WpfAppStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppStart.ViewModel.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {

        [TestMethod]
        public void InicioThreadIncluirItem()
        {
            MainWindowViewModel teste = new MainWindowViewModel();
           var test = teste.startThreadXP();
            Assert.AreEqual(true, test);
        }

        [TestMethod]
        public void InicioThreadAlteraritem()
        {
            MainWindowViewModel teste = new MainWindowViewModel();
            var test = teste.startAlteraThreadXP();
            Assert.AreEqual(true, test);
        }

        [TestMethod()]
        public void RandomNumberTest()
        {

            var teste = MainWindowViewModel.RandomNumber(8);
            Assert.AreEqual(true, Verifica(teste)=="Numeros");

        }

        [TestMethod()]
        public void RandomStringTest()
        {
            var teste = MainWindowViewModel.RandomString(8);
            Assert.AreEqual(true, Verifica(teste) == "Letras");
        }

       
        public string Verifica(string texto)
        {
            if (this.contemLetras(texto) && this.contemNumeros(texto))
            {
                return "LetrasNumeros";
            }
            else if (this.contemLetras(texto))
            {
                return "Letras";
            }
            else if (this.contemNumeros(texto))
            {
                return "Numeros";
            }else
            {
                return "";
            }


        }

        public bool contemLetras(string texto)
        {
            if (texto.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }

        public bool contemNumeros(string texto)
        {
            if (texto.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }
    }
}