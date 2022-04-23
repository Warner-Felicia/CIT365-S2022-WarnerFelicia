using System;

namespace MyFirstConsoleApplication
{
    internal static class GlazerApp
    {
        public static void RunExample()
        {
            //get window length from user and convert to a double
            double width;
            Console.WriteLine("Please enter the length of the window in feet");
            var widthString = Console.ReadLine();
            
            while (!double.TryParse(widthString, out width))
            {
                Console.WriteLine("Please enter the length of the window in feet");
                widthString = Console.ReadLine();
            }
            
            //get window height from user and convert to a double
            double height;
            Console.WriteLine("Please enter the height of the window in feet");
            var heightString = Console.ReadLine();
            
            while (!double.TryParse(heightString, out height))
            {
                Console.WriteLine("Please enter the height of the window in feet");
                heightString = Console.ReadLine();
            }
            
            //calculate the area for glass and perimeter for wood frame and output to console
            var woodLength = 2 * (width + height) * 3.25;
            var glassArea = 2 * (width * height);
            Console.WriteLine($"The length of the wood is {woodLength} feet.");
            Console.WriteLine($"The area of the glass is {glassArea} square meters.");
        }
    }

    
}
