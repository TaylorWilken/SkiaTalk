using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardSystemDrawing
{
    using System.Diagnostics;

    using StandardSystemDrawing.Classes;

    class Program
    {
        static void Main(string[] args)
        {
            var testCount = 10;

            var randomizer = new AssetRandomizer();
            var imageBuilder = new SystemDrawingImageBuilder();

            randomizer.ClearOutputPath();

            var jobTimer = new Stopwatch();
            jobTimer.Start();
            Console.WriteLine("Drawing Test Images with System.Drawing in .NET 4.6.1...");
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
