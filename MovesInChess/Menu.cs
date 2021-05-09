using System;
using System.IO;

namespace MovesInChess
{
    class Menu
    {
        public void Screen()
        {
            string[] screenNameGame = {"╔═══╣   ╦    ╦   ╔═══╣   ╔═══╣   ╔═══╣", "║       ║    ║   ║       ║       ║    ", "║       ╠════╣   ╠═══╣   ╚═══╗   ╚═══╗", "║       ║    ║   ║           ║       ║","╚═══╣   ╩    ╩   ╚═══╣   ╠═══╝   ╠═══╝"};
            string[] screenMenu = { "NEW GAME", "CONTINUE", "RATING", "EXIT" };
            int cursorPosition = 0;
            ItemHighlight(cursorPosition, screenNameGame, screenMenu);
            MoveInScreen(cursorPosition, screenNameGame, screenMenu);
        }
        private void MoveInScreen(int cursorPosition, string[] screenChess, string[] screenMenu)
        {
            Game game = new Game();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        cursorPosition -= 1;
                        if (CheckPositionInMenu(cursorPosition))
                        ItemHighlight(cursorPosition, screenChess, screenMenu);
                        else
                            cursorPosition += 1;
                        break;
                    case ConsoleKey.S:
                        cursorPosition += 1;
                        if (CheckPositionInMenu(cursorPosition))
                            ItemHighlight(cursorPosition, screenChess, screenMenu);
                        else
                            cursorPosition -= 1;
                        break;
                    case ConsoleKey.Enter:
                        if (cursorPosition == 0) //new game
                        {
                            if (File.Exists("ChessBoard.txt"))
                                File.Delete("ChessBoard.txt");
                            game.CycleForArray();
                        }
                        if (cursorPosition == 1) //continue
                            game.CycleForArray();
                        if (cursorPosition == 2) //rating
                            Console.WriteLine("Однажды тут будет рейтинг побед.");
                        if (cursorPosition == 3) //exit
                        {
                            WorkWithFIles workWithFIles = new WorkWithFIles();
                            string[,] newTable = workWithFIles.OpenForTXT();
                            workWithFIles.SaveForTXT(newTable);
                            Console.ResetColor();
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }
        private bool CheckPositionInMenu(int cursorPosition)
        {
            if (cursorPosition >= 0 && cursorPosition <= 3)
                return true;
            else
                return false;
        }
        private void ItemHighlight(int cursorPosition, string[] screenChess, string[] menu)
        {
            Console.Clear();
            for (int i = 0; i < screenChess.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(screenChess[i]);
            }
            for (int i = 0; i < menu.Length; i++)
            {
                if (i == cursorPosition)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(menu[i]);
            }
        }
    }
}
