using System;

namespace NewTracker.Figures
{
    /// <summary>
    /// Represents an ellipse figure.
    /// </summary>
    [Serializable]
    public class Ellipse : Rect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with default values.
        /// </summary>
        public Ellipse() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with the specified color.
        /// </summary>
        /// <param name="color">The color of the ellipse.</param>
        public Ellipse(Color color) : base() { Color = color; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with the specified starting and ending points and color.
        /// </summary>
        /// <param name="p1">The starting point of the ellipse.</param>
        /// <param name="p2">The ending point of the ellipse.</param>
        /// <param name="color">The color of the ellipse.</param>
        public Ellipse(Point p1, Point p2, Color color) : base(p1, p2, color) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with the specified starting and ending points.
        /// </summary>
        /// <param name="p1">The starting point of the ellipse.</param>
        /// <param name="p2">The ending point of the ellipse.</param>
        public Ellipse(Point p1, Point p2) : base(p1, p2) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with the specified starting point and dimensions.
        /// </summary>
        /// <param name="p1">The starting point of the ellipse.</param>
        /// <param name="x">The width of the ellipse.</param>
        /// <param name="y">The height of the ellipse.</param>
        public Ellipse(Point p1, int x, int y) : base(p1, x, y) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse"/> class with the specified rectangle and color.
        /// </summary>
        /// <param name="rect">The rectangle defining the ellipse's bounds.</param>
        /// <param name="color">The color of the ellipse.</param>
        public Ellipse(Rectangle rect, Color color) : base(rect, color) { }

        /// <summary>
        /// Determines whether the specified point is contained within the ellipse.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns><c>true</c> if the ellipse contains the specified point; otherwise, <c>false</c>.</returns>
        public override bool Contains(Point point)
        {
            double center_x = (p1.X + p2.X) / 2.0;
            double center_y = (p1.Y + p2.Y) / 2.0;

            double a = (p2.X - p1.X) / 2.0;
            double b = (p2.Y - p1.Y) / 2.0;

            double distance = Math.Sqrt(Math.Pow((point.X - center_x) / a, 2) + Math.Pow((point.Y - center_y) / b, 2));

            return distance <= 1;
        }

        /// <summary>
        /// Draws the ellipse on the specified graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object to draw on.</param>
        public override void Draw(Graphics graphics)
        {
            Pen.Color = Color;
            graphics.DrawEllipse(Pen, p1.X, p1.Y, Width, Height);
            graphics.FillEllipse(Brush, p1.X, p1.Y, Width, Height);
        }
    }
}
