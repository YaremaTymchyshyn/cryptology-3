using Microsoft.Win32;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Crypto.Classes.Caeser;

namespace Crypto.AppWindows
{
    public partial class ImageEncryptionWindow : Window
    {
        public string EncryptionLanguage;
        public string EncryptionType;

        public ImageEncryptionWindow()
        {
            InitializeComponent();
        }

        private void ValidateNumberTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TypeHandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            EncryptionType = rb.Name;
        }

        private void ArrowButtonClick(object sender, RoutedEventArgs e)
        {
            if (PreEncryptionTextBox.Text != string.Empty && NumberTextBox.Text != string.Empty)
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
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    string base64String = Convert.ToBase64String(imageBytes);
                    PreEncryptionTextBox.Text = base64String;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while opening the image: " + ex.Message);
                }
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string imageBase64String = PostEncryptionTextBox.Text;
                byte[] imageBytes = Convert.FromBase64String(imageBase64String);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, imageBytes);
                    MessageBox.Show("Image saved successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the image: " + ex.Message);
            }
        }
    }
}
