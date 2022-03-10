﻿using System;
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
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Sum()/numbers.Length);
            Console.WriteLine($"");

            //Order numbers in ascending order and decsending order. Print each to console.

            var ascending = numbers.OrderBy(number => number);
            foreach(var item in ascending)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"");

            var descending = numbers.OrderByDescending(number => number);
            foreach(var item in descending)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"");

            //Print to the console only the numbers greater than 6
            var overSix = numbers.Where(number => number > 6);
            foreach(var item in overSix)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**                     
            var newAscending = numbers.OrderBy(number => number).ToArray();
            Array.Resize(ref newAscending, 4);
            foreach(var item in newAscending)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 28;
            numbers = numbers.OrderByDescending(number => number).ToArray();
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine($"");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var employeeNamesFiltered = employees.Where(employee => employee.FirstName[0] == 'C' || employee.FirstName[0] == 'S').OrderBy(employee => employee.FirstName);
            Console.WriteLine($"");
            foreach(var employee in employeeNamesFiltered)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine($"");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var employeesAgeFiltered = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);
            foreach(var employee in employeesAgeFiltered)
            {
                Console.WriteLine(employee.FullName);
                Console.WriteLine(employee.Age);
            }
            Console.WriteLine($"");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var employeesExpFiltered = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine(employeesExpFiltered.Sum(employee => employee.YearsOfExperience));
            Console.WriteLine(employeesExpFiltered.Average(employee => employee.YearsOfExperience));
            Console.WriteLine($"");

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Master", "Chief", 35, 15)).ToList();
            foreach(var employee in employees)
            {
                Console.WriteLine(employee.FullName);
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
