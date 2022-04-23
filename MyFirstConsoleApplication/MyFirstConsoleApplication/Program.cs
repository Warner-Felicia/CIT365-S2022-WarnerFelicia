using System;

namespace MyFirstConsoleApplication
{
    internal class Program
    {
        static void Main()
        {
            GetUserNameAndLocation();
            PromptToContinueOrExit("continue");
            ChristmasCountdown(DateTime.Now);
            PromptToContinueOrExit("continues");
            GlazerApp.RunExample();
            PromptToContinueOrExit("exit");
        }

        private static void GetUserNameAndLocation()
        {
            //get name assign to new person object
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine(); 
            while (name == "")
            {
                Console.WriteLine("What is your name?");
                name = Console.ReadLine();
            }
            var person = new Person
            {
                Name = name
            };
             
            //get location and assign to person object
            Console.WriteLine($"Hi {person.Name}. Where are you from?");
            var location = Console.ReadLine();
            while (location == "")
            {
                Console.WriteLine("Where are you from?");
                location = Console.ReadLine();
            }
            person.Location = location;

            Console.WriteLine($"I have never been to {person.Location}. I bet it is nice.");
            
        }

        private static void ChristmasCountdown(DateTime date)
        {
            //format date and output
            var formattedDate = date.ToString("d");
            Console.WriteLine($"Today's date is: {formattedDate}");

            //calculate days until Christmas and output it
            var christmas = new DateTime(DateTime.Now.Year, 12, 25);
            var daysTillChristmas = christmas.Subtract(date).Days;
            Console.WriteLine($"There are {daysTillChristmas} days until Christmas!");
        }

        private static void PromptToContinueOrExit(String action)
        {
            //add space after previous section
            Console.WriteLine();
            
            Console.WriteLine($"Press any key to {action}...");
            Console.ReadKey();
            
            //add space before next section
            Console.WriteLine();
        }

        
    }
}
