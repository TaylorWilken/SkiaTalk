namespace CoreSkiaSharp.Classes
{
    using System;
    using System.IO;

    public class AssetRandomizer
    {
        private readonly string _assetFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "SkiaTalk");

        private readonly string[] _backgrounds = { "BG1.jpg", "BG2.jpg", "BG3.jpg", "BG4.jpg", "BG5.jpg" };

        private readonly string[] _fonts =
            {
                "BioRhyme-Regular.ttf", "BungeeShade-Regular.ttf", "Fruktur-Regular.ttf", "Lalezar-Regular.ttf",
                "Monoton-Regular.ttf"
            };

        private readonly string[] _images = { "IMG1.png", "IMG2.png", "IMG3.png", "IMG4.png", "IMG5.png" };

        private readonly string[] _quotes =
            {
                "The spectacle before us was indeed sublime.", "A red flare silhouetted the jagged edge of a wing.",
                "She stared through the window at the stars.", "I watched the storm, so beautiful yet terrific.",
                "Silver mist suffused the deck of the ship."
            };

        private readonly Random _randomizer = new Random();

        public void ClearOutputPath()
        {
            var outPath = Path.Combine(this._assetFolder, "skiaoutput");

            foreach (var filePath in Directory.GetFiles(outPath)) File.Delete(filePath);
        }

        public string GetOutputImage(int index)
        {
            return Path.Combine(this._assetFolder, "skiaoutput", string.Format("TestImage_{0}.png", index));
        }

        public string GetRandomBackground()
        {
            return Path.Combine(
                this._assetFolder,
                "assets",
                "backgrounds",
                this._backgrounds[this._randomizer.Next(1, 5)]);
        }

        public string GetRandomFont()
        {
            return Path.Combine(this._assetFolder, "assets", "fonts", this._fonts[this._randomizer.Next(1, 5)]);
        }

        public string GetRandomImage()
        {
            return Path.Combine(this._assetFolder, "assets", "images", this._images[this._randomizer.Next(1, 5)]);
        }

        public string GetRandomQuote()
        {
            return this._quotes[this._randomizer.Next(1, 5)];
        }
    }
}