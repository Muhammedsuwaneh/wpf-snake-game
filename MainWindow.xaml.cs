using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows.Input;
using System.Linq;

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
        private SolidColorBrush snakeBodyBrush = Brushes.Gray;

        /// <summary>
        /// Colors the Snake's head 
        /// </summary>
        private SolidColorBrush snakeHeadBrush = Brushes.Red;

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

        /// <summary>
        /// Indicates if the game playing
        /// </summary>
        private bool IsPlaying { get; set; } = false;

        /// <summary>
        /// Gives the snake food it's next position
        /// </summary>
        private Random randomPosition = new Random();

        private UIElement snakeFood = null;

        private SolidColorBrush foodBrush = Brushes.AliceBlue;

        private int currentScore = 0;

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

                    IsPlaying = false;

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
                    ResetCurrentGame();
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
        /// Closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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
                        if(IsPlaying)
                        {
                            snakeDirection = SnakeDirection.Up;
                            MoveSnake();
                        }
                        break;
                    case "Down":
                        if(IsPlaying)
                        {
                            snakeDirection = SnakeDirection.Down;
                            MoveSnake();
                        }
                        break;
                    case "Left":
                        if(IsPlaying)
                        {
                            snakeDirection = SnakeDirection.Left;
                            MoveSnake();
                        }
                        break;
                    case "Right":
                        if (IsPlaying)
                        {
                            snakeDirection = SnakeDirection.Right;
                            MoveSnake();
                        }
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

                // Remove potential dead snake parts and leftover food
                foreach(SnakePart snakeBodyPart in snakeParts)
                {
                    if(snakeBodyPart.UiElement != null)
                    {
                        GameArea.Children.Remove(snakeBodyPart.UiElement);
                    }
                }

                snakeParts.Clear();

                if (snakeFood != null) GameArea.Children.Remove(snakeFood);


                // reset 
                currentScore = 0;

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

                // Draw snake's food
                DrawSnakeFood();

                UpdateGameStatus();

                // Start Playing
                gameTickTimer.IsEnabled = true;

                IsPlaying = true;

                ContinueGame.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Resets Game 
        /// </summary>
        private void ResetCurrentGame()
        {
            // Remove potential dead snake parts and leftover food
            foreach (SnakePart snakeBodyPart in snakeParts)
            {
                if (snakeBodyPart.UiElement != null)
                {
                    GameArea.Children.Remove(snakeBodyPart.UiElement);
                }
            }

            snakeLength = SnakeSquareSize;

            currentScore = 0;

            snakeParts.Clear();

            if (snakeFood != null) GameArea.Children.Remove(snakeFood);

            gameTickTimer.IsEnabled = false;

            IsPlaying = false;
        }

        #endregion

        #region Drawing
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

            // Draws Black and White Rectangles
            while(!DoneDrawingBackground)
            {
                // create rectangle 
                Rectangle rectangle = new Rectangle()
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = Brushes.Blue,
                };

                // add rectangle to canvas 
                GameArea.Children.Add(rectangle);

                // set current top position 
                Canvas.SetTop(rectangle, nextY);

                // set current left position 
                Canvas.SetLeft(rectangle, nextX);

                // increase the x position - i.e next point on x-axis/Matrix row 
                nextX += SnakeSquareSize;

                // move to next row if the x point column is greater/equal to Game Area Width 
                if(nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += SnakeSquareSize;
                    rowCounter++;
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

        /// <summary>
        /// Returns the next random snake food position
        /// </summary>
        /// <returns>Snake food's position</returns>
        private Point GetNextFoodPosition()
        {
            int maxX = (int)(GameArea.ActualWidth / SnakeSquareSize);
            int maxY = (int)(GameArea.ActualHeight / SnakeSquareSize);
            int foodX = randomPosition.Next(0, maxX) * SnakeSquareSize;
            int foodY = randomPosition.Next(0, maxY) * SnakeSquareSize;

            foreach(SnakePart snakePart in snakeParts)
            {
                if((snakePart.Position.X == foodX) && (snakePart.Position.Y == foodY))
                {
                    return GetNextFoodPosition();
                }
            }

            return new Point(foodX, foodY);
        }

        /// <summary>
        /// Draws the snake'S food
        /// </summary>
        private void DrawSnakeFood()
        {
            Point foodPosition = GetNextFoodPosition();

            snakeFood = new Ellipse()
            {
                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Fill = foodBrush
            };

            GameArea.Children.Add(snakeFood);

            Canvas.SetTop(snakeFood, foodPosition.Y);
            Canvas.SetLeft(snakeFood, foodPosition.X);
        }

        #endregion

        private SnakeDirection PreviousPosition = SnakeDirection.Right;

        #region Motion - Moving Snake 
        /// <summary>
        /// Moves the snake over the game area 
        /// </summary>
        private void MoveSnake()
        {
            // avoid opposite movement conflicts
            if ((PreviousPosition == SnakeDirection.Left && snakeDirection == SnakeDirection.Right)
                 || (PreviousPosition == SnakeDirection.Right && snakeDirection == SnakeDirection.Left)
                 || (PreviousPosition == SnakeDirection.Up && snakeDirection == SnakeDirection.Down)
                 || (PreviousPosition == SnakeDirection.Down && snakeDirection == SnakeDirection.Up))
            {
                snakeDirection = PreviousPosition;
            }

            /* Remove last part of the snake, in preparation of the new part
             * added below
            */
            while (snakeParts.Count >= snakeLength)
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

            DoCollisionCheck();

            PreviousPosition = snakeDirection;
        }

        private void DoCollisionCheck()
        {
            SnakePart snakeHead = snakeParts[snakeParts.Count - 1];

            // if snake eats the food
            if((snakeHead.Position.X == Canvas.GetLeft(snakeFood)) &&
                (snakeHead.Position.Y == Canvas.GetTop(snakeFood)))
            {
                EatSnakeFood();
                return;
            }

            // if snake makes a collision with the walls
            if((snakeHead.Position.Y < 0) || 
                (snakeHead.Position.Y >= GameArea.ActualHeight) ||
                (snakeHead.Position.X < 0) ||
                (snakeHead.Position.X >= GameArea.ActualWidth))
            {
                EndGame();
            }

            // if snake eats itself/ snake head collides with the body
            foreach(SnakePart snakeBodyPart in snakeParts.Take(snakeParts.Count - 1))
            {
                if((snakeHead.Position.X == snakeBodyPart.Position.X) &&
                    (snakeHead.Position.Y == snakeBodyPart.Position.Y))
                {
                    EndGame();
                }
            }
        }

        /// <summary>
        /// Makes the snake eat the food and create another food 
        /// </summary>
        private void EatSnakeFood()
        {
            snakeLength++;
            currentScore++;

            // increase speed of game 
            int timerInterval = Math.Max(SnakeSpeedThreshold, (int)gameTickTimer.Interval.TotalMilliseconds - (currentScore * 2));

            gameTickTimer.Interval = TimeSpan.FromMilliseconds(timerInterval);

            GameArea.Children.Remove(snakeFood);

            DrawSnakeFood();

            UpdateGameStatus();
        }

        /// <summary>
        /// Ends a game when necessary
        /// </summary>
        private void EndGame()
        {
            gameTickTimer.IsEnabled = false;

            PlayGame.IsEnabled = true;

            PauseGame.Visibility = Visibility.Visible;

            MessageBox.Show("Game Over. Ok to Start Over");

            IsPlaying = false;

            StartNewGame();
        }

        /// <summary>
        /// Updates game status
        /// </summary>
        private void UpdateGameStatus()
        {
            this.tbStatusScore.Text = currentScore.ToString();
            this.tbStatusSpeed.Text = gameTickTimer.Interval.TotalMilliseconds.ToString();
        }

        #endregion

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Arrow Up - Moves Snake Up\nArrow Down - Moves Snake Down\nLeft Arrow - Moves Snake Left\nRight Arrow - Moves Snake Left");
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
