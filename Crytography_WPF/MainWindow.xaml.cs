using Crytography_WPF.Caesar;
using Crytography_WPF.RSA;
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

namespace Crytography_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TitlePage { get; set; }
        public MainWindow()
        {
            TitlePage = "Application Crytology by Le Ngoc Son";
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnCaesar_Click(object sender, RoutedEventArgs e)
        {
            CaesarForm fr = new CaesarForm();
            fr.Show();
            this.WindowState = WindowState.Minimized;
        }

        private void ControlBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btnRSA_Click(object sender, RoutedEventArgs e)
        {
            RSA_Form fr = new RSA_Form();
            fr.Show();
            this.WindowState = WindowState.Minimized;
        }
    }
}
