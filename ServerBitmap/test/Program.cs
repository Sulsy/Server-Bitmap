using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string n = "draw line";
            Int16[] a = {14, 24, 25, 12};
            string c = "4C4C3C";
            byte[] cc = {0x00, 0x04, 0x05};
            Builder A = new Builder(a,n, cc);
            Udp.SendMessage(A.Parse());
            Console.ReadLine();
            c = "9C4F2C";
            Int16[] aa = { 45, 38, 45, 14 };
            A = new Builder(aa, n, cc);
            Udp.SendMessage(A.Parse());

        }
    }
}
