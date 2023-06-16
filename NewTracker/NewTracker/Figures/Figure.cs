using Newtonsoft.Json;
using System.Text.Json;

namespace NewTracker.Figures
{
    /// <summary>
    /// Represents a base class for figures.
    /// </summary>
    [Serializable]
    public class Figure : IFigure
    {
        [JsonProperty("figures")]
        private readonly List<Figure> figures = new();

        /// <summary>
        /// Gets the number of figures in the collection.
        /// </summary>
        public int Length => figures.Count;

        /// <summary>
        /// Gets the width of the figure.
        /// </summary>
        protected float Width => Math.Abs(p1.X - p2.X);

        /// <summary>
        /// Gets the height of the figure.
        /// </summary>
        protected float Height => Math.Abs(p1.Y - p2.Y);

        /// <summary>
        /// Gets or sets the starting point of the figure.
        /// </summary>
        public Point p1 { get; set; }

        /// <summary>
        /// Gets or sets the ending point of the figure.
        /// </summary>
        public Point p2 { get; set; }

        /// <summary>
        /// Gets or sets the color of the figure.
        /// </summary>
        public Color Color;

        protected Pen Pen;
        private const int PEN_WIDTH = 3;

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class with default values.
        /// </summary>
        public Figure() : this(0, 0, 0, 0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x1">The X-coordinate of the starting point.</param>
        /// <param name="y1">The Y-coordinate of the starting point.</param>
        /// <param name="x2">The X-coordinate of the ending point.</param>
        /// <param name="y2">The Y-coordinate of the ending point.</param>
        public Figure(int x1, int y1, int x2, int y2)
        {
            Pen = new(Color.FromArgb(new Random().Next(int.MaxValue)))
            {
                Width = PEN_WIDTH
            };
            Color = Pen.Color;
            p1 = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            p2 = new Point(Math.Max(x1, x2), Math.Max(y1, y2));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class with the specified starting and ending points.
        /// </summary>
        /// <param name="p1">The starting point of the figure.</param>
        /// <param name="p2">The ending point of the figure.</param>
        public Figure(Point p1, Point p2)
        {
            Pen = new(Color.FromArgb(new Random().Next(int.MaxValue)))
            {
                Width = PEN_WIDTH
            };
            Color = Pen.Color;
            this.p1 = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            this.p2 = new Point(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Figure"/> class with the specified starting and ending points and color.
        /// </summary>
        /// <param name="p1">The starting point of the figure.</param>
        /// <param name="p2">The ending point of the figure.</param>
        /// <param name="color">The color of the figure.</param>
        public Figure(Point p1, Point p2, Color color) : this(p1, p2)
        {
            Pen = new(color)
            {
                Width = PEN_WIDTH
            };
            Color = color;
        }

        /// <summary>
        /// Gets or sets the figure at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the figure to get or set.</param>
        /// <returns>The figure at the specified index.</returns>
        public Figure this[int index]
        {
            get => figures[index];
            set => figures[index] = value;
        }

        /// <summary>
        /// Draws the figure on the specified graphics object.
        /// </summary>
        /// <param name="graphics">The graphics object to draw on.</param>
        public virtual void Draw(Graphics graphics) { }

        /// <summary>
        /// Gets the center point of the figure.
        /// </summary>
        /// <returns>The center point of the figure.</returns>
        public virtual Point Center() => new();

        /// <summary>
        /// Determines whether the figure contains the specified point.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns><see langword="true"/> if the figure contains the point; otherwise, <see langword="false"/>.</returns>
        public virtual bool Contains(Point point) => false;

        /// <summary>
        /// Removes the specified figure from the collection.
        /// </summary>
        /// <param name="figure">The figure to remove.</param>
        public void Remove(Figure figure)
        {
            if (figures.Contains(figure))
            {
                figures.Remove(figure);
            }
        }

        /// <summary>
        /// Removes all figures that match the specified condition.
        /// </summary>
        /// <param name="match">The condition to match.</param>
        public void RemoveAll(Predicate<Figure> match)
        {
            figures.RemoveAll(match);
        }

        /// <summary>
        /// Determines whether the current figure is equal to the specified figure.
        /// </summary>
        /// <typeparam name="T">The type of figure to compare.</typeparam>
        /// <param name="figure">The figure to compare.</param>
        /// <returns><see langword="true"/> if the current figure is equal to the specified figure; otherwise, <see langword="false"/>.</returns>
        public virtual bool Equals<T>(T figure) where T : Figure
        {
            if (GetType() == figure?.GetType() && figure.p1 == p1 && figure.p2 == p2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds the specified figure to the collection if it does not already exist, or updates the existing figure.
        /// </summary>
        /// <param name="val">The figure to add or update.</param>
        /// <returns>The index at which the figure is added or updated.</returns>
        public int AddUnique(Figure? val)
        {
            for (int i = 0; i < figures.Count; i++)
            {
                if (val != null && val.Equals(figures[i]))
                {
                    figures[i].Pen = new(Color.FromArgb(new Random().Next(int.MaxValue)))
                    {
                        Width = PEN_WIDTH
                    };

                    figures[i].Color = figures[i].Pen.Color;
                    return i;
                }
            }
            if (val != null)
            {
                figures.Add(val);
            }
            return Length - 1;
        }

        /// <summary>
        /// Returns the count of figures.
        /// </summary>
        /// <returns>A string representation of the figure count.</returns>
        public string Count()
        {
            return $"Total figures: {Length}";
        }
    }
}
