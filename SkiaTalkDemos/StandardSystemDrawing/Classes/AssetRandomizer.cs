namespace StandardSystemDrawing.Classes
{
    using System;

    public class AssetRandomizer
    {
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

        public string GetRandomBackground()
        {
            return this._backgrounds[this._randomizer.Next(1, 5)];
        }

        public string GetRandomFont()
        {
            return this._fonts[this._randomizer.Next(1, 5)];
        }

        public string GetRandomImage()
        {
            return this._images[this._randomizer.Next(1, 5)];
        }

        public string GetRandomQuote()
        {
            return this._quotes[this._randomizer.Next(1, 5)];
        }
    }
}