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

    
    public partial class MainMenu : UserControl
    {
           int counter = 0;

        public MainMenu()
        {
            InitializeComponent();

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {

            counter++;
            if(counter==1)
            {
               MainForm mainForm = this.FindForm() as MainForm;
               mainForm.mainMenu.Visible = false;
               mainForm.gameCanvas.Visible = true;
               mainForm.gameOverScreen.Visible = false;
               mainForm.highScore.Visible = false;
               mainForm.gameCanvas.Game();
            }
            else
            {
                MainForm mainForm = this.FindForm() as MainForm;
                mainForm.mainMenu.Visible = false;
                mainForm.gameCanvas.Visible = true;
                mainForm.gameOverScreen.Visible = false;
                mainForm.highScore.Visible = false;
                mainForm.gameCanvas.ResetGame();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.FindForm() as MainForm;
            mainForm.Close();
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.FindForm() as MainForm;
            mainForm.mainMenu.Visible = false;
            mainForm.gameCanvas.Visible = false;
            mainForm.gameOverScreen.Visible = false;
            mainForm.highScore.Visible = true;

            int max = 0;
            for(int i = 0;i<mainForm.highScore.ScoresList.Items.Count;i++)
            {
                string[] array = mainForm.highScore.ScoresList.Items[i].ToString().Split(new string[] { "                          " }, StringSplitOptions.None);


                if (int.Parse(array[1]) > max)
                {
                    max = int.Parse(array[1]);
                }
            }
            mainForm.highScore.labelHighScore.Text = "HighScore: " + max;
           

        }
    }
}
