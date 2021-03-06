using System.IO;

namespace AdvancedCalculator
{
    class WorkWithFiles
    {
        public string ReadingTheFunctionFromTXT()
        {
            string path = @"D:\Project\KsIgV\ChelGU\AdvancedCalculator\input.txt";
            using var sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
