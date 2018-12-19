using System;
using System.Text;
using System.Threading;


namespace ThreadP
{
    class Program
    {
        const int MAX_COUNTER = 100000000;

        //static int Counter = 0;
        static int CounterLocal1 = 0;
        static int CounterLocal2 = 0;
        static int CounterCommon = 0;

        //static void ThreadMethod1()
        //{
        //    for (;;){
        //        Console.WriteLine("START THREAD");

        //        for (int i = 0; i != MAX_COUNTER; i++)
        //        {
        //            Counter++;

        //            if(Counter % (MAX_COUNTER/20)==0)
        //            {
        //                Console.WriteLine("Counter = " + Counter);
        //            }               }

        //        Thread.Sleep(1000);
        //    }
        //}
        static void ThreadMethod1(){
            for (int i = 0; i != MAX_COUNTER; i++){
                CounterLocal1 ++;
                CounterCommon++;

            }
        }
        static void ThreadMethod2(){
            for (int i = 0; i != MAX_COUNTER; i++){
                CounterLocal2++;
                CounterCommon++;
            }
        }
        public static void Main(string[] args)
        {
            //Thread MyThread : new Thread(new ThreadStart(ThreadMethod));

            Console.WriteLine("MAIN: Start");

            // Thread MyThread = new Thread(ThreadMethod);
            Thread MyThread1 = new Thread(ThreadMethod1);
            Thread MyThread2 = new Thread(ThreadMethod2);


            //Start display
            MyThread1.Start();
            MyThread2.Start();

            // Wait user entry 
            Console.ReadLine();
            Console.WriteLine("STOP MAIN");
        }
    }
}
