using System;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите координаты коня до хода.\nЗатем введите координаты коня после хода.");
            string startmove = ReadCoordinate();
            string endmove = ReadCoordinate();
            HorseMove(startmove, endmove);
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
        static void HorseMove(string startmove, string endmove)
        {
            int move1 = Math.Abs(startmove[0] - endmove[0]);
            int move2 = Math.Abs(startmove[1] - endmove[1]);
            if (((move1 == 2) && (move2 == 1))
                || ((move1 == 1) && (move2 == 2)))
                Console.WriteLine("Верно");
            else
                Console.WriteLine("Не верно");
        }
    }
}
