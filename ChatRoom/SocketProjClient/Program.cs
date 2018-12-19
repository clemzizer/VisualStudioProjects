using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketProjClient
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPEndPoint iep = new IPEndPoint(IPAddress.Loopback, 5000);

            for ( ; ; )
            {
                String Message = Console.ReadLine();

                sock.SendTo(Encoding.UTF8.GetBytes(Message), iep);

                if (Message == "quit") break;
            }
        }
    }
}
