using System;

namespace MyFirstConsoleApplication
{
    internal static class GlazerApp
    {
        public static void RunExample()
        {
            //get window length from user and convert to a double
            double width;
            
            while (true)
            {
                Console.WriteLine("Please enter the length of the window in feet");
                var widthString = Console.ReadLine();
                if (!double.TryParse(widthString, out width))
                {
                    continue;
                }

                if (!(width > 0))
                {
                    continue;
                }

                break;
            }
            
            //get window height from user and convert to a double
            double height;
            while (true)
            {
                Console.WriteLine("Please enter the height of the window in feet");
                var heightString = Console.ReadLine();
                if (!double.TryParse(heightString, out height))
                {
                    continue;
                }

                if (!(height > 0))
                {
                    continue;
                }

                break;
            }

            //calculate the area for glass and perimeter for wood frame and output to console
            var woodLength = 2 * (width + height) * 3.25;
            var glassArea = 2 * (width * height);
            Console.WriteLine($"The length of the wood is {woodLength} feet.");
            Console.WriteLine($"The area of the glass is {glassArea} square meters.");
        }
    }

    
}
