using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ClassLibrary2;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Int16 a = 300;
            Int16 b = 200;
            Int16 c = 250;
            Int16 d = 230;
            byte[] x1 = BitConverter.GetBytes(a);
            byte[] x22 = BitConverter.GetBytes(b);
            byte[] x3 = BitConverter.GetBytes(c);
            byte[] x4 = BitConverter.GetBytes(d);
            byte[] x2 = new byte[12];
            x2[1] = x1[0];
            x2[2] = x1[1];
            x2[3] = x22[0];
            x2[4] = x22[1];
            x2[5] = x3[0];
            x2[6] = x3[1];
            x2[7] = x4[0];
            x2[8] = x4[1];
            x2[9] = 05;
            x2[10] = 03;
            x2[11] = 04;
            x2[0] = 0x03;
            Command command = Parser.Parse(x2);
            Consoles.Output(command);

        }

    }
}
