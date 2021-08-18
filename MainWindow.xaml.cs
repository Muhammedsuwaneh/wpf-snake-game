using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows.Input;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Snake properties

        public const int SnakeSquareSize = 20;

        /// <summary>
        ///  Colors the Snake's body
        /// </summary>
        private SolidColorBrush snakeBodyBrush = Brushes.Green;

        /// <summary>
        /// Colors the Snake's head 
        /// </summary>
        private SolidColorBrush snakeHeadBrush = Brushes.YellowGreen;

        /// <summary>
        /// Keeps a reference to all snake parts
        /// </summary>
        private List<SnakePart> snakeParts = new List<SnakePart>();

        /// <summary>
        /// Holds the snakes current direction
        /// </summary>
        private SnakeDirection snakeDirection = SnakeDirection.Right;

        /// <summary>
        /// Holds the snakes length
        /// </summary>
        private int snakeLength;

        /// <summary>
        /// Gives the snake it's initial speed
        /// </summary>
        public const int SnakeStartSpeed = 400;

        /// <summary>
        /// Snake speed threshold
        /// </summary>
        public const int SnakeSpeedThreshold = 100;

        /// <summary>
        /// Default snake length
        /// </summary>
        public const int SnakeStartLength = 3;

        #endregion

        #region Game Properties

        /// <summary>
        /// Game timer
        /// </summary>
        private DispatcherTimer gameTickTimer = new DispatcherTimer();

        private bool IsPlaying { get; set; } = false;

        #endregion

        #region Constructor 

        public MainWindow()
        {
            InitializeComponent();

            // start ticking 
            gameTickTimer.Tick += GameTickTimer_Tick;

            // Hide continue 
            ContinueGame.Visibility = Visibility.Collapsed;

            // set keyboard shortcuts

            // play 
            PlayCommand.InputGestures.Add(new KeyGesture(Key.G, ModifierKeys.Control));

            // pause 
            PauseCommand.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Control));

            // continue 
            ContinueCommand.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

            // reset
            ResetCommand.InputGestures.Add(new KeyGesture(Key.R, ModifierKeys.Control));

            // exit
            ExitCommand.InputGestures.Add(new KeyGesture(Key.Q, ModifierKeys.Control));
        }

        #endregion

        #region Game Commands 

        /// <summary>
        /// Game Play Command 
        /// </summary>
        public static RoutedCommand PlayCommand = new RoutedCommand();

        public static RoutedCommand PauseCommand = new RoutedCommand();

        public static RoutedCommand ContinueCommand = new RoutedCommand();

        public static RoutedCommand ResetCommand = new RoutedCommand();

        public static RoutedCommand ExitCommand = new RoutedCommand();

        private void PlayGameCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PlayGameCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Play);
        }

        private void PauseGameCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PauseGameCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Pause);
        }

        private void ContinueGameCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ContinueGameCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Continue);
        }

        private void ResetGameCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ResetGameCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Reset);
        }

        private void ExitGameCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitGameCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Exit);
        }

        #endregion

        #region Game Menu Events

        /// <summary>
        /// Plays the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayGame_Click(object sender, RoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Play);
        }

        /// <summary>
        ///  Exits the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Exit);
        }

        /// <summary>
        /// Resets game 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetGame_Click(object sender, RoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Reset);
        }

        /// <summary>
        /// Continues gmae if paused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinueGame_Click(object sender, RoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Continue);
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseGame_Click(object sender, RoutedEventArgs e)
        {
            PlayGameControls(GameMenu.Pause);
        }

        private void PlayGameControls(GameMenu gameMenu)
        {
            switch(gameMenu)
            {
                case GameMenu.Play:

                    if(!IsPlaying) StartNewGame();

                    PlayGame.IsEnabled = false;

                    break;
                case GameMenu.Pause:

                    gameTickTimer.IsEnabled = false;

                    ContinueGame.Visibility = Visibility.Visible;

                    PauseGame.Visibility = Visibility.Collapsed;

                    break;
                case GameMenu.Continue:

                    gameTickTimer.IsEnabled = true;

                    ContinueGame.Visibility = Visibility.Collapsed;

                    PauseGame.Visibility = Visibility.Visible;

                    IsPlaying = true;
                    break;
                case GameMenu.Reset:
                    StartNewGame();
                    break;
                case GameMenu.Exit:
                    var dialogResult = (System.Windows.Forms.DialogResult)MessageBox.Show("Are you sure ?", "Exit Game", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                    }

                    else return;
                    break;
                default:
                    return;
            }
        }

        #endregion

        #region Game Controls 

        /// <summary>
        /// Controls the movement of the snake 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(IsPlaying)
            {
                switch (e.Key.ToString())
                {
                    case "Up":
                        snakeDirection = SnakeDirection.Up;
                        MoveSnake();
                        break;
                    case "Down":
                        snakeDirection = SnakeDirection.Down;
                        MoveSnake();
                        break;
                    case "Left":
                        snakeDirection = SnakeDirection.Left;
                        MoveSnake();
                        break;
                    case "Right":
                        snakeDirection = SnakeDirection.Right;
                        MoveSnake();
                        break;
                }
            }
        }
        
        #endregion

        #region Play Game 

        /// <summary>
        /// Starts the timer 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTickTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        private void StartNewGame()
        {
            if (!IsPlaying)
            {
                snakeLength = SnakeStartLength;

                snakeDirection = SnakeDirection.Right;

                snakeParts.Add(new SnakePart()
                {
                    Position = new Point(SnakeSquareSize * 5, SnakeSquareSize * 5)
                });

                // set speed per second - accelaration
                gameTickTimer.Interval = TimeSpan.FromMilliseconds(SnakeStartSpeed);

                // Draw snake 
                DrawSnake();

                // Start Playing
                gameTickTimer.IsEnabled = true;

                IsPlaying = true;

                ContinueGame.Visibility = Visibility.Collapsed;
            }
        }

        #endregion

        #region Draw - Game Area and Snake
        /// <summary>
        /// Calls the <see cref="DrawGameArea()"/> when all controls are inside th window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            DrawGameArea();
        }

        /// <summary>
        ///  Draws the game area
        /// </summary>
        /// <returns></returns>
        private void DrawGameArea()
        {
            bool DoneDrawingBackground = false;

            int nextX = 0, nextY = 0;

            int rowCounter = 0;

            bool nextIsOdd = false;

            // Draws Black and White Rectangles
            while(!DoneDrawingBackground)
            {
                // create rectangle 
                Rectangle rectangle = new Rectangle()
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = nextIsOdd ? Brushes.White : Brushes.Black
                };

                // add rectangle to canvas 
                GameArea.Children.Add(rectangle);

                // set current top position 
                Canvas.SetTop(rectangle, nextY);

                // set current left position 
                Canvas.SetLeft(rectangle, nextX);

                // reverse odd 
                nextIsOdd = !nextIsOdd;

                // increase the x position - i.e next point on x-axis/Matrix row 
                nextX += SnakeSquareSize;

                // move to next row if the x point column is greater/equal to Game Area Width 
                if(nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += SnakeSquareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                // finish drawing if the next row is greater or equals Game Area Height
                if (nextY >= GameArea.ActualHeight)
                    DoneDrawingBackground = true;
            }
        }

        /// <summary>
        /// Draws and Paints the Snake's 
        /// </summary>
        private void DrawSnake()
        {
            foreach(SnakePart snakePart in snakeParts)
            {
                if(snakePart.UiElement == null)
                {
                    // Draws the snake body or head and colors it
                    snakePart.UiElement = new Rectangle()
                    {
                        Width = SnakeSquareSize,
                        Height = SnakeSquareSize,
                        Fill = (snakePart.IsHead ? snakeHeadBrush : snakeBodyBrush)
                    };

                    // Add snake part to Game Area 
                    GameArea.Children.Add(snakePart.UiElement);

                    Canvas.SetTop(snakePart.UiElement, snakePart.Position.Y);

                    Canvas.SetLeft(snakePart.UiElement, snakePart.Position.X);
                }
            }
        }

        #endregion

        #region Motion - Moving Snake 
        /// <summary>
        /// Moves the snake over the game area 
        /// </summary>
        private void MoveSnake()
        {
            /* Remove last part of the snake, in preparation of the new part
             * added below
            */
            while(snakeParts.Count >= snakeLength)
            {
                GameArea.Children.Remove(snakeParts[0].UiElement);
                snakeParts.RemoveAt(0);
            }
            /* Next up, we'll add a new element to the 
             * snake, which will be the (new) head  
             * Therefore, we mark all existing 
             * parts as non-head (body) elements and then  
             * we make sure that they use the body brush
            */
            foreach(SnakePart snakePart in snakeParts)
            {
                (snakePart.UiElement as Rectangle).Fill = snakeBodyBrush;
                snakePart.IsHead = false;
            }
            /* Determine in which direction to expand
             * the snake, based on the current direction  
            */

            SnakePart snakeHead = snakeParts[snakeParts.Count - 1];

            double nextX = snakeHead.Position.X;

            double nextY = snakeHead.Position.Y;

            switch(snakeDirection)
            {
                case SnakeDirection.Left:
                    nextX -= SnakeSquareSize;
                    break;
                case SnakeDirection.Right:
                    nextX += SnakeSquareSize;
                    break;
                case SnakeDirection.Up:
                    nextY -= SnakeSquareSize;
                    break;
                case SnakeDirection.Down:
                    nextY += SnakeSquareSize;
                    break;
                default:
                    return;
            }

            // Now add the new head part to our list of snake parts
            snakeParts.Add(new SnakePart()
            {
                Position = new Point(nextX, nextY),
                IsHead = true
            });

            DrawSnake();
            //DoCollisionCheck();
        }

        #endregion
    }
}
