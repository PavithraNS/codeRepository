using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");
            //List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            //employeeDetails.Add(new EmployeeDetails { EmployeeID = 1, EmployeeName = "Sindhu" });
            //employeeDetails.Add(new EmployeeDetails { EmployeeID = 2, EmployeeName = "Peeter" });
            //employeeDetails.Add(new EmployeeDetails { EmployeeID = 3, EmployeeName = "Kavitha" });
            //employeeDetails.Add(new EmployeeDetails { EmployeeID = 4, EmployeeName = "Aravindh" });


            //EmployeePayrollOperations employeePayrolloperations = new EmployeePayrollOperations();
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //employeePayrolloperations.addEmployeeToPayroll(employeeDetails);
            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.ElapsedMilliseconds);

            //Stopwatch stopWatch1 = new Stopwatch();
            //stopWatch1.Start();
            //employeePayrolloperations.addEmployeeToPayrollWithThread(employeeDetails);
            //stopWatch1.Stop();
            //Console.WriteLine(stopWatch1.ElapsedMilliseconds);
            //IteratingForLoopWithoutTask();
            //IteratingForLoopWithTask();

            //Stopwatch stopWatch3 = new Stopwatch();
            //stopWatch3.Start();
            //TestingMultiThreadSpeed.IncrementCounter1();
            //TestingMultiThreadSpeed.IncrementCounter2();
            //stopWatch3.Stop();

            //Console.WriteLine("Elapsed time without multithreading");
            //Console.WriteLine(stopWatch3.ElapsedMilliseconds);

            //Thread t1 = new Thread(TestingMultiThreadSpeed.IncrementCounter1);
            //Thread t2 = new Thread(TestingMultiThreadSpeed.IncrementCounter2);
            //Stopwatch stopWatch2 = new Stopwatch();
            //stopWatch2.Start();
            //t1.Start();
            //t2.Start();
            //stopWatch2.Stop();
            //t1.Join();
            //t2.Join();
            //Console.WriteLine("Elapsed time with multithreading");
            //Console.WriteLine(stopWatch2.ElapsedMilliseconds);

            TPLClass.TestUri();
            Console.ReadLine();
        }

        public static void IteratingForLoopWithoutTask()
        {
            Console.WriteLine("\nusing Normal For \n");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("i={0}, thread={1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
        public static void IteratingForLoopWithTask()
        {

            Console.WriteLine("\nusing Parallel.For \n");
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("i={0}, thread={1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
        }
    }
}
