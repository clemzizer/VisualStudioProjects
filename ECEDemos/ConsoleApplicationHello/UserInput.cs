using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleStudentsApp
{
    static class UserInput
    {
        public static String GetString()
        {
            return Console.ReadLine();
        }

        public static int GetInt()
        {
            for (; ; )
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("*** INPUT ERROR *** An int value is expected: try again");
                }
            }
        }
        
        public static float GetFloat()
        {
            for (; ; )
            {
                try
                {
                    return float.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("*** INPUT ERROR *** An float value is expected: try again");
                }
            }
        }
    }
}
