using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public interface WordSearchList
    {
        bool Find(string word, bool wholeWord);
    }
}
