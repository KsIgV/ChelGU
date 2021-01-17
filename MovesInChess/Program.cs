using System;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальную координату.\nЗатем введите конечную координату.");
            string startmove = ReadCoordinate();
            string endmove = ReadCoordinate();
            int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            Console.WriteLine("Введите соотвествующую букву, для фигуры которой вы хотите сходить.\nСлон - E, ладья - R, пешка - Р, конь - L, ферзь - Q, король - К");
            char figure = Convert.ToChar(Console.ReadLine());
            char[,] FigureArray = StartFigure();
            MotionFigure(figure, startmove, endmove, move1, move2, FigureArray);
            Console.Clear();
            //HorseMove(startmove, endmove);
            //ElephantMove(startmove, endmove, move1, move2);
            //RookMove(startmove, endmove);
            //QueenMove(startmove, endmove, move1, move2);
            //KingMove(startmove, endmove, move1, move2);
            //PawnMove(startmove, endmove, move1, move2);
            DrawTable(FigureArray);
            FillTableStartingFigures(FigureArray);
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
        static void HorseMove(int move1, int move2) //конь
        {
            if (((move1 == 2) && (move2 == 1))
                || ((move1 == 1) && (move2 == 2)))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void ElephantMove(string startmove, string endmove, int move1, int move2) // слон
        {
            if (((move1 == move2) && startmove[0] != endmove[0] && startmove[1] != endmove[1]))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void RookMove(string startmove, string endmove) // ладья
        {
            if (startmove[0] == endmove[0] || startmove[1] == endmove[1])
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void QueenMove(string startmove, string endmove, int move1, int move2) // ферзь
        {
            if (((move1 == move2) || (startmove[0] == endmove[0] || startmove[1] == endmove[1])))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void KingMove(string startmove, string endmove, int move1, int move2) // король
        {
            if (move1 + move2 == 1 || move1 == 1 && move2 == 1)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void PawnMove(string startmove, string endmove, int move1, int move2) // пешка
        {
            if (((startmove[1] == '2' || startmove[1] == '7') && (move2 == 1 || move2 == 2) && move1 == 0) || (move1 == 0 && move2 == 1))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void FillTableStartingFigures(char[,] FigureArray) //заносим в таблицу координаты
        {
            int cursorPositionY = 1;
            for (int i = 0; i < FigureArray.GetLength(0); i++)
            {
                int cursorPositionX = 1;
                for (int j = 0; j < FigureArray.GetLength(1); j++)
                {
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);
                    Console.Write(FigureArray[i, j]);
                    cursorPositionX += 2;
                }
                cursorPositionY += 2;
            }
            Console.WriteLine();
            Console.WriteLine();
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
        static char[,] StartFigure()
        {
            char[,] FigureArray = new char[8, 8] //создаем массив того, что будет на поле
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
            return FigureArray;
        }
        static void MotionFigure(char figure, string startmove, string endmove, int move1, int move2, char[,] FigureArray)
        {
            if (FigureArray[startmove[1] - '1', startmove[0] - 'A'] == figure)
            {
                switch (figure)
                {
                    case 'K':
                        KingMove(startmove, endmove, move1, move2);
                        FigureArray[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                        FigureArray[endmove[1] - '1', endmove[0] - 'A'] = figure;
                        break;
                    case 'Q':
                        QueenMove(startmove, endmove, move1, move2);
                        FigureArray[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                        FigureArray[endmove[1] - '1', endmove[0] - 'A'] = figure;
                        break;
                    case 'L':
                        HorseMove(move1, move2);
                        FigureArray[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                        FigureArray[endmove[1] - '1', endmove[0] - 'A'] = figure;
                        break;
                    case 'P':
                        PawnMove(startmove, endmove, move1, move2);
                        FigureArray[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                        FigureArray[endmove[1] - '1', endmove[0] - 'A'] = figure;
                        break;
                    case 'R':
                        RookMove(startmove, endmove);
                        FigureArray[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                        FigureArray[endmove[1] - '1', endmove[0] - 'A'] = figure;
                        break;
                    case 'E':
                        ElephantMove(startmove, endmove, move1, move2);
                        FigureArray[startmove[1] - '1', startmove[0] - 'A'] = ' ';
                        FigureArray[endmove[1] - '1', endmove[0] - 'A'] = figure;
                        break;
                }
            }
        }
    }
}
