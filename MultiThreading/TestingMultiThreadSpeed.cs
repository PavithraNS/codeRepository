using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading
{
    class TestingMultiThreadSpeed
    {
        public static  void IncrementCounter1()
        {
            int count = 0;
            for (long i = 1; i <= 1000000; i++)
            {
                count++;
               
            }
            Console.WriteLine("IncrementCount1= "+count);
        }
        public static void IncrementCounter2()
        {
            int count = 0;
            for (long i = 1; i <= 1000000; i++)
            {
                count++;
                //Console.Write(count);
            }
            Console.WriteLine("IncrementCount2= "+count);
        }
    }
}
