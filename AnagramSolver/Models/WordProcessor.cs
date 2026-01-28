using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramSolver.Models
{
    public class WordProcessor
    {
        private Dictionary<string, List<string>> _wordGroups = new Dictionary<string, List<string>>();

        public void AddWord(string word)
        {
            string signature = GetSignature(word.ToLower());

            if(_wordGroups.ContainsKey(signature))
            {
                _wordGroups[signature].Add(word);
            }

            else
            {
                List<string> newWordList = new List<string>();
                newWordList.Add(word);

                _wordGroups.Add(signature, newWordList);
            }
        }

        private string GetSignature(string word)
        {
            char[] wordArray = word.ToCharArray();

            Array.Sort(wordArray);

            return new string(wordArray);
        }

        public List<string> GetAnagrams(string input)
        {
            string signature = GetSignature(input.ToLower());

            if (_wordGroups.ContainsKey(signature))
            {
                return _wordGroups[signature];
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
