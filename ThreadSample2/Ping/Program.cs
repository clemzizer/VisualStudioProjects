using System;
using System.Threading;

namespace Ping
{
 class Program
    {
        static string
        static EventWaitHandle PingEvent; //Command
        static EventWaitHandle PongEvent; //Ack
        static EventWaitHandle QuitEvent;

        public static void Main(string[] args)
        {
            PingEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "PING_EVENT");
            PongEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "PONG_EVENT");
            QuitEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "QUIT_EVENT");

            for (;;)
            {
                if (Command == "quit") break;
                if (Command == "ping")
                {
                    PingEvent.Set();
                    PongEvent.WaitOne();
                }
            }
        }
    }
}
