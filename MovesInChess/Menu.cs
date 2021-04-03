using System;
using System.Collections.Generic;
using System.Text;

namespace MovesInChess
{
    class Menu
    {
        public void Screen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // устанавливаем цвет
            Console.WriteLine("╔═══╣   ╦    ╦   ╔═══╣   ╔═══╣   ╔═══╣");
            Console.WriteLine("║       ║    ║   ║       ║       ║    ");
            Console.WriteLine("║       ╠════╣   ╠═══╣   ╚═══╗   ╚═══╗");
            Console.WriteLine("║       ║    ║   ║           ║       ║");
            Console.WriteLine("╚═══╣   ╩    ╩   ╚═══╣   ╠═══╝   ╠═══╝");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("               NEW GAME");
            Console.WriteLine("               CONTINUE");
            Console.WriteLine("                RATING");
            Console.WriteLine("                 EXIT");
        }
    }
}
