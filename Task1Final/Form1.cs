using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            GameEngine gameEngine = new GameEngine();
            gameEngine.Round();
        }

        private void StatsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Timer.Enabled = true;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            Timer.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(MapBox);

            Map map = new Map(20);
            map.MakeMap();
            map.UpdateMap();
        }
    }
}
