﻿using System;

namespace MovesInChess
{
    class ChessFigure
    {
        private bool count = false; //определяет какой раз пользователь нажал ентер
        private int secondEnterY;
        private int secondEnterX;
        private int firstEnterX;
        private int firstEnterY;
        private int cursorPositionY = 1;
        private int cursorPositionX = 1;
        WorkWithFIles workWithFIles = new WorkWithFIles();
        public void CycleForArray() //делает ходы бесконечностью
        {
            ChessBoard chessBoard = new ChessBoard();
            string[,] newTable = workWithFIles.OpenForTXT();
            chessBoard.DrawTable(newTable);
            FillTableFigures(newTable);
            Console.SetCursorPosition(cursorPositionY, cursorPositionX);
            WASDandEnter(newTable, cursorPositionY, cursorPositionX, count);
        }
        private void FillTableFigures(string[,] newTable) //заносим в таблицу координаты 
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
            Console.WriteLine();
            Console.WriteLine();
        }
        private bool CheckEnterCoordinate(ref int firstEnterY, ref int firstEnterX, ref int secondEnterY, ref int secondEnterX, ref int cursorPositionY, ref int cursorPositionX, ref bool count) //проверяет какой раз мы нажимаем enter, то есть хотим мы с этого места ПЕРЕДВИНУТЬ фигуру, или наоборот ПОСТАВИТЬ фигуру
        {
            if (!count)
            {
                firstEnterY = cursorPositionY / 3;
                firstEnterX = cursorPositionX / 2;
                count = true;
            }
            else
            {
                secondEnterY = cursorPositionY / 3;
                secondEnterX = cursorPositionX / 2;
                count = false;
            }
            return count;
        }
        private void CheckPositionInTable(ref int cursorPositionY, ref int cursorPositionX) //проверяет чтоб мы далеко не ушли с доски
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
        private bool HorseMove(int move1, int move2) //конь
        {
            return ((move1 == 2) && (move2 == 1))
            || ((move1 == 1) && (move2 == 2));
        }
        private bool ElephantMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) // слон
        {
            return move1 == move2 && firstEnterX != secondEnterX && firstEnterY != secondEnterY;
        }
        private bool RookMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX) // ладья
        {
            return firstEnterX == secondEnterX || firstEnterY == secondEnterY;
        }
        private bool QueenMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) // ферзь
        {
            return move1 == move2 || firstEnterX == secondEnterX || firstEnterY == secondEnterY;
        }
        private bool KingMove(int move1, int move2) // король
        {
            return move1 + move2 == 1 || move1 == 1 && move2 == 1;
        }
        private bool PawnMove(int firstEnterX, int move1, int move2, string figure) // пешка
        {
            if (((firstEnterX == 1 && figure[1] == '1') || (firstEnterX == 6 && figure[1] == '2')) 
                && move1 == 0 && move2 == 2)
                return true;
            else
                return (figure[1] == '1' || figure[1] == '2') && move2 == 1;
        }
        private void MoveOfAPiece(string[,] newTable, int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) //ходы и рубка фигур
        {
            string firstFigure = newTable[firstEnterX, firstEnterY];
            string secondFigure = newTable[secondEnterX, secondEnterY];
            if ((firstFigure[0] == 'P' && secondFigure[0] != 'K' && move1 == move2) || (secondFigure == "  ")
                || (secondFigure[1] != firstFigure[1] && firstFigure[0] != 'P'))
            {
                newTable[secondEnterX, secondEnterY] = newTable[firstEnterX, firstEnterY];
                newTable[firstEnterX, firstEnterY] = "  ";
            }
        }
        private void NameAndCheckFigure(string[,] newTable, int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX)
        {
            string figure = newTable[firstEnterX, firstEnterY]; // берем значение фигуры
            int move1 = Math.Abs(firstEnterY - secondEnterY); // С B
            int move2 = Math.Abs(firstEnterX - secondEnterX); // 1 5
            switch (figure[0])
            {
                case 'K':
                    if (KingMove(move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, move1, move2);
                    break;
                case 'Q':
                    if (QueenMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY, move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, move1, move2);
                    break;
                case 'H':
                    if (HorseMove(move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, move1, move2);
                    break;
                case 'P':
                    if (PawnMove(firstEnterX, move1, move2, figure))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, move1, move2);
                    break;
                case 'R':
                    if (RookMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, move1, move2);
                    break;
                case 'E':
                    if (ElephantMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY, move1, move2))
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX, move1, move2);
                    break;
            }
        }
        private void WASDandEnter(string[,] newTable, int cursorPositionY, int cursorPositionX, bool count)
        {
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
                        CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.A:
                        cursorPositionY -= 3;
                        CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.S:
                        cursorPositionX += 2;
                        CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.D:
                        cursorPositionY += 3;
                        CheckPositionInTable(ref cursorPositionY, ref cursorPositionX);
                        break;
                    case ConsoleKey.Enter:
                        CheckEnterCoordinate(ref firstEnterY, ref firstEnterX, ref secondEnterY, ref secondEnterX, ref cursorPositionY, ref cursorPositionX, ref count);
                        if (!count)
                        {
                            NameAndCheckFigure(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                            FillTableFigures(newTable);
                            Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                        }
                        break;
                }
            }
        }
    }
}