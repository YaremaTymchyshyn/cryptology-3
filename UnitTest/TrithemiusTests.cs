using static Crypto.Classes.Trithemius;
namespace UnitTest
{
    [TestClass]
    public class TrithemiusTests
    {
        [TestMethod]
        public void TestLinearEnglishEncryption()
        {
            string input = "Hello World!";
            string expected = "jhpqugdxawp!";
            int[] vector = { 1, 2 };
            string output = Trithemius_English_Encryption(input, "Linear", vector);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestNonlinearEnglishEncryption()
        {
            string input = "Hello World!";
            string excepted = "kkwcokt tfs!";
            int[] vector = { 1, 2, 3 };
            string output = Trithemius_English_Encryption(input, "Nonlinear", vector);
            Assert.AreEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganEnglishEncryption()
        {
            string input = "Hello World!";
            string excepted = " pjdzyozpdo!";
            string slogan = "sky";
            string output = Trithemius_English_Encryption(input, "Slogan", null, slogan);
            Assert.AreEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearUkrainianEncryption()
        {
            string input = "Привіт Світ!";
            string expected = "фщупяйшрдо !";
            int[] vector = { 4, 5 };
            string output = Trithemius_Ukrainian_Encryption(input, "Linear", vector);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestNonLinearUkrainianEncryption()
        {
            string input = "Привіт Світ!";
            string excepted = "хбжх нзряїв!";
            int[] vector = { 4, 5, 6 };
            string output = Trithemius_Ukrainian_Encryption(input, "Nonlinear", vector);
            Assert.AreEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganUkrainianEncryption()
        {
            string input = "Привіт Світ!";
            string excepted = "гчїсщщбероф!";
            string slogan = "небо";
            string output = Trithemius_Ukrainian_Encryption(input, "Slogan", null, slogan);
            Assert.AreEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearEnglishDecryption()
        {
            string input = "jhpqugdxawp!";
            string expected = "hello world!";
            int[] vector = { 1, 2 };
            string output = Trithemius_English_Decryption(input, "Linear", vector);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestNonlinearEnglishDecryption()
        {
            string input = "kkwcokt tfs!";
            string excepted = "hello world!";
            int[] vector = { 1, 2, 3 };
            string output = Trithemius_English_Decryption(input, "Nonlinear", vector);
            Assert.AreEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganEnglishDecryption()
        {
            string input = " pjdzyozpdo!";
            string excepted = "hello world!";
            string slogan = "sky";
            string output = Trithemius_English_Decryption(input, "Slogan", null, slogan);
            Assert.AreEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearUkrainianDecryption()
        {
            string input = "фщупяйшрдо !";
            string expected = "привіт світ!";
            int[] vector = { 4, 5 };
            string output = Trithemius_Ukrainian_Decryption(input, "Linear", vector);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void TestNonLinearUkrainianDecryption()
        {
            string input = "хбжх нзряїв!";
            string excepted = "привіт світ!";
            int[] vector = { 4, 5, 6 };
            string output = Trithemius_Ukrainian_Decryption(input, "Nonlinear", vector);
            Assert.AreEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganUkrainianDecryption()
        {
            string input = "гчїсщщбероф!";
            string excepted = "привіт світ!";
            string slogan = "небо";
            string output = Trithemius_Ukrainian_Decryption(input, "Slogan", null, slogan);
            Assert.AreEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearEnglishEncryptionFail()
        {
            string input = "text";
            string expected = "text";
            int[] vector = { 1, 2 };
            string output = Trithemius_English_Encryption(input, "Linear", vector);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestNonlinearEnglishEncryptionFail()
        {
            string input = "text";
            string excepted = "text";
            int[] vector = { 1, 2, 3 };
            string output = Trithemius_English_Encryption(input, "Nonlinear", vector);
            Assert.AreNotEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganEnglishEncryptionFail()
        {
            string input = "text";
            string excepted = "text";
            string slogan = "sky";
            string output = Trithemius_English_Encryption(input, "Slogan", null, slogan);
            Assert.AreNotEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearUkrainianEncryptionFail()
        {
            string input = "текст";
            string expected = "текст";
            int[] vector = { 4, 5 };
            string output = Trithemius_Ukrainian_Encryption(input, "Linear", vector);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestNonLinearUkrainianEncryptionFail()
        {
            string input = "текст";
            string excepted = "текст";
            int[] vector = { 4, 5, 6 };
            string output = Trithemius_Ukrainian_Encryption(input, "Nonlinear", vector);
            Assert.AreNotEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganUkrainianEncryptionFail()
        {
            string input = "текст";
            string excepted = "текст";
            string slogan = "небо";
            string output = Trithemius_Ukrainian_Encryption(input, "Slogan", null, slogan);
            Assert.AreNotEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearEnglishDecryptionFail()
        {
            string input = "text";
            string expected = "text";
            int[] vector = { 1, 2 };
            string output = Trithemius_English_Decryption(input, "Linear", vector);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestNonlinearEnglishDecryptionFail()
        {
            string input = "text";
            string excepted = "text";
            int[] vector = { 1, 2, 3 };
            string output = Trithemius_English_Decryption(input, "Nonlinear", vector);
            Assert.AreNotEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganEnglishDecryptionFail()
        {
            string input = " text";
            string excepted = "text";
            string slogan = "sky";
            string output = Trithemius_English_Decryption(input, "Slogan", null, slogan);
            Assert.AreNotEqual(excepted, output);
        }



        [TestMethod]
        public void TestLinearUkrainianDecryptionFail()
        {
            string input = "текст";
            string expected = "текст";
            int[] vector = { 4, 5 };
            string output = Trithemius_Ukrainian_Decryption(input, "Linear", vector);
            Assert.AreNotEqual(expected, output);
        }

        [TestMethod]
        public void TestNonLinearUkrainianDecryptionFail()
        {
            string input = "текст";
            string excepted = "текст";
            int[] vector = { 4, 5, 6 };
            string output = Trithemius_Ukrainian_Decryption(input, "Nonlinear", vector);
            Assert.AreNotEqual(excepted, output);
        }

        [TestMethod]
        public void TestSloganUkrainianDecryptionFail()
        {
            string input = "текст";
            string excepted = "текст";
            string slogan = "небо";
            string output = Trithemius_Ukrainian_Decryption(input, "Slogan", null, slogan);
            Assert.AreNotEqual(excepted, output);
        }
    }
}
