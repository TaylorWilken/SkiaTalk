namespace CoreSkiaSharp
{
    using System;
    using System.Diagnostics;

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
            Console.WriteLine("Drawing Test Images with SkiaSharp in .NET Core 2.1...");
            for (var i = 1; i <= testCount; i++)
            {
                Console.WriteLine("Drawing Image {0}", i);
                imageBuilder.BuildSingleTestImage(randomizer, i);
            }

            Console.WriteLine("Drawing Test Complete");
            jobTimer.Stop();
            Console.WriteLine(
                "Drew {0} images in {1:F2} seconds. Any key to exit.",
                testCount,
                jobTimer.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }
}