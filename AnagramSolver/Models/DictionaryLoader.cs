using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Models
{
    public class DictionaryLoader
    {
        public void LoadWords(string path, WordProcessor processor)
        {
			try
			{
				using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
				{
					string line;

					while((line  = reader.ReadLine()) != null)
					{
						string word = line.Trim();

						if(!string.IsNullOrEmpty(word))
						{
							processor.AddWord(word);
						}
					}
				}
			}
			catch (Exception ex)
			{
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
