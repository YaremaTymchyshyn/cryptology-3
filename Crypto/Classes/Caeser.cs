namespace Crypto.Classes
{
    public class Caeser
    {
        const string Ukrainian_Alphabet = " абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        const string English_Alphabet = " abcdefghijklmnopqrstuvwxyz";

        public static string English_Encryption(string text, int key)
        {
            string encrypted_text = "";

            for(int i = 0; i < text.Length; i++)
            {
                var letter = text[i].ToString().ToLower();
                var letterIndex = English_Alphabet.IndexOf(letter);

                if (letterIndex == -1)
                {
                    encrypted_text += text[i];
                }
                else
                {
                    encrypted_text += English_Alphabet[(English_Alphabet.Length + letterIndex + key) % English_Alphabet.Length];
                }
            }
            return encrypted_text;
        }

        public static string English_Decryption(string text, int key)
        {
            string decrypted_text = "";
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
                    decrypted_text += English_Alphabet[(English_Alphabet.Length + letterIndex - key) % English_Alphabet.Length];
                }

            }
            return decrypted_text;
        }

        public static string Ukrainian_Encryption(string text, int key)
        {
            string encrypted_text = "";
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
                    encrypted_text += Ukrainian_Alphabet[(Ukrainian_Alphabet.Length + letterIndex + key) % Ukrainian_Alphabet.Length];
                }

            }
            return encrypted_text;
        }

        public static string Ukrainian_Decryption(string text, int key)
        {
            string encrypted_text = "";
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
                    encrypted_text += Ukrainian_Alphabet[(Ukrainian_Alphabet.Length + letterIndex - key) % Ukrainian_Alphabet.Length];
                }

            }
            return encrypted_text;
        }
    }
}
