using System;

namespace MovesInChess
{
    class ChessFigure
    {
        public bool count = false;
        public int secondEnterY;
        public int secondEnterX;
        public int firstEnterX;
        public int firstEnterY;
        public int cursorPositionY = 1;
        public int cursorPositionX = 1;
        WorkWithFIles workWithFIles = new WorkWithFIles();
        public void CycleForArray() //делает ходы бесконечностью
        {
            char[,] newTable = workWithFIles.OpenForTXT();
            ChessBoard chessBoard = new ChessBoard();
            chessBoard.DrawTable();
            FillTableFigures(newTable);
            Console.SetCursorPosition(1, 1);
            WASDandEnter(newTable, cursorPositionY, cursorPositionX, count);
        }
        private void FillTableFigures(char[,] newTable) //заносим в таблицу координаты 
        {
            int cursorPositionY = 1;
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                int cursorPositionX = 1;
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);
                    Console.Write(newTable[i, j]);
                    cursorPositionX += 2;
                }
                cursorPositionY += 2;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        private bool CheckEnterCoordinate(ref int firstEnterY, ref int firstEnterX, ref int secondEnterY, ref int secondEnterX, ref int cursorPositionY, ref int cursorPositionX, ref bool count) //проверяет какой раз мы нажимаем enter, то есть хотим мы с этого места ПЕРЕДВИНУТЬ фигуру, или наоборот ПОСТАВИТЬ фигуру
        {
            if (!count)
            {
                firstEnterY = cursorPositionY / 2;
                firstEnterX = cursorPositionX / 2;
                count = true;
            }
            else
            {
                secondEnterY = cursorPositionY / 2;
                secondEnterX = cursorPositionX / 2;
                count = false;
            }
            return count;
        }
        private int CheckPosition(char[,] newTable, int cursorPositionY, int cursorPositionX, bool count) //проверяет чтоб мы далеко не ушли с доски
        {
            if (cursorPositionX > 16 || cursorPositionY > 16 || cursorPositionY <= 0 || cursorPositionX <= 0)
            {
                cursorPositionY = 1;
                cursorPositionX = 1;
                Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                WASDandEnter(newTable, cursorPositionY, cursorPositionX, count);
            }
            else
                Console.SetCursorPosition(cursorPositionY, cursorPositionX);
            return cursorPositionX;
        }
        public bool HorseMove(int move1, int move2) //конь
        {
            return ((move1 == 2) && (move2 == 1))
            || ((move1 == 1) && (move2 == 2));
        }
        public bool ElephantMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) // слон
        {
            return move1 == move2 && firstEnterX != secondEnterX && firstEnterY != secondEnterY;
        }
        public bool RookMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX) // ладья
        {
            return firstEnterX == secondEnterX || firstEnterY == secondEnterY;
        }
        public bool QueenMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) // ферзь
        {
            return move1 == move2 || firstEnterX == secondEnterX || firstEnterY == secondEnterY;
        }
        public bool KingMove(int move1, int move2) // король
        {
            return move1 + move2 == 1 || move1 == 1 && move2 == 1;
        }
        public bool PawnMove(int firstEnterY, int move1, int move2) // пешка
        {
            return ((firstEnterY == '2' || firstEnterY == '7') && (move2 == 1 || move2 == 2) && move1 == 0) || (move1 == 0 && move2 == 1);
        }
        private void MoveOfAPiece(char[,] newTable, int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX) //меняет элементы массива
        {
            if (newTable[secondEnterX, secondEnterY] == ' ')
            {
                newTable[secondEnterX, secondEnterY] = newTable[firstEnterX, firstEnterY];
                newTable[firstEnterX, firstEnterY] = ' ';
            }
        }
        private void NameAndCheckFigure(char[,] newTable, int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX)
        {
            char figure = newTable[firstEnterX, firstEnterY]; // берем значение фигуры
            int move1 = Math.Abs(firstEnterY - secondEnterY); // С B
            int move2 = Math.Abs(firstEnterX - secondEnterX); // 1 5
            switch (figure)
            {
                case 'K':
                    if (KingMove(move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'Q':
                    if (QueenMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY, move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'L':
                    if (HorseMove(move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'P':
                    if (PawnMove(firstEnterY, move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'R':
                    if (RookMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'E':
                    if (ElephantMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY, move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
            }
        }
        private void WASDandEnter(char[,] newTable, int cursorPositionY, int cursorPositionX, bool count)
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        workWithFIles.SaveForTXT(newTable);
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.W:
                        cursorPositionX -= 2;
                        CheckPosition(newTable, cursorPositionY, cursorPositionX, count);
                        break;
                    case ConsoleKey.A:
                        cursorPositionY -= 2;
                        CheckPosition(newTable, cursorPositionY, cursorPositionX, count);
                        break;
                    case ConsoleKey.S:
                        cursorPositionX += 2;
                        CheckPosition(newTable, cursorPositionY, cursorPositionX, count);
                        break;
                    case ConsoleKey.D:
                        cursorPositionY += 2;
                        CheckPosition(newTable, cursorPositionY, cursorPositionX, count);
                        break;
                    case ConsoleKey.Enter:
                        CheckEnterCoordinate(ref firstEnterY, ref firstEnterX, ref secondEnterY, ref secondEnterX, ref cursorPositionY, ref cursorPositionX, ref count);
                        NameAndCheckFigure(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                        FillTableFigures(newTable);
                        Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                        break;
                }
            }
        }
    }
}