using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTemperatureSensorDemo
{
    class Program
    {
        static void FirstReceiver(int Temperature)
        {
            Console.WriteLine("I'am the first receiver: temperature is " + Temperature);
        }

        static void SecondReceiver(int Temperature)
        {
            Console.WriteLine("I'am the second receiver: temperature is " + Temperature);
        }

        static void AnotherReceiver(int Temperature)
        {
            Console.WriteLine("I don't care about temperature!! ");
        }

        static void Main(string[] args)
        {
            SensorTemperatureManager stm = new SensorTemperatureManager();

            stm.NotifyForTemperatureChange +=
                new SensorTemperatureManager.NotifyTemperatureChangeDelegate(FirstReceiver);

            stm.NotifyForTemperatureChange +=
                new SensorTemperatureManager.NotifyTemperatureChangeDelegate(SecondReceiver);

            stm.NotifyForTemperatureChange +=
                new SensorTemperatureManager.NotifyTemperatureChangeDelegate(AnotherReceiver);

            for (; ; )
            {
                try
                {
                    stm.Temperature = int.Parse(Console.ReadLine());
                }
                catch
                {
                    return;
                }
            }

        }
    }
}
