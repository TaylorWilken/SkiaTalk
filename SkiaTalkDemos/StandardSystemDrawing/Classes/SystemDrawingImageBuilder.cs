namespace StandardSystemDrawing.Classes
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;

    public class SystemDrawingImageBuilder
    {
        public void BuildSingleTestImage(AssetRandomizer randomizer, int imageIndex)
        {
            // create an empty bitmap and a graphics context (canvas)
            using (var imageBitmap = new Bitmap(1920, 1080))
            {
                using (var imageGraphics = Graphics.FromImage(imageBitmap))
                {
                    // always override these, the defaults make your pics look like doodoo
                    imageGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                    imageGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    // draw a random background
                    var backgroundBitmap = Image.FromFile(randomizer.GetRandomBackground());
                    imageGraphics.DrawImage(backgroundBitmap, new Rectangle(0, 0, 1920, 1080));

                    // draw a random quote in a random font
                    var fontCollection = new PrivateFontCollection();
                    fontCollection.AddFontFile(randomizer.GetRandomFont());
                    var quoteFont = new Font(fontCollection.Families[0], 60, FontStyle.Regular);
                    var quoteRect = new Rectangle(200, 800, 1520, 250);
                    var quoteBrush = new SolidBrush(Color.White);
                    var quoteFormat = new StringFormat
                                          {
                                              Alignment = StringAlignment.Center,
                                              LineAlignment = StringAlignment.Near
                                          };
                    imageGraphics.DrawString(randomizer.GetRandomQuote(), quoteFont, quoteBrush, quoteRect, quoteFormat);

                    // draw a random image
                    var iconBitmap = Image.FromFile(randomizer.GetRandomImage());
                    var iconRect = new Rectangle(704, 200, 512, 512);
                    imageGraphics.DrawImage(iconBitmap, iconRect);

                    // draw a rectangle
                    var strokePen = new Pen(Color.White, 2);
                    var rectRect = new Rectangle(20, 20, 1880, 1040);
                    imageGraphics.DrawRectangle(strokePen, rectRect);

                    // render the image back out as a PNG Image
                    imageGraphics.Flush();
                    imageBitmap.Save(randomizer.GetOutputImage(imageIndex), ImageFormat.Png);
                }
            }
        }
    }
}