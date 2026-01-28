using System;
using AnagramSolver;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\e.keizik\Desktop\AnagramSolver\AnagramSolver\temp\zodynas.txt";

        App myApp = new App(path);
        myApp.Run();
    }
}