using System;

namespace CoreSkiaSharp
{
    using System.Diagnostics;
    using System.Threading;
    using System.Timers;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch jobTimer = new Stopwatch();
            jobTimer.Start();
            Console.WriteLine("Drawing Test Images with Skia...");
            Thread.Sleep(876);
            Console.WriteLine("Drawing Test Complete");
            jobTimer.Stop();
            Console.WriteLine("Took {0:F2} seconds. Any key to exit.", jobTimer.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}
