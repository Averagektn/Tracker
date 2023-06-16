using NewTracker.Figures;

namespace NewTracker.Elements
{
    /// <summary>
    /// Represents a target composed of multiple figures.
    /// </summary>
    internal class Target
    {
        private const int FIELDS = 5;

        private readonly IFigure[] figures = new IFigure[FIELDS];
        private readonly Color[] colors = new Color[FIELDS] { Color.Red, Color.White, Color.Red, Color.White, Color.Red };
        private readonly int dx, dy;

        /// <summary>
        /// Gets or sets the starting point of the target.
        /// </summary>
        public Point p1
        {
            set
            {
                for (int i = 0; i < FIELDS; i++)
                {
                    figures[i].p1 = new Point(value.X + dx / 2 * i, value.Y + dy / 2 * i);
                }
            }
        }

        /// <summary>
        /// Gets or sets the ending point of the target.
        /// </summary>
        public Point p2
        {
            set
            {
                for (int i = 0; i < FIELDS; i++)
                {
                    figures[i].p2 = new Point(value.X - dx / 2 * i, value.Y - dy / 2 * i);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Target"/> class with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the target.</param>
        /// <param name="height">The height of the target.</param>
        public Target(int width, int height)
        {
            dx = width / FIELDS;
            dy = height / FIELDS;
            for (int i = 0; i < FIELDS; i++)
            {
                figures[i] = new Ellipse(colors[i]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Target"/> class with the specified figure type, width, and height.
        /// </summary>
        /// <param name="TFigure">The type of figure to create.</param>
        /// <param name="width">The width of the target.</param>
        /// <param name="height">The height of the target.</param>
        public Target(Type TFigure, int width, int height) : this(TFigure, new Rectangle(0, 0, width, height)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Target"/> class with the specified figure type and rectangle.
        /// </summary>
        /// <param name="TFigure">The type of figure to create.</param>
        /// <param name="rect">The rectangle defining the target's bounds.</param>
        public Target(Type TFigure, Rectangle rect)
        {
            dx = rect.Width / FIELDS;
            dy = rect.Height / FIELDS;

            for (int i = 0; i < FIELDS; i++)
            {
                figures[i] = Activator.CreateInstance(TFigure, rect, colors[i]) as IFigure ?? new Ellipse(rect, colors[i]);
                rect.X += dx / 2;
                rect.Y += dy / 2;
                rect.Width -= dx;
                rect.Height -= dy;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Target"/> class with the specified rectangle.
        /// </summary>
        /// <param name="rect">The rectangle defining the target's bounds.</param>
        public Target(Rectangle rect)
        {
            dx = rect.Width / FIELDS;
            dy = rect.Height / FIELDS;

            for (int i = 0; i < FIELDS; i++)
            {
                figures[i] = new Ellipse(rect, colors[i]);
                rect.X += dx / 2;
                rect.Y += dy / 2;
                rect.Width -= dx;
                rect.Height -= dy;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Target"/> class with the specified starting and ending points.
        /// </summary>
        /// <param name="p1">The starting point of the target.</param>
        /// <param name="p2">The ending point of the target.</param>
        public Target(Point p1, Point p2) : this(new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y)) { }

        /// <summary>
        /// Draws the target on the specified graphics object.
        /// </summary>
        /// <param name="g">The graphics object to draw on.</param>
        public void Draw(Graphics g)
        {
            foreach (var figure in figures)
            {
                figure.Draw(g);
            }
        }

        /// <summary>
        /// Determines which part of the target was hit by a given point.
        /// </summary>
        /// <param name="p">The point to check for a hit.</param>
        /// <returns>The index of the hit part of the target (1 to 5), or 0 if no part was hit.</returns>
        public int Shoot(Point p)
        {
            for (int i = FIELDS - 1; i >= 0; i--)
            {
                if (figures[i].Contains(p))
                {
                    return i + 1;
                }
            }
            return 0;
        }
    }
}
