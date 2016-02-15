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
                listBox_Skladniki.Items.Add(this.textBox_Skladnik.Text);
                this.textBox_Skladnik.Focus();
                this.textBox_Skladnik.Clear();
            }
            else
            {
                MessageBox.Show("Wpisz składnik", "Error", MessageBoxButton.OK, MessageBoxImage.Error,MessageBoxResult.OK);
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
    }
}
