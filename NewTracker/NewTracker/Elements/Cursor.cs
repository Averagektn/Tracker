using NewTracker.Figures;

namespace NewTracker.Elements
{
    /// <summary>
    /// Represents a cursor for the application.
    /// </summary>
    internal static class MyCursor
    {
        /// <summary>
        /// Creates a cursor using the default shape (Ellipse).
        /// </summary>
        /// <returns>The created cursor as an instance of <see cref="IFigure"/>.</returns>
        public static IFigure CreateCursor()
        {
            return new Ellipse();
        }

        /// <summary>
        /// Creates a cursor using the specified figure type, rectangle, and color.
        /// </summary>
        /// <param name="TFigure">The type of figure to create.</param>
        /// <param name="rect">The rectangle defining the cursor's bounds.</param>
        /// <param name="color">The color of the cursor.</param>
        /// <returns>The created cursor as an instance of <see cref="IFigure"/>.</returns>
        public static IFigure CreateCursor(Type TFigure, Rectangle rect, Color color)
        {
            return Activator.CreateInstance(TFigure, rect, color) as IFigure ?? new Ellipse(rect, color);
        }
    }
}
