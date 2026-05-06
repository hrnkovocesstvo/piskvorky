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


        private Button[,] buttonArray;

        public void Delej(int x_tar, int y_tar)
        {
            int aawidth = 50;
            int aaheight = aawidth;
            int aastartx = 50;
            int aastarty = 50;
            buttonArray = new Button[x_tar, y_tar];

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
            if (btn.Text == "") { btn.Text = player; Check(btn.Name); turn(); }
            if (popopo == (int)numericUpDownWin.Value) Console.WriteLine("winiwnwinwinwinwinwinwinwniwninwinwinwinwiniwnwiniwniwinwiiwniwninwinwinw");
            
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {

            Delej((int)numericUpDownRow.Value, (int)numericUpDownRow.Value);
            Console.WriteLine("done");
        }
        int[,] moves = {
                                { 1,  0 }, // 0 right
                                { -1,  0 }, // 1 left
                                {  0, 1 }, // 2 up
                                {  0, -1 }, // 3 down
                                { 1, 1 }, // 4 diagonal up-right
                                { -1, 1 }, // 5 diagonal up-left
                                { 1, -1 }, // 6 diagonal down-right
                                { -1, -1 }  // 7 diagonal down-left
                            };
        int popopo = 0;
        public void Check_Simple(int smer, int x, int y)
        {
            Console.WriteLine(popopo);
            int new_x = x + (int)moves[smer, 0];
            int new_y = y + (int)moves[smer, 1];
            if (new_x < 0 || new_y < 0 || new_x > buttonArray.GetLength(0)-1 || new_y > buttonArray.GetLength(1)-1) return;
            if (buttonArray[new_x, new_y].Text == player) popopo += 1; Check_Simple(smer, new_x, new_y);

        }
        private void Check(string name)
        {
            popopo = 0;
            string[] namee = name.Split('_');
            int X = Convert.ToInt32(namee[1]);
            int Y = Convert.ToInt32(namee[2]);

            
            Console.WriteLine($"pocatek {X} {Y}");
            
            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int x_x = X;
                int y_y = Y;
                x_x += (int)moves[i, 0];
                y_y += (int)moves[i, 1];
                if (x_x > buttonArray.GetLength(0)-1 || x_x < 0) continue;
                if (y_y > buttonArray.GetLength(1)-1 || y_y < 0) continue;
                Console.WriteLine($"{i}: {(int)moves[i, 0]} {(int)moves[i, 1]}; {x_x} {y_y}");

                if (buttonArray[x_x, y_y].Text == player) { popopo += 1; Check_Simple(i, x_x, y_y) ; Console.WriteLine($"nalezeno: {i}"); };
                                            //ijbsdcjkbsdklbjhsdajhbsdcjhsdcbjhsdabjh
                
                
            }
        

        }


        private void numericUpDownRow_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
