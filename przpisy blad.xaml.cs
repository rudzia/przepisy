using System;
using System.Collections.Generic;
using System.IO;
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

namespace Przepisy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_DodajSkladnik_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox_Skladnik.Text != "")
            {
                listBox_Skladniki.Items.Add(this.textBox_Skladnik.Text + " " + this.textBox_ilosc.Text);
                this.textBox_Skladnik.Focus();
                this.textBox_Skladnik.Clear();
                this.textBox_ilosc.Focus();
                this.textBox_ilosc.Clear();

            }
            else
            {
                // error
                MessageBox.Show("Wpisz składnik", "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
                this.textBox_Skladnik.Focus();
            }
        }

        private void button_Usuń_Click(object sender, RoutedEventArgs e)
        {
            if (this.listBox_Skladniki.SelectedIndex >= 0)
            {
                this.listBox_Skladniki.Items.RemoveAt(this.listBox_Skladniki.SelectedIndex);
            }
        }

        private void button_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter File = new StreamWriter(textBox_nazwijprzepis.Text + "." + "txt");


            File.Write(textBox_nazwijprzepis.Text + ";");
            foreach (string itemText in listBox_Skladniki.Items) 
            {
                File.Write(itemText + "|");
            }
            File.Write(";");
            File.Write(textBox_przygotowanie.Text);
            File.Close();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"C:\projekty\przepisy\Przepisy\bin\Debug\zupka.txt");
            
            string[] przepis = text.Split(';');
            textBox_nazwijprzepis.Text = przepis[0];
            //listBox_Skladniki.Items.Add( przepis[1]);
            textBox_przygotowanie.Text = przepis[2];
            string[] skladniki = przepis[1].Split('|');
            foreach (string skladnik in skladniki)
            { 
            listBox_Skladniki.Items.Add(skladnik);
            }

            int t = 0;

        }

        private void textBox_nazwijprzepis_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
  
}
