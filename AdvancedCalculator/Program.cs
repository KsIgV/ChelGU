using System;
using System.Collections.Generic;
using System.IO;

namespace AdvancedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithFiles workWithFile = new WorkWithFiles();
            SearchSomething Search = new SearchSomething();
            RPN rPN = new RPN();
            string functionTXT = workWithFile.ReadingTheFunctionFromTXT();
            char[] charsToTrim = { '=', 'y' };
            string function = functionTXT.Trim(charsToTrim);
            string[] numberInFunction = Search.SearchNumbersInTXT(function);
            int valueOperationsInBrace = Search.SearchValueOperationsInBrace(function);
            rPN.ParseExpression(numberInFunction, function, valueOperationsInBrace);

            //Console.WriteLine("Введите шаг построения (значение, на которое увеличивает X).");
            //int buildStep = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("X изначально равен 0. Введите диапазон значений X.");
            //int rangeOfValues = Convert.ToInt32(Console.ReadLine());
            //Console.Clear();
            //string[,] tableOfFunctionValues = new string[rangeOfValues + 1, 2]; // rangeOfValues + (ячейки под Х и У)
            //TableValues(tableOfFunctionValues, rangeOfValues, buildStep);
            //int maxLenght = 0;
            //MaxNumber(tableOfFunctionValues, rangeOfValues, maxLenght);
            ////DrawTable(rangeOfValues, maxLenght);
            //FillTableFigures(tableOfFunctionValues, rangeOfValues);
        }
    }
}