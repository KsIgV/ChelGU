using System;
using System.IO;

namespace MovesInChess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessFigure chessFigure = new ChessFigure();
            chessFigure.CycleForArray();
        }
    }
}