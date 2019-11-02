using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class GameForm : Form
    {
        Random rd = new Random();
        List<Panel> snakePanels = new List<Panel>();
        List<Point> snakePoints = new List<Point>();
        int score;
        bool arcade;
        int speed;
        Timer timer;
        List<Direction> directions = new List<Direction>();
        Direction direction;
        private bool lose;
        private bool started = false;

        public GameForm(int speed, bool arcade)
        {
            InitializeComponent();
            panel1.Size = new Size(500, 500);
            SnakeHead.Size = new Size(25, 25);
            SnakeHead.Location = new Point(225, 225);
            Fruit.Visible = false;
            Fruit.Size = new Size(25, 25);
            panel1.MaximumSize = panel1.Size;
            panel1.MinimumSize = panel1.Size;
            this.arcade = arcade;
            this.speed = speed;
            timer = TimerInitialize();
            snakePanels.Add(SnakeHead);
            snakePoints.Add(SnakeHead.Location);
        }
        private void Start()
        {
            timer.Start();
            ChangeFruitLocaton();
            started = true;
        }
        private Timer TimerInitialize()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(Tick);
            timer.Interval = speed * 100;
            return timer;
        }
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (directions.Count != 0)
                    {
                        if (directions[directions.Count - 1] != Direction.Right && directions[directions.Count - 1] != Direction.Left)
                        {
                            directions.Add(Direction.Left);
                        }
                    }
                    else
                    {
                        if (direction != Direction.Right && direction != Direction.Left)
                        {
                            directions.Add(Direction.Left);
                            direction = directions[0];
                        }
                    }
                    break;
                case Keys.Right:
                    if (directions.Count != 0)
                    {
                        if (directions[directions.Count - 1] != Direction.Left && directions[directions.Count - 1] != Direction.Right)
                        {
                            directions.Add(Direction.Right);
                        }
                    }
                    else
                    {
                        if (direction != Direction.Left && direction != Direction.Right)
                        {
                            directions.Add(Direction.Right);
                            direction = directions[0];
                        }
                    }
                    break;
                case Keys.Up:
                    if (directions.Count != 0)
                    {
                        if (directions[directions.Count - 1] != Direction.Down && directions[directions.Count - 1] != Direction.Up)
                        {
                            directions.Add(Direction.Up);
                        }
                    }
                    else
                    {
                        if (direction != Direction.Down && direction != Direction.Up)
                        {
                            directions.Add(Direction.Up);
                            direction = directions[0];
                        }
                    }
                    break;
                case Keys.Down:
                    if (directions.Count != 0)
                    {
                        if (directions[directions.Count - 1] != Direction.Up && directions[directions.Count - 1] != Direction.Down)
                        {
                            directions.Add(Direction.Down);
                        }
                    }
                    else
                    {
                        if (direction != Direction.Up && direction != Direction.Down)
                        {
                            directions.Add(Direction.Down);
                            direction = directions[0];
                        }
                    }
                    break;
            }
            if (!started)
            {
                Start();
            }
        }
        private void Tick(object sender, EventArgs e)
        {
            byte step = byte.Parse(SnakeHead.Size.Width.ToString());
            if (directions.Count != 0)
            {
                direction = directions[0];
            }
            switch (direction)
            {
                case Direction.Up:
                    ChangePosition(0, -step);
                    break;
                case Direction.Down:
                    ChangePosition(0, step);
                    break;
                case Direction.Left:
                    ChangePosition(-step, 0);
                    break;
                case Direction.Right:
                    ChangePosition(step, 0);
                    break;
            }
            if (directions.Count != 0)
            {
                directions.RemoveAt(0);
            }
            if (lose)
            {
                timer.Stop();
                System.Threading.Thread.Sleep(1500);
                this.Close();
            }
        }

        private void ChangePosition(int x, int y)
        {
            CheckPosition(new Point(SnakeHead.Location.X + x, SnakeHead.Location.Y + y));
            if (!lose)
            {
                SnakeHead.Location = new Point(SnakeHead.Location.X + x, SnakeHead.Location.Y + y);
                for (int i = 1; i < snakePoints.Count; i++)
                {
                    snakePanels[i].Location = snakePoints[i - 1];
                }

                for (int i = 0; i < snakePoints.Count; i++)
                {
                    snakePoints[i] = snakePanels[i].Location;
                }
            }
        }

        private void CheckPosition(Point point)
        {
            if (point == Fruit.Location)
            {
                scoreLabel.Text = "Score : " + (++score).ToString();
                AddSnake();
                if (arcade)
                {
                    ChangeSpeed();
                }

                ChangeFruitLocaton();
            }
            else if (point.X >= panel1.Width || point.X < 0 || point.Y < 0 || point.Y >= panel1.Height || PointEqually(point))
            {
                lose = true;
                return;
            }

        }

        private void ChangeSpeed()
        {
            timer.Interval = timer.Interval - (score * 2);
        }
        private void AddSnake()
        {
            Panel panel = new Panel() { BackColor = Color.Aqua, Size = SnakeHead.Size };
            panel.Location = snakePoints[snakePoints.Count - 1];
            panel1.Controls.Add(panel);
            snakePoints.Add(panel.Location);
            snakePanels.Add(panel);
        }
        private bool PointEqually(Point point)
        {
            foreach (Point item in snakePanels.Select(p => p.Location))
            {
                if (point == item)
                {
                    return true;
                }
            }
            return false;
        }
        private void ChangeFruitLocaton()
        {
            Point point;
            if (Fruit.Visible == false)
            {
                Fruit.Visible = true;
            }
            while (true)
            {
                point = new Point(rd.Next(20) * 25, rd.Next(20) * 25);
                if (!PointEqually(point))
                {
                    break;
                }
            }
            Fruit.Location = point;
        }

    }
}
