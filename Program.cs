using System;
using System.Globalization;
using System.IO;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Secao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(",");
                    string name = line[0];
                    string email = line[1];
                    double salary = Double.Parse(line[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double salaryEnter = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Email of people whose salary is more than {salaryEnter.ToString("F2", CultureInfo.InvariantCulture)}:");

            var emails = employees.Where(e => e.Salary > 2000.00).OrderBy(e => e.Name).Select(e => e.Email);
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            var sum = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sum.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
