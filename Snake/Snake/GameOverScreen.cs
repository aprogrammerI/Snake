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
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.FindForm() as MainForm;
            mainForm.gameOverScreen.Visible = false;
            mainForm.gameCanvas.Visible = true;


            mainForm.gameCanvas.ResetGame();



        }

        private void btnBackToMainMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.FindForm() as MainForm;
            mainForm.gameOverScreen.Visible = false;
            mainForm.mainMenu.Visible = true;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MainForm mainForm = this.FindForm() as MainForm;
            mainForm.Close();

        }
    }
}
