using System;
using System.Collections.Generic;
using System.IO;

namespace AdvancedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ваш пример должен начинаться с y=, а также дробные числа должны быть записаны через запятую. И пробелов в примере быть не должно. \nТеперь введите чему равен x.");
            char valueX = Convert.ToChar(Console.ReadLine());
            WorkWithFiles workWithFile = new WorkWithFiles();
            SearchSomething Search = new SearchSomething();
            RPN rPN = new RPN();
            string functionTXT = workWithFile.ReadingTheFunctionFromTXT();
            char[] charsToTrim = { '=', 'y' };
            string function = functionTXT.Trim(charsToTrim).Replace('x', valueX);
            string[] numberInFunction = Search.SearchNumbersInTXT(function);
            int valueOperationsInBrace = Search.SearchValueOperationsInBrace(function);
            rPN.ParseExpression(numberInFunction, function, valueOperationsInBrace);
            object[] result = rPN.Calculate().ToArray();
            Console.WriteLine(result[0]);
        }
    }
}