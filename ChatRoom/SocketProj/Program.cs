using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketProj
{
    class Program
    {
        private static String message = "Test";
        private static String ip = null;
        static Int32 port = 13000;
        static TcpClient client;
        static NetworkStream stream;

        static void Read()
        {
            Console.WriteLine(ip);
            try
            {

                // Buffer to store the response bytes.
                Byte[] data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                for (; ; )
                {


                // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);
                  
                }

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }

        static void Write()
        {
         
            try
            {
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);
                for (; ; )
                {
                    String Message = Console.ReadLine();
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(Message);

                    stream.Write(msg, 0, msg.Length);

                    if (Message == "quit") break;
                }

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
          
        }
        static void Server()
        {


            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 13000);
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
                ip = Message;
                break;
            }

        }
        static void init(){
            client = new TcpClient(ip, port);
            stream = client.GetStream();
        }

        static void Main(string[] args)
        {

            Thread mythread = new Thread(Server);

            mythread.Start();
            mythread.Join();

            Thread threadInit = new Thread(init);
            threadInit.Start();
            threadInit.Join();

           

            Console.WriteLine(ip);

            //Thread mythread2 = new Thread(Read);
            //mythread2.Start();
            Thread mythread3 = new Thread(Write);
            mythread3.Start();

            // Close everything.
            stream.Close();
            client.Close();
           
        }
    }
}
