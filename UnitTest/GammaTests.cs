using Crypto.Classes;
using static Crypto.Classes.Gamma;
namespace UnitTest
{
    [TestClass]
    public class GammaTests
    {
        [TestMethod]
        public void TestEnglishEncryption()
        {
            string input = "Hello World!";
            Gamma.key = "fkfza qxctymbmepi";
            string expected = "nprkp mlueb!";
            string output = Gamma_English_Encryption(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianEncryption()
        {
            string input = "Привіт Світ!";
            Gamma.key = "рряєзамдцюивізмшш";
            string expected = "еєзисумчщз !";
            string output = Gamma_Ukrainian_Encryption(input, key);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestEnglishDecryption()
        {
            string input = "nprkp mlueb!";
            Gamma.key = "fkfza qxctymbmepi";
            string expected = "hello world!";
            string output = Gamma_English_Decryption(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianDecryption()
        {
            string input = "еєзисумчщз !";
            Gamma.key = "рряєзамдцюивізмшш";
            string expected = "привіт світ!";
            string output = Gamma_Ukrainian_Decryption(input, key);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestEnglishSymmetricalEncryption()
        {
            string input = "Hello World!";
            Gamma.key = "czumnkucyockuwqky";
            string expected = "kdyaaublkcg!";
            string output = Gamma_English_Symmetrical(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianSymmetricalEncryption()
        {
            string input = "Привіт Світ!";
            Gamma.key = "зявхгсцххйпеюулпт";
            string expected = "єкзмявггмжт!";
            string output = Gamma_Ukrainian_Symmetrical(input);
            Assert.AreEqual(expected, output);
        }
    }
}
