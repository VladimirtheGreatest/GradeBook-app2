using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            List<decimal> termsList = new List<decimal>();

            bool execute = true;
            string userInput = "";
            string userName = "";
            string executionCommand = "execute";

            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();
            Console.WriteLine($"Welcome {userName}");
            book.Name = userName;
  

            while (execute != false)
            {
                Console.WriteLine("Enter your grade or press `execute` to calculate your grades");
                userInput = Console.ReadLine();
                if (userInput == executionCommand)
                {
                    execute = false;
                    Console.WriteLine($"Thank you for using Gradebook 1.0 {book.Name}");
                    Console.WriteLine("Here is the list of your grades");
                    //book.grades.OrderBy(x => x).ToList();


                    IEnumerable<double> scoreQuery =
                from something in book.grades
                where something > 60 && something < 90
                orderby something ascending
                select something;


                    //Execute the query.
                    foreach (double i in scoreQuery)
                    {
                        Console.Write(i + " ");
                    }

                   // book.grades.ForEach(i => Console.WriteLine("{0}\t", i));
                   // var orderedList = book.grades.OrderBy(x => x).ToList();
                   // Console.WriteLine(orderedList);
                    Console.ReadLine();
                }
                else
                {
                    try
                    {
                        double converted = Double.Parse(userInput);
                        if (converted <= 100 && converted >= 0)
                        {
                            book.AddGrade(converted);
                        }
                        else
                        {
                            Console.WriteLine("Invalid value");
                        }

                        var stats = book.GetStatistics();
                        Console.WriteLine($"{book.Name}`s gradebook");
                        Console.WriteLine($"The lowest grade is {stats.Low}");
                        Console.WriteLine($"The highest grade is {stats.High}");
                        Console.WriteLine($"The average grade is {stats.Average:N1}");
                        Console.WriteLine($"Your total grade is {stats.Letter}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Mistakes were made, that is not a grade");
                    }
                }
            }
        }
    }
}
