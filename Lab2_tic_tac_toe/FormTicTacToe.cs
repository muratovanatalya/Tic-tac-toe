using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_tic_tac_toe
{
    public partial class FormTicTacToe : Form
    {

        public DrawingField paint;

        public FormTicTacToe()
        {
            InitializeComponent();
        }

        private void FormTicTacToe_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            paint = new DrawingField(g);
            DrawingField.DrawGrid();
        }
        
        private void FormTicTacToe_MouseClick(object sender, MouseEventArgs e)
        {
            if (Game.GameStatus == 0)
            {
                if (e.Button == MouseButtons.Left) //проверка нажатия левой кнопки
                {
                    int X = e.X;
                    int Y = e.Y;
                    Game.MakeStep(X, Y);
                }
            }
        }
    }
}
