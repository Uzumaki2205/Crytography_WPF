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
    /// Interaction logic for ControlBar.xaml
    /// </summary>
    public partial class ControlBar : UserControl
    {
        public ControlBar()
        {
            InitializeComponent();
        }

        private void btn_CommandClick(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            Button btnClick = sender as Button;
            if (btnClick.Tag.Equals("btnClose"))
            {
                ExitForm exit = new ExitForm();
                exit.ShowDialog();
                if (exit.Status == true)
                    window.Close();
            }
            else if (btnClick.Tag.Equals("btnMaximize"))
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            }
            else if (btnClick.Tag.Equals("btnMinimize"))
                window.WindowState = WindowState.Minimized;
        }
    }
}
