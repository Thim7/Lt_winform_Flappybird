using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuGame : Form
    {
        public MenuGame()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();
            gameWindow.Show();
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {
            HelpScreen helpScreen = new HelpScreen();
            helpScreen.Show();
        }

        private void MenuGame_Load(object sender, EventArgs e)
        {
            
        }
    }
}
