using Snake.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Snake
{


    public partial class GameCanvas : UserControl
    {
        

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        public int FinalScore;
        Random rand = new Random();

        public string date;
        

        public GameCanvas()
        {
            InitializeComponent();
            new Movement();
            
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {

            
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Movement.direction)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            picGame.Invalidate();


        }

        private void EatFood()
        {
            score += 1;
            ScoreLabel.Text = "Score: " + score;
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameCanvas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a' && Movement.direction != "right")
            {
                Movement.direction = "left";
            }
            else if (e.KeyChar == 'd' && Movement.direction != "left")
            {
                Movement.direction = "right";
            }
            else if (e.KeyChar == 'w' && Movement.direction != "down")
            {
                Movement.direction = "up";
            }
            else if (e.KeyChar == 's' && Movement.direction != "up")
            {
                Movement.direction = "down";
            }
            else if (e.KeyChar == 'k')
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            GameTimer.Stop();

            FinalScore = score;

            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");
            date = formattedTime;

            MainForm mainForm = this.FindForm() as MainForm;
            mainForm.mainMenu.Visible = false;
            mainForm.gameCanvas.Visible = false;
            mainForm.highScore.Visible = false;
            mainForm.gameOverScreen.Visible = true;
            mainForm.highScore.ScoresList.Items.Add("    "+ date +"                          " + FinalScore);
        }

        private void picGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush b;
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    b = Brushes.Black;
                }
                else
                {
                    b = Brushes.DarkGreen;
                }
                canvas.FillEllipse(b, new Rectangle
                    (
                    Snake[i].X * Movement.Width,
                    Snake[i].Y * Movement.Height,
                    Movement.Width, Movement.Height
                    ));
            }
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Movement.Width,
            food.Y * Movement.Height,
            Movement.Width, Movement.Height
            ));
        }


        public void Game()
        {
            maxWidth = picGame.Width / Movement.Width - 1;
            maxHeight = picGame.Height / Movement.Height - 1;
            Snake.Clear();
            score = 0;
            ScoreLabel.Text = "Score: " + score;
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); 
            for (int i = 0; i < 3; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            GameTimer.Start();
        }

        public void ResetGame()
        {
            
            maxWidth = picGame.Width / Movement.Width - 1;
            maxHeight = picGame.Height / Movement.Height - 1;
            Snake.Clear();
            score = 0;
            ScoreLabel.Text = "Score: " + score;
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);
            for (int i = 0; i < 3; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            
            GameTimer.Start();

            
            this.Focus();
        }

    }
}