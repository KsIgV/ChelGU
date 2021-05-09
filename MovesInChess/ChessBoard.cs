using System;

namespace MovesInChess
{
    class ChessBoard
    {
        public void CheckPositionInTable(ref int cursorPositionY, ref int cursorPositionX) //проверяет чтоб мы далеко не ушли с доски
        {
            if (cursorPositionX > 16)
                cursorPositionX = 15;
            if (cursorPositionX <= 0)
                cursorPositionX = 1;
            if (cursorPositionY <= 0)
                cursorPositionY = 1;
            if (cursorPositionY > 22)
                cursorPositionY = 22;
            Console.SetCursorPosition(cursorPositionY, cursorPositionX);
        }
        public void FillTableFigures(string[,] newTable) //заносим в таблицу координаты 
        {
            int cursorPositionY = 1;
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                int cursorPositionX = 1;
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);
                    Console.Write(newTable[i, j]);
                    cursorPositionX += 3;
                }
                cursorPositionY += 2;
            }
            //Console.WriteLine();
            //Console.WriteLine();
        }
        public void DrawTable(string[,] newTable) //рисуем таблицу
        {
            Console.Clear();
            Console.ResetColor();
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                string upLeftLine = "┌";
                string upRightLine = "┐";
                string downLeftLine = "└";
                string downRightLine = "┘";
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j * 3, i * 2);
                    if (i != 0)
                    {
                        upLeftLine = "├";
                        upRightLine = "┤";
                    }
                    if (j != 0)
                    {
                        upLeftLine = "┬";
                        downLeftLine = "┴";
                    }
                    if (i != 0 && j != 0)
                        upLeftLine = "┼";
                    Console.WriteLine(upLeftLine + "──" + upRightLine);
                    Console.SetCursorPosition(j * 3, Console.CursorTop);
                    Console.WriteLine("│" + "  " + "│");
                    Console.SetCursorPosition(j * 3, Console.CursorTop);
                    Console.Write(downLeftLine + "──" + downRightLine);
                }
            }
        }
    }
}