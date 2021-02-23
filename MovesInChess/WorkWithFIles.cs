using System;
using System.IO;

namespace MovesInChess
{
    class WorkWithFIles //работа с файлами
    {
        private string path = @"D:\Project\KsIgV\ChelGU\MovesInChess\ChessBoard.txt";
        private string[,] StartingPositionOfTheFiguresOnTheBoard() //создает стартовый массив
        {
            string[,] newTable = new string[8, 8]
            {
            {"R1", "L1", "E1", "Q1", "K1", "E1", "L1", "R1"}, //a
            {"P1", "P1", "P1", "P1", "P1", "P1", "P1", "P1"}, //b
            {" ", " ", " ", " ", " ", " ", " ", " "}, //c
            {" ", " ", " ", " ", " ", " ", " ", " "}, //d
            {" ", " ", " ", " ", " ", " ", " ", " "},
            {" ", " ", " ", " ", " ", " ", " ", " "},
            {"P1", "P1", "P1", "P1", "P1", "P1", "P1", "P1"},
            {"R1", "L1", "E1", "Q1", "K1", "E1", "L1", "R1"}
            };
            return newTable;
        }
        public string[,] OpenForTXT() //открывает файл если имеется
        {
            if (File.Exists(path))
            {
                string[,] newTable = new string[8, 8];
                using (StreamReader popa = new StreamReader(path))
                {
                    string str;
                    for (int i = 0; i < newTable.GetLength(0); i++)
                    {
                        str = popa.ReadLine();
                        string[] text = str.Split(".");
                        for (int j = 0; j < newTable.GetLength(1); j++)
                        {
                            newTable[i, j] = text[j];
                        }
                    }
                }
                return newTable; //возвращает массив из файла
            }
            else
                return StartingPositionOfTheFiguresOnTheBoard(); //возвращает новый стартовый массив
        }
        public void SaveForTXT(string[,] newTable) //записывает файл в тхт
        {
            using StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < newTable.GetLength(0); i++)
            {
                for (int j = 0; j < newTable.GetLength(1); j++)
                {
                    sw.Write(newTable[i, j]);
                    sw.Write(".");
                }
                sw.WriteLine();
            }
        }
    }
}