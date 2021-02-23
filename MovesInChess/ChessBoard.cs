using System;

namespace MovesInChess
{
    class ChessBoard
    {
        WorkWithFIles workWithFIles = new WorkWithFIles();
        public void DrawTable() //рисуем таблицу
        {
            string[,] newTable = workWithFIles.OpenForTXT();
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                string UpLeftLine = "┌";
                string UpRightLine = "┐";
                string DownLeftLine = "└";
                string DownRightLine = "┘";
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j * 2, i * 2);
                    if (i != 0)
                    {
                        UpLeftLine = "├";
                        UpRightLine = "┤";
                    }
                    if (j != 0)
                    {
                        UpLeftLine = "┬";
                        DownLeftLine = "┴";
                    }
                    if (i != 0 && j != 0)
                        UpLeftLine = "┼";
                    Console.WriteLine(UpLeftLine + "─" + UpRightLine);
                    Console.SetCursorPosition(j * 2, Console.CursorTop);
                    Console.WriteLine("│" + " " + "│");
                    Console.SetCursorPosition(j * 2, Console.CursorTop);
                    Console.Write(DownLeftLine + "─" + DownRightLine);
                }
            }
        }
    }
}