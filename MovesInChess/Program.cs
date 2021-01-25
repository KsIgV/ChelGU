using System;
using System.IO;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Перемещайтесь по полю с помощью клавиш WASD.\nЕсли хотите выйти нажмите Esc.");
            char figure = ' ';
            char[,] newTable = OpenForTXT();
            CycleForArray(newTable, figure);
        }
        //static string ReadCoordinate() //считываем координаты
        //{
        //    string coordinate;
        //    do
        //    {
        //        coordinate = Console.ReadLine().ToUpper();
        //    } while (!CheckCoordinate(coordinate));
        //    return coordinate;
        //}
        //static bool CheckCoordinate(string coordinate)//проверка координат введеных
        //{
        //    if (coordinate.Length == 2 && coordinate[0] >= 'A' && coordinate[0] <= 'H' && coordinate[1] >= '1' && coordinate[1] <= '8')
        //        return true;
        //    else
        //        return false;
        //}
        static bool HorseMove(int move1, int move2) //конь
        {
            if (((move1 == 2) && (move2 == 1))
                || ((move1 == 1) && (move2 == 2)))
                return true;
            else
                return false;
        }
        static bool ElephantMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) // слон
        {
            if ((move1 == move2) && firstEnterX != secondEnterX && firstEnterY != secondEnterY)
                return true;
            else
                return false;
        }
        static bool RookMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX) // ладья
        {
            if (firstEnterX == secondEnterX || firstEnterY == secondEnterY)
                return true;
            else
                return false;
        }
        static bool QueenMove(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, int move1, int move2) // ферзь
        {
            if (((move1 == move2) || (firstEnterX == secondEnterX || firstEnterY == secondEnterY)))
                return true;
            else
                return false;
        }
        static bool KingMove(int move1, int move2) // король
        {
            if (move1 + move2 == 1 || move1 == 1 && move2 == 1)
                return true;
            else
                return false;
        }
        static bool PawnMove(int firstEnterY, int move1, int move2) // пешка
        {
            if (((firstEnterY == '2' || firstEnterY == '7') && (move2 == 1 || move2 == 2) && move1 == 0) || (move1 == 0 && move2 == 1))
                return true;
            else
                return false;
        }
        static void DrawTable(char[,] newTable) //рисуем таблицу
        {
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
        static void MotionFigure(int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX, char[,] newTable) //проверка
        {
            char figure = newTable[firstEnterX, firstEnterY]; // берем значение фигуры
            int move1 = Math.Abs(firstEnterY - secondEnterY); // С B
            int move2 = Math.Abs(firstEnterX - secondEnterX); // 1 5
            switch (figure)
            {
                case 'K':
                    if (KingMove(move1, move2) == true)
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'Q':
                    if (QueenMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY, move1, move2) == true)
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'L':
                    if (HorseMove(move1, move2) == true)
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'P':
                    if (PawnMove(firstEnterY, move1, move2) == true)
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'R':
                    if (RookMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY) == true)
                        MoveOfAPiece(newTable,  firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
                case 'E':
                    if (ElephantMove(firstEnterX, firstEnterY, secondEnterX, secondEnterY, move1, move2) == true)
                        MoveOfAPiece(newTable, firstEnterY, firstEnterX, secondEnterY, secondEnterX);
                    break;
            }
        }
        static void MoveOfAPiece(char[,] newTable, int firstEnterY, int firstEnterX, int secondEnterY, int secondEnterX) //меняет элементы массива
        {
            if (newTable[secondEnterX, secondEnterY] == ' ')
            {
                newTable[secondEnterX, secondEnterY] = newTable[firstEnterX, firstEnterY];
                newTable[firstEnterX, firstEnterY] = ' ';
            }
        }
        static char[,] ChangeTable() //создает массив начальный
        {
            char[,] newTable = new char[8, 8]
            {
            {'R', 'L', 'E', 'Q', 'K', 'E', 'L', 'R'}, //a
            {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'}, //b
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //c
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}, //d
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
            {'R', 'L', 'E', 'Q', 'K', 'E', 'L', 'R'}
            };
            return newTable;
        }
        static void FillTableFigures(char[,] newTable) //заносим в таблицу координаты 
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
        static void CycleForArray(char[,] newTable, char figure) //делает ходы бесконечностью
        {
            bool count = false;
            int cursorPositionY = 1;
            int cursorPositionX = 1;
            int firstEnterY = 0;
            int firstEnterX = 0;
            int secondEnterX = 0;
            int secondEnterY = 0;
            //string startmove;
            //char figure;
            //string endmove;
            //int move1;
            //int move2;
            //if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            //{
            //    SaveForTXT(newTable);
            //    Environment.Exit(0);
            //}
            //startmove = ReadCoordinate();
            //endmove = ReadCoordinate();
            //move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            //move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            //Console.WriteLine("Введите соотвествующую букву, для фигуры которой вы хотите сходить.\nСлон - E, ладья - R, пешка - Р, конь - L, ферзь - Q, король - К");
            //figure = Convert.ToChar(Console.ReadLine());
            //MotionFigure(figure, startmove, endmove, move1, move2, newTable);
            //MoveOfAPiece(figure, startmove, endmove, newTable);
            DrawTable(newTable);
            FillTableFigures(newTable);
            Console.SetCursorPosition(cursorPositionY, cursorPositionX);
            WASDandEnter(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
        }
        static void SaveForTXT(char[,] newTable) //записывает файл в тхт
        {
            string path = @"D:\Project\KsIgV\ChelGU\MovesInChess\ChessBoard.txt";
            using StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    sw.Write(newTable[i, j]);
                    sw.Write('.');
                }
                sw.WriteLine();
            }
        }
        static char[,] OpenForTXT() //открывает файл если имеется
        {
            string path = @"D:\Project\KsIgV\ChelGU\MovesInChess\ChessBoard.txt";
            if (File.Exists(path) == true)
            {
                char[,] newTable = new char[8, 8];
                using (StreamReader popa = new StreamReader(path))
                {
                    string str;
                    for (int i = 0; i < newTable.GetLength(0); i++)
                    {
                        str = popa.ReadLine();
                        string[] text = str.Split('.');
                        for (int j = 0; j < newTable.GetLength(1); j++)
                        {
                            newTable[i, j] = Convert.ToChar(text[j]);
                        }
                    }
                }
                DrawTable(newTable);
                FillTableFigures(newTable);
                return newTable;
            }
            return ChangeTable();
        }
        static void WASDandEnter(char[,] newTable, int secondEnterY, int secondEnterX, int firstEnterX, int firstEnterY, int cursorPositionY, int cursorPositionX, bool count, char figure)
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        SaveForTXT(newTable);
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.W:
                        cursorPositionX -= 2;
                        CheckPosition(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
                        break;
                    case ConsoleKey.A:
                        cursorPositionY -= 2;
                        CheckPosition(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
                        break;
                    case ConsoleKey.S:
                        cursorPositionX += 2;
                        CheckPosition(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
                        break;
                    case ConsoleKey.D:
                        cursorPositionY += 2;
                        CheckPosition(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
                        break;
                    case ConsoleKey.Enter:
                        CheckEnterCoordinate(newTable, ref firstEnterY, ref firstEnterX, ref secondEnterY, ref secondEnterX, cursorPositionY, cursorPositionX, ref count, figure);
                        MotionFigure(firstEnterY, firstEnterX, secondEnterY, secondEnterX, newTable);
                        FillTableFigures(newTable);
                        Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                        break;
                }
            }
        }
        static int CheckPosition(char[,] newTable, int secondEnterY, int secondEnterX, int firstEnterX, int firstEnterY, int cursorPositionY, int cursorPositionX, bool count, char figure)
        {
            if (cursorPositionX > 16 || cursorPositionY > 16 || cursorPositionY <= 0 || cursorPositionX <= 0)
            {
                cursorPositionY = 1;
                cursorPositionX = 1;
                Console.SetCursorPosition(cursorPositionY, cursorPositionX);
                WASDandEnter(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
            }
            else
                Console.SetCursorPosition(cursorPositionY, cursorPositionX);
            return cursorPositionX;
        }
        static bool CheckEnterCoordinate(char[,] newTable, ref int firstEnterY, ref int firstEnterX, ref int secondEnterY, ref int secondEnterX, int cursorPositionY, int cursorPositionX, ref bool count, char figure)
        {
            if (count == false)
            {
                firstEnterY = cursorPositionY / 2;
                firstEnterX = cursorPositionX / 2;
                count = true;
                WASDandEnter(newTable, secondEnterY, secondEnterX, firstEnterX, firstEnterY, cursorPositionY, cursorPositionX, count, figure);
            }
            if (count == true)
            {
                secondEnterY = cursorPositionY / 2;
                secondEnterX = cursorPositionX / 2;
                count = false;
            }
            return count;
        }
    }
}