using System.Collections.Generic;

namespace Project2
{
    public interface IWord
    {
        int CountInText { get; }
        HashSet<int> LineNumber { get; }
        string Value { get; }
    }
}