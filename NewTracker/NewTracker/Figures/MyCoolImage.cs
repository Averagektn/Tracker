namespace NewTracker.Figures
{
    /// <summary>
    /// Represents a figure that is an image.
    /// </summary>
    public class MyCoolImage : Figure
    {
        /// <summary>
        /// Gets or sets the file name of the image.
        /// </summary>
        public string FileName { get; set; } = "";
        /// <summary>
        /// Gets or sets a value indicating whether the image is a rectangle.
        /// </summary>
        public bool IsRect { get; set; } = true;

        /// <summary>
        /// Gets the image object from the file.
        /// </summary>
        protected Image Image => Image.FromFile(FileName);

        /// <summary>
        /// Initializes a new instance of the <see cref="MyCoolImage"/> class with default values.
        /// </summary>
        public MyCoolImage() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyCoolImage"/> class with the specified file name and coordinates.
        /// </summary>
        /// <param name="fileName">The file name of the image.</param>
        /// <param name="p1">The starting point of the image.</param>
        /// <param name="p2">The ending point of the image.</param>
        public MyCoolImage(string fileName, Point p1, Point p2) : base(p1, p2)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Determines whether the image is equal to the specified figure.
        /// </summary>
        /// <typeparam name="T">The type of the figure.</typeparam>
        /// <param name="figure">The figure to compare.</param>
        /// <returns><see langword="true"/> if the image is equal to the specified figure; otherwise, <see langword="false"/>.</returns>
        public override bool Equals<T>(T figure)
        {
            if (base.Equals(figure) && FileName == (figure as MyCoolImage)?.FileName)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the image contains the specified point.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns><see langword="true"/> if the image contains the point; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(Point point)
        {
            if (point.X >= p1.X && point.X <= p2.X && point.Y >= p1.Y && point.Y <= p2.Y)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws the image on the specified graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object to draw on.</param>
        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(Image, p1.X, p1.Y, Width, Height);
        }
    }
}
