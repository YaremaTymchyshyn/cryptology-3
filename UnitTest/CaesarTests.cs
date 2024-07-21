using static Crypto.Classes.Caeser;
namespace UnitTest
{
    [TestClass]
    public class CaesarTests
    {
        [TestMethod]
        public void TestEnglishEncryption()
        {
            string input = "Hello World!";
            string expected = "mjqqteatwqi!";
            int step = 5;
            string output = English_Encryption(input, step);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianEncryption()
        {
            string input = "Привіт Світ!";
            string expected = "фхлємчґцємч!";
            int step = 5;
            string output = Ukrainian_Encryption(input, step);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestEnglishDecryption()
        {
            string input = "mjqqteatwqi!";
            string expected = "hello world!";
            int step = 5;
            string output = English_Decryption(input, step);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianDecryption()
        {
            string input = "фхлємчґцємч!";
            string expected = "привіт світ!";
            int step = 5;
            string output = Ukrainian_Decryption(input, step);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestEnglishEncryptionFail()
        {
            string input = "text";
            string expected = "text";
            int step = 5;
            string output = English_Encryption(input, step);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianEncryptionFail()
        {
            string input = "текст";
            string expected = "текст";
            int step = 5;
            string output = Ukrainian_Encryption(input, step);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestEnglishDecryptionFail()
        {
            string input = "text";
            string expected = "text";
            int step = 5;
            string output = English_Decryption(input, step);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestUkrainianDecryptionFail()
        {
            string input = "текст";
            string expected = "текст";
            int step = 5;
            string output = Ukrainian_Decryption(input, step);
            Assert.AreNotEqual(expected, output);
        }
    }
}