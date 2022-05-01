using System;

namespace MyFirstConsoleApplication
{
    internal static class GlazerApp
    {
        public static void RunExample()
        {
            //get window length from user and convert to a double
            var width = GetValidInput("width");
            
            //get window height from user and convert to a double
            var height = GetValidInput("height");

            //calculate the area for glass and perimeter for wood frame and output to console
            var woodLength = 2 * (width + height) * 3.25;
            var glassArea = 2 * (width * height);
            Console.WriteLine($"The length of the wood is {woodLength} feet.");
            Console.WriteLine($"The area of the glass is {glassArea} square meters.");
        }

        public static double GetValidInput(string dimension)
        {
            double number;
            while (true)
            {
                Console.WriteLine($"Please enter the {dimension} of the window in feet");
                var numberString = Console.ReadLine();
                
                //make sure number is double
                if (!double.TryParse(numberString, out number))
                {
                    continue;
                }

                //make sure number is not negative
                if (!(number > 0))
                {
                    continue;
                }

                break;
            }
            return number;
        }
    }

    
}
