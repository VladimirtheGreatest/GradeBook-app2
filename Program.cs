using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();

            bool execute = true;
            string userInput = "";
            string executionCommand = "execute";

            while (execute != false)
            {
                Console.WriteLine("Enter your grade or press `execute` to calculate your grades");
                userInput = Console.ReadLine();
                if (userInput == executionCommand)
                {
                    execute = false;
                    Console.WriteLine("Thank you for using Gradebook 1.0");
                    Console.WriteLine("Here is the list of your grades");
                    book.grades.ForEach(i => Console.WriteLine("{0}\t", i));
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
