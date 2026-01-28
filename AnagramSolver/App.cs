using System;
using System.Collections.Generic;
using System.Linq;
using AnagramSolver.Models;

namespace AnagramSolver
{
    public class App
    {
        private readonly string _filePath;
        private readonly WordProcessor _processor;
        private readonly DictionaryLoader _loader;

        private const int MaxAnagramsToShow = 10;
        private const int MinWordLength = 3;


        public App(string filePath)
        {
            _filePath = filePath;
            _processor = new WordProcessor();
            _loader = new DictionaryLoader();
        }

       public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Atsisiunciamas zodynas");
            _loader.LoadWords(_filePath, _processor);
            Console.WriteLine("Zodynas atsiustas. Ivesti 0 kad baigti.");

            while (true)
            {
                string input = "";
                bool lengthCheck = false;
                int anagramCount = 0;

                while (!lengthCheck)
                {
                    Console.WriteLine("\nIveskite zodi kurio anagramas norite suzinot(bent 3 raides): ");
                    input = Console.ReadLine()?.Trim() ?? "";
                    if (input == "0") return;

                    if (input.Length >= MinWordLength)
                    {
                        lengthCheck = true;
                    }
                    else
                    {
                        Console.WriteLine($"Klaida: Zodis per trumpas!");
                    }
                }

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                List<string> anagrams = _processor.GetAnagrams(input);
                if (anagrams.Any())
                {
                    Console.WriteLine($"Zodzio {input} anagramos: ");
                    foreach (string anagram in anagrams)
                    {
                        if(anagram != input && anagramCount<MaxAnagramsToShow)
                        {
                            Console.WriteLine($"- {anagram}");
                            anagramCount++;
                        }
                    }
                    if(anagramCount == 0)
                    {
                        Console.WriteLine("Zodine rastas tik ivestas zodis su sutampanciom raidem.");
                    }
                }
                else
                {
                    Console.WriteLine($"Anagramu zodziui {input} nera.");
                }
            }
            Console.WriteLine("Viso gero!");
        }
    }
}
