using System.Collections.Generic;

namespace Project2
{
    public interface IWord
    {
        int CountInText { get; }
        HashSet<int> SentenceNumbers { get; }
        string Value { get; }
    }
}