using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crytography_WPF.RSA
{
    class RSA_Method
    {
        public List<int> ListE(int p, int q)
        {
            List<int> snt = new List<int>();

            for (int i = 2; i <= Fil(p, q); i++)
            {
                if (checkSNT(i) == true && (i % p != 0 && i % q != 0))
                    snt.Add(i);
            }

            return snt;
        }

        static bool checkSNT(int num)
        {
            //Neu num chia het cho 1 trong cac so chay tu 2 -> num/2 
            //Num kp la so nguyen to
            //num la so nguyen to : khi no chia het cho 1 va chinh num

            int max = num / 2;
            for (int i = 2; i <= max; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public int Fil(int p, int q) => (p - 1) * (q - 1);

        public List<DataTable> ListRSA(int p, int q, int eItem)
        {
            DataTable db = new DataTable();

            db.R1 = Fil(p, q);
            db.R2 = eItem;
            db.Q = db.R1 / db.R2;
            db.R = db.R1 % db.R2;
            db.T1 = 0;
            db.T2 = 1;
            db.T = db.T1 - db.Q * db.T2;

            List<DataTable> data = new List<DataTable>();

            data.Add(db);
            //data.Add(new DataTable() { Q = db.R1 / db.R2, R1 = db.R1, R2 = eItem, R = db.R1 % db.R2, T1 = 0, T2 = 1, T = db.T1 - db.Q * db.T2 });

            Console.WriteLine(data[0].R1);
            for (int i = 1; data[i - 1].R2 != 0; i++)
            {
                db = new DataTable();

                db.R1 = data[i - 1].R2;
                db.R2 = data[i - 1].R;

                if (db.R1 == 1 && db.R2 == 0)
                {
                    db.Q = 0;
                    db.R = 0;
                    db.T = 0;
                    db.T1 = data[i - 1].T2;
                    db.T2 = data[i - 1].T;
                }
                else
                {
                    db.Q = db.R1 / db.R2;
                    db.R = db.R1 % db.R2;
                    db.T1 = data[i - 1].T2;
                    db.T2 = data[i - 1].T;
                    db.T = db.T1 - db.Q * db.T2; //t=t1-q.t2
                }


                data.Add(db);
            }

            return data;
        }
    }
    public class DataTable
    {
        public int Q { get; set; }
        public int R1 { get; set; }
        public int R2 { get; set; }
        public int R { get; set; }
        public int T1 { get; set; }
        public int T2 { get; set; }
        public int T { get; set; }
    }
}
