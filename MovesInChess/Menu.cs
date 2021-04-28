using System;
using System.IO;

namespace MovesInChess
{
    class Menu
    {
        private int cursorPositionX = 6;
        private WorkWithFIles workWithFIles = new WorkWithFIles();
        public void Screen()
        {
            string[] screenChess = {"╔═══╣   ╦    ╦   ╔═══╣   ╔═══╣   ╔═══╣", "║       ║    ║   ║       ║       ║    ", "║       ╠════╣   ╠═══╣   ╚═══╗   ╚═══╗", "║       ║    ║   ║           ║       ║","╚═══╣   ╩    ╩   ╚═══╣   ╠═══╝   ╠═══╝"};
            string[] menu = { "               NEW GAME", "               CONTINUE", "                RATING", "                 EXIT" };
            ItemHighlight(screenChess, menu);
            string[,] newTable = workWithFIles.OpenForTXT();
            WASDScreen(newTable, screenChess, menu);
        }
        private void WASDScreen(string[,] newTable, string[] screenChess, string[] menu)
        {
            ChessFigure chessFigure = new ChessFigure();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        cursorPositionX -= 1;
                        if (CheckPositionInMenu())
                        ItemHighlight(screenChess, menu);
                        else
                            cursorPositionX += 1;
                        break;
                    case ConsoleKey.S:
                        cursorPositionX += 1;
                        if (CheckPositionInMenu())
                            ItemHighlight(screenChess, menu);
                        else
                            cursorPositionX -= 1;
                        break;
                    case ConsoleKey.UpArrow:
                        cursorPositionX -= 1;
                        if (CheckPositionInMenu())
                            ItemHighlight(screenChess, menu);
                        else
                            cursorPositionX += 1;
                        break;
                    case ConsoleKey.DownArrow:
                        cursorPositionX += 1;
                        if (CheckPositionInMenu())
                            ItemHighlight(screenChess, menu);
                        else
                            cursorPositionX -= 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (cursorPositionX == 6) //new game
                        {
                            if (File.Exists("ChessBoard.txt"))
                                File.Delete("ChessBoard.txt");
                            InfoAbouPlayers();
                            Console.Clear();
                            chessFigure.CycleForArray();
                        }
                        if (cursorPositionX == 7) //continue
                            chessFigure.CycleForArray();
                        if (cursorPositionX == 8) //rating
                            Console.WriteLine("Однажды тут будет рейтинг побед");
                        if (cursorPositionX == 9) //exit
                        {
                            workWithFIles.SaveForTXT(newTable);
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }
        private void InfoAbouPlayers()
        {
            Console.WriteLine("Enter a name for the player PLAYER1."); 
            string player1 = Console.ReadLine();
            Console.WriteLine("Enter a name for the player PLAYER2.");
            string player2 = Console.ReadLine();
        }
        private bool CheckPositionInMenu()
        {
            if (cursorPositionX >= 6 && cursorPositionX <= 9)
                return true;
            else
                return false;
        }
        private void ItemHighlight(string[] screenChess, string[] menu)
        {
            Console.Clear();
            for (int i = 0; i < screenChess.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(screenChess[i]);
            }
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == cursorPositionX - 6)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(menu[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menu[i]);
                }
            }
            Console.ResetColor();
        }
    }
}
