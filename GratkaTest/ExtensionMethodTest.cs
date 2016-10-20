using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gratka.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GratkaTest
{
    [TestClass]
    public class ExtensionMethodTest
    {
        [TestMethod]
        public void RemovePolishLetters()
        {
            var polish = "ąęóśłżźćńqwertyuiopasdfjklzxcvbnm";
            var noPolish = polish.RemovePolishLetters();

            Assert.AreEqual("aeoslzzcnqwertyuiopasdfjklzxcvbnm", noPolish);
        }
    }
}
