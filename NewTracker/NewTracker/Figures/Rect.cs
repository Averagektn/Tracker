namespace NewTracker.Figures
{
    /// <summary>
    /// Represents a rectangle figure.
    /// </summary>
    [Serializable]
    public class Rect : Line
    {
        /// <summary>
        /// Gets the brush used for filling the rectangle.
        /// </summary>
        protected Brush Brush => new SolidBrush(Color);
        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> class with default values.
        /// </summary>
        public Rect() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> class with the specified starting point and dimensions.
        /// </summary>
        /// <param name="p1">The starting point of the rectangle.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        public Rect(Point p1, int w, int h) : base()
        {
            this.p1 = p1;
            p2 = new Point(p1.X + w, p1.Y + h);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> class with the specified starting and ending points.
        /// </summary>
        /// <param name="p1">The starting point of the rectangle.</param>
        /// <param name="p2">The ending point of the rectangle.</param>
        public Rect(Point p1, Point p2) : base(p1, p2) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> class with the specified starting and ending points, and color.
        /// </summary>
        /// <param name="p1">The starting point of the rectangle.</param>
        /// <param name="p2">The ending point of the rectangle.</param>
        /// <param name="color">The color of the rectangle.</param>
        public Rect(Point p1, Point p2, Color color) : base(p1, p2, color) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rect"/> class with the specified rectangle and color.
        /// </summary>
        /// <param name="rect">The rectangle defining the position and size of the figure.</param>
        /// <param name="color">The color of the rectangle.</param>
        public Rect(Rectangle rect, Color color)
        {
            p1 = new Point(rect.Left, rect.Top);
            p2 = new Point(rect.Right, rect.Bottom);
            Color = color;
        }

        /// <summary>
        /// Determines whether the rectangle contains the specified point.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns><see langword="true"/> if the rectangle contains the point; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(Point point)
        {
            if (point.X >= p1.X && point.X <= p2.X && point.Y >= p1.Y && point.Y <= p2.Y)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws the rectangle on the specified graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object to draw on.</param>
        public override void Draw(Graphics graphics)
        {
            Pen.Color = Color;
            graphics.DrawRectangle(Pen, p1.X, p1.Y, Width, Height);
            graphics.FillRectangle(Brush, p1.X, p1.Y, Width, Height);
        }
    }
}
