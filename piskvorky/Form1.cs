using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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

    
    

        public void Delej(int x_tar, int y_tar)
        {
            int aawidth = 50;
            int aaheight = aawidth;
            int aastartx = 50;
            int aastarty = 50;
            Button[,] buttonArray = new Button[x_tar,y_tar];
            
            for (int x = 0; x < x_tar; x++)
            {
                for (int y = 0; y < y_tar; y++)
                {
                    buttonArray[x,y] = new Button();
                    buttonArray[x,y].Name = $"btn_{x}_{y}";
                    buttonArray[x,y].Size = new Size(aawidth, aaheight); 
                    buttonArray[x,y].Location = new Point(aastartx+(aawidth*x), aastarty + (aaheight * y));
                    buttonArray[x,y].Click += new System.EventHandler(button_Click); this.Controls.Add(buttonArray[x,y]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Delej((int)numericUpDownRow.Value, (int)numericUpDownRow.Value);
        }
        public string player = "X";
        public void turn() { if (player == "X") player = "O";else if (player == "O") player = "X"; }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "") { btn.Text = player; turn(); }
            Check(btn.Name);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {

            Delej((int)numericUpDownRow.Value, (int)numericUpDownRow.Value);
            Console.WriteLine("done");
        }

        private void Check(string name)
        {
            string[] namee = name.Split('_');
            int X = Convert.ToInt32(namee[1]);
            int Y = Convert.ToInt32(namee[2]);
            int[,] moves = {
                                { +1,  0 }, // right
                                { -1,  0 }, // left
                                {  0, +1 }, // up
                                {  0, -1 }, // down
                                { +1, +1 }, // diagonal up-right
                                { -1, +1 }, // diagonal up-left
                                { +1, -1 }, // diagonal down-right
                                { -1, -1 }  // diagonal down-left
                            };
            for (int i = 0; i < moves.Length; i++)
            {

            }
        }

        private void numericUpDownRow_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
