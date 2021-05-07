using System;

namespace MovesInChess
{
    class ChessBoard
    {
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