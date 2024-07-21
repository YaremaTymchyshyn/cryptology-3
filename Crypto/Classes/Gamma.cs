using System;

namespace Crypto.Classes
{
    public class Gamma
    {
        const string Ukrainian_Alphabet = " абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        const string English_Alphabet = " abcdefghijklmnopqrstuvwxyz";

        public static string key { get; set; } = "";

        public static void GenerateKey(int length, string language)
        {
            if (language == "English")
            {
                language = English_Alphabet;
            }
            else if (language == "Ukrainian")
            {
                language = Ukrainian_Alphabet;
            }

            Random random = new Random();
            string gamma_key = "";

            for (int i = 0; i < length + 5; i++)
            {
                gamma_key += language[random.Next(0, language.Length)];
            }

            key = gamma_key;
        }

        public static string Gamma_English_Encryption(string text)
        {
            string encrypted_text = "";
            int gammaIndex = 0;
            string key = "secretkey";

            for (int i = 0; i < text.Length; i++)
            {
                var letter = text[i].ToString().ToLower();
                var letterIndex = English_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    encrypted_text += text[i];
                }
                else
                {
                    var keyLetter = key[gammaIndex % key.Length].ToString().ToLower();
                    var keyLetterIndex = English_Alphabet.IndexOf(keyLetter);
                    encrypted_text += English_Alphabet[(English_Alphabet.Length + letterIndex + keyLetterIndex) % English_Alphabet.Length];
                    gammaIndex++;
                }
            }
            return encrypted_text;
        }

        public static string Gamma_English_Decryption(string text)
        {
            string decrypted_text = "";
            int gammaIndex = 0;
            string key = "secretkey";

            for (int i = 0; i < text.Length; i++)
            {
                var letter = text[i].ToString().ToLower();
                var letterIndex = English_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    decrypted_text += text[i];
                }
                else
                {
                    var keyLetter = key[gammaIndex % key.Length].ToString().ToLower();
                    var keyLetterIndex = English_Alphabet.IndexOf(keyLetter);
                    decrypted_text += English_Alphabet[(English_Alphabet.Length + letterIndex - keyLetterIndex) % English_Alphabet.Length];
                    gammaIndex++;
                }
            }
            return decrypted_text;
        }

        public static string Gamma_English_Symmetrical(string text)
        {
            string encrypted_text = "";
            int gammaIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                var letter = char.ToLower(text[i]);
                var letterIndex = English_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    encrypted_text += text[i];
                }
                else
                {
                    encrypted_text += English_Alphabet[(letter ^ key[gammaIndex]) % English_Alphabet.Length];
                    gammaIndex++;
                }
            }
            return encrypted_text;
        }

        public static string Gamma_Ukrainian_Encryption(string text, string key)
        {
            string encrypted_text = "";
            int gammaIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                var letter = text[i].ToString().ToLower();
                var letterIndex = Ukrainian_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    encrypted_text += text[i];
                }
                else
                {
                    encrypted_text += Ukrainian_Alphabet[(Ukrainian_Alphabet.Length + letterIndex + Ukrainian_Alphabet.IndexOf(key[gammaIndex])) % Ukrainian_Alphabet.Length];
                    gammaIndex++;
                }
            }
            return encrypted_text;
        }

        public static string Gamma_Ukrainian_Decryption(string text, string key)
        {
            string decrypted_text = "";
            int gammaIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                var letter = text[i].ToString().ToLower();
                var letterIndex = Ukrainian_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    decrypted_text += text[i];
                }
                else
                {
                    decrypted_text += Ukrainian_Alphabet[(Ukrainian_Alphabet.Length + letterIndex - Ukrainian_Alphabet.IndexOf(key[gammaIndex])) % Ukrainian_Alphabet.Length];
                    gammaIndex++;
                }
            }
            return decrypted_text;
        }

        public static string Gamma_Ukrainian_Symmetrical(string text)
        {
            string encrypted_text = "";
            int gammaIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                var letter = char.ToLower(text[i]);
                var letterIndex = Ukrainian_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    encrypted_text += text[i];
                }
                else
                {
                    encrypted_text += Ukrainian_Alphabet[(letter ^ key[gammaIndex]) % Ukrainian_Alphabet.Length];
                    gammaIndex++;
                }
            }
            return encrypted_text;
        }
    }
}
