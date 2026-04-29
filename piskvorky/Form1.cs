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
            int width = 20;
            int height = 20;
            int left = 30;
            Button[,] buttonArray = new Button[x_tar,y_tar];
            for (int x = 0; x < x_tar-1; x++)
            {
                for (int y = 0; y < y_tar-1; y++)
                {
                    buttonArray[x,y] = new Button();
                    buttonArray[x, y].Name = $"btn_{x}_{y}";
                    buttonArray[x,y].Size = new Size(width, height); 
                    buttonArray[x,y].Location = new Point(20, 20);
                    buttonArray[x,y].Click += new System.EventHandler(button_Click); this.Controls.Add(buttonArray[x,y]);
                    left += 56;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {

        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Delej((int)numericUpDownRow.Value, (int)numericUpDownRow.Value);
            Console.WriteLine("done");
        }


    }
}
