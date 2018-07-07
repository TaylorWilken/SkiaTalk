namespace CoreSkiaSharp.Classes
{
    using System.IO;

    using SkiaSharp;

    public class SkiaImageBuilder
    {
        public void BuildSingleTestImage(AssetRandomizer randomizer, int imageIndex)
        {
            var imageBitmap = new SKBitmap(1920, 1080);
            var imageCanvas = new SKCanvas(imageBitmap);
            imageCanvas.Clear();

            // draw a random background
            var backgroundFileStream = File.OpenRead(randomizer.GetRandomBackground());
            var backgroundBitmap = SKBitmap.Decode(backgroundFileStream);
            imageCanvas.DrawBitmap(backgroundBitmap, new SKRect(0, 0, 1980, 1020));

            // draw a random quote in a random font
            var font = SKTypeface.FromFile(randomizer.GetRandomFont());
            var brush = new SKPaint
                            {
                                Typeface = font,
                                TextSize = 58.0f,
                                IsAntialias = true,
                                Color = new SKColor(255, 255, 255, 128)
                            };
            imageCanvas.DrawText(randomizer.GetRandomQuote(), 50, 400, brush);
            imageCanvas.Flush();

            // draw a random image
            var iconFileStream = File.OpenRead(randomizer.GetRandomImage());
            var iconBitmap = SKBitmap.Decode(iconFileStream);
            imageCanvas.DrawBitmap(iconBitmap, new SKRect(50, 50, 250, 250));
            imageCanvas.Flush();

            // draw a rectangle
            var rectRect = new SKRect(20, 20, 300, 120);
            var rectBrush = new SKPaint { Color = new SKColor(255, 50, 50, 200) };
            imageCanvas.DrawRect(rectRect, rectBrush);
            imageCanvas.Flush();

            // render the image back out as a PNG
            var image = SKImage.FromBitmap(imageBitmap);
            using (var data = image.Encode(SKEncodedImageFormat.Png, 90))
            {
                // save the data to a stream
                using (var stream = File.OpenWrite(randomizer.GetOutputImage(imageIndex)))
                {
                    data.SaveTo(stream);
                }
            }
        }
    }
}