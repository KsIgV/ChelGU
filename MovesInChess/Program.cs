using System;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            string startmove;
            char figure;
            string endmove;
            int move1;
            int move2;
            char[,] newTable = ChangeTable();
            CycleForArray(newTable, out figure, out startmove, out endmove, out move1, out move2);
        }
        static string ReadCoordinate() //считываем координаты
        {
            string coordinate;
            do
            {
                coordinate = Console.ReadLine().ToUpper();
            } while (!CheckCoordinate(coordinate));
            return coordinate;
        }
        static bool CheckCoordinate(string coordinate)//проверка координат введеных
        {
            if (coordinate.Length == 2 && coordinate[0] >= 'A' && coordinate[0] <= 'H' && coordinate[1] >= '1' && coordinate[1] <= '8')
                return true;
            else
                return false;
        }
        static bool HorseMove(int move1, int move2) //конь
        {
            if (((move1 == 2) && (move2 == 1))
                || ((move1 == 1) && (move2 == 2)))
                return true;
            else
                return false;
        }
        static bool ElephantMove(string startmove, string endmove, int move1, int move2) // слон
        {
            if ((move1 == move2) && startmove[0] != endmove[0] && startmove[1] != endmove[1])
                return true;
            else
                return false;
        }
        static bool RookMove(string startmove, string endmove) // ладья
        {
            if (startmove[0] == endmove[0] || startmove[1] == endmove[1])
                return true;
            else
                return false;
        }
        static bool QueenMove(string startmove, string endmove, int move1, int move2) // ферзь
        {
            if (((move1 == move2) || (startmove[0] == endmove[0] || startmove[1] == endmove[1])))
                return true;
            else
                return false;
        }
        static bool KingMove(string startmove, string endmove, int move1, int move2) // король
        {
            if (move1 + move2 == 1 || move1 == 1 && move2 == 1)
                return true;
            else
                return false;
        }
        static bool PawnMove(string startmove, string endmove, int move1, int move2) // пешка
        {
            if (((startmove[1] == '2' || startmove[1] == '7') && (move2 == 1 || move2 == 2) && move1 == 0) || (move1 == 0 && move2 == 1))
                return true;
            else
                return false;
        }
        static void DrawTable(char[,] FigureArray) //рисуем таблицу
        {
            for (int i = 0; i < FigureArray.GetLength(0); i++)
            {
                string UpLeftLine = "┌";
                string UpRightLine = "┐";
                string DownLeftLine = "└";
                string DownRightLine = "┘";
                for (int j = 0; j < FigureArray.GetLength(1); j++)
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
        static void MotionFigure(char figure, string startmove, string endmove, int move1, int move2, char[,] newTable) 
        {
            if (newTable[startmove[1] - '1', startmove[0] - 'A'] == figure)
            {
                switch (figure)
                {
                    case 'K':
                        if (KingMove(startmove, endmove, move1, move2) == true)
                            MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                        break;
                    case 'Q':
                        if (QueenMove(startmove, endmove, move1, move2) == true)
                            MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                        break;
                    case 'L':
                        if (HorseMove(move1, move2) == true)
                            MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                        break;
                    case 'P':
                        if (PawnMove(startmove, endmove, move1, move2) == true)
                            MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                        break;
                    case 'R':
                        if (RookMove(startmove, endmove) == true)
                            MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                        break;
                    case 'E':
                        if (ElephantMove(startmove, endmove, move1, move2) == true)
                            MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                        break;
                }
            }
        }
        static void MoveOfAPiece(char figure, string startmove, string endmove, int move1, int move2, char[,] newTable)
        {
            if (newTable[startmove[1] - '1', startmove[0] - 'A'] == figure)
            {
                newTable[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                newTable[endmove[1] - '1', endmove[0] - 'A'] = figure;
            }
        }
        static char[,] ChangeTable()
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
        static void CycleForArray(char[,] newTable, out char figure, out string startmove, out string endmove, out int move1, out int move2)
        {
            while (true)
            {
                Console.WriteLine("Введите начальную координату.\nЗатем введите конечную координату.");
                startmove = ReadCoordinate();
                endmove = ReadCoordinate();
                move1 = Math.Abs(startmove[0] - endmove[0]); // С B
                move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
                Console.WriteLine("Введите соотвествующую букву, для фигуры которой вы хотите сходить.\nСлон - E, ладья - R, пешка - Р, конь - L, ферзь - Q, король - К");
                figure = Convert.ToChar(Console.ReadLine());
                MotionFigure(figure, startmove, endmove, move1, move2, newTable);
                Console.Clear();
                ChangeTable();
                MoveOfAPiece(figure, startmove, endmove, move1, move2, newTable);
                DrawTable(newTable);
                FillTableFigures(newTable);
            }
        }
    }
}