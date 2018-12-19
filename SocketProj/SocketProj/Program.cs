using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketProj
{
    class Program
    {

        static void client(){
 
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress ip = IPAddress.Parse("172.20.10.2");
            IPEndPoint iep = new IPEndPoint(ip, 5000); //IPAddress.Loopback

            for (; ; )
            {
                String Message = Console.ReadLine();

                sock.SendTo(Encoding.UTF8.GetBytes(Message), iep);

                if (Message == "quit") break;
            }
        }
        static void server(){
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 5000);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            byte[] data = new byte[1024];

            for (; ; )
            {
                int recv = sock.ReceiveFrom(data, ref ep);
                String Message = Encoding.UTF8.GetString(data, 0, recv);
                if (Message == "quit") break;

                Console.WriteLine(Message);
            }

        }
        static void Main(string[] args)
        {
            new Thread(client).Start();
            new Thread(server).Start();
        }
    }
}
