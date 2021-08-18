using System.Windows;

namespace SnakeGame
{
    public class SnakePart
    {
        #region Public Properties 

        /// <summary>
        /// Indicates which UI element is used i.e Rectangle for our case 
        /// </summary>
        public UIElement UiElement { get; set; }

        /// <summary>
        /// Snakes position
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// Indicates if reactangle is snake's head or body
        /// </summary>
        public bool IsHead { get; set; }

        #endregion
    }
}
