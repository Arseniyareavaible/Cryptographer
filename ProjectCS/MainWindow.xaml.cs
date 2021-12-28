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
using Microsoft.Win32;

namespace ProjectCS
{
     public partial class MainWindow : Window
     {
          public MainWindow()
          {
               InitializeComponent();
          }

          private void Window_MouseDown(object sender, MouseButtonEventArgs e)
          {
               if (e.LeftButton == MouseButtonState.Pressed)
               {
                    DragMove();
               }
          }

          private void Button_Save(object sender, RoutedEventArgs e)
          {
               SaveFileDialog saveFileDialog = new SaveFileDialog();
               saveFileDialog.Filter = "Text file (*.txt)|*.txt";
               saveFileDialog.DefaultExt = ".txt";
               if (saveFileDialog.ShowDialog() == true)
               {
                    File.WriteAllText(saveFileDialog.FileName, TextBoxText.Text);
                    TextBoxText.Text = string.Empty;
                    TextBoxKey.Text = string.Empty;
               }
          }

          private void Button_Import(object sender, RoutedEventArgs e)
          {
               OpenFileDialog fileDialog = new OpenFileDialog();
               fileDialog.Filter = "Text file (*.txt)|*.txt";
               fileDialog.DefaultExt = ".txt";
               if (fileDialog.ShowDialog() == true)
               {
                    string path = string.Empty;
                    foreach (string sFilename in fileDialog.FileNames)
                    {
                         path += sFilename;
                    }
                    string textLines = File.ReadAllText(path);
                    TextBoxText.Text = textLines;
               }
          }

          private void Button_Exit(object sender, RoutedEventArgs e)
          {
               Environment.Exit(0);
          }

          private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
          {
               if (string.IsNullOrEmpty(TextBoxKey.Text))
               {
                    TextBoxKey.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Enter key!");
                    TextBoxKey.BorderBrush = new SolidColorBrush(Colors.White);
               }
               else if (string.IsNullOrEmpty(TextBoxText.Text))
               {
                    TextBoxText.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Enter text!");
                    TextBoxText.BorderBrush = new SolidColorBrush(Colors.White);
               }
               else
               {
                    TextBoxText.Text = CipherVigenere.Encrypt(TextBoxText.Text, TextBoxKey.Text);
               }
          }

          private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
          {
               if (string.IsNullOrEmpty(TextBoxKey.Text))
               {
                    TextBoxKey.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Enter key!");
                    TextBoxKey.BorderBrush = new SolidColorBrush(Colors.White);
               }
               else if (string.IsNullOrEmpty(TextBoxText.Text))
               {
                    TextBoxText.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Enter text!");
                    TextBoxText.BorderBrush = new SolidColorBrush(Colors.White);
               }
               else
               {
                    TextBoxText.Text = CipherVigenere.Decrypt(TextBoxText.Text, TextBoxKey.Text);
               }
          }

          private void ButtonQuest_Click(object sender, RoutedEventArgs e)
          {
               MessageBox.Show("Программа «шифратор текстов» предназначена для шифрования и дешифрования текстовых файлов по методу Виженера, с помощью функций “Открытие” и “Сохранение” упрощается шифрование больших текстовых файлов. Доступна функция dragNdrop");
          }

          private void Window_DragEnter(object sender, DragEventArgs e)
          {
               if (e.Data.GetDataPresent(DataFormats.FileDrop))
               {
                    e.Effects = DragDropEffects.All;
               }
          }

          private void Window_Drop(object sender, DragEventArgs e)
          {
               string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
               TextBoxText.Text = File.ReadAllText(path[0]);
          }
     }
}
