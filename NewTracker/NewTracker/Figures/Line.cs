namespace NewTracker.Figures
{
    /// <summary>
    /// Represents a line figure.
    /// </summary>
    [Serializable]
    public class Line : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class with default values.
        /// </summary>
        public Line() : this(0, 0, 0, 0) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x1">The x-coordinate of the starting point.</param>
        /// <param name="y1">The y-coordinate of the starting point.</param>
        /// <param name="x2">The x-coordinate of the ending point.</param>
        /// <param name="y2">The y-coordinate of the ending point.</param>
        public Line(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class with the specified starting and ending points.
        /// </summary>
        /// <param name="p1">The starting point of the line.</param>
        /// <param name="p2">The ending point of the line.</param>
        public Line(Point p1, Point p2) : base(p1, p2) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class with the specified starting and ending points and color.
        /// </summary>
        /// <param name="p1">The starting point of the line.</param>
        /// <param name="p2">The ending point of the line.</param>
        /// <param name="color">The color of the line.</param>
        public Line(Point p1, Point p2, Color color) : base(p1, p2, color) { }

        /// <summary>
        /// Determines whether the line contains the specified point.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns><see langword="true"/> if the line contains the point; otherwise, <see langword="false"/>.</returns>
        public override bool Contains(Point point)
        {
            int dx = Math.Abs(p2.X - p1.X);
            int dy = Math.Abs(p2.Y - p1.Y);
            double expectedY;
            try
            {
                expectedY = p1.Y + dy / dx * (point.X - p1.X);
            }
            catch
            {
                return true;
            }

            return Math.Abs(point.Y - expectedY) < 5;
        }

        /// <summary>
        /// Gets the center point of the line.
        /// </summary>
        /// <returns>The center point of the line.</returns>
        public override Point Center()
        {
            return new Point(p1.X + (p2.X - p1.X) / 2, p1.Y + (p2.Y - p1.Y) / 2);
        }

        /// <summary>
        /// Draws the line on the specified graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object to draw on.</param>
        public override void Draw(Graphics graphics)
        {
            Pen.Color = Color;
            graphics.DrawLine(Pen, p1, p2);
        }
    }
}
