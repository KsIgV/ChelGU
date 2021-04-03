using System.IO;

namespace AdvancedCalculator
{
    class WorkWithFiles
    {
        public string ReadingTheFunctionFromTXT()
        {
            string path = @"input.txt";
            using var sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
