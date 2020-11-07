using System;

namespace TableOfFunctionValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, в данном коде задана функция -> 4^x \nВведите шаг построения (значение, на которое увеличивает х)");
            int buildStep = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("А теперь диапазон значений х");
            int rangeOfValues = Convert.ToInt32(Console.ReadLine());
            int increaseX = 0;
            int function = 1;
            Console.WriteLine("x     y");
            while ((buildStep >= 0) && (rangeOfValues > 0))
            {
                while (increaseX >= 0)
                {
                    function = function * 4;
                    increaseX--;
                }
                increaseX = increaseX + buildStep; // увеличивает значение
                rangeOfValues--; // диапазон значений
                Console.WriteLine(increaseX + "     " + function);
            }
            if ((buildStep < 0) || (rangeOfValues <= 0))
            {
                Console.WriteLine("-     -\nВозможно вы где то ошиблись.. Попробуйте еще раз");
            }
        }
    }
}