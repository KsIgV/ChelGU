using System;
using System.Collections.Generic;

namespace AdvancedCalculator
{
    class RPN
    {
        public enum Operations
        {
            plus = 1,
            minus = 2,
            multiplication = 3,
            division = 4,
            degree = 5,
            firstBrace = 6,
            secondBrace = 7
        }
        public void ParseExpression(string[] numberInFunction, string function, int valueOperationsInBrace) //находим значение функции
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
    }
}
