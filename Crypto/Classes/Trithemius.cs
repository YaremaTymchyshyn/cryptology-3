namespace Crypto.Classes
{
    public class Trithemius
    {
        const string Ukrainian_Alphabet = " абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        const string English_Alphabet = " abcdefghijklmnopqrstuvwxyz";

        public static string Trithemius_English_Encryption(string text, string key_type, int[] vector, string slogan = "")
        {
            string encrypted_text = "";

            if (key_type == "Linear")
            {
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
                        var key = vector[0] * i + vector[1];
                        encrypted_text += English_Alphabet[(letterIndex + key) % English_Alphabet.Length];
                    }
                }
            }
            else if (key_type == "Nonlinear")
            {
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
                        var key = vector[0] * i * i + vector[1] * i + vector[2];
                        encrypted_text += English_Alphabet[(letterIndex + key) % English_Alphabet.Length];
                    }
                }
            }
            else
            {
                int sloganIndex = 0;

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
                        var key = English_Alphabet.IndexOf(slogan[sloganIndex]);

                        sloganIndex++;
                        if (sloganIndex >= slogan.Length)
                        {
                            sloganIndex = 0;
                        }
                        encrypted_text += English_Alphabet[(letterIndex + key) % English_Alphabet.Length];
                    }
                }
            }
            return encrypted_text;
        }

        public static string Trithemius_English_Decryption(string text, string key_type, int[] vector, string slogan = "")
        {
            string decrypted_text = "";

            if (key_type == "Linear")
            {
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
                        var key = vector[0] * i + vector[1];
                        decrypted_text += English_Alphabet[(letterIndex + English_Alphabet.Length - (key % English_Alphabet.Length)) % English_Alphabet.Length];
                    }
                }
            }
            else if (key_type == "Nonlinear")
            {
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
                        var key = vector[0] * i * i + vector[1] * i + vector[2];
                        decrypted_text += English_Alphabet[(letterIndex + English_Alphabet.Length - (key % English_Alphabet.Length)) % English_Alphabet.Length];
                    }
                }
            }
            else
            {
                int sloganIndex = 0;

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
                        var key = English_Alphabet.IndexOf(slogan[sloganIndex]);

                        sloganIndex++;
                        if (sloganIndex >= slogan.Length)
                        {
                            sloganIndex = 0;
                        }

                        var index = (letterIndex - key) % English_Alphabet.Length;

                        if (index < 0)
                        {
                            index += English_Alphabet.Length;
                        }

                        decrypted_text += English_Alphabet[index];
                    }
                }
            }
            return decrypted_text;
        }

        public static string Trithemius_Ukrainian_Encryption(string text, string key_type, int[] vector, string slogan = "")
        {
            string encrypted_text = "";

            if (key_type == "Linear")
            {
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
                        var key = vector[0] * i + vector[1];
                        encrypted_text += Ukrainian_Alphabet[(letterIndex + key) % Ukrainian_Alphabet.Length];
                    }
                }
            }
            else if (key_type == "Nonlinear")
            {
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
                        var key = vector[0] * i * i + vector[1] * i + vector[2];
                        encrypted_text += Ukrainian_Alphabet[(letterIndex + key) % Ukrainian_Alphabet.Length];
                    }
                }
            }
            else
            {
                int sloganIndex = 0;

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
                        var key = Ukrainian_Alphabet.IndexOf(slogan[sloganIndex]);

                        sloganIndex++;
                        if (sloganIndex >= slogan.Length)
                        {
                            sloganIndex = 0;
                        }
                        encrypted_text += Ukrainian_Alphabet[(letterIndex + key) % Ukrainian_Alphabet.Length];
                    }
                }
            }
            return encrypted_text;
        }

        public static string Trithemius_Ukrainian_Decryption(string text, string key_type, int[] vector, string slogan = "")
        {
            string decrypted_text = "";

            if (key_type == "Linear")
            {
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
                        var key = vector[0] * i + vector[1];
                        decrypted_text += Ukrainian_Alphabet[(letterIndex + Ukrainian_Alphabet.Length - (key % Ukrainian_Alphabet.Length)) % Ukrainian_Alphabet.Length];
                    }
                }
            }
            else if (key_type == "Nonlinear")
            {
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
                        var key = vector[0] * i * i + vector[1] * i + vector[2];
                        decrypted_text += Ukrainian_Alphabet[(letterIndex + Ukrainian_Alphabet.Length - (key % Ukrainian_Alphabet.Length)) % Ukrainian_Alphabet.Length];
                    }
                }
            }
            else
            {
                int sloganIndex = 0;

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
                        var key = Ukrainian_Alphabet.IndexOf(slogan[sloganIndex]);

                        sloganIndex++;
                        if (sloganIndex >= slogan.Length)
                        {
                            sloganIndex = 0;
                        }

                        var index = (letterIndex - key) % Ukrainian_Alphabet.Length;

                        if (index < 0)
                        {
                            index += Ukrainian_Alphabet.Length;
                        }

                        decrypted_text += Ukrainian_Alphabet[index];
                    }
                }
            }
            return decrypted_text;
        }
    }
}
