using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Crytography_WPF.Caesar
{
    /// <summary>
    /// Interaction logic for CaesarForm.xaml
    /// </summary>
    public partial class CaesarForm : Window
    {
        public string TitlePage { get; set; }
        public CaesarForm()
        {
            TitlePage = "Ceasar Method";
            InitializeComponent();

            this.DataContext = this;

            cbxKey.ItemsSource = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        void CaesarProcess(string method)
        {
            foreach (var item in CaesarMethod.Caesar(tbxLetter.Text, int.Parse(cbxKey.Text), method))
            {
                tbxResult.Text = string.Concat(tbxResult.Text, item.ToString());
            }
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            if (tbxLetter.Text == string.Empty || cbxKey.SelectedItem == null)
            {
                MessageBox.Show("Enter the letter, please!!!", "Ưhat's up", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tbxResult.Clear();

                Button btnClick = sender as Button;

                if (btnClick.Tag.Equals("Encrypt"))
                    CaesarProcess("Encrypt");
                else if (btnClick.Tag.Equals("Decrypt"))
                    CaesarProcess("Decrypt");
            }
            
        }

        private void ControlBar_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
