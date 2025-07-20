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
    public partial class MainForm : Form
    {


        public MainMenu mainMenu;
        public GameCanvas gameCanvas;
        public HighScore highScore;
        public GameOverScreen gameOverScreen;


        public MainForm()
        {
            InitializeComponent();



            mainMenu = new MainMenu();
            gameCanvas = new GameCanvas();
            highScore = new HighScore();
            gameOverScreen = new GameOverScreen();

            mainPanel.Controls.Add(mainMenu);
            mainPanel.Controls.Add(gameCanvas);
            mainPanel.Controls.Add(highScore);
            mainPanel.Controls.Add(gameOverScreen);

           


        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            mainMenu.Visible = true;
            gameCanvas.Visible = false;
            gameOverScreen.Visible = false;
            highScore.Visible = false;
        }

        
    }
}
