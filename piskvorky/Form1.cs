using System;
using System.Drawing;
using System.Windows.Forms;

namespace piskvorky
{
    public partial class Form1 : Form
    {
        private Button[,] buttonArray;
        private string player = "X";
        private bool Konec = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartZnova();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartZnova();
        }

        private void StartZnova()
        {
            if (buttonArray != null)
            {
                foreach (Button btn in buttonArray)
                    this.Controls.Remove(btn);
            }

            player = "X";
            Konec = false;
            textBoxWin.Text = "";

            int size = (int)numericUpDownRow.Value;
            DelejTlacitka(size, size);
        }

        private void DelejTlacitka(int cols, int rows)
        {
            const int btnSize = 50;
            const int startX = 50;
            const int startY = 50;

            buttonArray = new Button[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Button btn = new Button();
                    btn.Name = $"btn_{x}_{y}";
                    btn.Size = new Size(btnSize, btnSize);
                    btn.Location = new Point(startX + btnSize * x, startY + btnSize * y);
                    btn.Click += button_Click;

                    this.Controls.Add(btn);
                    buttonArray[x, y] = btn;
                }
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (Konec) return;

            Button btn = (Button)sender;
            if (btn.Text != "") return;          

            btn.Text = player;

            string[] parts = btn.Name.Split('_');
            int x = int.Parse(parts[1]);
            int y = int.Parse(parts[2]);

            if (WinKontrola(x, y))
            {
                Win(player);
                Konec = true;
                return;
            }

            bool draw = true;
            foreach (Button b in buttonArray)
            {
                if (b.Text == "") { draw = false; break; }
            }
            if (draw)
            {
                Win("JSTE RETARDI HOLT");
                Konec = true;
                return;
            }

            HracZmena();
        }

        private void HracZmena()
        {
            player = (player == "X") ? "O" : "X";
        }


        private int[,] Smery =
        {
            {  1,  0 },   // horizontal
            {  0,  1 },   // vertical
            {  1,  1 },   // diagonal  ↘
            {  1, -1 },   // diagonal  ↗
        };

        private int PociPoci(int x, int y, int dx, int dy)
        {
            int count = 0;
            int nx = x + dx;
            int ny = y + dy;

            while (nx >= 0 && ny >= 0 &&
                   nx < buttonArray.GetLength(0) &&
                   ny < buttonArray.GetLength(1))
            {
                if (buttonArray[nx, ny].Text == player)
                {
                    count++;
                    nx += dx;
                    ny += dy;
                }
                else break;
            }

            return count;
        }

        private bool WinKontrola(int x, int y)
        {
            int winLength = (int)numericUpDownWin.Value;

            for (int i = 0; i < Smery.GetLength(0); i++)
            {
                int dx = Smery[i, 0];
                int dy = Smery[i, 1];

                int lineLength = 1
                    + PociPoci(x, y, dx, dy)
                    + PociPoci(x, y, -dx, -dy);

                if (lineLength >= winLength)
                    return true;
            }

            return false;
        }

        private void Win(string vitez)
        {
            if (vitez == "JSTE RETARDI HOLT") textBoxWin.Text = "remiza :(";
            else textBoxWin.Text = $"Vyhrál: { vitez}";
        }

        private void numericUpDownRow_ValueChanged(object sender, EventArgs e) { }
    }
}