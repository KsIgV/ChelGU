using System;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите координаты коня до хода");
            string beforemove = Console.ReadLine(); // C3
            Console.WriteLine("Здравствуйте, введите координаты коня после хода");
            string aftermove = Console.ReadLine(); // E5
            char move1X = beforemove[0]; // C
            char move1Y = beforemove[1]; // 3
            int move2X = aftermove[0]; // E
            int move2Y = aftermove[1]; // 5
            if (move1X >= 'A' && move2X >= 'A' 
                && move1Y > '0' && move2Y > '0' 
                    && move1X <= 'H' && move2X <= 'H' 
                        && move1Y < '9' && move2Y < '9')
            {
                int move1 = Math.Abs(move1X - move2X);
                int move2 = Math.Abs(move1Y - move2Y);
                if (((move1 == 2) && (move2 == 1)) 
                    || ((move1 == 1) && (move2 == 2)))
                {
                    Console.WriteLine("Верно");
                }
                else
                {
                    Console.WriteLine(move2);
                }
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
