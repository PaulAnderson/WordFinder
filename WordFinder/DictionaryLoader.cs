using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public enum DictionaryEdition
    {
        OSPD,
        ENABLE,
        UKACD,
        SUPPLEMENT,
    }

    public interface DictionaryLoader
    {
        void LoadDictionary(DictionaryEdition edition);
    }
}
