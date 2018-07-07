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
                                TextSize = 60.0f,
                                IsAntialias = true,
                                Color = new SKColor(255, 255, 255, 255),
                                Style = SKPaintStyle.Fill
                            };
            imageCanvas.DrawText(randomizer.GetRandomQuote(), 50, 950, brush);
            imageCanvas.Flush();

            // draw a random image
            var iconFileStream = File.OpenRead(randomizer.GetRandomImage());
            var iconBitmap = SKBitmap.Decode(iconFileStream);
            imageCanvas.DrawBitmap(iconBitmap, new SKRect(704, 300, 1216, 812));
            imageCanvas.Flush();

            // draw a rectangle
            var rectRect = new SKRect(20, 20, 1900, 1000);
            var rectBrush = new SKPaint { Color = new SKColor(255, 255, 255, 200), Style = SKPaintStyle.Stroke };
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