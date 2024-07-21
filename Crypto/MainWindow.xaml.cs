using Crypto.AppWindows;
using Crypto.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using static Crypto.Classes.Caeser;
using static Crypto.Classes.Trithemius;
using static Crypto.Classes.Gamma;

namespace Crypto
{
    public class DataEntry
    {
        public string Key { get; set; }
        public int LetterFrequency { get; set; }
        public double RelativeLetterFrequency { get; set; }
    }

    public partial class MainWindow : Window
    {
        public string EncryptionLanguage;
        public string EncryptionType;
        public string EncryptionMethod;
        public string KeyType;

        public MainWindow()
        {
            InitializeComponent();
        }
  
        private void ValidateNumberTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ValidateCharacterTextBox(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (char.IsDigit(c))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void LanguageHandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            EncryptionLanguage = rb.Name;
        }

        private void TypeHandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            EncryptionType = rb.Name;
        }

        private void MethodHandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            EncryptionMethod = rb.Name;

            if (EncryptionMethod == "Caeser" && CaeserMethod != null)
            {
                CaeserMethod.Visibility = Visibility.Visible;
                TrithemiusMethod.Visibility = Visibility.Collapsed;
                GammaMethod.Visibility = Visibility.Collapsed;
            }
            else if (EncryptionMethod == "Trithemius" && TrithemiusMethod != null)
            {
                CaeserMethod.Visibility = Visibility.Collapsed;
                TrithemiusMethod.Visibility = Visibility.Visible;
                GammaMethod.Visibility = Visibility.Collapsed;
            }
            else if ((EncryptionMethod == "GammaC" || EncryptionMethod == "GammaS") && GammaMethod != null)
            {
                CaeserMethod.Visibility = Visibility.Collapsed;
                TrithemiusMethod.Visibility = Visibility.Collapsed;
                GammaMethod.Visibility = Visibility.Visible;
            }
        }

        private void KeyTypeHandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            KeyType = rb.Name;

            if (KeyType == "Linear" && LinearKeyType != null)
            {
                LinearKeyType.Visibility = Visibility.Visible;
                NonlinearKeyType.Visibility = Visibility.Collapsed;
                SloganKeyType.Visibility = Visibility.Collapsed;
            }
            else if (KeyType == "Nonlinear" && NonlinearKeyType != null)
            {
                LinearKeyType.Visibility = Visibility.Visible;
                NonlinearKeyType.Visibility = Visibility.Visible;
                SloganKeyType.Visibility = Visibility.Collapsed;
            }
            else if (KeyType == "Slogan" && LinearKeyType != null)
            {
                LinearKeyType.Visibility = Visibility.Collapsed;
                NonlinearKeyType.Visibility = Visibility.Collapsed;
                SloganKeyType.Visibility = Visibility.Visible;
            }
        }

        private void ArrowButtonClick(object sender, RoutedEventArgs e)
        {
            PostEncryptionTextBox.Text = "";
            if (EncryptionMethod == "Caeser")
            {
                if (PreEncryptionTextBox.Text != string.Empty && !string.IsNullOrWhiteSpace(NumberTextBox.Text))
                {
                    if (EncryptionLanguage == "English")
                    {
                        if (EncryptionType == "Encrypt")
                        {
                            PostEncryptionTextBox.Text = English_Encryption(PreEncryptionTextBox.Text, int.Parse(NumberTextBox.Text));
                        }
                        else
                        {
                            PostEncryptionTextBox.Text = English_Decryption(PreEncryptionTextBox.Text, int.Parse(NumberTextBox.Text));
                        }
                    }
                    else
                    {
                        if (EncryptionType == "Encrypt")
                        {
                            PostEncryptionTextBox.Text = Ukrainian_Encryption(PreEncryptionTextBox.Text, int.Parse(NumberTextBox.Text));
                        }
                        else
                        {
                            PostEncryptionTextBox.Text = Ukrainian_Decryption(PreEncryptionTextBox.Text, int.Parse(NumberTextBox.Text));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please input the correct data!");
                }
            }
            else if (EncryptionMethod == "Trithemius")
            {
                if (PreEncryptionTextBox.Text != string.Empty)
                {
                    if (KeyType == "Linear" && ACoefficientTextBox.Text != string.Empty && BCoefficientTextBox.Text != string.Empty)
                    {
                        if (int.Parse(ACoefficientTextBox.Text) > 100 || int.Parse(BCoefficientTextBox.Text) > 100)
                        {
                            MessageBox.Show("The coefficients must be less than 100!");
                        }
                        else
                        {
                            int[] vector = new int[2];
                            vector[0] = int.Parse(ACoefficientTextBox.Text);
                            vector[1] = int.Parse(BCoefficientTextBox.Text);

                            if (EncryptionLanguage == "English")
                            {
                                if (EncryptionType == "Encrypt")
                                {
                                    PostEncryptionTextBox.Text = Trithemius_English_Encryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                                else
                                {
                                    PostEncryptionTextBox.Text = Trithemius_English_Decryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                            }
                            else
                            {
                                if (EncryptionType == "Encrypt")
                                {
                                    PostEncryptionTextBox.Text = Trithemius_Ukrainian_Encryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                                else
                                {
                                    PostEncryptionTextBox.Text = Trithemius_Ukrainian_Decryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                            }
                        }
                    }
                    else if (KeyType == "Nonlinear" && ACoefficientTextBox.Text != string.Empty && BCoefficientTextBox.Text != string.Empty && CCoefficientTextBox.Text != string.Empty)
                    {
                        if (int.Parse(ACoefficientTextBox.Text) > 100 || int.Parse(BCoefficientTextBox.Text) > 100 || int.Parse(CCoefficientTextBox.Text) > 100)
                        {
                            MessageBox.Show("The coefficients must be less than 100!");
                        }
                        else
                        {
                            int[] vector = new int[3];
                            vector[0] = int.Parse(ACoefficientTextBox.Text);
                            vector[1] = int.Parse(BCoefficientTextBox.Text);
                            vector[2] = int.Parse(CCoefficientTextBox.Text);

                            if (EncryptionLanguage == "English")
                            {
                                if (EncryptionType == "Encrypt")
                                {
                                    PostEncryptionTextBox.Text = Trithemius_English_Encryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                                else
                                {
                                    PostEncryptionTextBox.Text = Trithemius_English_Decryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                            }
                            else
                            {
                                if (EncryptionType == "Encrypt")
                                {
                                    PostEncryptionTextBox.Text = Trithemius_Ukrainian_Encryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                                else
                                {
                                    PostEncryptionTextBox.Text = Trithemius_Ukrainian_Decryption(PreEncryptionTextBox.Text, KeyType, vector);
                                }
                            }
                        }
                    }
                    else if (KeyType == "Slogan" && SloganTextBox.Text != string.Empty)
                    {
                        if (EncryptionLanguage == "English")
                        {
                            if (EncryptionType == "Encrypt")
                            {
                                PostEncryptionTextBox.Text = Trithemius_English_Encryption(PreEncryptionTextBox.Text, KeyType, null, SloganTextBox.Text);
                            }
                            else
                            {
                                PostEncryptionTextBox.Text = Trithemius_English_Decryption(PreEncryptionTextBox.Text, KeyType, null, SloganTextBox.Text);
                            }
                        }
                        else
                        {
                            if (EncryptionType == "Encrypt")
                            {
                                PostEncryptionTextBox.Text = Trithemius_Ukrainian_Encryption(PreEncryptionTextBox.Text, KeyType, null, SloganTextBox.Text);
                            }
                            else
                            {
                                PostEncryptionTextBox.Text = Trithemius_Ukrainian_Decryption(PreEncryptionTextBox.Text, KeyType, null, SloganTextBox.Text);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please input the correct data!");
                    }
                }
                else
                {
                    MessageBox.Show("Please input the correct data!");
                }
            }
            else if (EncryptionMethod == "GammaC")
            {
                if (PreEncryptionTextBox.Text != string.Empty)
                {
                    if (EncryptionLanguage == "English")
                    {
                        //if (Gamma.key == "" || Gamma.key.Length < PreEncryptionTextBox.Text.Length)
                        //{
                        //    GenerateKey(PreEncryptionTextBox.Text.Length, "English");
                        //    GammaTextBox.Text = Gamma.key;
                        //}

                        if (EncryptionType == "Encrypt")
                        {
                            PostEncryptionTextBox.Text = Gamma_English_Encryption(PreEncryptionTextBox.Text);
                        }
                        else
                        {
                            PostEncryptionTextBox.Text = Gamma_English_Decryption(PreEncryptionTextBox.Text);
                        }
                    }
                    else
                    {
                        if (Gamma.key == "" || Gamma.key.Length < PreEncryptionTextBox.Text.Length)
                        {
                            GenerateKey(PreEncryptionTextBox.Text.Length, "Ukrainian");
                            GammaTextBox.Text = Gamma.key;
                        }
                        if (EncryptionType == "Encrypt")
                        {
                            PostEncryptionTextBox.Text = Gamma_Ukrainian_Encryption(PreEncryptionTextBox.Text, Gamma.key);
                        }
                        else
                        {
                            PostEncryptionTextBox.Text = Gamma_Ukrainian_Decryption(PreEncryptionTextBox.Text, Gamma.key);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please input the correct data!");
                }
            }
            else if (EncryptionMethod == "GammaS")
            {
                if (PreEncryptionTextBox.Text != string.Empty)
                {
                    if (EncryptionLanguage == "English")
                    {
                        if (Gamma.key == "" || Gamma.key.Length < PreEncryptionTextBox.Text.Length)
                        {
                            GenerateKey(PreEncryptionTextBox.Text.Length, "English");
                            GammaTextBox.Text = Gamma.key;
                        }

                        PostEncryptionTextBox.Text = Gamma_English_Symmetrical(PreEncryptionTextBox.Text);
                    }
                    else
                    {
                        if (Gamma.key == "" || Gamma.key.Length < PreEncryptionTextBox.Text.Length)
                        {
                            GenerateKey(PreEncryptionTextBox.Text.Length, "Ukrainian");
                            GammaTextBox.Text = Gamma.key;
                        }

                        PostEncryptionTextBox.Text = Gamma_Ukrainian_Symmetrical(PreEncryptionTextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Please input the correct data!");
                }
            }
        }

        private void GenerateGammaClick(object sender, RoutedEventArgs e)
        {
            GenerateKey(PreEncryptionTextBox.Text.Length, EncryptionLanguage);
            GammaTextBox.Text = Gamma.key;
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    PreEncryptionTextBox.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while opening the file: " + ex.Message);
                }
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    string textToSave = PostEncryptionTextBox.Text;
                    File.WriteAllText(filePath, textToSave);
                    MessageBox.Show("File saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message);
                }
            }
        }

        private void ImageButtonClick(object sender, RoutedEventArgs e)
        {
            ImageEncryptionWindow imageCryptionWindow = new ImageEncryptionWindow();
            imageCryptionWindow.Show();
        }

        private void TableButtonClick(object sender, RoutedEventArgs e)
        {
            string text = PreEncryptionTextBox.Text;

            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (charCounts.ContainsKey(c))
                    {
                        charCounts[c]++;
                    }
                    else
                    {
                        charCounts[c] = 1;
                    }
                }
            }

            int totalChars = charCounts.Values.Sum();

            List<DataEntry> dataEntries = new List<DataEntry>();
            foreach (var cc in charCounts)
            {
                dataEntries.Add(new DataEntry
                { 
                    Key = cc.Key.ToString(),
                    LetterFrequency = cc.Value,
                    RelativeLetterFrequency = (double)cc.Value / totalChars
                });
            }

            LetterFrequencyWindow letter_frequency_window = new LetterFrequencyWindow();

            letter_frequency_window.LetterFrequencyListView.ItemsSource = dataEntries;
            letter_frequency_window.Show();
        }

        private void AttackButtonClick(Object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            string encrypted_text = PostEncryptionTextBox.Text;
            string decrypted_text = PreEncryptionTextBox.Text;

            if (EncryptionMethod == "Caeser")
            {
                stopwatch.Start();
                for (int i = 0; i < 30; i++)
                {
                    string text = English_Decryption(encrypted_text, i);
                    if (text == decrypted_text || decrypted_text == "")
                    {
                        stopwatch.Stop();
                        MessageBox.Show($"Key : {i}.\nTime spent: {stopwatch.ElapsedMilliseconds} ms.");
                        return;
                    }
                }
                stopwatch.Stop();
                MessageBox.Show("Brute force attack failed: Key not found.");
            }
            else if (EncryptionMethod == "Trithemius")
            {
                stopwatch.Start();
                if (KeyType == "Linear")
                {
                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            int[] vector = { i, j };
                            string text = Trithemius_English_Decryption(encrypted_text, "Linear", vector);
                            if (text == decrypted_text)
                            {
                                stopwatch.Stop();
                                MessageBox.Show($"Key : {i}, {j}.\nTime spent: {stopwatch.ElapsedMilliseconds} ms.");
                                return;
                            }
                        }
                    }
                }
                else if (KeyType == "Nonlinear")
                {
                    stopwatch.Start();
                    for (int i = 0; i < 100; i++)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            for (int k = 0; k < 100; k++)
                            {
                                int[] vector = { i, j, k };
                                string text = Trithemius_English_Decryption(encrypted_text, "Nonlinear", vector);
                                if (text == decrypted_text)
                                {
                                    stopwatch.Stop();
                                    MessageBox.Show($"Key : {i}, {j}, {k}.\nTime spent: {stopwatch.ElapsedMilliseconds} ms.");
                                    return;
                                }
                            }
                        }
                    }
                }
                else if (KeyType == "Slogan")
                {
                    stopwatch.Start();
                    int letterIndex = 0;
                    string slogan = "";
                    const string English_Alphabet = " abcdefghijklmnopqrstuvwxyz";
                    while (true)
                    {
                        if (English_Alphabet.IndexOf(encrypted_text[letterIndex]) != -1)
                        {
                            int slogan_letterIndex = (English_Alphabet.IndexOf(encrypted_text[letterIndex]) - English_Alphabet.IndexOf(decrypted_text[letterIndex])) % English_Alphabet.Length;
                            if (slogan_letterIndex < 0) slogan_letterIndex += English_Alphabet.Length;

                            slogan += English_Alphabet[slogan_letterIndex];
                            Debug.WriteLine(slogan);

                            string text = Trithemius_English_Decryption(encrypted_text, "Slogan", null, slogan);

                            if (decrypted_text == text)
                            {
                                stopwatch.Stop();
                                MessageBox.Show($"Key : {slogan}.\nTime spent: {stopwatch.ElapsedMilliseconds} ms.");
                                return;
                            }
                        }
                        letterIndex++;
                    }
                }
            }
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            PrintDialog print_dialog = new PrintDialog();

            if (print_dialog.ShowDialog() == true)
            {
                FlowDocument document = new FlowDocument(new Paragraph(new Run(PostEncryptionTextBox.Text)));
                document.PagePadding = new Thickness(50);
                document.ColumnGap = 0;
                document.ColumnWidth = print_dialog.PrintableAreaWidth;

                print_dialog.PrintDocument(((IDocumentPaginatorSource)document).DocumentPaginator, "Print Document");
            }
        }

        private void AboutButtonClick(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
