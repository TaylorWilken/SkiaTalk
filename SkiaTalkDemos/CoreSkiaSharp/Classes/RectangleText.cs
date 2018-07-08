namespace CoreSkiaSharp.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using SkiaSharp;

    // Skia does not draw text in boxes with line breaks, etc, like System.Drawing
    // This class is based on this: https://forums.xamarin.com/discussion/105582/drawtext-multiline
    public class RectangleText
    {
        public void DrawText(SKCanvas canvas, string text, SKRect area, SKPaint paint)
        {
            float lineHeight = paint.TextSize * 1.2f;
            var lines = SplitLines(text, paint, area.Width);

            var y = area.Top;

            foreach (var line in lines)
            {
                y += lineHeight;
                var x = area.MidX - (line.Width / 2);
                canvas.DrawText(line.Value, x, y, paint);
            }
        }

        private static RectangleTextLine[] SplitLines(string text, SKPaint paint, float maxWidth)
        {
            var spaceWidth = paint.MeasureText(" ");
            var lines = text.Split('\n');

            return lines.SelectMany(
                (line) =>
                    {
                        var result = new List<RectangleTextLine>();

                        var words = line.Split(new[] { " " }, StringSplitOptions.None);

                        var lineResult = new StringBuilder();
                        float width = 0;
                        foreach (var word in words)
                        {
                            var wordWidth = paint.MeasureText(word);
                            var wordWithSpaceWidth = wordWidth + spaceWidth;
                            var wordWithSpace = word + " ";

                            if (width + wordWidth > maxWidth)
                            {
                                result.Add(new RectangleTextLine() { Value = lineResult.ToString(), Width = width });
                                lineResult = new StringBuilder(wordWithSpace);
                                width = wordWithSpaceWidth;
                            }
                            else
                            {
                                lineResult.Append(wordWithSpace);
                                width += wordWithSpaceWidth;
                            }
                        }

                        result.Add(new RectangleTextLine() { Value = lineResult.ToString(), Width = width });

                        return result.ToArray();
                    }).ToArray();
        }
    }
}