using System;

namespace WorkingWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, введите какой-то текст.");
            string text = Console.ReadLine();
            string[] specialTextArray = (text.ToLower()).Split(new char[] { '!', '-', '.', ',', ':', ';', '"', '(', ')', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries); //разбиваем текст на отдельные слова
            int max = 0;
            int indexMaxWord = 0;
            ValuePunct(text);
            BreakTextFor(text);
            SpecialWordInText(specialTextArray);
            TheLongestWordInTheText(specialTextArray, ref max, ref indexMaxWord);
            evenOrOddLongWord(specialTextArray, max, indexMaxWord);
        }
        static void ValuePunct(string text)
        {
            char[] textArray = text.ToCharArray();
            char[] punctuationMarks = new char[] { '!', '-', '.', ',', ':', ';', '"', '(', ')', '?' };
            int valuePunctuation = 0;
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < punctuationMarks.Length; j++)
                {
                    if (Convert.ToString(textArray[i]).Contains(punctuationMarks[j]))
                        valuePunctuation++;
                }
            }
            Console.WriteLine("Кол-во знаков препинания в тексте: " + valuePunctuation);
        }
        static void BreakTextFor(string text)
        {
            string[] breakText = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Разбиваем текст на отдельные предложения:");
            for (int i = 0; i < breakText.Length; i++)
                Console.WriteLine(breakText[i]);
        }
        static void SpecialWordInText(string[] specialTextArray) //переписать
        {
            Console.Write("Уникальные слова в тексте: ");
            //for (int i = 0; i < specialTextArray.Length; i++)
            //{
            //    int similarityValue = 0;
            //    for (int j = 0; j < specialTextArray.Length; j++)
            //    {
            //        if (specialTextArray[i] != specialTextArray[j] && i != j)
            //            similarityValue++;
            //    }
            //    if (similarityValue == (specialTextArray.Length - 1))
            //        Console.Write(specialTextArray[i] + ", ");
            //}
            for (int i = 0; i < specialTextArray.Length; i++)
            {
                for (int j = 0; j < specialTextArray.Length; j++)
                {
                    if (specialTextArray[i] == specialTextArray[j] && i != j)
                        specialTextArray[i] = "";
                }
            }
            Console.WriteLine(specialTextArray);
        }
        static void TheLongestWordInTheText(string[] specialTextArray, ref int max, ref int indexMaxWord)
        {
            for (int i = 0; i < specialTextArray.Length; i++)
            {
                if (specialTextArray[i].Length > max)
                {
                    max = specialTextArray[i].Length;
                    indexMaxWord = i;
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Самое длинное слово во всем тексте: " + specialTextArray[indexMaxWord]);
        }
        static void evenOrOddLongWord(string[] specialTextArray, int max, int indexMaxWord)
        {
            if (max % 2 == 0) // четное
                Console.WriteLine(specialTextArray[indexMaxWord].Substring(max / 2));
            else // нечетное
            {
                char[] longWord = specialTextArray[indexMaxWord].ToCharArray(); // раскладываем слово на массив букв
                int middleOfTheWord = max / 2; //ищем индекс середины слова
                longWord[middleOfTheWord] = '*';
                Console.Write(longWord);
            }
        }
    }
}