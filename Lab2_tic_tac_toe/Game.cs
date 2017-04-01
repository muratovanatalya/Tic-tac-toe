using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_tic_tac_toe
{
    class Game
    {
        public const int O = 1;
        public const int X = 2;
        public static int Step = 0;                                //количество ходов
        public static int GameStatus = 0;                          //0 - игра идет, 1 - игра завершилась
        public static int[,] GameField = new int[3, 3];

        public static bool CheckLine(int n, ref int i, ref int j)                  //проверка строки на 2 одинаковых символа                                                                    
        {                                                                          //и 1 пустую клетку
            for (i = 0; i < 3; i++)
            {
                int k = 0;
                j = -1;
                for (int l = 0; l < 3; l++)
                {
                    if (GameField[i, l] == n)
                        k++;
                    if (GameField[i, l] == 0)
                        j = l;  
                }
                if (k == 2 && j != -1)
                    return true;
            }
            return false;
        }

        public static bool CheckColumn(int n, ref int i, ref int j)                //проверка столбца на 2 одинаковых символа                                                                    
        {                                                                          //и 1 пустую клетку
            for (j = 0; j < 3; j++)
            {
                int k = 0;
                i = -1;
                for (int l = 0; l < 3; l++)
                {
                    if (GameField[l, j] == n)
                        k++;
                    if (GameField[l, j] == 0)
                        i = l;
                }
                if (k == 2 && i != -1)
                    return true;
            }
            return false;
        }

        public static bool CheckMainDiagonal(int n, ref int i, ref int j)         //проверка главной диагонали
        {
            int k = 0;
            j = -1;
            for (i = 0; i < 3; i++)
            {
                if (GameField[i, i] == n)
                    k++;
                if (GameField[i, i] == 0)
                    j=i;
            }
            i = j;
            if (k == 2 && j != -1)
                return true;

            return false;
        }

        public static bool CheckSecondaryDiagonal(int n, ref int i, ref int j)         //проверка побочной диагонали
        {
            int k = 0;
            j = -1;
            for (i = 0; i < 3; i++)
            {
                if (GameField[i, 2 - i] == n)
                    k++;
                if (GameField[i, 2 - i] == 0)
                    j = 2 - i;
            }
            i = 2 - j;
            if (k == 2 && j != -1)
                return true;

            return false;
        }


        public static bool Warning(int n, ref int i, ref int j)                         //проверка критической ситуации
        {
            if (CheckLine(n, ref i, ref j))
                return true;
            if (CheckColumn(n, ref i, ref j))
                return true;
            if (CheckMainDiagonal(n, ref i, ref j))
                return true;
            if (CheckSecondaryDiagonal(n, ref i, ref j))
                return true;
            return false;
        }

        public static void ComputerTurn()                                                //ход компьютера
        {
            int i = 0;
            int j = 0;
            if (Warning(O, ref i, ref j)) {               //есть ли 1 свободная клетка в линии из двух O
                GameField[i, j] = O;
                DrawingField.DrawO(i, j);
                return;
            }
            i = 0;
            j = 0;
            if (Warning(X, ref i, ref j))                 //есть ли 1 свободная клетка в линии из двух X
            {
                GameField[i, j] = O;
                DrawingField.DrawO(i, j);
                return;
            }
            if (GameField[1, 1] == 0)                    //занять центральную клетку
            {
                GameField[1, 1] = O;
                DrawingField.DrawO(1, 1);
                return;
            }
            for (i = 0; i < 3; i++)                      //занять оставшуюся клетку
                for (j = 0; j < 3; j++)
                    if (GameField[i, j] == 0)
                    {
                        GameField[i, j] = O;
                        DrawingField.DrawO(i, j);
                        return;
                    }
        }

        public static bool Checking(int n)                                             //проверка на победу
        {
            int i;
            for (i = 0; i < 3; i++) {
                int j = 0;
                while (j < 3 && GameField[i, j] == n)
                    j++;
                if (j == 3)
                    return true;
            }

            for (i = 0; i < 3; i++)
            {
                int j = 0;
                while (j < 3 && GameField[j, i] == n)
                    j++;
                if (j == 3)
                    return true;
            }

            i = 0;
            while (i < 3 && GameField[i, i] == n)
                i++;
            if (i == 3)
                return true;

            i = 0;
            while (i < 3 && GameField[i, 2 - i] == n)
                i++;
            if (i == 3)
                return true;

            return false;
        }

         public static bool Victory()
         {
            if (Checking(X))
            {
                MessageBox.Show("Вы выиграли!");
                return true;
            }
            if (Checking(O))
            {
                MessageBox.Show("Победа компьютера!", "Message");
                return true;
            }
            if (Step == 9)
            {
                MessageBox.Show("Ничья!", "Message");
                return true;
            }
            return false;
        }


        public static void MakeStep(int locX, int locY)
        {
            int i = locX / DrawingField.h;
            int j = locY / DrawingField.h;

            if (Step < 9 && Step % 2 == 0)
                if (GameField[j, i] != O && GameField[j, i] != X)
                {
                    GameField[j, i] = X;
                    DrawingField.DrawX(i, j);
                    Step++;
                }
            if (Victory())
            {
                GameStatus = 1;
                return;
            }

            if (Step < 9 && Step % 2 == 1)
            {
                ComputerTurn();
                Step++;
            }
            if (Victory())
            {
                GameStatus = 1;
                return;
            }

        }
    }
}
