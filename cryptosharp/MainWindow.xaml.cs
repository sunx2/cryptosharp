using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace cryptosharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            /*
            _checks.Add("AES",true);
            _checks.Add("SHA256",false);
            _checks.Add("Unicode",false);*/
        }
        
        private readonly Dictionary<string,bool> _checks = new Dictionary<string, bool>();
        

        private void Encrypt_click(object sender, RoutedEventArgs e)
        {
            if (_checks["Unicode"])
            {
                Label1.Content = "Unicode isn't supported for now" ;
            }
            else if ( _checks["SHA256"])
                
            {
                Label1.Content = "SHA256 isn't supported for now" ;
            }
            else if (_checks["AES"])
            {
                var data = Encoding.Unicode.GetBytes(Textbox1.Text);
                SymmetricAlgorithm aes = Aes.Create();
                using (MemoryStream ms= new MemoryStream())
                {
                    var a = aes.Key;
                    var b = aes.IV;
                    using (CryptoStream cs= new CryptoStream(ms , aes.CreateEncryptor(a,b) , CryptoStreamMode.Write))
                    {
                        cs.Write(data,0 ,data.Length);
                    }

                    Textbox1.Text = $"DATA: {Convert.ToBase64String(ms.ToArray())}\n KEY: {Convert.ToBase64String(a.ToArray())}\n IV: {Convert.ToBase64String(b.ToArray())}";
                }

            }
        }
            
    

        private void Decrypt_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("decrypt ");
        }

        private void sha_check(object sender, RoutedEventArgs e)
        {
            _checks["AES"] = false;
            _checks["SHA256"] = true;
            _checks["Unicode"] = false;

        }
        private void aes_check(object sender, RoutedEventArgs e)
        {
            _checks["AES"] = true;
            _checks["SHA256"] = false;
            _checks["Unicode"] = false;
        }
        private void unicode_check(object sender, RoutedEventArgs e)
        {
            _checks["AES"] = false;
            _checks["SHA256"] = false;
            _checks["Unicode"] = true;
        }

        
    }
}