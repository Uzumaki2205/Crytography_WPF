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
using System.Windows.Shapes;

namespace Crytography_WPF
{
    /// <summary>
    /// Interaction logic for ExitForm.xaml
    /// </summary>
    public partial class ExitForm : Window
    {
        public bool Status;
        public ExitForm()
        {
            InitializeComponent();
            Status = false;
        }

        private void btn_CommandClick(object sender, RoutedEventArgs e)
        {
            Button btnClick = sender as Button;
            if (btnClick.Tag.Equals("btnClose"))
                this.Close();
            else if (btnClick.Tag.Equals("btnMaximize"))
                MessageBox.Show("Form nhỏ vậy phóng to làm gì mấy má :v", "Rảnh ghê =))", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (btnClick.Tag.Equals("btnMinimize"))
                this.WindowState = WindowState.Minimized;
            else if (btnClick.Tag.Equals("btnCancel"))
                this.Close();
            else if (btnClick.Tag.Equals("btnExit"))
            {
                this.Close();
                Status = true;
            }
        }
    }
}
