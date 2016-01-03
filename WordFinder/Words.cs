using System;
using System.Collections.Generic;

public class Words
{
    private  List<String> wordList { get; set; }
    private Dictionary<String,bool> wordsDict { get; set; }
    //todo: change to use a search trie if too slow

    public Words()
    {
        wordList = new List<String>();
        wordsDict = new Dictionary<String, bool> ();
    }

    public void AddWord(String word)
    {
        word = word.ToUpper();
        wordList.Add(word);
        if (!wordsDict.ContainsKey(word))
        { 
            wordsDict.Add(word, true);
        }
    }

    public bool isWordPrefixInList(string prefix)
    {
       foreach ( string w in wordList) {
            if (w.StartsWith(prefix,StringComparison.InvariantCultureIgnoreCase))
            {
                return true; 
            }
        }
        return false;
    }

    public bool isWordInList(string word)
    {
        return wordsDict.ContainsKey(word);
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
