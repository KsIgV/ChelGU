using System;
using System.IO;

namespace MovesInChess
{
    class WorkWithFIles //работа с файлами
    {
        private string path = @"D:\Project\KsIgV\ChelGU\MovesInChess\ChessBoard.txt";
        private char[,] StartingPositionOfTheFiguresOnTheBoard() //создает стартовый массив
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
        public char[,] OpenForTXT() //открывает файл если имеется
        {
            if (File.Exists(path))
            {
                char[,] newTable = new char[8, 8];
                using (StreamReader popa = new StreamReader(path))
                {
                    string str;
                    for (int i = 0; i < newTable.GetLength(0); i++)
                    {
                        str = popa.ReadLine();
                        string[] text = str.Split('.');
                        for (int j = 0; j < newTable.GetLength(1); j++)
                        {
                            newTable[i, j] = Convert.ToChar(text[j]);
                        }
                    }
                }
                return newTable; //возвращает массив из файла
            }
            else
                return StartingPositionOfTheFiguresOnTheBoard(); //возвращает новый стартовый массив
        }
        public void SaveForTXT(char[,] newTable) //записывает файл в тхт
        {
            using StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    sw.Write(newTable[i, j]);
                    sw.Write('.');
                }
                sw.WriteLine();
            }
        }
    }
}