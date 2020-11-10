using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiThreading;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given4Employee_WhenAddedTOList_ShouldMatchEmployeeEntries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails { EmployeeID = 1, EmployeeName = "Sindhu" });
            employeeDetails.Add(new EmployeeDetails { EmployeeID = 2, EmployeeName = "Peeter" });
            employeeDetails.Add(new EmployeeDetails { EmployeeID = 3, EmployeeName = "Kavitha" });
            employeeDetails.Add(new EmployeeDetails { EmployeeID = 4, EmployeeName = "Aravindh" });


            EmployeePayrollOperations employeePayrolloperations = new EmployeePayrollOperations();
            DateTime startDateTime = DateTime.Now;
            employeePayrolloperations.addEmployeeToPayroll(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - startDateTime));
            DateTime startDateTimeThread = DateTime.Now;
            employeePayrolloperations.addEmployeeToPayrollWithThread(employeeDetails);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (stopDateTimeThread - startDateTimeThread));
            Console.ReadLine();

        }
    }
}
