﻿using System;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите координаты коня до хода.\nЗатем введите координаты коня после хода.");
            string startmove = ReadCoordinate();
            string endmove = ReadCoordinate();
            PawnMove(startmove, endmove);
        }
        static string ReadCoordinate()
        {
            string coordinate;
            do
            {
                coordinate = Console.ReadLine().ToUpper();
            } while (!CheckCoordinate(coordinate));
            return coordinate;
        }
        static bool CheckCoordinate(string coordinate)
        {
            if (coordinate.Length == 2 && coordinate[0] >= 'A' && coordinate[0] <= 'H' && coordinate[1] >= '1' && coordinate[1] <= '8')
                return true;
            else
                return false;
        }
        static void HorseMove(string startmove, string endmove) // конь
        {
            int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            if (((move1 == 2) && (move2 == 1))
                || ((move1 == 1) && (move2 == 2)))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void ElephantMove(string startmove, string endmove) // слон
        {
            int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            if (((move1 + move2) % 2 == 0) && startmove[0] != endmove[0] && startmove[1] != endmove[1])
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
        static void QueenMove(string startmove, string endmove) // ферзь
        {
            int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            if (((move1 + move2) % 2 == 0) || (startmove[0] == endmove[0] || startmove[1] == endmove[1]))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void KingMove(string startmove, string endmove) // король
        {
            int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            if (move1 == move2 || move1 - move2 == 1 || move2 - move1 == 1)
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
        static void PawnMove(string startmove, string endmove) // пешка
        {
            int move1 = Math.Abs(startmove[0] - endmove[0]); // С B
            int move2 = Math.Abs(startmove[1] - endmove[1]); // 1 5
            if (((startmove[1] == '2' || startmove[1] == '7') && (move2 == 1 || move2 == 2) && move1 == 0) || (move1 == 0 && move2 == 1))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
    }
}
