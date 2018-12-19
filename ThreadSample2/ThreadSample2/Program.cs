using System;
using System.Threading;

namespace ThreadSample2
{
    class Program
    {
        static EventWaitHandle PingEvent; //Command
        static EventWaitHandle PongEvent; //Ack
        static void PongMethod()
        {
            for (;;)
            {
                PingEvent.WaitOne();
                Console.WriteLine("Pong");
                Thread.Sleep(1000);
                PongEvent.Set();
            }
        }
        public static void Main(string[] args)
        {
            PingEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            PongEvent = new EventWaitHandle(false, EventResetMode.AutoReset);


            Thread PongThread = new Thread(PongMethod);
            PongThread.IsBackground=true;
            PongThread.Start();

            for (;;)
            {
                String Command = Console.ReadLine();

                if (Command == "quit") break;
                if (Command == "ping") {
                    PingEvent.Set();
                    PongEvent.WaitOne();
                }
            }
        }
    }
}
