namespace NewTracker.Figures
{
    /// <summary>
    /// Represents an interface for a figure.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Gets or sets the starting point of the figure.
        /// </summary>
        public Point p1 { get; set; }
        /// <summary>
        /// Gets or sets the ending point of the figure.
        /// </summary>
        public Point p2 { get; set; }

        /// <summary>
        /// Draws the figure on the specified graphics object.
        /// </summary>
        /// <param name="g">The graphics object to draw on.</param>
        public void Draw(Graphics g);

        /// <summary>
        /// Determines whether the figure contains the specified point.
        /// </summary>
        /// <param name="p">The point to check.</param>
        /// <returns><see langword="true"/> if the figure contains the point; otherwise, <see langword="false"/>.</returns>
        public bool Contains(Point p);

        /// <summary>
        /// Gets the center point of the figure.
        /// </summary>
        /// <returns>The center point of the figure.</returns>
        public Point Center();
    }
}
