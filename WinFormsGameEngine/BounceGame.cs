using Microsoft.VisualBasic.ApplicationServices;
using WinFormsGameEngineAPI;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WinFormsGameEngine
{
    public partial class BounceGame : Form
    {
        public BounceGame()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(shutdown);
        }
        //List<Button> Entities = new List<Button>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.Initialise();
            Renderer.Initialise(panel2);
            Renderer.NewEntity(EntityType.Default, "Alex", 2, [2, 2], [2, 2]);
            Renderer.NewEntity(EntityType.Default, "NPC", 2, [5, 5], [26, 26]);
            Renderer.NewEntity(EntityType.Immovable, "Wall1", 100, [31F, 1F], [0, 0]);
            Renderer.NewEntity(EntityType.Immovable, "Wall2", 100, [1F, 30F], [30, 1F]);
            Renderer.NewEntity(EntityType.Immovable, "Wall3", 100, [1F, 30F], [0, 1F]);
            Renderer.NewEntity(EntityType.Immovable, "Wall4", 100, [30F, 1], [0, 30]);
            Renderer.NewEntity(EntityType.Immovable, "Beano", 100, [30F, 30F], [0, 0], [0, 0], false);
            Renderer.Pan = [15.5F, 15.5F];
            Renderer.Zoom = 0.23F;
        }

        public void shutdown(object sender, FormClosingEventArgs e)
        {
            Engine.Enabled = false;
        }

        private void buttonGravOn_Click(object sender, EventArgs e)
        {

        }

        private void buttonGravOff_Click(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.W):
                    Engine.Entities[0].AForce[1] = -20;
                    break;
                case (Keys.S):
                    Engine.Entities[0].AForce[1] = 20;
                    break;
                case (Keys.A):
                    Engine.Entities[0].AForce[0] = -20;
                    break;
                case (Keys.D):
                    Engine.Entities[0].AForce[0] = 20;
                    break;
                case (Keys.NumPad8):
                    Engine.Entities[1].AForce[1] = -20;
                    break;
                case (Keys.NumPad5):
                    Engine.Entities[1].AForce[1] = 20;
                    break;
                case (Keys.NumPad4):
                    Engine.Entities[1].AForce[0] = -20;
                    break;
                case (Keys.NumPad6):
                    Engine.Entities[1].AForce[0] = 20;
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


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            float x = 10;
            float y = 3;
            Console.WriteLine(-10 % 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Renderer.Zoom = Convert.ToSingle(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Engine.GravField = 9.81F;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Engine.GravField = 0F;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Engine.Entities[0].Position = [2, 2];
            Engine.Entities[0].Velocity = [0, 0];
            Engine.Entities[1].Position = [26, 26];
            Engine.Entities[1].Velocity = [0, 0];
        }
    }
}
