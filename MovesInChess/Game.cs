using System;

namespace MovesInChess
{
    class Game
    {
        public readonly bool count = false; //определяет какой раз пользователь нажал ентер
        readonly WorkWithFIles workWithFIles = new WorkWithFIles();
        readonly ChessBoard chessBoard = new ChessBoard();
        public void CycleForArray() //делает ходы бесконечностью
        {
            string[,] newTable = workWithFIles.OpenForTXT();
            chessBoard.DrawTable(newTable);
            chessBoard.FillTableFigures(newTable);
            int cursorPositionX = 1;
            int cursorPositionY = 1;
            Console.SetCursorPosition(cursorPositionY, cursorPositionX);
            MoveFigureInBoard(newTable, cursorPositionY, cursorPositionX, count);
        }
        public void WinOrNo(string firstFigure, string[,] newTable, int volueFigureP1, int volueFigureP2)
        {
            for (int i = 0; i < newTable.GetLength(0); i++) //считаем сколько фигур на поле у 1 и 2 игрока
            {
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    string figure = newTable[i, j];
                    if (figure[1] == '1')
                        volueFigureP1++;
                    if (figure[1] == '2')
                        volueFigureP2++;
                }
            }
            if (volueFigureP1 == 0 || volueFigureP2 == 0)
            {
                Console.Clear();
                Console.WriteLine("Игрок номер " + firstFigure[1] + " выиграл! Поздравляем!");
                Environment.Exit(0);
            }
        }
        public void MoveFigureInBoard(string[,] newTable, int cursorPositionY, int cursorPositionX, bool count)
        {
            int volueFigureP1 = 0;
            int volueFigureP2 = 0;
            int secondEnterY = 0;
            int secondEnterX = 0;
            int firstEnterX = 0;
            int firstEnterY = 0;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        workWithFIles.SaveForTXT(newTable);
                        Menu menu = new Menu();
                        menu.Screen();
                        break;
                    case ConsoleKey.W:
                        cursorPositionX -= 2;
                        chessBoard.CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.A:
                        cursorPositionY -= 3;
                        chessBoard.CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.S:
                        cursorPositionX += 2;
                        chessBoard.CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.D:
                        cursorPositionY += 3;
                        chessBoard.CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.Enter:
                        ChessFigure chessFigure = new ChessFigure();
                        chessFigure.CheckEnterCoordinate(ref firstEnterY, ref firstEnterX, ref secondEnterY, ref secondEnterX, ref cursorPositionY, ref cursorPositionX, ref count);
                        if (!count)
                        {
                            chessFigure.NameAndCheckFigure(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, volueFigureP1, volueFigureP2);
                            chessBoard.FillTableFigures(newTable);
                            Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                        }
                        break;
                }
            }
        }
    }
}
