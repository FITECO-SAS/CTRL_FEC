using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalyseEtControleFEC.Controller;

namespace AnalyseEtControleFEC.tests
{
    [TestClass]
    public class OpenFileTest
    {
        [TestInitialize]
        public void InitialisationDesTests()
        {
            
        }

        [TestMethod]
        public void isCellValid_Col1_Tests()
        {
            MainController main = new MainController();
            bool resultat = false;

            resultat = main.isCellValid(0, "");

            Assert.IsTrue(resultat);
         }

        [TestMethod]
        public void isCellValid_Col2_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col3_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col4_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col5_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col6_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col7_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col8_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col9_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col10_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col11_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col12_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col13_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col14_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col15_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col16_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col17_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }

        [TestMethod]
        public void isCellValid_Col18_Tests()
        {
            MainController main = new MainController();

            bool resultat = main.isCellValid(0, "JournalCode");
            Assert.AreEqual(true, resultat, "La valeur doit être égale à JournalCode");
        }
    }
}
