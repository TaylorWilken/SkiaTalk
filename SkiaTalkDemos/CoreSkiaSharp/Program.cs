namespace CoreSkiaSharp
{
    using System;
    using System.Diagnostics;
    using System.IO;

    using CoreSkiaSharp.Classes;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var testCount = 10;

            var randomizer = new AssetRandomizer();
            var imageBuilder = new SkiaImageBuilder();

            randomizer.ClearOutputPath();

            var jobTimer = new Stopwatch();
            jobTimer.Start();
            Console.WriteLine("Drawing Test Images with Skia...");
            for (var i = 1; i <= testCount; i++)
            {
                Console.WriteLine("Drawing Image {0}", i);
                imageBuilder.BuildSingleTestImage(randomizer, i);
            }
            Console.WriteLine("Drawing Test Complete");
            jobTimer.Stop();
            Console.WriteLine("Took {0:F2} seconds. Any key to exit.", jobTimer.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}