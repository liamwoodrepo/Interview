using Interview_Web_API.Database.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_Web_API.Helpers
{
    public class ConvertCSVToEmployee
    {
        public static List<Employee> ConvertCSVFileTOEmployees(string FilePath)
        {
            List<Employee> employees = new List<Employee>();
            var cultureInfo = new CultureInfo("en-US");

            string[] lines = System.IO.File.ReadAllLines(FilePath);

            foreach (string line in lines)
            {
                Employee employee = new Employee();

                var lineValue = line.Split(",");

                employee.Title = lineValue[0].Trim();
                employee.FirstName = lineValue[1].Trim();
                employee.lastName = lineValue[2].Trim();
                employee.Gender = lineValue[3].Trim();
                employee.DateOfBirth = DateTime.ParseExact(lineValue[4].Trim(), "MM/dd/yyyy", cultureInfo);
                employee.Email = lineValue[5].Trim();
                employee.JobRole = lineValue[6].Trim();
                employee.Salary = Double.Parse(lineValue[7].Trim());

                employees.Add(employee);
            }

            return employees;
        }
    }
}
