using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataRoman
{
    [TestClass]
    public class NumericToRomanTest
    {

        KataRoman kr;

        /// <summary>
        /// Initialise les tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            kr = new KataRoman();
        }
        
        /// <summary>
        /// Permet de tester si ca retourne vide quand on envoie 0.
        /// </summary>
        [TestMethod]
        public void ReturnEmptyIfNumericIsZeroTest()
        {
            var output = kr.Transform("0");
            Assert.AreEqual(string.Empty, output); 
        }

        /// <summary>
        /// Permet de tester si on renvoi vide quand on envoie null.
        /// </summary>
        [TestMethod]
        public void ReturnEmptyIfRomanIsNullTest()
        {
            var output = kr.Transform("");
            Assert.AreEqual(string.Empty, output);
        }

        /// <summary>
        /// Permet de tester la conversion des chiffres numériques vers les chiffres romains.
        /// </summary>
        [TestMethod]
        public void NumToRomanTest()
        {
            var output = kr.NumToRoman(1);
            Assert.AreEqual("I", output);
            output = kr.NumToRoman(5);
            Assert.AreEqual("V", output);
            output = kr.NumToRoman(10);
            Assert.AreEqual("X", output);
            output = kr.NumToRoman(4);
            Assert.AreEqual("IV", output);
            output = kr.NumToRoman(199);
            Assert.AreEqual("CXCIX", output);
        }

        /// <summary>
        /// Permet de tester la convertion des chiffres romains en numérique.
        /// </summary>
        [TestMethod]
        public void RomanToNumTest()
        {
            var output = kr.RomanToNum("I");
            Assert.AreEqual("1", output);
            output = kr.RomanToNum("VIII");
            Assert.AreEqual("8", output);
            output = kr.RomanToNum("III");
            Assert.AreEqual("3", output);
            output = kr.RomanToNum("XII");
            Assert.AreEqual("12", output);
            output = kr.RomanToNum("IV");
            Assert.AreEqual("4", output);
            output = kr.RomanToNum("CXCIX");
            Assert.AreEqual("199", output);
        }


        [TestMethod]
        public void NumericOrRomanTest()
        {

            var output = kr.Transform("12");
            Assert.AreEqual("XII", output);
            output = kr.Transform("8");
            Assert.AreEqual("VIII", output);
            output = kr.Transform("80");
            Assert.AreEqual("LXXX", output);
            output = kr.Transform("1");
            Assert.AreEqual("I", output);

            output = kr.Transform("XII");
            Assert.AreEqual("12", output);
            output = kr.Transform("VIII");
            Assert.AreEqual("8", output);
            output = kr.Transform("LXXX");
            Assert.AreEqual("80", output);
            output = kr.Transform("I");
            Assert.AreEqual("1", output);
        }
        
    }
}
