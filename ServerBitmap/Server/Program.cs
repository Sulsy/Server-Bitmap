using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using ClassLibrary2;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data, mas = {0};
            while (true)
            {
                data= Udp.ReceiveMessage();
                if (data != null)
                {
                    Udp.SendMessage(mas);
                    Command command = Parser.Parse(data);
                    Consoles.Output(command);
                }
                data = null;
            }

        }

    }
}
