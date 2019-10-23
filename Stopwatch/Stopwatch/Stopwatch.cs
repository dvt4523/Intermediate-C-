using System;
using System.Collections.Generic;
using System.Text;

namespace Stopwatch
{
    class Stopwatch
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public TimeSpan elapsed { get; set; }

        public bool isRunning = false;
        public void Start()
        {
            if (isRunning)
            {
                throw new InvalidOperationException("Stopwatch is already running!");
            }
            
            start = DateTime.Now;
            Console.WriteLine("Watch is running...");
            isRunning = true;
        }

        public void Stop()
        {
            if (!isRunning)
            {
                throw new InvalidOperationException("Please start the watch first!");
            }

            end = DateTime.Now;
            Console.WriteLine("The watch has stoped.");
            elapsed = end - start;
            isRunning = false;
        }
    }
}
