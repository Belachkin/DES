using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace DES
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string sKey;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void butEncrypt_Click(object sender, RoutedEventArgs e)
        {
            sKey = txtInputKey.Text;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog.Filter = "des files |*.des";

                if(saveFileDialog.ShowDialog() == true)
                {
                    string destination = saveFileDialog.FileName;
                    EncryptFile(source, destination, sKey);
                }
            }
        }

        private void butDecrypt_Click(object sender, RoutedEventArgs e)
        {
            sKey = txtInputKey.Text;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            openFileDialog1.Filter = "des files |*.des";
            if (openFileDialog1.ShowDialog() == true)
            {
                string source = openFileDialog1.FileName;
                saveFileDialog.Filter = "txt files |*.txt";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string destination = saveFileDialog.FileName;
                    DecryptFile(source, destination, sKey);
                }
            }
        }

        private void EncryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateEncryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] byteArrayInput = new byte[fsInput.Length - 0];
                fsInput.Read(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Write(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            fsInput.Close();
            fsEncrypted.Close();

            MessageBox.Show("Fine!");
        }

        private void DecryptFile(string source, string destination, string sKey)
        {
            FileStream fsInput = new FileStream(source, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(destination, FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();

            try
            {
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                CryptoStream cryptoStream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);
                byte[] byteArrayInput = new byte[fsInput.Length - 0];
                fsInput.Read(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Write(byteArrayInput, 0, byteArrayInput.Length);
                cryptoStream.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            fsInput.Close();
            fsEncrypted.Close();

            MessageBox.Show("Fine!");
        }
    }
}
