using System;
using VisioForge.Shared.MediaFoundation.OPM;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            //    Console.WriteLine("Здравствуйте, введите координаты коня до хода.\nЗатем введите координаты коня после хода.");
            //    string startmove = ReadCoordinate();
            //    string endmove = ReadCoordinate();
            //    HorseMove(startmove, endmove);
            //    int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            //    int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            //    //HorseMove(startmove, endmove, move1, move2);
            //    ElephantMove(startmove, endmove, move1, move2);
            //    //RookMove(startmove, endmove);
            //    //QueenMove(startmove, endmove, move1, move2);
            //    //KingMove(startmove, endmove, move1, move2);
            //    //PawnMove(startmove, endmove, move1, move2);
            //}
            //static string ReadCoordinate()
            //{
            //    string coordinate;
            //    do
            //    {
            //        coordinate = Console.ReadLine().ToUpper();
            //    } while (!CheckCoordinate(coordinate));
            //    return coordinate;
            //}
            //static bool CheckCoordinate(string coordinate)
            //{
            //    if (coordinate.Length == 2 && coordinate[0] >= 'A' && coordinate[0] <= 'H' && coordinate[1] >= '1' && coordinate[1] <= '8')
            //        return true;
            //    else
            //        return false;
            //}
            //static void HorseMove(string startmove, string endmove)
            //{
            //    int move1 = Math.Abs(startmove[0] - endmove[0]);
            //    int move2 = Math.Abs(startmove[1] - endmove[1]);
            //    if (((move1 == 2) && (move2 == 1))
            //        || ((move1 == 1) && (move2 == 2)))
            //        Console.WriteLine("Верно");
            //    else
            //        Console.WriteLine("Не верно");
            //}
            //static void ElephantMove(string startmove, string endmove, int move1, int move2) // слон
            //{
            //    if (((move1 == move2) && startmove[0] != endmove[0] && startmove[1] != endmove[1]))
            //        Console.WriteLine("Верно");
            //    else
            //        Console.WriteLine("Не верно");
            //}
            //static void RookMove(string startmove, string endmove) // ладья
            //{
            //    if (startmove[0] == endmove[0] || startmove[1] == endmove[1])
            //        Console.WriteLine("Верно");
            //    else
            //        Console.WriteLine("Не верно");
            //}
            //static void QueenMove(string startmove, string endmove, int move1, int move2) // ферзь
            //{
            //    if (((move1 == move2) || (startmove[0] == endmove[0] || startmove[1] == endmove[1])))
            //        Console.WriteLine("Верно");
            //    else
            //        Console.WriteLine("Не верно");
            //}
            //static void KingMove(string startmove, string endmove, int move1, int move2) // король
            //{
            //    if (move1 + move2 == 1 || move1 == 1 && move2 == 1)
            //        Console.WriteLine("Верно");
            //    else
            //        Console.WriteLine("Не верно");
            //}
            //static void PawnMove(string startmove, string endmove, int move1, int move2) // пешка
            //{
            //    if (((startmove[1] == '2' || startmove[1] == '7') && (move2 == 1 || move2 == 2) && move1 == 0) || (move1 == 0 && move2 == 1))
            //        Console.WriteLine("Верно");
            //    else
            //        Console.WriteLine("Не верно");
            //}
            char[,] FigureArray = StartFigure();
            DrawTable(FigureArray);
            FillTableStartingFigures(FigureArray);
        }
        static void FillTableStartingFigures(char[,] FigureArray)
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
        }
        static void DrawTable(char[,] FigureArray)
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
            char[,] FigureArray = new char[8, 8]; //Создали массив того, что будет на поле
            {
                for (int i = 0; i < 8; i++) //пешка
                {
                    FigureArray[1, i] = 'P';
                    for (int j = 0; j < 8; j++)
                        FigureArray[6, j] = 'P';
                }
                for (int i = 0; i < 8; i = i + 7) //ладья
                    FigureArray[0, i] = 'R';

                for (int j = 0; j < 8; j = j + 7)
                        FigureArray[7, j] = 'R';
                for (int i = 1; i < 7; i = i + 5) //конь
                    FigureArray[0, i] = 'L';
                    for (int j = 1; j < 7; j = j + 5)
                        FigureArray[7, j] = 'L';
                for (int i = 2; i < 6; i = i + 3) //слон
                    FigureArray[0, i] = 'E';
                    for (int j = 2; j < 6; j = j + 3)
                        FigureArray[7, j] = 'E';
                for (int i = 0; i < 8; i = i + 7) //ферзь
                    FigureArray[i, 3] = 'Q';
                for (int i = 0; i < 8; i = i + 7) //король
                    FigureArray[i, 4] = 'K';
            }
            return FigureArray;
        }
    }
}
