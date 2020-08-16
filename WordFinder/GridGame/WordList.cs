using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WordFinder
{
  
    public class WordList : WordSearchList
    {

#if DEBUG
        const string DICTFILE_OSPD = "..\\..\\ospd.txt";
        const string DICTFILE_ENABLE = "..\\..\\enable1.txt";
        const string DICTFILE_UKACD = "..\\..\\UK%20Advanced%20Cryptics%20Dictionary.txt";
        const string DICTFILE_SUPPLEMENT = "..\\..\\Supplement.txt"; //extra file of missing words, loaded after the main dictionary
#else
        const string DICTFILE_OSPD = "ospd.txt";
        const string DICTFILE_ENABLE = "enable1.txt";
        const string DICTFILE_UKACD = "UK%20Advanced%20Cryptics%20Dictionary.txt";
        const string DICTFILE_SUPPLEMENT = "Supplement.txt"; //extra file of missing words, loaded after the main dictionary

#endif

        public int MinWordLength { get; set; } = 0;
        public int MaxWordLength { get; set; } = 15;

        private Dictionary<string, Words> dictionaries;
        private Words dictWords;

        public void LoadDictionary(DictionaryEdition edition)
        {
            LoadDictionary(GetFileNameForEdition(edition));
        }
        private string GetFileNameForEdition(DictionaryEdition edition)
        {
            switch (edition)
            {
                case DictionaryEdition.OSPD:
                    return DICTFILE_OSPD;
                case DictionaryEdition.ENABLE:
                    return DICTFILE_ENABLE;
                case DictionaryEdition.UKACD:
                    return DICTFILE_UKACD;
                case DictionaryEdition.SUPPLEMENT:
                    return DICTFILE_SUPPLEMENT;
                default:
                    throw new Exception("unknown edition");
            }
        }
        private void LoadDictionary(string fileName)
        {
            if (dictionaries == null)
            {
                dictionaries = new Dictionary<string, Words>();
            }
            if (dictionaries.ContainsKey(fileName))
            {
                //swap out the dictionary for the pre-loaded one if available
                dictWords = dictionaries[fileName];
            }
            else
            {
                //not already loaded, load it now and store for later.
                dictWords = new Words();
                dictionaries.Add(fileName, dictWords);

                //Read words from file
                FileStream fs = File.Open(Path.Combine(Application.StartupPath, fileName), FileMode.Open);
                try
                {
                    StreamReader sr = new StreamReader(fs);
                    bool inWordSection = false;
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.Equals("aa", StringComparison.InvariantCultureIgnoreCase)) inWordSection = true; //look for first word, ignore headers etc
                        if (inWordSection)
                        {
                            if (line.Length >= MinWordLength && line.Length <= MaxWordLength)
                            {
                                dictWords.AddWord(line);
                            }
                        }
                    }
                }
                finally
                {
                    fs.Close();
                }
                loadSupplementDictionary();
            }

        }
        private void loadSupplementDictionary()
        {
            try
            {
                //Read words from file
                FileStream fs = File.Open(Path.Combine(Application.StartupPath, DICTFILE_SUPPLEMENT), FileMode.Open);
                try
                {
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        if (line.Length >= MinWordLength && line.Length <= MaxWordLength)
                        {
                            if (!dictWords.Find(line, wholeWord: true))
                            {
                                dictWords.AddWord(line);
                            }
                        }
                    }
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException)
            {
                //ignore
            }
        }

        public bool Find(string word, bool wholeWord)
        {
            return dictWords.Find(word, wholeWord);
        }
    }
}
