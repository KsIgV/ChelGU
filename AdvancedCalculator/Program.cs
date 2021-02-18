using System;

namespace TableOfFunctionValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Функция в коде Y = 4^X, изначально X = 0. \nВведите шаг построения (значение, на которое увеличивает X).");
            int buildStep = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите диапазон значений X.");
            int rangeOfValues = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            string[,] tableOfFunctionValues = new string[rangeOfValues + 1, 2]; // rangeOfValues + (ячейки под Х и У)
            TableValues(tableOfFunctionValues, rangeOfValues, buildStep);
            int maxLenght = 0;
            MaxNumber(tableOfFunctionValues, rangeOfValues, maxLenght);
            //DrawTable(rangeOfValues, maxLenght);
            FillTableFigures(tableOfFunctionValues, rangeOfValues);
        }
        static string[,] TableValues(string[,] tableOfFunctionValues, int rangeOfValues, int buildStep) // создаем массив в котором храниться значение Х и У
        {
            double x = 0;
            tableOfFunctionValues[0, 0] = "X";
            tableOfFunctionValues[0, 1] = "Y";
            for (int i = 1; i < rangeOfValues + 1; i++) //вносим в столбец Х значения
            {
                tableOfFunctionValues[i, 0] = Convert.ToString(x);
                double y = Math.Pow(4, x);
                tableOfFunctionValues[i, 1] = Convert.ToString(y);
                x = buildStep + x;
            }
            return tableOfFunctionValues;
        }
        private static int MaxNumber(string[,] tableOfFunctionValues, int rangeOfValues, int maxLenght) //ищем максимальную длину число, для того чтобы оно вписалось в таблицу и не выходило из нее
        {
            for (int i = 0; i < rangeOfValues + 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (maxLenght < tableOfFunctionValues[i, j].Length)
                    {
                        maxLenght = tableOfFunctionValues[i, j].Length;
                    }
                }
            }
            return maxLenght;
        }
        //private static void DrawTable(int rangeOfValues, int maxLenght) //рисуем таблицу
        //{
        //    for (int i = 0; i < rangeOfValues + 1; i++)
        //    {
        //        string UpLeftLine = "┌";
        //        string UpRightLine = "┐";
        //        string DownLeftLine = "└";
        //        string DownRightLine = "┘";
        //        for (int j = 0; j < 2; j++)
        //        {
        //            Console.SetCursorPosition(j * 2, i * 2);
        //            if (i != 0)
        //            {
        //                UpLeftLine = "├";
        //                UpRightLine = "┤";
        //            }
        //            if (j != 0)
        //            {
        //                UpLeftLine = "┬";
        //                DownLeftLine = "┴";
        //            }
        //            if (i != 0 && j != 0)
        //                UpLeftLine = "┼";
        //            Console.WriteLine(UpLeftLine + "─" + UpRightLine);
        //            Console.SetCursorPosition(j * 2, Console.CursorTop);
        //            Console.WriteLine("│" + " " + "│");
        //            Console.SetCursorPosition(j * 2, Console.CursorTop);
        //            Console.Write(DownLeftLine + "─" + DownRightLine);
        //        }
        //    }
        //}
        private static void FillTableFigures(string[,] tableOfFunctionValues, int rangeOfValues) //заносим в таблицу значения 
        {
            int cursorPositionY = 1;
            for (int i = 0; i < rangeOfValues + 1; i++)
            {
                int cursorPositionX = 1;
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);
                    Console.Write(tableOfFunctionValues[i, j]);
                    cursorPositionX += 2;
                }
                cursorPositionY += 2;
            }
        }
    }
}