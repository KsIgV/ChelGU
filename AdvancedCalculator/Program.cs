using System;
using System.Collections.Generic;
using System.IO;

namespace TableOfFunctionValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] op = new string[] { "+", "-", "/", "*", "^", ")", "(" }; 
            string functionTXT = ReadingTheFunctionFromTXT();
            char[] charsToTrim = { '=', 'y' };
            string function = functionTXT.Trim(charsToTrim);
            string[] numberInFunction = SearchNumbersInTXT(function, op);
            int valueOperationsInBrace = SearchValueOperationsInBrace(function);
            ParseExpression(numberInFunction, function, valueOperationsInBrace);

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
        private static int SearchValueOperationsInBrace(string function)
        {
            int value = 0;
            string[] op = new string[] { "+", "-", "/", "*", "^"};
            int findFirstBrace = function.IndexOf('(');
            int secondFirstBrace = function.IndexOf(')');
            for (int i = 0; i < op.Length; i++)
            {
                function = function.Replace(op[i], "#");
            }
            for (int i = findFirstBrace + 1; i < secondFirstBrace; i++)
            {
                if (function[i] == '#')
                    value++;
            }
            return value;
        }
        private static string ReadingTheFunctionFromTXT()
        {
            string path = @"D:\Project\KsIgV\ChelGU\AdvancedCalculator\input.txt";
            using (var sr = new StreamReader(path))
                return sr.ReadToEnd();
        }
        private static string[] SearchNumbersInTXT(string functionTXT, string[] op)
        {
            string functionWithoutOperations = functionTXT;
            for (int i = 0; i < op.Length; i++)
            {
                functionWithoutOperations = functionWithoutOperations.Replace(op[i], "$");
                functionWithoutOperations = functionWithoutOperations.Replace("$$", "$");
            }
            functionWithoutOperations = functionWithoutOperations.Trim('$');
            return functionWithoutOperations.Split("$");
        }
        enum Operations
        {
            plus = 1,
            minus = 2,
            multiplication = 3,
            division = 4,
            degree = 5,
            firstBrace = 6,
            secondBrace = 7
        }
        static void ParseExpression(string[] numberInFunction, string function, int valueOperationsInBrace) //находим значение функции
        {
            int count = 0;
            bool numberOrOperation = true; //чтобы он формировал целое число
            List<object> numbersAndOperation = new List<object>();
            Stack<Operations> operations = new Stack<Operations>();
            for (int i = 0; i < function.Length; i++)
            {
                string elementFunctionTXT = Convert.ToString(function[i]);
                if ((double.TryParse(elementFunctionTXT, out _) || elementFunctionTXT == "x") && count < numberInFunction.Length && numberOrOperation == true)
                {
                    numbersAndOperation.Add(numberInFunction[count]);
                    count++;
                    numberOrOperation = false;
                }
                else
                {
                    switch (elementFunctionTXT)
                    {
                        case "(":
                            numberOrOperation = true;
                            operations.Push(Operations.firstBrace);
                            break;
                        case ")":
                            numberOrOperation = true;
                            if (operations.Count != 0)
                            {
                                while (operations.Count != 0 && operations.Peek() != Operations.firstBrace && valueOperationsInBrace > 0) //вытаскивает все операции стоящие перед скобокой (
                                {
                                    numbersAndOperation.Add(operations.Pop());
                                    valueOperationsInBrace--;
                                }
                                operations.Push(Operations.secondBrace);
                            }
                            break;
                        case "+":
                            numberOrOperation = true;
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.plus);
                                break;
                            }
                            if (operations.Peek() >= Operations.plus || operations.Peek() == Operations.minus)
                            {
                                numbersAndOperation.Add(operations.Pop());
                                if (operations.Count != 0 && (operations.Peek() == Operations.plus || operations.Peek() == Operations.minus))
                                {
                                    numbersAndOperation.Add(operations.Pop());
                                }
                                operations.Push(Operations.plus);
                            }
                            break;
                        case "-":
                            numberOrOperation = true;
                            if (operations.Count == 0)
                            {
                                operations.Push(Operations.minus);
                                break;
                            }
                            if (operations.Peek() >= Operations.minus || operations.Peek() == Operations.plus)
                            {
                                numbersAndOperation.Add(operations.Pop());
                                if (operations.Count != 0 && (operations.Peek() == Operations.plus || operations.Peek() == Operations.minus))
                                {
                                    numbersAndOperation.Add(operations.Pop());
                                }
                                operations.Push(Operations.minus);
                            }
                            break;
                        case "/":
                            numberOrOperation = true;
                            if (operations.Count != 0 && (operations.Peek() >= Operations.division || operations.Peek() == Operations.multiplication))
                            {
                                numbersAndOperation.Add(operations.Pop());
                                if (operations.Peek() == Operations.division || operations.Peek() == Operations.multiplication)
                                {
                                    numbersAndOperation.Add(operations.Pop());
                                }
                                operations.Push(Operations.division);
                                break;
                            }
                            if (operations.Count == 0 || operations.Peek() < Operations.division)
                            {
                                operations.Push(Operations.division);
                            }
                            break;
                        case "^":
                            numberOrOperation = true;
                            if (operations.Count == 0 || operations.Peek() < Operations.degree)
                            {
                                operations.Push(Operations.degree);
                                break;
                            }
                            if (operations.Peek() >= Operations.degree) 
                            {
                                numbersAndOperation.Add(operations.Pop());
                                operations.Push(Operations.degree);
                            }
                            break;
                        case "*":
                            numberOrOperation = true;
                            if (operations.Count != 0 && (operations.Peek() >= Operations.multiplication || operations.Peek() == Operations.division))
                            {
                                numbersAndOperation.Add(operations.Pop());
                                if (operations.Count != 0 && (operations.Peek() == Operations.division || operations.Peek() == Operations.multiplication))
                                {
                                    numbersAndOperation.Add(operations.Pop());
                                }
                                operations.Push(Operations.multiplication);
                                break;
                            }
                            if (operations.Count == 0 || operations.Peek() < Operations.multiplication)
                            {
                                operations.Push(Operations.multiplication);
                            }
                            break;
                    }
                }
            }
            while (operations.Count != 0)
            {
                numbersAndOperation.Add(operations.Pop());
            }
            foreach (var item in numbersAndOperation)
            {
                Console.WriteLine(item);
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