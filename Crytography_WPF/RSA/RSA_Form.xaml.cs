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

namespace Crytography_WPF.RSA
{
    /// <summary>
    /// Interaction logic for RSA_Form.xaml
    /// </summary>
    public partial class RSA_Form : Window
    {
        public string TitlePage { get; set; }

        int p, q, eItem;

        RSA_Method rsa = new RSA_Method();
        public RSA_Form()
        {
            TitlePage = "RSA";

            InitializeComponent();
            this.DataContext = this;

        }

        void checkErr()
        {
            try
            {
                if (pText.Text == "0" || qText.Text == "0")
                    pText.Text = "1";

                p = int.Parse(pText.Text);
                q = int.Parse(qText.Text);
            }
            catch (Exception)
            {
                pText.Text = "0";
                qText.Text = "1";
            }
        }

        private void ControlBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                eItem = int.Parse(cbxListE.Text);
                FillTable();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lẽ e sẽ làm bạn tính toán bị sai, vui lòng chọn số khác!!");
            } 
        }

        private void btnGetE_Click(object sender, RoutedEventArgs e)
        {
            checkErr();
            cbxListE.ItemsSource = null;
            cbxListE.ItemsSource = (rsa.ListE(p, q));
        }

        void FillTable()
        {
            //DataTable db = new DataTable();

            //db.R1 = rsa.Fil(p, q);
            //db.R2 = eItem;
            //db.Q = db.R1 / db.R2;
            //db.R = db.R1 % db.R2;
            //db.T1 = 0;
            //db.T2 = 1;
            //db.T = db.T1 - db.Q * db.T2;

            //List<DataTable> data = new List<DataTable>();

            //data.Add(db);
            ////data.Add(new DataTable() { Q = db.R1 / db.R2, R1 = db.R1, R2 = eItem, R = db.R1 % db.R2, T1 = 0, T2 = 1, T = db.T1 - db.Q * db.T2 });

            //Console.WriteLine(data[0].R1);
            //for (int i = 1; data[i-1].R2 != 0; i++)
            //{
            //    db = new DataTable();

            //    db.R1 = data[i - 1].R2;
            //    db.R2 = data[i - 1].R;

            //    if (db.R1 == 1 && db.R2 == 0)
            //    {
            //        db.Q = 0;
            //        db.R = 0;
            //        db.T = 0;
            //        db.T1 = data[i - 1].T2;
            //        db.T2 = data[i - 1].T;
            //    }  
            //    else
            //    {
            //        db.Q = db.R1 / db.R2;
            //        db.R = db.R1 % db.R2;
            //        db.T1 = data[i - 1].T2;
            //        db.T2 = data[i - 1].T;
            //        db.T = db.T1 - db.Q * db.T2; //t=t1-q.t2
            //    }


            //    data.Add(db);
            //}

            var res = rsa.ListRSA(p, q, eItem);

            code.Text = Convert.ToString(res[res.Count()-1].T2 + res[res.Count()-1].T1);
            code.Visibility = Visibility;

            cbxListE.SelectedIndex = -1;

            dtgCrypt.ItemsSource = res;
        }
    }
}
