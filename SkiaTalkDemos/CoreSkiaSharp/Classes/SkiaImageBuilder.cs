namespace CoreSkiaSharp.Classes
{
    using System.IO;

    using SkiaSharp;

    public class SkiaImageBuilder
    {
        public void BuildSingleTestImage(AssetRandomizer randomizer, int imageIndex)
        {
            // create an empty bitmap and a graphics context (canvas)
            using (var imageBitmap = new SKBitmap(1920, 1080))
            {
                using (var imageCanvas = new SKCanvas(imageBitmap))
                {
                    imageCanvas.Clear();

                    // draw a random background
                    var backgroundFileStream = File.OpenRead(randomizer.GetRandomBackground());
                    var backgroundBitmap = SKBitmap.Decode(backgroundFileStream);
                    imageCanvas.DrawBitmap(backgroundBitmap, new SKRect(0, 0, 1980, 1020));

                    // draw a random quote in a random font
                    var quoteFont = SKTypeface.FromFile(randomizer.GetRandomFont());
                    var quoteRect = new SKRect(200, 800, 1720, 1050);
                    var brush = new SKPaint
                                    {
                                        Typeface = quoteFont,
                                        TextSize = 60.0f,
                                        IsAntialias = true,
                                        Color = new SKColor(255, 255, 255, 255),
                                        Style = SKPaintStyle.Fill
                                    };

                    RectangleText boxWriter = new RectangleText();
                    boxWriter.DrawText(imageCanvas, randomizer.GetRandomQuote(), quoteRect, brush);

                    // draw a random image
                    var iconFileStream = File.OpenRead(randomizer.GetRandomImage());
                    var iconBitmap = SKBitmap.Decode(iconFileStream);
                    var iconRect = new SKRect(704, 200, 1216, 612);
                    imageCanvas.DrawBitmap(iconBitmap, iconRect);

                    // draw a rectangle
                    var strokeBrush =
                        new SKPaint { Color = new SKColor(255, 255, 255, 200), Style = SKPaintStyle.Stroke };
                    var rectRect = new SKRect(20, 20, 1900, 1000);
                    imageCanvas.DrawRect(rectRect, strokeBrush);

                    // render the image back out as a PNG Image
                    imageCanvas.Flush();
                    var image = SKImage.FromBitmap(imageBitmap);
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 90))
                    {
                        using (var stream = File.OpenWrite(randomizer.GetOutputImage(imageIndex)))
                        {
                            data.SaveTo(stream);
                        }
                    }
                }
            }
        }
    }
}