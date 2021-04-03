using System;
using System.Collections.Generic;

namespace AdvancedCalculator
{
    class RPN
    {
        private List<object> numbersAndOperation = new List<object>();
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
        public List<object> ParseExpression(string[] numberInFunction, string function, int valueOperationsInBrace) //находим значение функции
        {
            int count = 0;
            bool numberOrOperation = true; //чтобы он формировал целое число
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
                            if (operations.Peek() == Operations.firstBrace || operations.Count == 0 || operations.Peek() < Operations.division)
                            {
                                operations.Push(Operations.division);
                                break;
                            }
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
                            if (operations.Peek() == Operations.firstBrace || operations.Count == 0 || operations.Peek() < Operations.multiplication)
                            {
                                operations.Push(Operations.multiplication);
                                break;
                            }
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
                            break;
                    }
                }
            }
            while (operations.Count != 0)
            {
                numbersAndOperation.Add(operations.Pop());
            }
            return numbersAndOperation;
        }
        public List<object> Calculate()
        {
            double firstNumber;
            double secondNumber;
            decimal result = 0;
            while (numbersAndOperation.Count != 1)
            {
                for (int i = 0; i < numbersAndOperation.Count - 1; i++)
                {
                    //string number = Convert.ToString(numbersAndOperation[i]);
                    //string operation = Convert.ToString(numbersAndOperation[i + 1]);
                    if (Convert.ToString(numbersAndOperation[i + 1]) == "firstBrace" || Convert.ToString(numbersAndOperation[i + 1]) == "secondBrace")
                    {
                        numbersAndOperation.RemoveAt(i + 1);
                    }
                    if (Convert.ToString(numbersAndOperation[i]) == "firstBrace" || Convert.ToString(numbersAndOperation[i]) == "secondBrace")
                    {
                        numbersAndOperation.RemoveAt(i);
                    }
                    if (double.TryParse(Convert.ToString(numbersAndOperation[i]), out _) && !double.TryParse(Convert.ToString(numbersAndOperation[i + 1]), out _))
                    {
                        firstNumber = Convert.ToDouble(numbersAndOperation[i - 1]);
                        secondNumber = Convert.ToDouble(numbersAndOperation[i]);
                        switch (Convert.ToString(numbersAndOperation[i + 1]))
                        {
                            case "plus":
                                result = (decimal)(firstNumber + secondNumber);
                                break;
                            case "minus":
                                result = (decimal)(firstNumber - secondNumber);
                                break;
                            case "multiplication":
                                result = (decimal)(firstNumber * secondNumber);
                                break;
                            case "division":
                                result = (decimal)(firstNumber / secondNumber);
                                break;
                            case "degree":
                                result = (decimal)Math.Pow(firstNumber, secondNumber);
                                break;
                        }
                        numbersAndOperation.RemoveAt(i - 1);
                        numbersAndOperation.RemoveAt(i);
                        numbersAndOperation.Insert(i - 1, result);
                        numbersAndOperation.RemoveAt(i);
                        i = 0;
                    }
                }
            }
            return numbersAndOperation;
        }
    }
}
