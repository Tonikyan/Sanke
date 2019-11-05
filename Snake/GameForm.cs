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
        private bool autoPilot;

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
            if (!started)
            {
                Start();
            }
            timer.Stop();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }
                    break;
                case Keys.Right:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }
                    break;
                case Keys.Up:
                    if (direction != Direction.Down)
                    {
                        direction = Direction.Up;
                    }
                    break;
                case Keys.Down:
                    if (direction != Direction.Up)
                    {
                        direction = Direction.Down;
                    }
                    break;
                case Keys.Enter:
                    if (!autoPilot)
                    {
                        autoPilot = true;
                        AutoPilot();
                    }
                    else
                    {
                        autoPilot = false;
                    }
                    break;
            }
            Tick(null, new EventArgs());
            timer.Start();
        }

        private void AutoPilot()
        {
            timer.Stop();
            directions = new List<Direction>();
            int x = (SnakeHead.Location.X - Fruit.Location.X) / SnakeHead.Width;
            int y = (SnakeHead.Location.Y - Fruit.Location.Y) / SnakeHead.Width;
            Direction myDirection = x > 0 ? Direction.Left : Direction.Right;
            for (int i = 0; i < Math.Abs(x); i++)
            {
                directions.Add(myDirection);
            }
            myDirection = y > 0 ? Direction.Up : Direction.Down;
            for (int i = 0; i < Math.Abs(y); i++)
            {
                directions.Add(myDirection);
            }
            timer.Start();
        }

        private void Tick(object sender, EventArgs e)
        {
            byte step = byte.Parse(SnakeHead.Size.Width.ToString());
            if (autoPilot)
            {
                direction = directions[0];
                directions.RemoveAt(0);
            }
            int x = 0;
            int y = 0;
            switch (direction)
            {
                case Direction.Up:
                    x = 0; y = -step;
                    break;
                case Direction.Down:
                    x = 0; y = step;
                    break;
                case Direction.Left:
                    x = -step; y = 0;
                    break;
                case Direction.Right:
                    x = step; y = 0;
                    break;
            }
            CheckPosition(new Point(SnakeHead.Location.X + x, SnakeHead.Location.Y + y));
            ChangePosition(x, y);
            if (lose)
            {
                timer.Stop();
                System.Threading.Thread.Sleep(1500);
                this.Close();
            }
        }

        private void ChangePosition(int x, int y)
        {

            if (!lose)
            {
                SnakeHead.Location = new Point(SnakeHead.Location.X + x, SnakeHead.Location.Y + y);
                AutoPilot();
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
            else if (point.X >= panel1.Width || point.X < 0 || point.Y < 0 || point.Y >= panel1.Height)
            {
                lose = true;
                return;
            }
            else if (PointEqually(point))
            {
                if (!autoPilot)
                {
                    lose = true;
                    return;
                }
                else
                {

                }
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
                if (!PointEqually(point) && point != Fruit.Location)
                {
                    break;
                }
            }
            Fruit.Location = point;
        }

    }
}
