using System;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stopwatch:");
            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Press 1 to start the watch.\n Press 2 to stop the watch.\n Press anything else to exit the application.");
            int userSelection = Convert.ToInt32(Console.ReadLine());
            switch (userSelection)
                {
                    case 1:
                        watch.Start();
                        break;
                    case 2:
                        watch.Stop();
                        Console.WriteLine("Time elapsed: " + watch.elapsed);
                        break;
                }
            Console.ReadLine();
            
            
        }
    }
}
