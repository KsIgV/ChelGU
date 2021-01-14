using System;

namespace WorkingWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите какой-то текст.");
            string text = Console.ReadLine();
            ValuePunct(text);
            BreakText(text);
        }
        static void ValuePunct(string text)
        {
            string[] temp = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[] punctuationMarks = new char[] { '!', '?', ';', '.', ',', '-', '"', '(', ')' };
            int value = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                foreach (var item in punctuationMarks)
                {
                    if (temp[i].Contains(item))
                        value += 1;
                }
            }
            Console.WriteLine(value);
        }
        static void BreakText(string text)
        { 
            string[] breakString = text.Split('.','!', '?');
            foreach (var item in breakString)
            {
                Console.WriteLine(item);
            }
        }
        static void BreakText(string text)
    }
}
