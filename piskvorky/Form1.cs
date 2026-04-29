using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace piskvorky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    
    

        private void Delej(int x_tar, int y_tar)
        {
            int width = 50;
            int height = width;
            int startx = 50;
            int starty = 50;
            Button[,] buttonArray = new Button[x_tar,y_tar];
            for (int x = 0; x < x_tar; x++)
            {
                for (int y = 0; y < y_tar; y++)
                {
                    buttonArray[x,y] = new Button();
                    buttonArray[x,y].Name = $"btn_{x}_{y}";
                    buttonArray[x,y].Size = new Size(width, height); 
                    buttonArray[x,y].Location = new Point(startx+(width*x), starty +(height* y));
                    buttonArray[x,y].Click += new System.EventHandler(button_Click); this.Controls.Add(buttonArray[x,y]);
                }
            }
        }

        public string player = "X";
        public void turn() { if (player == "X") player = "O";else if (player == "O") player = "X"; }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Text = player;
            turn();
            
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {

            Delej((int)numericUpDownRow.Value, (int)numericUpDownRow.Value);
            Console.WriteLine("done");
        }

        private void numericUpDownRow_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}