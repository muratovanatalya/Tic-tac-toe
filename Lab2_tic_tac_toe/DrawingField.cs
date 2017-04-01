using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2_tic_tac_toe
{
    public class DrawingField
    {
        private static Graphics Gr;
        public static int N = 360;                          //длина игрового поля
        public static int h = N / 3;                        //длина каждой клетки

        public DrawingField(Graphics gr)
        {
            Gr = gr;
        }

        public static void DrawGrid()
        {
            Pen myPen = new Pen(Color.Black, 3);

            for (int i = 0; i < 4; i++)
            {
                Gr.DrawLine(myPen, i * h, 0, i * h, N);            //вертикальная линия
                Gr.DrawLine(myPen, 0, i * h, N, i * h);            //горизонтальная линия
            }
        }

        public static void DrawX(int i, int j)
        {
            Pen myPen = new Pen(Color.Black, 3);
            
            Gr.DrawLine(myPen, i * h + 10, j * h + 10, i * h + 110, j * h + 110);
            Gr.DrawLine(myPen, i * h + 10, j * h + 110, i * h + 110, j * h + 10);
        }

        public static void DrawO(int i, int j)
        {
            Pen myPen = new Pen(Color.Blue, 3);
            Gr.DrawEllipse(myPen, j * h + 10, i * h + 10, 100, 100);
        }
    }
}
