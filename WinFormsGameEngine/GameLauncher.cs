using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGameEngine
{
    public partial class GameLauncher : Form
    {
        public GameLauncher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BounceGame bounce = new BounceGame();
            bounce.ShowDialog();
            bounce = null;
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FootballGame football = new FootballGame();
            football.ShowDialog();
            football = null;
            this.Show();
        }
    }
}
