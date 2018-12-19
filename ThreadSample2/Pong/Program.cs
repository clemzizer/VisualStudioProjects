using System;
using System.Threading;

namespace Pong
{
    class Program
    {
        static EventWaitHandle PingEvent; //Command
        static EventWaitHandle PongEvent; //Ack
        static EventWaitHandle QuitEvent; 


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
            QuitEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "QUIT_EVENT");

            Thread PongThread = new Thread(PongMethod);
            PongThread.IsBackground = true;
            PongThread.Start();

            for (;;)
            {
                WaitHandle[] events = { PingEvent, QuitEvent };

                int id = WaitHandle.WaitAny(events);

                if (id == 0)
                {
                    Console.WriteLine("Pong");
                    PongEvent.Set();
                }
                if (id == 1) 
                {
                    PongEvent.Set();
                    break;
                }
            }
        }
    }
}
