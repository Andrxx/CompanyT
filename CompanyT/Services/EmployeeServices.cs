using CompanyT.Models;
using System.Collections.Generic;

namespace CompanyT.Services
{
    public static class EmployeeServices
    {
        public static List<Employee> GetEmployees(int CompanyId, ApplicationContext context)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = (from e in context.Employees
                             where e.cId == CompanyId
                             orderby e.LastName
                             select e).ToList();
            }
            catch (Exception ex) { }
            if (employees.Count < 5) employees = CreateTestList(employees, CompanyId);
            return employees;
        }


        /// <summary>
        ///  Тестовые записи
        /// </summary>
        /// <returns></returns>
        static List<Employee> CreateTestList(List<Employee> EmployeesList, int cId)
        {
            for (int i = 0; i < 5; i++)
            {
                Employee employee = new Employee();
                employee.cId = cId;
                employee.FirstName = Fname[new Random().Next(Fname.Count)];
                employee.LastName = Lname[new Random().Next(Lname.Count)];
                employee.Position = "trader";
                employee.BirthDate = new DateOnly(1985, 3, 3) ;
                EmployeesList.Add(employee);
            }

            return EmployeesList;
        }

        static List<string> Fname = new List<string>() {"John", "Bill", "Jack", "Don", "Bob", "Ken"};
        static List<string> Lname = new List<string>() { "Smith", "Black", "Jonson", "Tracy", "Clark", "Rott" };
    }  
}
