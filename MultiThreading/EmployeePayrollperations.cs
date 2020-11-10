using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class EmployeePayrollOperations
    {
        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();
        public void addEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine(" Employee being added: " + employeeData.EmployeeName);
                this.addEmployeePayroll(employeeData); 
                Console.WriteLine(" Employee added: " + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailList.Count);
            Console.WriteLine();
        }
        public void addEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine(" Employee being added: " + employeeData.EmployeeName);
                    this.addEmployeePayroll(employeeData);
                    Console.WriteLine(" Employee added: " + employeeData.EmployeeName);
                });
                thread.Start();
            });
            Console.WriteLine(this.employeePayrollDetailList.Count);
        }

        public void addEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailList.Add(emp);
        }
         
        public int EmployeeCount()
        {
            return this.employeePayrollDetailList.Count;
        }
    }
}
