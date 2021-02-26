using System;
using System.Collections.Generic;
using System.IO;

namespace TableOfFunctionValues
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] validVariablesInAFunction = new char[] { '+', '-', '/', '*', '^', 'x' }; //закинуть в метод обратно, и убрать Х
            string[] numberInFunction = ReadingTheFunctionFromTXT();
            if (CheckAboutAnotherSymbol(numberInFunction, validVariablesInAFunction))
            {
                //Console.WriteLine("Введите шаг построения (значение, на которое увеличивает X).");
                //int buildStep = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("X изначально равен 0. Введите диапазон значений X.");
                //int rangeOfValues = Convert.ToInt32(Console.ReadLine());
                //Console.Clear();
                FunctionValue(numberInFunction);
                //string[,] tableOfFunctionValues = new string[rangeOfValues + 1, 2]; // rangeOfValues + (ячейки под Х и У)
                //TableValues(tableOfFunctionValues, rangeOfValues, buildStep);
                //int maxLenght = 0;
                //MaxNumber(tableOfFunctionValues, rangeOfValues, maxLenght);
                ////DrawTable(rangeOfValues, maxLenght);
                //FillTableFigures(tableOfFunctionValues, rangeOfValues);
            }
        }
        private static string[] ReadingTheFunctionFromTXT()
        {
            string path = @"D:\Project\KsIgV\ChelGU\AdvancedCalculator\input.txt";
            string[] op = new string[] { "+", "-", "/", "*", "^" };
            using (var sr = new StreamReader(path))
            {
                string functionTXT = sr.ReadToEnd();
                string functionWithoutOperations = functionTXT;
                for (int i = 0; i < op.Length; i++)
                {
                    functionWithoutOperations = functionWithoutOperations.Replace(op[i], "$");
                }
                string[] numberInFunction = functionWithoutOperations.Split("$");
                return numberInFunction;
            }
        }
        enum Operations
        {
            plus = 0,
            minus = 0,
            multiplication = 1,
            division = 1, 
            degree = 2
        }
        static bool CheckAboutAnotherSymbol(string[] function, char[] validVariablesInAFunction)
        {
            int value = 2;
            if (function[0] == "y" && function[1] == "=")
            {
                for (int i = 2; i < function.Length; i++)
                {
                    if (())
                        value++;
                    for (int j = 0; j < validVariablesInAFunction.Length; j++)
                    {
                        if (())
                            value++;
                    }
                }
            }
            else
                Console.WriteLine("Перепроверьте заданную функцию. Возможно ваша функция начинается не с \"y=...\"");
            if (value == function.Length)
                return true;
            return false;
        }
        static void FunctionValue(string[] function) //находим значение функции
        {
            List<object> numbersAndOperation = new List<object>();
            Stack<Operations> operations = new Stack<Operations>();
            for (int i = 2; i < function.Length; i++) //начинаем со второй потому что сначала записано y= а потом уже вся нужная нам функция
            {
                if (function[i] == "x" || ())
                {
                    numbersAndOperation.Add(function[i]);
                }
                else
                {
                    switch (function[i])
                    {
                        case "+":
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.plus);
                                break;
                            }
                            if (operations.Peek() <= Operations.plus)
                                operations.Push(Operations.plus);
                            numbersAndOperation.Add(operations.Pop());
                            break;
                        case "-":
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.minus);
                                break;
                            }
                            if (operations.Peek() <= Operations.minus)
                                operations.Push(Operations.minus);
                            numbersAndOperation.Add(operations.Pop());
                            break;
                        case "/":
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.division);
                                break;
                            }
                            if (operations.Peek() <= Operations.division)
                                operations.Push(Operations.division);
                            numbersAndOperation.Add(operations.Pop());
                            break;
                        case "^":
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.degree);
                                break;
                            }
                            if (operations.Peek() < Operations.degree)
                                operations.Push(Operations.degree);
                            numbersAndOperation.Add(operations.Pop());
                            break;
                        case "*":
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.multiplication);
                                break;
                            }
                            if (operations.Peek() <= Operations.multiplication)
                                operations.Push(Operations.multiplication);
                            numbersAndOperation.Add(operations.Pop());
                            break;
                    }
                }
                
            }
            foreach (object z in numbersAndOperation)
            {
                Console.WriteLine(z);
            }
        }
        static string[,] TableValues(string[,] tableOfFunctionValues, int rangeOfValues, int buildStep, string function) // создаем массив в котором храниться значение Х и У
        {
            double x = 0;
            tableOfFunctionValues[0, 0] = "X";
            tableOfFunctionValues[0, 1] = "Y";
            for (int i = 1; i < rangeOfValues + 1; i++) //вносим в столбец Х значения, а потом в У
            {
                tableOfFunctionValues[i, 0] = Convert.ToString(x);
                double y = 1; /*FunctionValue(function); // function*/
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