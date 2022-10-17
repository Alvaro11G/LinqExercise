using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");

            //TODO: Print the Average of numbers
            var average = numbers.Average();
            Console.WriteLine($"Average: {average}");

            //TODO: Order numbers in ascending order and print to the console
            var ascending = numbers.OrderBy(x => x);
            Console.Write("Ascending: ");
            foreach (int asc in ascending)
            {
                Console.Write($",{asc}");
            }
            Console.WriteLine();
            //TODO: Order numbers in decsending order and print to the console
            var decsending = numbers.OrderBy(z => -z);
            Console.Write("Decsending: ");
            foreach(int dec in decsending)
            {
                Console.Write($",{dec}");
            }
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6
            var six = numbers.Where(x => x > 6);
            Console.Write("Greater than 6: ");
            foreach (int num in six)
            {
                Console.Write($",{num}");
            }
            Console.WriteLine();
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var four = numbers.Take(4);
            Console.Write("Print only 4: ");
            foreach (var num in four)
            {
                Console.Write($",{num}");
            }
            Console.WriteLine();
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 20;
            var age = numbers.OrderBy(x => -x);
            Console.Write("Change index 4 to age: ");
            foreach(var num in age)
            {
                Console.Write($",{num}");
            }
            Console.WriteLine();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName[0] == 'S')
            .OrderBy(person => person.FirstName);
            Console.WriteLine("First name starts with C or S: ");
            foreach(Employee employee in filtered)
            {
                Console.WriteLine(employee.FullName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var EmployeeAge = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);
            Console.WriteLine("Employees over age 26: ");
            foreach(Employee employee1 in EmployeeAge)
            {
                Console.WriteLine($"Age: {employee1.Age} Name: {employee1.FullName}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var SumOfYOE = years.Sum(x => x.YearsOfExperience);
            var AverageOfYOE = years.Average(x => x.YearsOfExperience);
            Console.WriteLine($"Sum of YOE: {SumOfYOE} Average of YOE: {AverageOfYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("firstName", "lastName", 30, 3)).ToList();
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
