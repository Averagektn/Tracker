using NewTracker.Elements;
using NewTracker.Figures;
using NewTracker.Network;
using Timer = System.Windows.Forms.Timer;

namespace NewTracker
{
    public partial class PaintForm : Form
    {
        private const int LOAD_FILE_FREQUENCY = 1, LOAD_SERVER_FREQUENCY = 50000;
        private const double DIAGONAL_CORRECTION = 1.4;

        // CONFIG
        private static readonly string LOG_FILE_PATH = App.Default.DstFile;
        private static readonly string LOAD_FILE_PATH = App.Default.SrcFile;
        private static readonly bool IS_TARGET_ELLIPSE = App.Default.IsTargetEllipse;
        private static readonly bool IS_TARGET_RECT = App.Default.IsTargetRect;
        private static readonly bool IS_CURSOR_ELLIPSE = App.Default.IsCursorEllipse;
        private static readonly bool IS_CURSOR_RECT = App.Default.IsCursorRect;
        private static readonly bool WRITE_UNIQUE = App.Default.WriteUnique;
        private static readonly bool IS_GET_FROM_FILE = App.Default.IsGetFromFile;
        private static readonly bool IS_GET_FROM_SERVER = App.Default.IsGetFromServer;
        private static readonly bool IS_UDP_SERVER = App.Default.IsUDPConnection;
        private static readonly bool IS_TCP_SERVER = App.Default.IsTCPConnection;
        private static readonly int SPEED = App.Default.Speed;
        private static readonly int SAVE_FREQUENCY = App.Default.SaveFrequency;
        private static readonly int SHOT_FREQUENCY = App.Default.ShotFrequency;
        private static readonly int TARGET_WIDTH = App.Default.TargetWidth;
        private static readonly int TARGET_HEIGHT = App.Default.TargetHeight;
        private static readonly int CURSOR_WIDTH = App.Default.CursorWidth;
        private static readonly int CURSOR_HEIGHT = App.Default.CursorHeight;
        private static readonly int SCREEN_WIDTH = App.Default.ScreenWidth;
        private static readonly int SCREEN_HEIGHT = App.Default.ScreenHeight;
        private static readonly Color CURSOR_COLOR = App.Default.CursorColor;

        private static readonly int SCREEN_CENTER_X = SCREEN_WIDTH / 2;
        private static readonly int SCREEN_CENTER_Y = SCREEN_HEIGHT / 2;

        private bool IsGameOver;
        private readonly Thread? _thread;
        private readonly IFigure cursor;
        private readonly Target target;
        private Rectangle rect;

        private readonly Timer timerLOG, timerLoadTarget, timerShot;
        private bool leftPressed, rightPressed, upPressed, downPressed;
        private int targetX, targetY, score, linesToSkip;

        public PaintForm()
        {
            InitializeComponent();

            linesToSkip = 0;
            rect = new(SCREEN_CENTER_X - CURSOR_WIDTH / 2, SCREEN_CENTER_Y - CURSOR_HEIGHT / 2, CURSOR_WIDTH, CURSOR_HEIGHT);
            score = 0;
            IsGameOver = false;

            // Cursor initialization
            // Default cursor
            cursor = MyCursor.CreateCursor(typeof(Ellipse), rect, CURSOR_COLOR);
            if (IS_CURSOR_RECT)
            {
                cursor = MyCursor.CreateCursor(typeof(Rect), rect, CURSOR_COLOR);
            }

            // Shooter initialization
            timerShot = new Timer
            {
                Interval = SHOT_FREQUENCY
            };
            timerShot.Tick += new EventHandler(Timer_SHOT_Tick);
            timerShot.Start();

            // Loader initialization
            if (IS_GET_FROM_FILE)
            {
                timerLoadTarget = new Timer
                {
                    Interval = LOAD_FILE_FREQUENCY
                };
                timerLoadTarget.Tick += new EventHandler(Timer_LOAD_FROM_FILE_Tick);
                timerLoadTarget.Start();
            }
            else if (IS_GET_FROM_SERVER)
            {
                if (IS_UDP_SERVER)
                {
                    _thread = new(UDPReceiver.Start);
                    _thread.Start();

                    timerLoadTarget = new Timer
                    {
                        Interval = LOAD_SERVER_FREQUENCY
                    };
                    timerLoadTarget.Tick += new EventHandler(Timer_LOAD_FROM_UDP_SERVER_Tick);
                    timerLoadTarget.Start();
                }
                else if (IS_TCP_SERVER)
                {
                    _thread = new(TCPReceiver.Start);
                    _thread.Start();

                    timerLoadTarget = new Timer
                    {
                        Interval = LOAD_SERVER_FREQUENCY
                    };
                    timerLoadTarget.Tick += new EventHandler(Timer_LOAD_FROM_TCP_SERVER_Tick);
                    timerLoadTarget.Start();
                }
                else
                {
                    timerLoadTarget = new Timer
                    {
                        Interval = LOAD_FILE_FREQUENCY
                    };
                    timerLoadTarget.Tick += new EventHandler(Timer_LOAD_FROM_FILE_Tick);
                    timerLoadTarget.Start();
                }
            }
            else
            {
                timerLoadTarget = new Timer
                {
                    Interval = LOAD_FILE_FREQUENCY
                };
                timerLoadTarget.Tick += new EventHandler(Timer_LOAD_FROM_FILE_Tick);
                timerLoadTarget.Start();
            }

            // Target initialization
            var rnd = new Random();
            targetX = rnd.Next() % (SCREEN_WIDTH - TARGET_WIDTH);
            targetY = rnd.Next() % (SCREEN_HEIGHT - TARGET_HEIGHT);
            target = new(typeof(Ellipse), TARGET_WIDTH, TARGET_HEIGHT);
            if (IS_TARGET_RECT)
            {
                target = new(typeof(Rect), TARGET_WIDTH, TARGET_HEIGHT);
            }

            timerLOG = new Timer
            {
                Interval = SAVE_FREQUENCY
            };
            timerLOG.Tick += new EventHandler(Timer_LOG_Tick);
            timerLOG.Start();

            // Clear file
            using var sw = new StreamWriter(LOG_FILE_PATH, false);
            sw.Write(string.Empty);

            // Intialize client size
            ClientSize = new(SCREEN_WIDTH, SCREEN_HEIGHT);
        }

        private void Timer_LOAD_FROM_TCP_SERVER_Tick(object? sender, EventArgs e)
        {
            int[] numbers = TCPReceiver.GetNewTarget();

            if (numbers == Array.Empty<int>())
            {
                StopGame();
            }
            else
            {
                targetX = numbers[0] + SCREEN_CENTER_X - TARGET_WIDTH / 2;
                targetY = numbers[1] + SCREEN_CENTER_Y - TARGET_HEIGHT / 2;

                if (targetX + TARGET_WIDTH > SCREEN_WIDTH || targetY + TARGET_HEIGHT > SCREEN_HEIGHT || targetX < 0 || targetY < 0)
                {
                    timerLoadTarget.Interval = 1;
                }

                timerLoadTarget.Interval = Math.Abs(numbers[2]);
            }
        }

        private void Timer_LOAD_FROM_UDP_SERVER_Tick(object? sender, EventArgs e)
        {
            int[] numbers = UDPReceiver.GetNewTarget();

            if (numbers == Array.Empty<int>())
            {
                StopGame();
            }
            else
            {
                targetX = numbers[0] + SCREEN_CENTER_X - TARGET_WIDTH / 2;
                targetY = numbers[1] + SCREEN_CENTER_Y - TARGET_HEIGHT / 2;

                if (targetX + TARGET_WIDTH > SCREEN_WIDTH || targetY + TARGET_HEIGHT > SCREEN_HEIGHT || targetX < 0 || targetY < 0)
                {
                    timerLoadTarget.Interval = 1;
                }

                timerLoadTarget.Interval = Math.Abs(numbers[2]);
            }
        }

        private void Timer_SHOT_Tick(object? sender, EventArgs e)
        {
            score += target.Shoot(cursor.Center());

            Text = $"Score: {score}";
        }

        private void Timer_LOAD_FROM_FILE_Tick(object? sender, EventArgs e)
        {
            bool incorrectData = false;
            if (!File.Exists(LOAD_FILE_PATH))
            {
                StopGame();
                incorrectData = true;
            }

            while (!incorrectData && LOAD_FILE_PATH != null)
            {
                incorrectData = true;

                int[] numbers = Array.Empty<int>();
                string? line = File.ReadLines(LOAD_FILE_PATH).Skip(linesToSkip).FirstOrDefault();
                if (line != null)
                {
                    string[] numbersAsString = line.Split(' ');

                    numbers = new int[numbersAsString.Length];
                    for (int i = 0; i < numbersAsString.Length; i++)
                    {
                        _ = int.TryParse(numbersAsString[i], out numbers[i]);
                    }
                }

                if (numbers.Length != 3)
                {
                    StopGame();
                }
                else
                {
                    targetX = numbers[0] + SCREEN_CENTER_X - TARGET_WIDTH / 2;
                    targetY = numbers[1] + SCREEN_CENTER_Y - TARGET_HEIGHT /2;
                    timerLoadTarget.Interval = Math.Abs(numbers[2]);
                    linesToSkip++;
                    if (targetX + TARGET_WIDTH > SCREEN_WIDTH || targetY + TARGET_HEIGHT > SCREEN_HEIGHT || targetX < 0 || targetY < 0)
                    {
                        incorrectData = false;
                    }
                }
            }
        }

        private void StopGame()
        {
            Point p1 = new(), p2 = new();
            IsGameOver = true;
            Invalidate();

            timerLoadTarget.Stop();
            timerLOG.Stop();
            timerShot.Stop();
            MessageBox.Show($"GAME OVER. {score}");

            App.Default.BestScore = App.Default.BestScore < score ? score : App.Default.BestScore;

            using var sr = new StreamReader(LOG_FILE_PATH);
            string? str = sr.ReadLine();
            if (str != null)
            {
                string[] numbers = str.Split(' ');
                int num1 = 0, num2 = 0;
                if (numbers.Length == 2 && int.TryParse(numbers[0], out num1) && int.TryParse(numbers[1], out num2))
                {
                    p1 = new(num1 + SCREEN_CENTER_X, num2 + SCREEN_CENTER_Y);
                }
            }

            while ((str = sr.ReadLine()) != null)
            {
                string[] numbers = str.Split(' ');
                int num1 = 0, num2 = 0;
                if (numbers.Length == 2! && int.TryParse(numbers[0], out num1) && int.TryParse(numbers[1], out num2))
                {
                    p2 = new(num1 + SCREEN_CENTER_X, num2 + SCREEN_CENTER_Y);
                    var line = new Line(p1, p2, CURSOR_COLOR);
                    Graphics g = CreateGraphics();
                    line.Draw(g);
                    p1 = p2;
                }
            }
        }

        private void Timer_LOG_Tick(object? sender, EventArgs e)
        {
            int deltaX = 0;
            int deltaY = 0;

            double speed = SPEED;
            if ((downPressed ^ upPressed) && (rightPressed ^ leftPressed))
            {
                speed /= DIAGONAL_CORRECTION;
            }

            if (leftPressed)
            {
                deltaX -= (int)Math.Round(speed);
            }
            if (rightPressed)
            {
                deltaX += (int)Math.Round(speed);
            }
            if (upPressed)
            {
                deltaY -= (int)Math.Round(speed);
            }
            if (downPressed)
            {
                deltaY += (int)Math.Round(speed);
            }

            var prev = new Point(rect.X, rect.Y);

            if (rect.Left < 0)
            {
                rect.X = 0;
            }
            else if (rect.Right > SCREEN_WIDTH)
            {
                rect.X = SCREEN_WIDTH - rect.Width;
            }
            else
            {
                rect.X += deltaX;
            }

            if (rect.Top < 0)
            {
                rect.Y = 0;
            }
            else if (rect.Bottom > SCREEN_HEIGHT)
            {
                rect.Y = SCREEN_HEIGHT - rect.Height;
            }
            else
            {
                rect.Y += deltaY;
            }


            using var sw = new StreamWriter(LOG_FILE_PATH, true);
            if (WRITE_UNIQUE)
            {
                if (!(rect.X == prev.X && rect.Y == prev.Y))
                {
                    sw.WriteLine((cursor.Center().X - SCREEN_CENTER_X) + " " + (cursor.Center().Y - SCREEN_CENTER_Y));
                }
            }
            else
            {
                sw.WriteLine((cursor.Center().X - SCREEN_CENTER_X) + " " + (cursor.Center().Y - SCREEN_CENTER_Y)); ;
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            cursor.p1 = new(rect.Left, rect.Top);
            cursor.p2 = new(rect.Right, rect.Bottom);

            target.p1 = new(targetX, targetY);
            target.p2 = new(targetX + TARGET_WIDTH, targetY + TARGET_HEIGHT);

            if (!IsGameOver)
            {
                target.Draw(e.Graphics);
            }
            cursor.Draw(e.Graphics);
        }

        private void PaintForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Up:
                    upPressed = true;
                    break;
                case Keys.Down:
                    downPressed = true;
                    break;
            }
        }

        private void PaintForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
            }
        }

        private void PaintForm_Deactivate(object sender, EventArgs e)
        {
            downPressed = false;
            upPressed = false;
            leftPressed = false;
            rightPressed = false;
        }

        private void PaintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerLoadTarget.Stop();
            timerLOG.Stop();
            timerShot.Stop();
            UDPReceiver.Stop();
            TCPReceiver.Stop(LOG_FILE_PATH, SCREEN_CENTER_X, SCREEN_CENTER_Y);
            _thread?.Join();

            MainMenu? menu = Application.OpenForms[0] as MainMenu;
            menu?.Show();
        }
    }
}