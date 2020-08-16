using System;
using System.Collections.Generic;

namespace WordFinder
{
    class Words : WordSearchList
    {
        private List<String> wordList { get; set; }
        private Dictionary<String, bool> wordsDict { get; set; }
        private SearchTree STree;

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

        public bool Find(string word, bool wholeWord)
        {
            if (wholeWord)
            {
                //true if word is a valid word
                return (STree.findString(word) > -1);
            } else {
                //true if word is a prefix of a valid word
                return STree.findPrefix(word);

            }
        }
    }
}