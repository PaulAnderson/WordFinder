using System;
using System.Collections.Generic;

namespace WordFinder
{
    public class Words
    {
        private List<String> wordList { get; set; }
        private Dictionary<String, bool> wordsDict { get; set; }
        private SearchTree STree;
        //todo: change to use a search trie if too slow

        public Words()
        {
            wordList = new List<String>();
            wordsDict = new Dictionary<String, bool>();
            STree = new SearchTree(); //todo we can use the key to hold the value of the word
        }

        public void AddWord(String word)
        {
            word = word.ToUpper();
            wordList.Add(word);
            if (!wordsDict.ContainsKey(word))
            {
                wordsDict.Add(word, true);
            }
            STree.addString(1, word);
        }

        public bool isWordPrefixInList(string prefix)
        {
            return STree.findPrefix(prefix);
        }

        public bool isWordInList(string word)
        {
            return (STree.findString(word)>-1);

            //return wordsDict.ContainsKey(word);
            //foreach (string w in wordList)
            //{
            //    if (w.Equals(word,StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }
    }
}