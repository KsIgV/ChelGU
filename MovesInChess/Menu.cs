using System;
using System.Collections.Generic;
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
            string[,] newTable = workWithFIles.OpenForTXT();
            ItemHighlight(screenChess, menu);
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
                            Console.WriteLine("What's your name?"); //есть ощущение что эти четыре строки должны быть в другом месте
                            string nameFirstPerson = Console.ReadLine();
                            Console.WriteLine("What's your friend's name?");
                            string nameSecondPerson = Console.ReadLine();
                            Console.Clear();
                            chessFigure.CycleForArray();
                        }
                        if (cursorPositionX == 7) //cotionue
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
