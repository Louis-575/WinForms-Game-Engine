using WinFormsGameEngineAPI;
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
    public partial class FootballGame : Form
    {
        public FootballGame()
        {
            InitializeComponent();
        }
        private void Football_Load(object sender, EventArgs e)
        {
            Renderer.Initialise(render);

            Renderer.NewEntity(EntityType.Default, "Player 1", 6, [3, 3], [-31, 0]);
            Renderer.NewEntity(EntityType.Default, "Player 2", 6, [3, 3], [30, 0]);

            Renderer.NewEntity(EntityType.Default, "Ball", 2, [2, 2], [0.05F, 0.05F]);

            Renderer.NewEntity(EntityType.Immovable, "Centre", 1, [0.1F, 0.1F], [0.05F, 0.05F], [0, 0], false);

            Renderer.NewEntity(EntityType.Immovable, "Top Wall", 1, [104F, 1F], [-52F, -33F]);
            Renderer.NewEntity(EntityType.Immovable, "Bottom Wall", 1, [104F, 1F], [-52F, 32F]);

            Renderer.NewEntity(EntityType.Immovable, "Left Top Wall", 1, [1F, 29F], [-53F, -33F]);
            Renderer.NewEntity(EntityType.Immovable, "Right Top Wall", 1, [1F, 29F], [52F, -33F]);

            Renderer.NewEntity(EntityType.Immovable, "Left Bottom Wall", 1, [1F, 29F], [-53F, 4F]);
            Renderer.NewEntity(EntityType.Immovable, "Right Bottom Wall", 1, [1F, 29F], [52F, 4F]);

            Renderer.NewEntity(EntityType.Immovable, "Goal Left", 1, [1F, 10F], [-54F, -5F]);
            Renderer.NewEntity(EntityType.Immovable, "Goal Right", 1, [1F, 10F], [53F, -5F]);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.W):
                    Engine.Entities[0].AForce[1] = -100;
                    break;
                case (Keys.S):
                    Engine.Entities[0].AForce[1] = 100;
                    break;
                case (Keys.A):
                    Engine.Entities[0].AForce[0] = -100;
                    break;
                case (Keys.D):
                    Engine.Entities[0].AForce[0] = 100;
                    break;
                case (Keys.NumPad8):
                    Engine.Entities[1].AForce[1] = -100;
                    break;
                case (Keys.NumPad5):
                    Engine.Entities[1].AForce[1] = 100;
                    break;
                case (Keys.NumPad4):
                    Engine.Entities[1].AForce[0] = -100;
                    break;
                case (Keys.NumPad6):
                    Engine.Entities[1].AForce[0] = 100;
                    break;
                case (Keys.OemPeriod):
                    Renderer.Zoom /= 1.1F;
                    break;
                case (Keys.Oemcomma):
                    Renderer.Zoom *= 1.1F;
                    break;
                case (Keys.I):
                    Renderer.Pan[1] -= 0.2F / Renderer.Zoom;
                    break;
                case (Keys.K):
                    Renderer.Pan[1] += 0.2F / Renderer.Zoom;
                    break;
                case (Keys.J):
                    Renderer.Pan[0] -= 0.2F / Renderer.Zoom;
                    break;
                case (Keys.L):
                    Renderer.Pan[0] += 0.2F / Renderer.Zoom;
                    break;
            }
        }

        private void test(object sender, KeyPressEventArgs e)
        {

        }

        private void Football_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.W):
                    Engine.Entities[0].AForce[1] = 0;
                    break;
                case (Keys.S):
                    Engine.Entities[0].AForce[1] = 0;
                    break;
                case (Keys.A):
                    Engine.Entities[0].AForce[0] = 0;
                    break;
                case (Keys.D):
                    Engine.Entities[0].AForce[0] = 0;
                    break;
                case (Keys.NumPad8):
                    Engine.Entities[1].AForce[1] = 0;
                    break;
                case (Keys.NumPad5):
                    Engine.Entities[1].AForce[1] = 0;
                    break;
                case (Keys.NumPad4):
                    Engine.Entities[1].AForce[0] = 0;
                    break;
                case (Keys.NumPad6):
                    Engine.Entities[1].AForce[0] = 0;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Engine.Entities[0].Position = [-31, 0];
            Engine.Entities[0].Velocity = [0, 0];
            Engine.Entities[1].Position = [30, 0];
            Engine.Entities[1].Velocity = [0, 0];
            Engine.Entities[2].Position = [0, 0];
            Engine.Entities[2].Velocity = [0, 0];
        }
    }
}
