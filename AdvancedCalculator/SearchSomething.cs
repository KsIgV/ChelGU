
namespace AdvancedCalculator
{
    class SearchSomething
    {
        public string[] SearchNumbersInTXT(string functionTXT)
        {
            string[] op = new string[] { "+", "-", "/", "*", "^", ")", "(" };
            string functionWithoutOperations = functionTXT;
            for (int i = 0; i < op.Length; i++)
            {
                functionWithoutOperations = functionWithoutOperations.Replace(op[i], "$");
                functionWithoutOperations = functionWithoutOperations.Replace("$$", "$");
            }
            functionWithoutOperations = functionWithoutOperations.Trim('$');
            return functionWithoutOperations.Split("$");
        }
        public int SearchValueOperationsInBrace(string function)
        {
            int value = 0;
            string[] op = new string[] { "+", "-", "/", "*", "^" };
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
    }
}
